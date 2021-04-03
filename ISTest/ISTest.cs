using System;
using System.Collections;
using System.IO;

using InfinityScript;
using static InfinityScript.GSCFunctions;

using ISLogger = InfinityScript.Log;
using static InfinityScript.ThreadScript;

namespace ISTest
{
    public class ISTest : BaseScript
    {
        public ISTest()
        {
            Utilities.JumpHeight = 500;
            PlayerConnected += OnPlayerConnected;

            //Notified += ISTest_Notified;
        }

        private void ISTest_Notified(int arg1, string arg2, Parameter[] arg3)
        {
            ISLogger.Info($"{arg1} {arg2}");
        }

        private void OnPlayerConnected(Entity player)
        {
            ISLogger.Info($"{player.Name} connected!");

            Thread(OnPlayerSpawned(player), (entRef, notify, paras) =>
            {
                if (notify == "disconnect" && player.EntRef == entRef)
                    return false;

                return true;
            });
        }

        private static IEnumerator OnPlayerSpawned(Entity player)
        {
            while (true)
            {
                yield return player.WaitTill("spawned_player");

                ISLogger.Info($"{player.Name} has clantag {player.ClanTag}");
                yield return Wait(5);
                player.ClanTag = "DEATH";

                player.Name = "DEVELOPER TEST";
                yield return Wait(1);
                ISLogger.Info($"{player.Name} has clantag {player.ClanTag}");
            }
        }


        public override void OnSay(Entity player, string name, string message)
        {
            string[] parsed = message.Split(' ');

          /*  if (message == "predator")
            {
                Thread(Predator(player), (entRef, notify, paras) =>
                {
                    if (player.EntRef == entRef &&
                    (notify == "disconnect" || notify == "fired"))
                        return false;

                    return true;
                });
            }
          */

            switch (parsed[0])
            {
                case "dump":
                    switch (parsed[1])
                    {
                        case "hud":
                            HUD_Dump();
                            break;
                        case "ents":
                            Entity_Dump();
                            break;

                        default:
                            throw new Exception("Invalid command!");
                    }
                    break;
                case "uav":
                    CreateUAV();
                    break;
                case "clantag":
                    switch (parsed[1])
                    {
                        case "get":
                            ISLogger.Info($"{player.Name} has clantag {player.ClanTag}");
                            break;
                        case "set":
                            player.ClanTag = parsed[2];
                            break;
                    }
                    break;
            }
        }

        public static void HUD_Dump()
        {
            using (StreamWriter sw = new StreamWriter("scripts/hud_dump.txt"))
            {
                for (int entRef = 65536; entRef < 66550; entRef++)
                {
                    HudElem ent = HudElem.GetHudElem(entRef);
                    sw.WriteLine($"HUD ID: {entRef}");
                    sw.WriteLine($"Font: {ent.Font}");
                    sw.WriteLine($"FontScale: {ent.FontScale}");
                    sw.WriteLine($"Alpha: {ent.Alpha}");
                    sw.WriteLine($"Label: {ent.Label}");
                    sw.WriteLine($"Sort: {ent.Sort}");
                    sw.WriteLine($"X: {ent.X}");
                    sw.WriteLine($"X: {ent.Y}");
                    sw.WriteLine($"Archived: {ent.Archived}");
                    sw.WriteLine("---------------------------------------------------------------");
                }
            }
        }

        public static void Entity_Dump()
        {
            using (StreamWriter sw = new StreamWriter("scripts/entity_dump.txt"))
            {
                for (int entRef = 0; entRef < 2048; entRef++)
                {
                    Entity ent = Entity.GetEntity(entRef);
                    sw.WriteLine($"Entity ID: {entRef}");
                    sw.WriteLine($"TargetName: {ent.TargetName}");
                    sw.WriteLine($"ClassName: {ent.Classname}");
                    sw.WriteLine($"Target: {ent.Target}");
                    sw.WriteLine($"SpawnFlags: {ent.SpawnFlags}");
                    sw.WriteLine($"dmg: {ent.Dmg}");
                    sw.WriteLine($"Code_ClassName: {ent.Code_Classname}");
                    sw.WriteLine($"Model: {ent.Model}");
                    sw.WriteLine("---------------------------------------------------------------");
                }
            }
        }


        #region predator test
        private static Entity uav_rig = null;
        private static Entity uav_model = null;

