using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using InfinityScript;
using System.IO;

using static InfinityScript.Coroutine;

namespace ISTest
{
    public class ISTest : BaseScript
    {
        public override void OnSay(Entity player, string name, string message)
        {
            player.GiveWeapon(message);
            player.SwitchToWeaponImmediate(message);

            base.OnSay(player, name, message);
        }
        /// <summary>
        /// This is small test script
        /// </summary>
        public ISTest()
        {
            //Utilities.SetTeamLeaderVoice("allies", "AF_");
            //Tick += new Action(() => Log.Info("Tick"));

            Notified += new Action<int, string, Parameter[]>((a, b, c) =>
            {
                Log.Info($"{a}; {b}");
            });

            Log.Info($"Script successful loaded!");

            StartRoutine();
        }

        #region Coroutines test

        private static void StartRoutine()
        {
            StartThread(PlayerConnected());
            StartThread(PrematchDone());
        }

        private static IEnumerator PlayerConnected()
        {
            Parameter player = null;
            while (true)
            {
                yield return WaitTill("connected", args => player = args[0]);
                HUD_DamageFeedBack(player.As<Entity>());
                Utilities.PrintToConsole($"{player.As<Entity>().Name} connected!");
            }
        }

        private static IEnumerator PrematchDone()
        {
            while (true)
            {
                yield return WaitTill("prematch_done");
                Utilities.PrintToConsole("prematch_done event is complied!");

                Utilities.PrintToConsole("Finding AC130 model!");
                Entity ac130_model = GSCFunctions.GetEnt("vehicle_ac130_coop", "targetname");

                if (Utilities.IsEntDefined(ac130_model))
                {
                    Utilities.PrintToConsole("AC130 model funded!");

                    ac130_model.Show();
                    ac130_model.SetCanDamage(true);

                    ac130_model.MaxHealth = 300;
                    ac130_model.Health = 300;
                }
                else
                {
                    Utilities.PrintToConsole("AC130 model unfunded!");
                    yield break;
                }

                AfterDelay(1000, () =>
                {
                    Utilities.PrintToConsole($"Create a damage handler for AC130 model! (AC130 number is {ac130_model.EntRef})");
                });

                //yield break;
            }
        }

        private static IEnumerator AC130_damagehandler(Entity ac130)
        {
            Parameter[] parameters = null;
            while (true)
            {
                yield return WaitTill("damage", args => parameters = args);
                //Utilities.PrintToConsole(string.Join("\n", parameters.Select(x => x.ToString()).ToArray()));
                UpdateDamageFeedBack(parameters[1].As<Entity>());
            }
        }

        #endregion

        #region Damage feedback

        private static void HUD_DamageFeedBack(Entity player)
        {
            player.SetField("hud_damagefeedback", GSCFunctions.NewClientHudElem(player));
            player.GetField<HudElem>("hud_damagefeedback").HorzAlign = HudElem.HorzAlignments.Center;
            player.GetField<HudElem>("hud_damagefeedback").VertAlign = HudElem.VertAlignments.Middle;
            player.GetField<HudElem>("hud_damagefeedback").X = -12;
            player.GetField<HudElem>("hud_damagefeedback").Y = -12;
            player.GetField<HudElem>("hud_damagefeedback").Alpha = 0;
            player.GetField<HudElem>("hud_damagefeedback").SetShader("damage_feedback", 24, 48);
        }

        private static void UpdateDamageFeedBack(Entity player, string typeHit = "damage_feedback")
        {
            player.GetField<HudElem>("hud_damagefeedback").SetShader(typeHit, 24, 48);

            player.PlayLocalSound("MP_hit_alert");

            player.GetField<HudElem>("hud_damagefeedback").Alpha = 1;
            player.GetField<HudElem>("hud_damagefeedback").FadeOverTime(1);
            player.GetField<HudElem>("hud_damagefeedback").Alpha = 0;
        }
        #endregion
    }
}