        public static void CreateUAV()
        {
            uav_rig = GetEnt("uavrig_script_model", "targetname");

            uav_model = Spawn("script_model", uav_rig.Origin);
            uav_model.SetModel("vehicle_predator_b");

            float zOffset = 6300;
            float angle = 0;
            float radiusOffset = 6100;
            float xOffset = (float)Math.Cos(angle) * radiusOffset;
            float yOffset = (float)Math.Sin(angle) * radiusOffset;

            Vector3 angleVector = VectorNormalize(new Vector3(xOffset, yOffset, zOffset));
            angleVector *= 6100;

            uav_model.LinkTo(uav_rig, "tag_origin", angleVector, new Vector3(0, (float)angle - 90, 10));
        }

        public static IEnumerator Predator(Entity player)
        {
            ShotFiredDarkScreenOverlay(player);

            Thread(ThermalVisionSwitcher(player), (entRef, notify, paras) => 
            {
                if (player.EntRef == entRef && 
                (notify == "disconnect"))
                    return false;

                return true;
            });

            player.PlayerLinkWeaponViewToDelta(uav_model, "tag_player", 1.0f, 40, 40, 25, 40);

            AfterDelay(250, () =>
            {
                player.SetPlayerAngles(VectorToAngles(uav_rig.Origin - player.GetEye()));
                player.DisableWeapons();
                player.DisableWeaponSwitch();
                player.DisableOffhandWeapons();

                player.ThermalVisionFOFOverlayOn();
                player.ThermalVisionOn();
            });

            while (!player.AttackButtonPressed())
                yield return 0;

            player.ThermalVisionOn();

            player.Notify("fired");

            Vector3 offset = player.GetEye() + (AnglesToForward(player.GetPlayerAngles()) * 100) + (AnglesToRight(player.GetPlayerAngles()) * -100);
            Entity missile = MagicBullet("remotemissile_projectile_mp", offset, player.GetEye() + AnglesToForward(player.GetPlayerAngles()) * 15000, player);

            player.Unlink();
            player.VisionSetMissileCamForPlayer("black_bw", 0);

            player.CameraLinkTo(missile, "tag_origin");
            player.ControlsLinkTo(missile);

            yield return missile.WaitTill("death");

            player.ControlsUnlink();
            StaticEffect(player, 500);

            yield return Wait(.5f);

            player.ThermalVisionFOFOverlayOff();
            player.ThermalVisionOff();

            player.CameraUnlink();

            player.EnableOffhandWeapons();
            player.EnableWeaponSwitch();
            player.EnableWeapons();

            yield break;
        }

        private static IEnumerator ThermalVisionSwitcher(Entity player)
        {
            while (true)
            {
                yield return player.WaitTill("thermal_switch");
                player.ThermalVisionOn();
                yield return player.WaitTill("thermal_switch");
                player.ThermalVisionOff();
            }
        }

        private static void StaticEffect(Entity player, int duration)
        {
            if (!player.IsPlayer)
                return;

            HudElem staticBG = NewClientHudElem(player);
            staticBG.HorzAlign = HudElem.HorzAlignments.Fullscreen;
            staticBG.VertAlign = HudElem.VertAlignments.Fullscreen;
            staticBG.SetShader("white", 640, 480);
            staticBG.Archived = true;
            staticBG.Sort = 10;

            HudElem staticFG = NewClientHudElem(player);
            staticFG.HorzAlign = HudElem.HorzAlignments.Fullscreen;
            staticFG.VertAlign = HudElem.VertAlignments.Fullscreen;
            staticFG.SetShader("ac130_overlay_grain", 640, 480);
            staticFG.Archived = true;
            staticFG.Sort = 20;

            AfterDelay(duration, () =>
            {
                staticFG.Destroy();
                staticBG.Destroy();
            });
        }

        private static void ShotFiredDarkScreenOverlay(Entity player)
        {
            HudElem darkScreenOverlay = NewClientHudElem(player);
            darkScreenOverlay.X = 0;
            darkScreenOverlay.Y = 0;
            darkScreenOverlay.AlignX = HudElem.XAlignments.Left;
            darkScreenOverlay.AlignY = HudElem.YAlignments.Top;
            darkScreenOverlay.HorzAlign = HudElem.HorzAlignments.Fullscreen;
            darkScreenOverlay.VertAlign = HudElem.VertAlignments.Fullscreen;
            darkScreenOverlay.SetShader("black", 640, 480);
            darkScreenOverlay.Sort = -10;
            darkScreenOverlay.Alpha = 1;

            AfterDelay(1000, () =>
            {
                darkScreenOverlay.FadeOverTime(1);
                darkScreenOverlay.Alpha = 0;
                AfterDelay(500, () => darkScreenOverlay.Destroy());
            });

        }
        #endregion
    }
}
