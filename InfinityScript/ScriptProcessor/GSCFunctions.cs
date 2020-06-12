using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript
{
    public static class GSCFunctions
    {
        public static bool AnimHasNoteTrack(string animation, string noteTrackName)
        {
            Function.Call(ScriptNames.FunctionList.animhasnotetrack, animation, noteTrackName);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static float GetAngleDelta(string animation, float startTime = 0.0f, float endTime = 1f)
        {
            Function.Call(ScriptNames.FunctionList.getangledelta, animation, startTime, endTime);
            return (float)Function.GetReturns();
        }

        public static float GetAnimLength(string primitiveAnimation)
        {
            Function.Call(ScriptNames.FunctionList.getanimlength, primitiveAnimation);
            return (float)Function.GetReturns();
        }

        public static float GetMoveDelta(string animation, float startTime = 0.0f, float endTime = 1f)
        {
            Function.Call(ScriptNames.FunctionList.getmovedelta, animation, startTime, endTime);
            return (float)Function.GetReturns();
        }

        public static Array GetNoteTrackTimes(string animation, string noteTrackName)
        {
            throw new NotImplementedException();
        }

        public static int GetNumParts(string model)
        {
            Function.Call(ScriptNames.FunctionList.getnumparts, model);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static string GetPartName(string model, int index)
        {
            Function.Call(ScriptNames.FunctionList.getpartname, model, index);
            return (string)Function.GetReturns();
        }

        public static Vector3 GetTagAngles(this Entity entity, string tagName)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.gettagangles, tagName);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 GetTagOrigin(this Entity entity, string tagName)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.gettagorigin, tagName);
            return (Vector3)Function.GetReturns();
        }

        public static void ScriptModelPlayAnim(this Entity entity, string animation)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.scriptmodelplayanim, animation);
        }

        public static void ScriptModelClearAnim(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.scriptmodelclearanim);
        }

        public static string GetCorpseAnim(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcorpseanim);
            return (string)Function.GetReturns();
        }

        public static void AllClientsPrint(string message)
        {
            Function.Call(ScriptNames.FunctionList.allclientsprint, message);
        }

        public static void AllowSpectateTeam(this Entity entref, string team, bool canSpectate)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.allowspectateteam, team, canSpectate);
        }

        public static void Announcement(string message)
        {
            Function.Call(ScriptNames.FunctionList.announcement, message);
        }

        public static void BeginLocationSelection(this Entity entref, string locationSelector)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.beginlocationselection, locationSelector);
        }

        public static void BeginLocationSelection(this Entity entref, string locationSelector, float selectorSize)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.beginlocationselection, locationSelector, selectorSize);
        }

        public static void ClientAnnouncement(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.clientannouncement, entref, message);
        }

        public static void ClientPrint(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.clientprint, entref, message);
        }

        public static Entity ClonePlayer(this Entity entref, int duration = -1)
        {
            Function.SetEntRef(entref.EntRef);
            if (duration != -1)
                Function.Call(ScriptNames.FunctionList.cloneplayer, duration);
            else
                Function.Call(ScriptNames.FunctionList.cloneplayer);
            return (Entity)Function.GetReturns();
        }

        public static void DisableWeapons(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.disableweapons);
        }

        public static Entity DropItem(this Entity entref, string itemName)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.dropitem, itemName);
            return (Entity)Function.GetReturns();
        }

        public static void EnableWeapons(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.enableweapons);
        }

        public static void EndLocationSelection(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.endlocationselection);
        }

        public static string GetViewmodel(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.getviewmodel);
            return (string)Function.GetReturns();
        }

        public static bool IsMantling(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.ismantling);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsOnLadder(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.isonladder);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsPlayerNumber(this Entity entity, int number)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isplayernumber, entity, number);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsRagdoll(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.isragdoll);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsTalking(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.istalking);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void Kick(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.kick, entref);
        }

        public static void MakeDvarServerInfo(string dvar, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.makedvarserverinfo, dvar, value);
        }

        public static void SayAll(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.sayall, message);
        }

        public static void SayTeam(this Entity entref, string message)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.sayteam, message);
        }

        public static void SetRank(this Entity entref, int rank, int? prestige = null)
        {
            Function.SetEntRef(entref.EntRef);
            if (prestige.HasValue)
            {
                int? nullable = prestige;
                Function.Call(ScriptNames.FunctionList.setrank, rank, nullable.HasValue ? (Parameter)nullable.GetValueOrDefault() : null);
            }
            else
                Function.Call(ScriptNames.FunctionList.setrank, rank);
        }

        public static void SetSpawnWeapon(this Entity entref, string weapon)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.setspawnweapon, weapon);
        }

        public static void SetTeamForTrigger(Entity trigger, string team)
        {
            Function.SetEntRef(trigger.EntRef);
            Function.Call(ScriptNames.FunctionList.setteamfortrigger, team);
        }

        public static void ShowScoreBoard(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.showscoreboard);
        }

        public static void StartRagdoll(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startragdoll);
        }

        public static void Suicide(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.suicide);
        }

        public static void UpdateDMScores(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.updatedmscores);
        }

        public static void UpdateScores(this Entity entref)
        {
            Function.SetEntRef(entref.EntRef);
            Function.Call(ScriptNames.FunctionList.updatescores);
        }

        public static void FinishPlayerDamage(this Entity entref, Entity inflictor, Entity attacker, int damage, int damageFlags, string meansOfDeath, string weapon, Vector3 point, Vector3 direction, string hitLocation, float offsetTime)
        {
            Function.SetEntRef(entref.EntRef);
            if (inflictor == null && attacker != null)
                Function.Call(ScriptNames.FunctionList.finishplayerdamage, string.Empty, attacker, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            else if (attacker == null && inflictor != null)
                Function.Call(ScriptNames.FunctionList.finishplayerdamage, inflictor, string.Empty, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            else if (attacker == null && inflictor == null)
                Function.Call(ScriptNames.FunctionList.finishplayerdamage, string.Empty, string.Empty, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
            else
                Function.Call(ScriptNames.FunctionList.finishplayerdamage, inflictor, attacker, damage, damageFlags, meansOfDeath, weapon, point, direction, hitLocation, offsetTime);
        }

        public static void GlassRadiusDamage(Vector3 origin, int range, int maxDamage, int minDamage, Entity attacker = null)
        {
            if (attacker == null)
                Function.Call(ScriptNames.FunctionList.glassradiusdamage, origin, range, maxDamage, minDamage);
            else
                Function.Call(ScriptNames.FunctionList.glassradiusdamage, origin, range, maxDamage, minDamage, attacker);
        }

        public static void RadiusDamage(Vector3 origin, int range, int maxDamage, int minDamage, Entity attacker = null)
        {
            if (attacker == null)
                Function.Call(ScriptNames.FunctionList.radiusdamage, origin, range, maxDamage, minDamage);
            else
                Function.Call(ScriptNames.FunctionList.radiusdamage, origin, range, maxDamage, minDamage, attacker);
        }

        public static void RadiusDamage(this Entity entity, Vector3 origin, int range, int maxDamage, int minDamage, Entity attacker, string meansOfDeath, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_radiusdamage, origin, range, maxDamage, minDamage, attacker, meansOfDeath, weapon);
        }

        public static void SetCanDamage(this Entity entity, bool canDamage)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcandamage, canDamage);
        }

        public static void SetCanRadiusDamage(this Entity entity, bool canDamage)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcanradiusdamage, canDamage);
        }

        public static void SetPlayerIgnoreRadiusDamage(bool ignoreRadiusDamage)
        {
            Function.Call(ScriptNames.FunctionList.setplayerignoreradiusdamage, ignoreRadiusDamage);
        }

        public static bool IsExplosiveDamageMOD(string mod)
        {
            Function.Call(ScriptNames.FunctionList.isexplosivedamagemod, mod);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Entity AddTestClient()
        {
            Function.Call(ScriptNames.FunctionList.addtestclient);
            return (Entity)Function.GetReturns();
        }

        public static void Assert(bool value)
        {
            Function.Call(ScriptNames.FunctionList.assert, value);
        }

        public static void AssertEx(bool value, string message)
        {
            Function.Call(ScriptNames.FunctionList.assertex, value, message);
        }

        public static void AssertMsg(string message)
        {
            Function.Call(ScriptNames.FunctionList.assertmsg, message);
        }

        public static void IPrintLn(string message)
        {
            Function.Call(ScriptNames.FunctionList.iprintln, message);
        }

        public static void IPrintLnBold(string message)
        {
            Function.Call(ScriptNames.FunctionList.iprintlnbold, message);
        }

        public static void Line(Vector3 start, Vector3 end, Vector3? color = null, bool depthTest = false, int duration = 0)
        {
            if (!color.HasValue)
                color = new Vector3?(Vector3.Zero);

            Function.Call(ScriptNames.FunctionList.line, start, end, color.HasValue ? (Parameter)color.GetValueOrDefault() : null, depthTest, duration);
        }

        public static void Print(string message)
        {
            Function.Call(ScriptNames.FunctionList.print, message);
        }

        public static void Print3d(Vector3 origin, string text, Vector3 color)
        {
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color);
        }

        public static void Print3d(Vector3 origin, string text, Vector3 color, float alpha)
        {
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color, alpha);
        }

        public static void Print3d(Vector3 origin, string text, Vector3 color, float alpha, float scale)
        {
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color, alpha, scale);
        }

        public static void Print3d(Vector3 origin, string text, Vector3 color, float alpha, float scale, int duration)
        {
            Function.Call(ScriptNames.FunctionList.print3d, origin, text, color, alpha, scale, duration);
        }

        public static void PrintLn(string message)
        {
            Function.Call(ScriptNames.FunctionList.println, message);
        }

        public static string SetPrintChannel(string channel)
        {
            Function.Call(ScriptNames.FunctionList.setprintchannel, channel);
            return (string)Function.GetReturns();
        }

        public static void NoClip(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.noclip);
        }

        public static void Ufo(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ufo);
        }

        public static float GetBuildVersion()
        {
            Function.Call(ScriptNames.FunctionList.getbuildversion);
            return (float)Function.GetReturns();
        }

        public static float GetBuildNumber()
        {
            Function.Call(ScriptNames.FunctionList.getbuildnumber);
            return (float)Function.GetReturns();
        }

        public static int GetSystemTime()
        {
            Function.Call(ScriptNames.FunctionList.getsystemtime);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void CreatePrintChannel(string channel)
        {
            Function.Call(ScriptNames.FunctionList.createprintchannel, channel);
        }

        public static string GetDvar(string dvar)
        {
            Function.Call(ScriptNames.FunctionList.getdvar, dvar);
            return (string)Function.GetReturns();
        }

        public static float GetDvarFloat(string dvar)
        {
            Function.Call(ScriptNames.FunctionList.getdvarfloat, dvar);
            return (float)Function.GetReturns();
        }

        public static int GetDvarInt(string dvar)
        {
            Function.Call(ScriptNames.FunctionList.getdvarint, dvar);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void SetDvar(string dvar, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.setdvar, dvar, value);
        }

        public static void SetDynamicDvar(string dvar, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.setdynamicdvar, dvar, value);
        }

        public static void SetDvarIfUninitialized(string dvar, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.setdvarifuninitialized, dvar, value);
        }

        public static void SetDevDvar(string dvar, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.setdevdvar, dvar, value);
        }

        public static void SetDevDvarIfUninitialized(string dvar, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.setdevdvarifuninitialized, dvar, value);
        }

        public static Vector3 GetDvarVector(string dvar)
        {
            Function.Call(ScriptNames.FunctionList.getdvarvector, dvar);
            return (Vector3)Function.GetReturns();
        }

        public static int LoadFX(string effect)
        {
            Function.Call(ScriptNames.FunctionList.loadfx, effect);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void VisionSetNaked(string vision)
        {
            Function.Call(ScriptNames.FunctionList.visionsetnaked, vision);
        }

        public static void VisionSetNaked(string vision, int transitionTime)
        {
            Function.Call(ScriptNames.FunctionList.visionsetnaked, vision, transitionTime);
        }

        public static void VisionSetNight(string vision)
        {
            Function.Call(ScriptNames.FunctionList.visionsetnight, vision);
        }

        public static void VisionSetNight(string vision, int transitionTime)
        {
            Function.Call(ScriptNames.FunctionList.visionsetnight, vision, transitionTime);
        }

        public static void PlayFX(int effect, Vector3 position, Vector3? forward = null, Vector3? up = null)
        {
            if (forward.HasValue && up.HasValue)
                Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null, up.HasValue ? (Parameter)up.GetValueOrDefault() : null);
            else if (forward.HasValue && !up.HasValue)
                Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null);
            else
                Function.Call(ScriptNames.FunctionList.playfx, effect, position);
        }

        public static Entity PlayFX_Ret(int effect, Vector3 position, Vector3? forward = null, Vector3? up = null)
        {
            if (forward.HasValue && up.HasValue)
                Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null, up.HasValue ? (Parameter)up.GetValueOrDefault() : null);
            else if (forward.HasValue && !up.HasValue)
                Function.Call(ScriptNames.FunctionList.playfx, effect, position, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null);
            else
                Function.Call(ScriptNames.FunctionList.playfx, effect, position);

            return (Entity)Function.GetReturns();
        }

        public static void PlayFXOnTag(int effect, Entity entity, string tag)
        {
            Function.Call(ScriptNames.FunctionList.playfxontag, effect, entity, tag);
        }

        public static void StopFXOnTag(int effect, Entity entity, string tag)
        {
            Function.Call(ScriptNames.FunctionList.stopfxontag, effect, entity, tag);
        }

        public static void PlayFXOnTagForClients(int effect, Entity entity, string tag, Entity client)
        {
            Function.Call(ScriptNames.FunctionList.playfxontagforclients, effect, entity, tag, client);
        }

        public static void VisionSetMissileCam(string vision)
        {
            Function.Call(ScriptNames.FunctionList.visionsetmissilecam, vision);
        }

        public static void VisionSetMissileCam(string vision, float fade)
        {
            Function.Call(ScriptNames.FunctionList.visionsetmissilecam, vision, fade);
        }

        public static void VisionSetThermal(string vision)
        {
            Function.Call(ScriptNames.FunctionList.visionsetthermal, vision);
        }

        public static void VisionSetThermal(string vision, float fade)
        {
            Function.Call(ScriptNames.FunctionList.visionsetthermal, vision, fade);
        }

        public static void VisionSetPain(string vision)
        {
            Function.Call(ScriptNames.FunctionList.visionsetpain, vision);
        }

        public static void VisionSetPain(string vision, float fade)
        {
            Function.Call(ScriptNames.FunctionList.visionsetpain, vision, fade);
        }

        public static void SetBlurForPlayer(this Entity entity, float blur, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setblurforplayer, blur, time);
        }

        public static Entity PlayLoopedFX(int effect, float time, Vector3 origin, int offset = 0, Vector3? forward = null, Vector3? up = null)
        {
            if (!forward.HasValue && !up.HasValue)
                Function.Call(ScriptNames.FunctionList.playloopedfx, effect, time, origin, offset);
            else if (!up.HasValue)
                Function.Call(ScriptNames.FunctionList.playloopedfx, effect, time, origin, offset, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null);
            else if (!forward.HasValue)
                Function.Call(ScriptNames.FunctionList.playloopedfx, effect, time, origin, offset, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null, up.HasValue ? (Parameter)up.GetValueOrDefault() : null);

            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnFX(int effect, Vector3 position)
        {
            Function.Call(ScriptNames.FunctionList.spawnfx, effect, position);
            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnFX(int effect, Vector3 position, Vector3 forward)
        {
            Function.Call(ScriptNames.FunctionList.spawnfx, effect, position, forward);
            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnFX(int effect, Vector3 position, Vector3 forward, Vector3 up)
        {
            Function.Call(ScriptNames.FunctionList.spawnfx, effect, position, forward, up);
            return (Entity)Function.GetReturns();
        }

        public static void TriggerFX(Entity effect)
        {
            Function.Call(ScriptNames.FunctionList.triggerfx, effect);
        }

        public static void TriggerFX(Entity effect, float when)
        {
            Function.Call(ScriptNames.FunctionList.triggerfx, effect, when);
        }

        public static void Delete(this Entity entity)
        {
            if (!Utilities.isEntDefined(entity))
                return;
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.delete);
        }

        public static void Detonate(this Entity entity, Entity newAttacker = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (newAttacker == null)
                Function.Call(ScriptNames.FunctionList.detonate);
            else
                Function.Call(ScriptNames.FunctionList.detonate, newAttacker);
        }

        public static void DisableAimAssist(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableaimassist);
        }

        public static void EnableAimAssist(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableaimassist);
        }

        public static Entity GetEnt(string name, string key)
        {
            Function.Call(ScriptNames.FunctionList.getent, name, key);
            return (Entity)Function.GetReturns();
        }

        public static Entity[] GetEntArray(string name = "", string key = "")
        {
            List<Entity> ents = new List<Entity>();
            for (int i = 0; i < 2048; i++)
            {
                if (key == "targetname")
                {
                    if (Entity.GetEntity(i).TargetName == name)
                        ents.Add(Entity.GetEntity(i));
                }
                else if (key == "target")
                {
                    if (Entity.GetEntity(i).TargetName == name)
                        ents.Add(Entity.GetEntity(i));
                }
            }

            return ents.ToArray();
        }

        public static Entity GetEntByNum(int entNum)
        {
            Function.Call(ScriptNames.FunctionList.getentbynum, entNum);
            return (Entity)Function.GetReturns();
        }

        public static int GetEntityNumber(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentitynumber);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetNormalHealth(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnormalhealth);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static Vector3 GetOrigin(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getorigin);
            return (Vector3)Function.GetReturns();
        }

        public static void Hide(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hide);
        }

        public static void HidePart(this Entity entity, string tag, string model = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (model != "")
                Function.Call(ScriptNames.FunctionList.hidepart, tag, model);
            else
                Function.Call(ScriptNames.FunctionList.hidepart, tag);
        }

        public static bool IsTouching(this Entity ent, Entity entity)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.istouching, entity);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void LaserOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseroff);
        }

        public static void LaserOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseron);
        }

        public static void LinkTo(this Entity ent, Entity entity, string tag = "", Vector3? originOffset = null, Vector3? anglesOffset = null)
        {
            Function.SetEntRef(ent.EntRef);
            if (tag == "")
                Function.Call(ScriptNames.FunctionList.linkto, entity);
            else if (tag != "" && !originOffset.HasValue)
            {
                Function.Call(ScriptNames.FunctionList.linkto, entity, tag);
            }
            else
            {
                if (!originOffset.HasValue)
                    return;
                if (!originOffset.HasValue)
                    originOffset = new Vector3?(Vector3.Zero);
                if (!anglesOffset.HasValue)
                    anglesOffset = new Vector3?(Vector3.Zero);

                Function.Call(ScriptNames.FunctionList.linkto, entity, tag, originOffset.HasValue ? (Parameter)originOffset.GetValueOrDefault() : null, anglesOffset.HasValue ? (Parameter)anglesOffset.GetValueOrDefault() : null);
            }
        }

        public static void LocalToWorldCoords(this Entity entity, Vector3 localCoord)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.localtoworldcoords, localCoord);
        }

        public static int SetContents(this Entity entity, int contents)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcontents, contents);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void SetCursorHint(this Entity entity, string hint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcursorhint, hint);
        }

        public static void SetHintString(this Entity entity, string hint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sethintstring, hint);
        }

        public static void SetModel(this Entity entity, string model)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmodel, model);
        }

        public static void SetNormalHealth(this Entity entity, int health)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setnormalhealth, health);
        }

        public static void Show(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.show);
        }

        public static void ShowAllParts(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showallparts);
        }

        public static void ShowPart(this Entity entity, string tag, string model = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (model != "")
                Function.Call(ScriptNames.FunctionList.showpart, tag, model);
            else
                Function.Call(ScriptNames.FunctionList.showpart, tag);
        }

        public static void ShowToPlayer(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showtoplayer, player);
        }

        public static void Unlink(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.unlink);
        }

        public static void UseBy(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.useby, player);
        }

        public static void UseTriggerRequireLookAt(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.usetriggerrequirelookat);
        }

        public static void PlayFX(this Entity entity, int effect, Vector3 position, Vector3? forward = null, Vector3? up = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (forward.HasValue && up.HasValue)
                Function.Call(ScriptNames.FunctionList.target_playfx, effect, position, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null, up.HasValue ? (Parameter)up.GetValueOrDefault() : null);
            else if (forward.HasValue && !up.HasValue)
                Function.Call(ScriptNames.FunctionList.target_playfx, effect, position, forward.HasValue ? (Parameter)forward.GetValueOrDefault() : null);
            else
                Function.Call(ScriptNames.FunctionList.target_playfx, effect, position);
        }

        public static Entity DropScavengerBag(this Entity entity, string item)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.dropscavengerbag, item);
            return (Entity)Function.GetReturns();
        }

        public static void Attach(this Entity entity, string model, string tag = "", bool ignoreCollision = false)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.attach, model, tag, ignoreCollision);
        }

        public static void Detach(this Entity entity, string model, string tag = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (tag != "")
                Function.Call(ScriptNames.FunctionList.detach, model, tag);
            else
                Function.Call(ScriptNames.FunctionList.detach, model);
        }

        public static void DetachAll(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.detachall);
        }

        public static void AttachShieldModel(this Entity entity, string model, string tag)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.attachshieldmodel, model, tag);
        }

        public static void DetachShieldModel(this Entity entity, string model, string tag)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.detachshieldmodel, model, tag);
        }

        public static void MoveShieldModel(this Entity entity, string model, string tag1, string tag2)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveshieldmodel, model, tag1, tag2);
        }

        public static int GetAttachSize(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachsize);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static string GetAttachModelName(this Entity entity, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachmodelname, index);
            return (string)Function.GetReturns();
        }

        public static string GetAttachTagName(this Entity entity, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachtagname, index);
            return (string)Function.GetReturns();
        }

        public static bool GetAttachIgnoreCollision(this Entity entity, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachignorecollision, index);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void HidePart_AllInstances(this Entity entity, string tag)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hidepart_allinstances, tag);
        }

        public static void HideAllParts(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hideallparts);
        }

        public static void LinkToBlendToTag(this Entity ent, Entity entity, string tag)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.linktoblendtotag, entity, tag);
        }

        public static void LinkToBlendToTag(this Entity ent, Entity entity, string tag, Vector3 originOffset, Vector3 anglesOffset)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.linktoblendtotag, entity, tag, originOffset, anglesOffset);
        }

        public static bool IsLinked(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.islinked);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void EnableLinkTo(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enablelinkto);
        }

        public static void LaserAltViewOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseraltviewon);
        }

        public static void LaserAltViewOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laseraltviewoff);
        }

        public static void MakeUsable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makeusable);
        }

        public static void MakeUnUsable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makeunusable);
        }

        public static Vector3 GetEntityVelocity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentityvelocity);
            return (Vector3)Function.GetReturns();
        }

        public static void SetTargetEnt(this Entity entity, Entity target)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetent, target);
        }

        public static void SetTargetPos(this Entity entity, Vector3 target)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetpos, target);
        }

        public static void ClearTarget(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartarget);
        }

        public static void SetFlightModeDirect(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setflightmodedirect);
        }

        public static void SetFlightModeTop(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setflightmodetop);
        }

        public static float GetLightIntensity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getlightintensity);
            return (float)Function.GetReturns();
        }

        public static void SetLightIntensity(this Entity entity, float intensity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setlightintensity, intensity);
        }

        public static void CameraLinkTo(this Entity ent, Entity entity, string tag = "")
        {
            Function.SetEntRef(ent.EntRef);
            if (tag != "")
                Function.Call(ScriptNames.FunctionList.cameralinkto, entity, tag);
            else
                Function.Call(ScriptNames.FunctionList.cameralinkto, entity);
        }

        public static void CameraLinkTo(this Entity ent, Entity entity, string tag, Vector3 originOffset, Vector3 anglesOffset)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.cameralinkto, entity, tag, originOffset, anglesOffset);
        }

        public static void CameraUnlink(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cameraunlink);
        }

        public static void ControlsLinkTo(this Entity ent, Entity entity)
        {
            Function.SetEntRef(ent.EntRef);
            Function.Call(ScriptNames.FunctionList.controlslinkto, entity);
        }

        public static void ControlsUnlink(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.controlsunlink);
        }

        public static void MakeVehicleSolidCapsule(this Entity entity, float xRadius, float zOffset, float zRadius)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makevehiclesolidcapsule, xRadius, zOffset, zRadius);
        }

        public static void MakeVehicleSolidSphere(this Entity entity, float radius, float zOffset)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makevehiclesolidsphere, radius, zOffset);
        }

        public static void TransferMarksToNewScriptModel(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.transfermarkstonewscriptmodel);
        }

        public static void CloneBrushModelToScriptModel(this Entity entity, Entity brushModel)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clonebrushmodeltoscriptmodel, brushModel);
        }

        public static void EnablePlayerUse(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableplayeruse, player);
        }

        public static void DisablePlayerUse(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableplayeruse, player);
        }

        public static void MakeScrambler(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makescrambler, owner);
        }

        public static void MakePortableRadar(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makeportableradar, owner);
        }

        public static void MakeTrophySystem(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketrophysystem, owner);
        }

        public static bool IsSpawner(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isspawner, entity);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void DeleteAttractor(Entity attractor)
        {
            Function.Call(ScriptNames.FunctionList.deleteattractor, attractor);
        }

        public static void SetThermalBodyMaterial(string body)
        {
            Function.Call(ScriptNames.FunctionList.setthermalbodymaterial, body);
        }

        public static Entity GetMissileOwner(Entity explosive)
        {
            Function.Call(ScriptNames.FunctionList.getmissileowner, explosive);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetGlass(string name)
        {
            Function.Call(ScriptNames.FunctionList.getglass, name);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetGlassArray(string name)
        {
            Function.SetEntRef(-1);
            Function.Call(ScriptNames.FunctionList.getglassarray, name);
            return (Entity)Function.GetReturns();
        }

        public static Vector3 GetGlassOrigin(int glass)
        {
            Function.Call(ScriptNames.FunctionList.getglassorigin, glass);
            return (Vector3)Function.GetReturns();
        }

        public static bool IsGlassDestroyed(int glass)
        {
            Function.Call(ScriptNames.FunctionList.isglassdestroyed, glass);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void DestroyGlass(int glass)
        {
            Function.Call(ScriptNames.FunctionList.destroyglass, glass);
        }

        public static void DeleteGlass(int glass)
        {
            Function.Call(ScriptNames.FunctionList.deleteglass, glass);
        }

        public static int GetEntChannelsCount(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentchannelscount, entity);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static string GetEntChannelName(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getentchannelname, entity);
            return (string)Function.GetReturns();
        }

        public static void SetScriptMoverInKillcam(this Entity mover, string type)
        {
            Function.SetEntRef(mover.EntRef);
            Function.Call(ScriptNames.FunctionList.setscriptmoverinkillcam, type);
        }

        public static void SetDamageState(this Entity entity, int state)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.helicopter_setdamagestate, state);
        }

        public static int CloseFile(int fileNum)
        {
            Function.Call(ScriptNames.FunctionList.closefile, fileNum);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void FGetArg(int fileNum, int arg)
        {
            Function.Call(ScriptNames.FunctionList.fgetarg, fileNum, arg);
        }

        public static void FPrintFields(int fileNum, params Parameter[] output)
        {
            throw new NotImplementedException();
        }

        public static void FPrintLn(int fileNum, string output)
        {
            Function.Call(ScriptNames.FunctionList.fprintln, fileNum, output);
        }

        public static int FReadLn(int fileNum)
        {
            Function.Call(ScriptNames.FunctionList.freadln, fileNum);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int OpenFile(string filename, string mode)
        {
            Function.Call(ScriptNames.FunctionList.openfile, filename, mode);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void ChangeFontScaleOverTime(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveovertime2, time);
        }

        public static void ClearAllTextAfterHudelem(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clearalltextafterhudelem);
        }

        public static void ClearTargetEnt(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartargetent);
        }

        public static void Destroy(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.destroy);
        }

        public static void FadeOverTime(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fadeovertime, time);
        }

        public static void FadeOverTime2(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fadeovertime2);
        }

        public static void MoveOverTime(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveovertime, time);
        }

        public static void MoveOverTime2(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveovertime2);
        }

        public static HudElem NewClientHudElem(Entity client)
        {
            Function.Call(ScriptNames.FunctionList.newclienthudelem, client);
            return new HudElem((Entity)Function.GetReturns());
        }

        public static HudElem NewHudElem()
        {
            Function.Call(ScriptNames.FunctionList.newhudelem);
            return new HudElem((Entity)Function.GetReturns());
        }

        public static HudElem NewTeamHudElem(string team)
        {
            Function.Call(ScriptNames.FunctionList.newteamhudelem, team);
            return new HudElem((Entity)Function.GetReturns());
        }

        public static void Obituary(Entity victim, Entity attacker, string weapon, string meansOfDeath)
        {
            Function.Call(ScriptNames.FunctionList.obituary, victim, attacker, weapon, meansOfDeath);
        }

        public static void Reset(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.reset);
        }

        public static void ScaleOverTime(this HudElem hud, float time, int width, int height)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.scaleovertime, time, width, height);
        }

        public static void SetClock(this HudElem hud, float time, float totalTime, string material, int width = 64, int height = 64)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclock, time, totalTime, material, width, height);
        }

        public static void SetClockUp(this HudElem hud, float time, float totalTime, string material, int width = 64, int height = 64)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclockup, time, totalTime, material, width, height);
        }

        public static void SetMapNameString(this HudElem hud, string mapname)
        {
            throw new NotImplementedException();
        }

        public static void SetPlayerNameString(this HudElem hud, Entity player)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayernamestring, player);
        }

        public static void SetPulseFX(this HudElem hud, int speed, int decayStart, int decayDuration)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setpulsefx, speed, decayStart, decayDuration);
        }

        public static void SetShader(this HudElem hud, string material, int width = 64, int height = 64)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setshader, material, width, height);
            hud._shader = material;
            hud.Width = width;
            hud.Height = height;
        }

        public static void SetTargetEnt(this HudElem hud, Entity entity)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetent_hud, entity);
        }

        public static void SetTenthsTimer(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settenthstimer, time);
        }

        public static void SetTenthsTimerUp(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settenthstimerup, time);
        }

        public static void SetText(this HudElem hud, string text)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settext, text);
        }

        public static void SetTimer(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settimer, time);
        }

        public static void SetTimerUp(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settimerup, time);
        }

        public static void SetValue(this HudElem hud, int value)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setvalue, value);
        }

        public static void SetWaypoint(this HudElem hud, bool constantSize)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize);
        }

        public static void SetWaypoint(this HudElem hud, bool constantSize, bool pinToScreenEdge)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize, pinToScreenEdge);
        }

        public static void SetWaypoint(this HudElem hud, bool constantSize, bool pinToScreenEdge, bool fadeOutPinnedIcon)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize, pinToScreenEdge, fadeOutPinnedIcon);
        }

        public static void SetWaypoint(this HudElem hud, bool constantSize, bool pinToScreenEdge, bool fadeOutPinnedIcon, bool is3D)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypoint, constantSize, pinToScreenEdge, fadeOutPinnedIcon, is3D);
        }

        public static void ShowHudSplash(this Entity entity, string splash, int slot)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showhudsplash, splash, slot);
        }

        public static void ShowHudSplash(this Entity entity, string splash, int slot, int optionalNum)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.showhudsplash, splash, slot, optionalNum);
        }

        public static void SetTimerStatic(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settimerstatic, time);
        }

        public static void SetTenthsTimerStatic(this HudElem hud, float time)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settenthstimerstatic, time);
        }

        public static void SetWaypointEdgeStyle_RotatingIcon(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypointedgestyle_rotatingicon);
        }

        public static void SetWaypointEdgeStyle_SecondaryArrow(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypointedgestyle_secondaryarrow);
        }

        public static void SetWaypointIconOffScreenOnly(this HudElem hud)
        {
            Function.SetEntRef(hud.Entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaypointiconoffscreenonly);
        }

        public static void Earthquake(float scale, float duration, Vector3 source, int radius)
        {
            Function.Call(ScriptNames.FunctionList.earthquake, scale, duration, source, radius);
        }

        public static void ExitLevel(bool savePersistent)
        {
            Function.Call(ScriptNames.FunctionList.exitlevel, savePersistent);
        }

        public static float GetNorthYaw()
        {
            Function.Call(ScriptNames.FunctionList.getnorthyaw);
            return (float)Function.GetReturns();
        }

        public static int GetStartTime()
        {
            Function.Call(ScriptNames.FunctionList.getstarttime);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetTime()
        {
            Function.Call(ScriptNames.FunctionList.gettime);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static bool IsSplitScreen()
        {
            Function.Call(ScriptNames.FunctionList.issplitscreen);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsValidGametype(string gametype)
        {
            Function.Call(ScriptNames.FunctionList.isvalidgametype, gametype);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool MapExists(string mapname)
        {
            Function.Call(ScriptNames.FunctionList.mapexists, mapname);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void SetClientNameMode(string mode)
        {
            Function.Call(ScriptNames.FunctionList.setclientnamemode, mode);
        }

        public static void SetGameEndTime(int time)
        {
            Function.Call(ScriptNames.FunctionList.setgameendtime, time);
        }

        public static void SetMapCenter(Vector3 center)
        {
            Function.Call(ScriptNames.FunctionList.setmapcenter, center);
        }

        public static void SetMiniMap(string material, int upperLeftX, int upperLeftY, int lowerRightX, int lowerRightY)
        {
            Function.Call(ScriptNames.FunctionList.setminimap, material, upperLeftX, upperLeftY, lowerRightX, lowerRightY);
        }

        public static void SetWinningPlayer(Entity player)
        {
            Function.Call(ScriptNames.FunctionList.setwinningplayer, player);
        }

        public static void SetWinningTeam(string team)
        {
            Function.Call(ScriptNames.FunctionList.setwinningteam, team);
        }

        public static void UpdateClientNames()
        {
            Function.Call(ScriptNames.FunctionList.updateclientnames);
        }

        public static int WorldEntNumber()
        {
            Function.Call(ScriptNames.FunctionList.worldentnumber);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void SetSunlight(Vector3 rgb)
        {
            Function.Call(ScriptNames.FunctionList.setsunlight, rgb.X, rgb.Y, rgb.Z);
        }

        public static void ResetSunlight()
        {
            Function.Call(ScriptNames.FunctionList.resetsunlight);
        }

        public static void Map_Restart()
        {
            Function.Call(ScriptNames.FunctionList.map_restart);
        }

        public static void MatchEnd()
        {
            Function.Call(ScriptNames.FunctionList.matchend);
        }

        public static void EndParty()
        {
            Function.Call(ScriptNames.FunctionList.endparty);
        }

        public static int GetUAVStrengthMin()
        {
            Function.Call(ScriptNames.FunctionList.getuavstrengthmin);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetUAVStrengthMax()
        {
            Function.Call(ScriptNames.FunctionList.getuavstrengthmax);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetUAVStrengthLevelNeutral()
        {
            Function.Call(ScriptNames.FunctionList.getuavstrengthlevelneutral);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetUAVStrengthLevelShowEnemyFastSweep()
        {
            Function.Call(ScriptNames.FunctionList.getuavstrengthlevelshowenemyfastsweep);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetUAVStrengthLevelShowEnemyDirectional()
        {
            Function.Call(ScriptNames.FunctionList.getuavstrengthlevelshowenemydirectional);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void SetMatchData(params Parameter[] data)
        {
            Function.Call(ScriptNames.FunctionList.setmatchdata, data);
        }

        public static Parameter GetMatchData(params Parameter[] data)
        {
            Function.Call(ScriptNames.FunctionList.getmatchdata, data);
            return new Parameter(Function.GetReturns());
        }

        public static void SendMatchData()
        {
            Function.Call(ScriptNames.FunctionList.sendmatchdata);
        }

        public static void ClearMatchData()
        {
            Function.Call(ScriptNames.FunctionList.clearmatchdata);
        }

        public static void SetMatchDataDef(string name)
        {
            Function.Call(ScriptNames.FunctionList.setmatchdatadef, name);
        }

        public static void SetMatchClientIP(Entity client, int clientID)
        {
            Function.Call(ScriptNames.FunctionList.setmatchclientip, client, clientID);
        }

        public static void SetMatchDataID()
        {
            Function.Call(ScriptNames.FunctionList.setmatchdataid);
        }

        public static void SetClientMatchData(params Parameter[] data)
        {
            Function.Call(ScriptNames.FunctionList.setclientmatchdata, data);
        }

        public static Parameter GetClientMatchData(params Parameter[] dataNames)
        {
            Function.Call(ScriptNames.FunctionList.getclientmatchdata, dataNames);
            return new Parameter(Function.GetReturns());
        }

        public static void SetClientMatchDataDef(string name)
        {
            Function.Call(ScriptNames.FunctionList.setclientmatchdatadef, name);
        }

        public static void SendClientMatchData()
        {
            Function.Call(ScriptNames.FunctionList.sendclientmatchdata);
        }

        public static string GetMatchRulesData(string rule, params string[] parameters)
        {
            List<Parameter> parametersArray = new List<Parameter>()
            {
                rule
            };
            parametersArray = parametersArray.Concat(parameters.Select(x => new Parameter(x))).ToList();
            Function.Call(ScriptNames.FunctionList.getmatchrulesdata, parametersArray.ToArray());
            return (string)Function.GetReturns();
        }

        public static bool IsUsingMatchRulesData()
        {
            Function.Call(ScriptNames.FunctionList.isusingmatchrulesdata);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void EndLobby()
        {
            Function.Call(ScriptNames.FunctionList.endlobby);
        }

        public static string GetMapCustom(string name)
        {
            Function.Call(ScriptNames.FunctionList.getmapcustom, name);
            return (string)Function.GetReturns();
        }

        public static void UpdateSkill(Entity attacker, Entity defender, string gametype, float scalar)
        {
            Function.Call(ScriptNames.FunctionList.updateskill, attacker, defender, gametype, scalar);
        }

        public static void SetNorthYaw(int yaw)
        {
            Function.Call(ScriptNames.FunctionList.setnorthyaw, yaw);
        }

        public static void SetSlowMotion(float startScale, float endScale, float lerpDuration)
        {
            Function.Call(ScriptNames.FunctionList.setslowmotion, startScale, endScale, lerpDuration);
        }

        public static void SetExpFog(float startDist, float halfwayDist, Vector3 rgb, float opacity, float transitionTime, Vector3 sunRGB, float sunOpacity, Vector3 sunDirection, float sunBeginFadeAngle, float sunEndFadeAngle)
        {
            Function.Call(ScriptNames.FunctionList.setexpfog, startDist, halfwayDist, rgb.X, rgb.Y, rgb.Z, opacity, transitionTime, sunRGB.X, sunRGB.Y, sunRGB.Z, sunOpacity, sunDirection, sunBeginFadeAngle, sunEndFadeAngle);
        }

        public static Entity GetVehicleNode(string name, string key)
        {
            Function.Call(ScriptNames.FunctionList.getvehiclenode, name, key);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetVehicleNodeArray(string name, string key)
        {
            Function.Call(ScriptNames.FunctionList.getvehiclenodearray, name, key);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetAllVehicleNodes()
        {
            Function.Call(ScriptNames.FunctionList.getallvehiclenodes);
            return (Entity)Function.GetReturns();
        }

        public static int GetNumVehicles()
        {
            Function.Call(ScriptNames.FunctionList.getnumvehicles);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static Entity Vehicle_GetSpawnerArray()
        {
            Function.Call(ScriptNames.FunctionList.vehicle_getspawnerarray);
            return (Entity)Function.GetReturns();
        }

        public static Entity Vehicle_GetArray()
        {
            Function.Call(ScriptNames.FunctionList.vehicle_getarray);
            return (Entity)Function.GetReturns();
        }

        public static int GetCounterTotal(string stat)
        {
            Function.Call(ScriptNames.FunctionList.getcountertotal, stat);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void IncrementCounter(string stat, int increment)
        {
            Function.Call(ScriptNames.FunctionList.incrementcounter, stat, increment);
        }

        public static float ACos(float cosValue)
        {
            Function.Call(ScriptNames.FunctionList.acos, cosValue);
            return (float)Function.GetReturns();
        }

        public static float ASin(float sinValue)
        {
            Function.Call(ScriptNames.FunctionList.asin, sinValue);
            return (float)Function.GetReturns();
        }

        public static float ATan(float tanValue)
        {
            Function.Call(ScriptNames.FunctionList.atan, tanValue);
            return (float)Function.GetReturns();
        }

        public static float Cos(float angle)
        {
            Function.Call(ScriptNames.FunctionList.cos, angle);
            return (float)Function.GetReturns();
        }

        public static int Int(float value)
        {
            return (int)value;
        }

        public static float Float(string value)
        {
            return float.Parse(value);
        }

        public static Vector3 PointOnSegmentNearestToPoint(Vector3 segmentA, Vector3 segmentB, Vector3 point)
        {
            Function.Call(ScriptNames.FunctionList.pointonsegmentnearesttopoint, segmentA, segmentB, point);
            return (Vector3)Function.GetReturns();
        }

        public static float RandomFloat(float max)
        {
            Function.Call(ScriptNames.FunctionList.randomfloat, max);
            return (float)Function.GetReturns();
        }

        public static float RandomFloatRange(float min, float max)
        {
            Function.Call(ScriptNames.FunctionList.randomfloatrange, min, max);
            return (float)Function.GetReturns();
        }

        public static int RandomInt(int max)
        {
            Function.Call(ScriptNames.FunctionList.randomint, max);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int RandomIntRange(int min, int max)
        {
            Function.Call(ScriptNames.FunctionList.randomintrange, min, max);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static float Sin(float angle)
        {
            Function.Call(ScriptNames.FunctionList.sin, angle);
            return (float)Function.GetReturns();
        }

        public static float Tan(float angle)
        {
            Function.Call(ScriptNames.FunctionList.tan, angle);
            return (float)Function.GetReturns();
        }

        public static Vector3 VectorFromLineToPoint(Vector3 segmentA, Vector3 segmentB, Vector3 point)
        {
            Function.Call(ScriptNames.FunctionList.vectorfromlinetopoint, segmentA, segmentB, point);
            return (Vector3)Function.GetReturns();
        }

        public static float Abs(float input)
        {
            Function.Call(ScriptNames.FunctionList.abs, input);
            return (float)Function.GetReturns();
        }

        public static float Min(float input, float minimum)
        {
            Function.Call(ScriptNames.FunctionList.min, input, minimum);
            return (float)Function.GetReturns();
        }

        public static float Max(float input, float maximum)
        {
            Function.Call(ScriptNames.FunctionList.max, input, maximum);
            return (float)Function.GetReturns();
        }

        public static float Floor(float input)
        {
            Function.Call(ScriptNames.FunctionList.floor, input);
            return (float)Function.GetReturns();
        }

        public static float Ceil(float input)
        {
            Function.Call(ScriptNames.FunctionList.ceil, input);
            return (float)Function.GetReturns();
        }

        public static float Exp(float input)
        {
            Function.Call(ScriptNames.FunctionList.exp, input);
            return (float)Function.GetReturns();
        }

        public static float Log(float input)
        {
            Function.Call(ScriptNames.FunctionList.log, input);
            return (float)Function.GetReturns();
        }

        public static float Sqrt(float input)
        {
            return (float)Math.Sqrt((double)input);
        }

        public static float Squared(float input)
        {
            return input *= input;
        }

        public static float Clamp(float input, float minimum, float maximum)
        {
            Function.Call(ScriptNames.FunctionList.clamp, input, minimum, maximum);
            return (float)Function.GetReturns();
        }

        public static Vector3 AngleClamp(Vector3 angle, float minimum, float maximum)
        {
            Function.Call(ScriptNames.FunctionList.angleclamp, angle, minimum, maximum);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 AngleClamp180(float angle)
        {
            Function.Call(ScriptNames.FunctionList.angleclamp180, angle);
            return (Vector3)Function.GetReturns();
        }

        public static void OpenPopUpMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openpopupmenu, menu);
        }

        public static void OpenPopUpMenuNoMouse(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openpopupmenunomouse, menu);
        }

        public static void ClosePopUpMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closepopupmenu, menu);
        }

        public static void OpenMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.openmenu, menu);
        }

        public static void CloseMenu(this Entity entity, string menu)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closemenu, menu);
        }

        public static void CloseInGameMenu(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.closeingamemenu);
        }

        public static void MoveGravity(this Entity entity, Vector3 velocity, int time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movegravity, velocity, time);
        }

        public static void MoveTo(this Entity entity, Vector3 point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveto, point, time);
        }

        public static void MoveTo(this Entity entity, Vector3 point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveto, point, time, accelTime);
        }

        public static void MoveTo(this Entity entity, Vector3 point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveto, point, time, accelTime, decelTime);
        }

        public static void MoveX(this Entity entity, float point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movex, point, time);
        }

        public static void MoveX(this Entity entity, float point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movex, point, time, accelTime);
        }

        public static void MoveX(this Entity entity, float point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movex, point, time, accelTime, decelTime);
        }

        public static void MoveY(this Entity entity, float point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movey, point, time);
        }

        public static void MoveY(this Entity entity, float point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movey, point, time, accelTime);
        }

        public static void MoveY(this Entity entity, float point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movey, point, time, accelTime, decelTime);
        }

        public static void MoveZ(this Entity entity, float point, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movez, point, time);
        }

        public static void MoveZ(this Entity entity, float point, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movez, point, time, accelTime);
        }

        public static void MoveZ(this Entity entity, float point, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.movez, point, time, accelTime, decelTime);
        }

        public static void NotSolid(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.notsolid);
        }

        public static void PhysicsLaunchClient(this Entity entity, Vector3 point, Vector3 force)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicslaunchclient, point, force);
        }

        public static void PhysicsLaunchServer(this Entity entity, Vector3 point, Vector3 force)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicslaunchserver, point, force);
        }

        public static void RotatePitch(this Entity entity, int pitch, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatepitch, pitch, time);
        }

        public static void RotatePitch(this Entity entity, int pitch, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatepitch, pitch, time, accelTime);
        }

        public static void RotatePitch(this Entity entity, int pitch, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatepitch, pitch, time, accelTime, decelTime);
        }

        public static void RotateRoll(this Entity entity, int roll, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateroll, roll, time);
        }

        public static void RotateRoll(this Entity entity, int roll, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateroll, roll, time, accelTime);
        }

        public static void RotateRoll(this Entity entity, int roll, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateroll, roll, time, accelTime, decelTime);
        }

        public static void RotateTo(this Entity entity, Vector3 angles, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateto, angles, time);
        }

        public static void RotateTo(this Entity entity, Vector3 angles, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateto, angles, time, accelTime);
        }

        public static void RotateTo(this Entity entity, Vector3 angles, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateto, angles, time, accelTime, decelTime);
        }

        public static void RotateVelocity(this Entity entity, Vector3 velocity, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatevelocity, velocity, time);
        }

        public static void RotateVelocity(this Entity entity, Vector3 velocity, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatevelocity, velocity, time, accelTime);
        }

        public static void RotateVelocity(this Entity entity, Vector3 velocity, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotatevelocity, velocity, time, accelTime, decelTime);
        }

        public static void RotateYaw(this Entity entity, int yaw, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time);
        }

        public static void RotateYaw(this Entity entity, int yaw, float time, float accelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time, accelTime);
        }

        public static void RotateYaw(this Entity entity, int yaw, float time, float accelTime, float decelTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time, accelTime, decelTime);
        }

        public static void Solid(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.solid);
        }

        public static void Vibrate(this Entity entity, Vector3 direction, float amplitude, float period, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.vibrate, direction, amplitude, period, time);
        }

        public static void MoveSlide(this Entity entity, Vector3 point, float time, Vector3 velocity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.moveslide, point, time, velocity);
        }

        public static void StopMoveSlide(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopmoveslide);
        }

        public static void AddPitch(this Entity entity, int pitch)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addpitch, pitch);
        }

        public static void AddYaw(this Entity entity, int yaw)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addyaw, yaw);
        }

        public static void AddRoll(this Entity entity, int roll)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.addroll, roll);
        }

        public static void PhysicsLaunchServerItem(this Entity entity, Vector3 point, Vector3 force)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.physicslaunchserveritem, point, force);
        }

        public static void TransformMove(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.transformmove, entity);
        }

        public static void PhysicsExplosionSphere(Vector3 center, int radius, int height, int force)
        {
            Function.Call(ScriptNames.FunctionList.physicsexplosionsphere, center, radius, height, force);
        }

        public static void PhysicsExplosionCylinder(Vector3 center, int radius, int height, int force)
        {
            Function.Call(ScriptNames.FunctionList.physicsexplosioncylinder, center, radius, height, force);
        }

        public static void PhysicsJolt(Vector3 center, int outerRadius, int innerRadius, int force)
        {
            Function.Call(ScriptNames.FunctionList.physicsjolt, center, outerRadius, innerRadius, force);
        }

        public static void PhysicsJitter(Vector3 center, int outerRadius, int innerRadius, float minDisplacement, float maxDisplacement)
        {
            Function.Call(ScriptNames.FunctionList.physicsjitter, center, outerRadius, innerRadius, minDisplacement, maxDisplacement);
        }

        public static void Objective_Add(int objectiveNumber, string state, Vector3? position = null, string shader = "")
        {
            if (!position.HasValue && shader == "")
                Function.Call(ScriptNames.FunctionList.objective_add, objectiveNumber, state);
            else if (shader == "")
                Function.Call(ScriptNames.FunctionList.objective_add, objectiveNumber, state, position.HasValue ? (Parameter)position.GetValueOrDefault() : null);
            else
                Function.Call(ScriptNames.FunctionList.objective_add, objectiveNumber, state, position.HasValue ? (Parameter)position.GetValueOrDefault() : null, shader);
        }

        public static void Objective_Current(int objectiveIndex, params int[] additionalIndex)
        {
            List<Parameter> parametersArray = new List<Parameter>() { objectiveIndex };
            parametersArray = parametersArray.Concat(additionalIndex.Select(x => new Parameter(x))).ToList();

            Function.Call(ScriptNames.FunctionList.objective_current, parametersArray.ToArray());
        }

        public static void Objective_Delete(int objectiveNumber)
        {
            Function.Call(ScriptNames.FunctionList.objective_delete, objectiveNumber);
        }

        public static void Objective_Icon(int objectiveNumber, string icon)
        {
            Function.Call(ScriptNames.FunctionList.objective_icon, objectiveNumber, icon);
        }

        public static void Objective_OnEntity(int objectiveNumber, Entity entity)
        {
            Function.Call(ScriptNames.FunctionList.objective_onentity, objectiveNumber, entity);
        }

        public static void Objective_Position(int objectiveNumber, Vector3 position)
        {
            Function.Call(ScriptNames.FunctionList.objective_position, objectiveNumber, position);
        }

        public static void Objective_State(int objectiveNumber, string state)
        {
            Function.Call(ScriptNames.FunctionList.objective_state, objectiveNumber, state);
        }

        public static void Objective_Team(int objectiveNumber, string team)
        {
            Function.Call(ScriptNames.FunctionList.objective_team, objectiveNumber, team);
        }

        public static void PingPlayer(this Entity player)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.pingplayer);
        }

        public static void Objective_Player(int objectiveNumber, int playerNumber)
        {
            Function.Call(ScriptNames.FunctionList.objective_player, objectiveNumber, playerNumber);
        }

        public static void Objective_PlayerTeam(int objectiveNumber, int playerNumber)
        {
            Function.Call(ScriptNames.FunctionList.objective_playerteam, objectiveNumber, playerNumber);
        }

        public static void Objective_PlayerEnemyTeam(int objectiveNumber, int playerNumber)
        {
            Function.Call(ScriptNames.FunctionList.objective_playerenemyteam, objectiveNumber, playerNumber);
        }

        public static bool AdsButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.adsbuttonpressed);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void AllowAds(this Entity entity, bool ads)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.allowads, ads);
        }

        public static void AllowJump(this Entity entity, bool jump)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.allowjump, jump);
        }

        public static void AllowSprint(this Entity entity, bool sprint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.allowsprint, sprint);
        }

        public static bool AnyAmmoForWeaponModes(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.anyammoforweaponmodes, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool AttackButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.attackbuttonpressed);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool ButtonPressed(this Entity entity, string key)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.buttonpressed, key);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void ClearPerks(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clearperks);
        }

        public static void DeactivateChannelVolumes(this Entity entity, string priority, int fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.deactivatechannelvolumes, priority, fade);
        }

        public static void DeactivateReverb(this Entity entity, string priority, int fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.deactivatereverb, priority, fade);
        }

        public static bool FragButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fragbuttonpressed);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void FreezeControls(this Entity entity, bool state)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.freezecontrols, state);
        }

        public static string GetCurrentOffhand(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentoffhand);
            return (string)Function.GetReturns();
        }

        public static string GetCurrentWeapon(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentweapon);
            return (string)Function.GetReturns();
        }

        public static int GetCurrentWeaponClipAmmo(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentweaponclipammo);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static float GetFractionMaxAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getfractionmaxammo, weapon);
            return (float)Function.GetReturns();
        }

        public static float GetFractionStartAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getfractionstartammo, weapon);
            return (float)Function.GetReturns();
        }

        public static Vector3 GetNormalizedMovement(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnormalizedmovement);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 GetNormalizedCameraMovement(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getnormalizedcameramovement);
            return (Vector3)Function.GetReturns();
        }

        public static string GetOffhandSecondaryClass(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getoffhandsecondaryclass);
            return (string)Function.GetReturns();
        }

        public static Vector3 GetPlayerAngles(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerangles);
            return (Vector3)Function.GetReturns();
        }

        public static string GetStance(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getstance);
            return (string)Function.GetReturns();
        }

        public static Vector3 GetVelocity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getvelocity);
            return (Vector3)Function.GetReturns();
        }

        public static int GetWeaponAmmoClip(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponammoclip, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetWeaponAmmoStock(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponammostock, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static Entity GetWeaponsList(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslist);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetWeaponsListAll(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistall);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetWeaponsListPrimaries(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistprimaries);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetWeaponsListOffhands(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistoffhands);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetWeaponsListItems(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistitems);
            return (Entity)Function.GetReturns();
        }

        public static Entity GetWeaponsListExclusives(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponslistexclusives);
            return (Entity)Function.GetReturns();
        }

        public static void GiveMaxAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.givemaxammo, weapon);
        }

        public static void GiveStartAmmo(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.givestartammo, weapon);
        }

        public static void GiveWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.giveweapon, weapon);
        }

        public static void GiveWeapon(this Entity entity, string weapon, int index)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.giveweapon, weapon, index);
        }

        public static void GiveWeapon(this Entity entity, string weapon, int index, bool akimbo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.giveweapon, weapon, index, akimbo);
        }

        public static bool HasPerk(this Entity entity, string perk)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hasperk, perk);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool HasWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.hasweapon, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsOnGround(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isonground);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool MeleeButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.meleebuttonpressed);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void NotifyOnPlayerCommand(this Entity entity, string notify, string command)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.notifyonplayercommand, notify, command);
        }

        public static float PlayerAds(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerads);
            return (float)Function.GetReturns();
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag = "")
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "")
                Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag);
            else
                Function.Call(ScriptNames.FunctionList.playerlinkto, entity);
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction);
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc);
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc);
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc, topArc);
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
        }

        public static void PlayerLinkTo(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkto, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
        }

        public static void PlayerLinkToAbsolute(this Entity player, Entity entity, string tag = "")
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "")
                Function.Call(ScriptNames.FunctionList.playerlinktoabsolute, entity, tag);
            else
                Function.Call(ScriptNames.FunctionList.playerlinktoabsolute, entity);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag = "")
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "")
                Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag);
            else
                Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc, topArc);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
        }

        public static void PlayerLinkToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinktodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
        }

        public static void PlayLocalSound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playlocalsound, sound);
        }

        public static void ResetSpreadOverride(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.resetspreadoverride);
        }

        public static bool SecondaryOffhandButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.secondaryoffhandbuttonpressed);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void SetActionSlot(this Entity entity, int slot, string option, string weapon = "")
        {
            Function.SetEntRef(entity.EntRef);
            if (weapon != "")
                Function.Call(ScriptNames.FunctionList.setactionslot, slot, option, weapon);
            else
                Function.Call(ScriptNames.FunctionList.setactionslot, slot, option);
        }

        public static void SetChannelVolumes(this Entity entity, string priority, string shockName, float fade = 0.0f)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setchannelvolumes, priority, shockName, fade);
        }

        public static void SetClientDvar(this Entity entity, string dvar, Parameter value)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientdvar, dvar, value);
        }

        public static void SetClientDvars(this Entity entity, string dvar, Parameter value, params Parameter[] additionalValues)
        {
            List<Parameter> parametersArray = new List<Parameter>()
            {
                dvar, value
            };
            parametersArray = parametersArray.Concat(additionalValues).ToList();

            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setclientdvars, parametersArray.ToArray());
        }

        public static void SetDepthOfField(this Entity entity, int nearStart, int nearEnd, int farStart, int farEnd, float nearBlur, float farBlur)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdepthoffield, nearStart, nearEnd, farStart, farEnd, nearBlur, farBlur);
        }

        public static void SetMoveSpeedScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmovespeedscale, scale);
        }

        public static void SetOffhandSecondaryClass(this Entity entity, string name)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setoffhandsecondaryclass, name);
        }

        public static void SetOrigin(this Entity entity, Vector3 origin)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setorigin, origin);
        }

        public static void SetPerk(this Entity entity, string perk)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setperk, perk);
        }

        public static void SetPerk(this Entity entity, string perk, bool codePerk)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setperk, perk, codePerk);
        }

        public static void SetPerk(this Entity entity, string perk, bool codePerk, bool useSlot)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setperk, perk, codePerk, useSlot);
        }

        public static void SetPlayerAngles(this Entity entity, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerangles, angles);
        }

        public static void SetReverb(this Entity entity, string priority, string roomType, float dryLevel = 0.0f, float wetLevel = 0.0f, float fade = 0.0f)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setreverb, priority, roomType, dryLevel, wetLevel, fade);
        }

        public static void SetSpreadOverride(this Entity entity, int spread)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setspreadoverride, spread);
        }

        public static void SetVelocity(this Entity entity, Vector3 velocity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setvelocity, velocity);
        }

        public static void SetViewModel(this Entity entity, string viewmodel)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewmodel, viewmodel);
        }

        public static void SetViewModelDepthOfField(this Entity entity, float start, float end)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewmodeldepthoffield, start, end);
        }

        public static void SetWeaponAmmoClip(this Entity entity, string weapon, int ammo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setweaponammoclip, weapon, ammo);
        }

        public static void SetWeaponAmmoStock(this Entity entity, string weapon, int ammo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setweaponammostock, weapon, ammo);
        }

        public static void ShellShock(this Entity entity, string shellshock, float duration)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.shellshock, shellshock, duration);
        }

        public static void ShellShock(this Entity entity, string shellshock, float duration, bool overrideCheat)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.shellshock, shellshock, duration, overrideCheat);
        }

        public static void StopLocalSound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stoplocalsound, sound);
        }

        public static void StopShellShock(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopshellshock);
        }

        public static void SwitchToOffhand(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.switchtooffhand);
        }

        public static void SwitchToWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.switchtoweapon, weapon);
        }

        public static void SwitchToWeaponImmediate(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.switchtoweaponimmediate, weapon);
        }

        public static void TakeAllWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.takeallweapons);
        }

        public static void TakeWeapon(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.takeweapon, weapon);
        }

        public static void UnSetPerk(this Entity entity, string perk, bool useSlot = true)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.unsetperk, perk, useSlot);
        }

        public static bool UseButtonPressed(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.usebuttonpressed);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void ViewKick(this Entity entity, int force, Vector3 source)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.viewkick, force, source);
        }

        public static void WeaponLockFinalize(this Entity player, Entity entity)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlockfinalize, entity);
        }

        public static void WeaponLockFree(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlockfree);
        }

        public static void WeaponLockNoClearance(this Entity entity, bool noClearance)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlocknoclearance, noClearance);
        }

        public static void WeaponLockStart(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlockstart);
        }

        public static void WeaponLockTargetTooClose(this Entity entity, bool tooClose)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.weaponlocktargettooclose, tooClose);
        }

        public static float GetPlayerViewHeight(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerviewheight);
            return (float)Function.GetReturns();
        }

        public static string GetCurrentPrimaryWeapon(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getcurrentprimaryweapon);
            return (string)Function.GetReturns();
        }

        public static bool IsDualWielding(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isdualwielding);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsReloading(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isreloading);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsSwitchingWeapon(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isswitchingweapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsUsingTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isusingturret);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static string GetOffhandPrimaryClass(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getoffhandprimaryclass);
            return (string)Function.GetReturns();
        }

        public static void SetOffhandPrimaryClass(this Entity entity, string name)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setoffhandprimaryclass, name);
        }

        public static void DisableOffhandWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableoffhandweapons);
        }

        public static void EnableOffhandWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableoffhandweapons);
        }

        public static void DisableWeaponSwitch(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableweaponswitch);
        }

        public static void EnableWeaponSwitch(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableweaponswitch);
        }

        public static void DisableUsability(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableusability);
        }

        public static void EnableUsability(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableusability);
        }

        public static void SetWhizBySpreads(this Entity entity, float x, float y, float z)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwhizbyspreads, x, y, z);
        }

        public static void SetWhizByRadii(this Entity entity, float x, float y, float z)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwhizbyradii, x, y, z);
        }

        public static void SetVolMod(this Entity entity, float vol, float overrideVol)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setvolmod, vol, overrideVol);
        }

        public static void SetChannelVolume(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setchannelvolume);
        }

        public static void SetAimSpreadMovementScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setaimspreadmovementscale, scale);
        }

        public static void SetViewKickScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewkickscale, scale);
        }

        public static float GetViewKickScale(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getviewkickscale);
            return (float)Function.GetReturns();
        }

        public static Array CanPlayerPlaceSentry(this Entity entity)
        {
            throw new NotImplementedException();
        }

        public static Array CanPlayerPlaceTank(this Entity entity)
        {
            throw new NotImplementedException();
        }

        public static void VisionSetNakedForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnakedforplayer, vision);
        }

        public static void VisionSetNakedForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnakedforplayer, vision, fade);
        }

        public static void VisionSetNightForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnightforplayer, vision);
        }

        public static void VisionSetNightForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetnightforplayer, vision, fade);
        }

        public static void VisionSetMissileCamForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetmissilecamforplayer, vision);
        }

        public static void VisionSetMissileCamForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetmissilecamforplayer, vision, fade);
        }

        public static void VisionSetThermalForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetthermalforplayer, vision);
        }

        public static void VisionSetThermalForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetthermalforplayer, vision, fade);
        }

        public static void VisionSetPainForPlayer(this Entity entity, string vision)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetpainforplayer, vision);
        }

        public static void VisionSetPainForPlayer(this Entity entity, string vision, float fade)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsetpainforplayer, vision, fade);
        }

        public static string GetPlayerWeaponModel(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerweaponmodel);
            return (string)Function.GetReturns();
        }

        public static string GetPlayerKnifeModel(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerknifemodel);
            return (string)Function.GetReturns();
        }

        public static void UpdatePlayerModelWithWeapons(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.updateplayermodelwithweapons);
        }

        public static bool CanMantle(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canmantle);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void ForceMantle(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.forcemantle);
        }

        public static int Player_RecoilScaleOn(this Entity entity, int scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.player_recoilscaleon, scale);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void Player_RecoilScaleOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.player_recoilscaleoff);
        }

        public static void VisionSyncWithPlayer(this Entity entity, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.visionsyncwithplayer, player);
        }

        public static void SetEnterTime(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setentertime);
        }

        public static string GetGUID(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getguid);
            return (string)Function.GetReturns();
        }

        public static string GetXUID(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getxuid);
            return (string)Function.GetReturns();
        }

        public static bool IsHost(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.ishost);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Entity GetSpectatingPlayer(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getspectatingplayer);
            return (Entity)Function.GetReturns();
        }

        public static void PredictStreamPos(this Entity entity, Vector3 origin, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.predictstreampos, origin, angles);
        }

        public static void SetCardDisplaySlot(this Entity entity, Entity player, int slot)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcarddisplayslot, player, slot);
        }

        public static void SetCardTitle(this Entity entity, string title)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcardtitle, title);
        }

        public static void SetCardIcon(this Entity entity, string icon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcardicon, icon);
        }

        public static void SetCardNamePlate(this Entity entity, string nameplate)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setcardnameplate, nameplate);
        }

        public static void LastStandRevive(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.laststandrevive);
        }

        public static void SetSpectateDefaults(this Entity entity, Vector3 origin, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setspectatedefaults, origin, angles);
        }

        public static float GetThirdPersonCrosshairOffset(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getthirdpersoncrosshairoffset);
            return (float)Function.GetReturns();
        }

        public static void DisableWeaponPickup(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disableweaponpickup);
        }

        public static void EnableWeaponPickup(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enableweaponpickup);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc, bool collide)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc, int bottomArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc, int topArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc, topArc);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc, int leftArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc, leftArc);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction, int rightArc)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction, rightArc);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag, float viewFraction)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag, viewFraction);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity, string tag)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity, tag);
        }

        public static void PlayerLinkWeaponViewToDelta(this Entity player, Entity entity)
        {
            Function.SetEntRef(player.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkweaponviewtodelta, entity);
        }

        public static void PlayerLinkToBlend(this Entity player, Entity entity, string tag = "", float viewFraction = 0.0f, int rightArc = 180, int leftArc = 180, int topArc = 180, int bottomArc = 180, bool collide = false)
        {
            Function.SetEntRef(player.EntRef);
            if (tag != "")
                Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity, tag, viewFraction, rightArc, leftArc, topArc, bottomArc, collide);
            else
                Function.Call(ScriptNames.FunctionList.playerlinktoblend, entity);
        }

        public static void PlayerLinkedOffsetEnable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedoffsetenable);
        }

        public static void PlayerLinkedOffsetDisable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedoffsetdisable);
        }

        public static void PlayerLinkedSetViewZNear(this Entity entity, bool zNear)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedsetviewznear, zNear);
        }

        public static void PlayerLinkedSetUseBaseAngleForViewClamp(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerlinkedsetusebaseangleforviewclamp);
        }

        public static void LerpViewAngleClamp(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.lerpviewangleclamp);
        }

        public static void SetViewAngleResistance(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setviewangleresistance);
        }

        public static void ThermalVisionOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionon);
        }

        public static void ThermalVisionOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionoff);
        }

        public static void ThermalVisionFOFOverlayOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionfofoverlayon);
        }

        public static void ThermalVisionFOFOverlayOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermalvisionfofoverlayoff);
        }

        public static void AutospotOverlayOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.autospotoverlayon);
        }

        public static void AutospotOverlayOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.autospotoverlayoff);
        }

        public static void ForceUseHintOn(this Entity entity, string hint)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.forceusehinton, hint);
        }

        public static void ForceUseHintOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.forceusehintoff);
        }

        public static Entity MakeSoft(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makesoft);
            return (Entity)Function.GetReturns();
        }

        public static Entity MakeHard(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.makehard);
            return (Entity)Function.GetReturns();
        }

        public static void WillNeverChange(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.willneverchange);
        }

        public static void SetStance(this Entity entity, string stance)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setstance, stance);
        }

        public static void StunPlayer(this Entity entity, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stunplayer, time);
        }

        public static void FadeOutShellShock(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.fadeoutshellshock);
        }

        public static void SetMotionBlurMoveScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotionblurmovescale, scale);
        }

        public static void SetMotionBlurTurnScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotionblurturnscale, scale);
        }

        public static void SetMotionBlurZoomScale(this Entity entity, float scale)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotionblurzoomscale, scale);
        }

        public static string GetPlayerSetting(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayersetting);
            return (string)Function.GetReturns();
        }

        public static string GetLocalPlayerProfileData(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getlocalplayerprofiledata);
            return (string)Function.GetReturns();
        }

        public static void SetLocalPlayerProfileData(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setlocalplayerprofiledata);
        }

        public static void RemoteCameraSoundscapeOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecamerasoundscapeon);
        }

        public static void RemoteCameraSoundscapeOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecamerasoundscapeoff);
        }

        public static void RadarJamOn(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.radarjamon);
        }

        public static void RadarJamOff(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.radarjamoff);
        }

        public static void SetMotionTrackerVisible(this Entity entity, bool visible)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmotiontrackervisible, visible);
        }

        public static bool GetMotionTrackerVisible(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmotiontrackervisible);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void SetWaterSheeting(this Entity entity, int sheet, int duration)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setwatersheeting, sheet, duration);
        }

        public static void SetWeaponHudIconOverride(this Entity entity, string icon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setweaponhudiconoverride, icon);
        }

        public static string GetWeaponHudIconOverride(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getweaponhudiconoverride);
            return (string)Function.GetReturns();
        }

        public static void SetEMPJammed(this Entity entity, bool jammed)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setempjammed, jammed);
        }

        public static void PlayerSetExpFog(this Entity entity, float startDist, float halfwayDist, Vector3 RGB, float transitionTime)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playersetexpfog, startDist, halfwayDist, RGB.X, RGB.Y, RGB.Z, transitionTime);
        }

        public static bool IsItemUnlocked(this Entity entity, string item)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isitemunlocked, item);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Parameter GetPlayerData(this Entity entity, params Parameter[] data)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getplayerdata, data);
            return new Parameter(Function.GetReturns());
        }

        public static void SetPlayerData(this Entity entity, params Parameter[] data)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerdata, data);
        }

        public static bool IsUsingOnlineDataOffline(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isusingonlinedataoffline);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static int GetRestedTime(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getrestedtime);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int Send73Command(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.send73command_unk);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void SendLeaderboards(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.sendleaderboards);
        }

        public static void PlayerForceDeathAnim(this Entity entity, Entity inflictor, string meansOfDeath, string hitLoc, Vector3 direction)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerforcedeathanim, inflictor, meansOfDeath, hitLoc, direction);
        }

        public static void StartAC130(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startac130);
        }

        public static void StopAC130(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopac130);
        }

        public static bool CanSpawn(this Entity entity, Vector3 origin)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.canspawn, entity, origin);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void IPrintLn(this Entity entity, string message)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_iprintln, message);
        }

        public static void IPrintLnBold(this Entity entity, string message)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_iprintlnbold, message);
        }

        public static void PlayerHide(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playerhide);
        }

        public static bool IsSplitScreenPlayer(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.issplitscreenplayer);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsSplitScreenPlayerPrimary(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.issplitscreenplayerprimary);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void TrackerUpdate(this Entity entity, string stat, int value)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.trackerupdate, stat, value);
        }

        public static void ThermalDrawEnable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermaldrawenable);
        }

        public static void ThermalDrawDisable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.thermaldrawdisable);
        }

        public static void PreCacheHeadIcon(string headicon)
        {
            Function.Call(ScriptNames.FunctionList.precacheheadicon, headicon);
        }

        public static void PreCacheItem(string item)
        {
            Function.Call(ScriptNames.FunctionList.precacheitem, item);
        }

        public static void PreCacheLocationSelector(string material)
        {
            Function.Call(ScriptNames.FunctionList.precachelocationselector, material);
        }

        public static void PreCacheMenu(string menu)
        {
            Function.Call(ScriptNames.FunctionList.precachemenu, menu);
        }

        public static void PreCacheModel(string model)
        {
            Function.Call(ScriptNames.FunctionList.precachemodel, model);
        }

        public static void PreCacheRumble(string rumble)
        {
            Function.Call(ScriptNames.FunctionList.precacherumble, rumble);
        }

        public static void PreCacheShader(string material)
        {
            Function.Call(ScriptNames.FunctionList.precacheshader, material);
        }

        public static void PreCacheShellShock(string shellshock)
        {
            Function.Call(ScriptNames.FunctionList.precacheshellshock, shellshock);
        }

        public static void PreCacheStatusIcon(string icon)
        {
            Function.Call(ScriptNames.FunctionList.precachestatusicon, icon);
        }

        public static void PreCacheString(string text)
        {
            Function.Call(ScriptNames.FunctionList.precachestring, text);
        }

        public static void PreCacheVehicle(string vehicle)
        {
            Function.Call(ScriptNames.FunctionList.precachevehicle, vehicle);
        }

        public static string TableLookupIString(string filename, int column, Parameter value, int columnReturn)
        {
            Function.Call(ScriptNames.FunctionList.tablelookupistring, filename, column, value, columnReturn);
            return (string)Function.GetReturns();
        }

        public static string TableLookup(string filename, int column, Parameter value, int columnReturn)
        {
            Function.Call(ScriptNames.FunctionList.tablelookup, filename, column, value, columnReturn);
            return (string)Function.GetReturns();
        }

        public static void PreCacheFXTeamThermal(int effect, string tag)
        {
            Function.Call(ScriptNames.FunctionList.precachefxteamthermal, effect, tag);
        }

        public static void PreCacheMiniMapIcon(string icon)
        {
            Function.Call(ScriptNames.FunctionList.precacheminimapicon, icon);
        }

        public static void PreCacheMpAnim(string anim)
        {
            Function.Call(ScriptNames.FunctionList.precachempanim, anim);
        }

        public static void PreCacheLeaderboards(string leaderboard)
        {
            Function.Call(ScriptNames.FunctionList.precacheleaderboards, leaderboard);
        }

        public static string TableLookupByRow(string filename, int row, int column)
        {
            Function.Call(ScriptNames.FunctionList.tablelookupbyrow, filename, row, column);
            return (string)Function.GetReturns();
        }

        public static string TableLookupIStringByRow(string filename, int row, int column)
        {
            Function.Call(ScriptNames.FunctionList.tablelookupistringbyrow, filename, row, column);
            return (string)Function.GetReturns();
        }

        public static int TableLookupRowNum(string filename, int column, Parameter value)
        {
            Function.Call(ScriptNames.FunctionList.tablelookuprownum, filename, column, value);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void PreCacheTurret(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.precacheturret, weapon);
        }

        public static void PlayRumbleLoopOnEntity(this Entity entity, string rumble)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playrumblelooponentity, rumble);
        }

        public static void PlayRumbleLoopOnPosition(string rumble, Vector3 position)
        {
            Function.Call(ScriptNames.FunctionList.playrumblelooponposition, rumble, position);
        }

        public static void PlayRumbleOnEntity(this Entity entity, string rumble)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playrumbleonentity, rumble);
        }

        public static void PlayRumbleOnPosition(string rumble, Vector3 position)
        {
            Function.Call(ScriptNames.FunctionList.playrumbleonposition, rumble, position);
        }

        public static void StopAllRumbles()
        {
            Function.Call(ScriptNames.FunctionList.stopallrumbles);
        }

        public static void StopRumble(this Entity entity, string rumble)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stoprumble, rumble);
        }

        public static Vector3 GetEye(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.geteye);
            return (Vector3)Function.GetReturns();
        }

        public static bool IsAlive(Entity entity)
        {
            Function.Call(ScriptNames.FunctionList.isalive, entity);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsPlayer(Entity entity)
        {
            Function.Call(ScriptNames.FunctionList.isplayer, entity);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void AmbientPlay(string ambient)
        {
            Function.Call(ScriptNames.FunctionList.ambientplay, ambient);
        }

        public static void AmbientPlay(string ambient, float fade)
        {
            Function.Call(ScriptNames.FunctionList.ambientplay, ambient, fade);
        }

        public static void AmbientStop()
        {
            Function.Call(ScriptNames.FunctionList.ambientstop);
        }

        public static void AmbientStop(float fade)
        {
            Function.Call(ScriptNames.FunctionList.ambientstop, fade);
        }

        public static void PlayLoopSound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playloopsound, sound);
        }

        public static void PlaySound(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsound, sound);
        }

        public static void PlaySoundAsMaster(this Entity entity, string sound)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsoundasmaster, sound);
        }

        public static void PlaySoundToPlayer(this Entity entity, string sound, Entity player)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.playsoundtoplayer, sound, player);
        }

        public static void PlaySoundToTeam(this Entity entity, string sound, string team, Entity ignorePlayer = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (ignorePlayer != null)
                Function.Call(ScriptNames.FunctionList.playsoundtoteam, sound, team, ignorePlayer);
            else
                Function.Call(ScriptNames.FunctionList.playsoundtoteam, sound, team);
        }

        public static bool SoundExists(string alias)
        {
            Function.Call(ScriptNames.FunctionList.soundexists, alias);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void StopLoopSound(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stoploopsound);
        }

        public static void StopSound(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopsounds);
        }

        public static void PlaySoundAtPos(Vector3 origin, string sound)
        {
            Function.Call(ScriptNames.FunctionList.playsoundatpos, origin, sound);
        }

        public static void SetAC130Ambience(string ambience)
        {
            Function.Call(ScriptNames.FunctionList.setac130ambience, ambience);
        }

        public static void PlaceSpawnPoint(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.placespawnpoint);
        }

        public static bool PositionWouldTelefrag(Vector3 position)
        {
            Function.Call(ScriptNames.FunctionList.positionwouldtelefrag, position);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Entity Spawn(string classname, Vector3 origin)
        {
            Function.Call(ScriptNames.FunctionList.spawn, classname, origin);
            return (Entity)Function.GetReturns();
        }

        public static Entity Spawn(string classname, Vector3 origin, int flags, int radius, int height)
        {
            Function.Call(ScriptNames.FunctionList.spawn, classname, origin, flags, radius, height);
            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnStruct()
        {
            Function.Call(ScriptNames.FunctionList.spawnstruct);
            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnTurret(string classname, Vector3 origin, string weapon)
        {
            Function.Call(ScriptNames.FunctionList.spawnturret, classname, origin, weapon);
            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnVehicle(string model, string targetname, string vehicleType, Vector3 origin, Vector3 angles, Entity owner)
        {
            Function.Call(ScriptNames.FunctionList.spawnvehicle, model, targetname, vehicleType, origin, angles, owner);
            return (Entity)Function.GetReturns();
        }

        public static void Spawn(this Entity entity, Vector3 origin, Vector3 angles)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.target_spawn, origin, angles);
        }

        public static Entity SpawnPlane(Entity owner, string classname, Vector3 origin, string friendlyIcon, string enemyIcon)
        {
            Function.Call(ScriptNames.FunctionList.spawnplane, owner, classname, origin, friendlyIcon, enemyIcon);
            return (Entity)Function.GetReturns();
        }

        public static Entity SpawnHelicopter(Entity owner, Vector3 pathStart, Vector3 forward, string vehicle, string model)
        {
            Function.Call(ScriptNames.FunctionList.spawnhelicopter, owner, pathStart, forward, vehicle, model);
            return (Entity)Function.GetReturns();
        }

        public static Entity CreateAttractorEnt(Entity entity, int strength, int range)
        {
            Function.Call(ScriptNames.FunctionList.createattractorent, entity, strength, range);
            return (Entity)Function.GetReturns();
        }

        public static Entity CreateAttractorOrigin(Vector3 origin, int strength, int range)
        {
            Function.Call(ScriptNames.FunctionList.createattractororigin, origin, strength, range);
            return (Entity)Function.GetReturns();
        }

        public static Entity CreateRepulsorEnt(Entity entity, int strength, int range)
        {
            Function.Call(ScriptNames.FunctionList.createrepulsorent, entity, strength, range);
            return (Entity)Function.GetReturns();
        }

        public static Entity CreateRepulsorOrigin(Vector3 origin, int strength, int range)
        {
            Function.Call(ScriptNames.FunctionList.createrepulsororigin, origin, strength, range);
            return (Entity)Function.GetReturns();
        }

        public static string GetSubStr(string text, int startIndex, int endIndex = -1)
        {
            Function.Call(ScriptNames.FunctionList.getsubstr, text, startIndex, endIndex);
            return (string)Function.GetReturns();
        }

        public static bool IsSubStr(string text, string subString)
        {
            Function.Call(ScriptNames.FunctionList.issubstr, text, subString);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Array StrTok(string text, string delim)
        {
            throw new NotImplementedException();
        }

        public static string ToLower(string text)
        {
            Function.Call(ScriptNames.FunctionList.tolower, text);
            return (string)Function.GetReturns();
        }

        public static bool IsEndStr(string text, string endString)
        {
            Function.Call(ScriptNames.FunctionList.isendstr, text, endString);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool StriCmp(string str1, string str2)
        {
            Function.Call(ScriptNames.FunctionList.stricmp, str1, str2);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void LogPrint(string text)
        {
            Function.Call(ScriptNames.FunctionList.logprint, text);
        }

        public static void LogString(string text)
        {
            Function.Call(ScriptNames.FunctionList.logstring_0, text);
        }

        public static void ResetTimeout()
        {
            Function.Call(ScriptNames.FunctionList.resettimeout);
        }

        public static void SetArchive()
        {
            Function.Call(ScriptNames.FunctionList.setarchive);
        }

        public static int GetAssignedTeam(Entity player)
        {
            Function.Call(ScriptNames.FunctionList.getassignedteam, player);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int GetTeamPlayersAlive(string team)
        {
            Function.Call(ScriptNames.FunctionList.getteamplayersalive, team);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static bool GetTeamRadar(string team)
        {
            Function.Call(ScriptNames.FunctionList.getteamradar, team);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static int GetTeamScore(string team)
        {
            Function.Call(ScriptNames.FunctionList.getteamscore, team);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void SetTeamRadar(string team, bool availability)
        {
            Function.Call(ScriptNames.FunctionList.setteamradar, team, availability);
        }

        public static void SetTeamScore(string team, int score)
        {
            Function.Call(ScriptNames.FunctionList.setteamscore, team, score);
        }

        public static void SetPlayerTeamRank(Entity player, int clientID, int rank)
        {
            Function.Call(ScriptNames.FunctionList.setplayerteamrank, player, clientID, rank);
        }

        public static void SetTeamRadarStrength(string team, int strength)
        {
            Function.Call(ScriptNames.FunctionList.setteamradarstrength, team, strength);
        }

        public static int GetTeamRadarStrength(string team)
        {
            Function.Call(ScriptNames.FunctionList.getteamradarstrength, team);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static void BlockTeamRadar(string team)
        {
            Function.Call(ScriptNames.FunctionList.blockteamradar, team);
        }

        public static void UnBlockTeamRadar(string team)
        {
            Function.Call(ScriptNames.FunctionList.unblockteamradar, team);
        }

        public static bool IsTeamRadarBlocked(string team)
        {
            Function.Call(ScriptNames.FunctionList.isteamradarblocked, team);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Array BulletTrace(Vector3 start, Vector3 end, bool hitCharacters, Entity ignore)
        {
            throw new NotImplementedException();
        }

        public static bool BulletTracePassed(Vector3 start, Vector3 end, bool hitCharacters, Entity ignore = null)
        {
            if (ignore != null)
                Function.Call(ScriptNames.FunctionList.bullettracepassed, start, end, hitCharacters, ignore);
            else
                Function.Call(ScriptNames.FunctionList.bullettracepassed, start, end, hitCharacters);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static float DamageConeTrace(this Entity entity, Vector3 origin, Entity ignore = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (ignore != null)
                Function.Call(ScriptNames.FunctionList.damageconetrace, origin, ignore);
            else
                Function.Call(ScriptNames.FunctionList.damageconetrace, origin);
            return (float)Function.GetReturns();
        }

        public static Vector3 PhysicsTrace(Vector3 start, Vector3 end)
        {
            Function.Call(ScriptNames.FunctionList.physicstrace, start, end);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 PlayerPhysicsTrace(Vector3 start, Vector3 end)
        {
            Function.Call(ScriptNames.FunctionList.playerphysicstrace, start, end);
            return (Vector3)Function.GetReturns();
        }

        public static float SightConeTrace(this Entity entity, Vector3 position, Entity ignore = null)
        {
            Function.SetEntRef(entity.EntRef);
            if (ignore != null)
                Function.Call(ScriptNames.FunctionList.sightconetrace, position, ignore);
            else
                Function.Call(ScriptNames.FunctionList.sightconetrace, position);
            return (float)Function.GetReturns();
        }

        public static bool SightTracePassed(Vector3 start, Vector3 end, bool hitCharacters, params Entity[] ignore)
        {
            if (ignore.Length == 0)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters);
            else if (ignore.Length == 1)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters, ignore[0]);
            else if (ignore.Length == 2)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters, ignore[0], ignore[1]);
            else if (ignore.Length == 3)
                Function.Call(ScriptNames.FunctionList.sighttracepassed, start, end, hitCharacters, ignore[0], ignore[1], ignore[2]);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static float SpawnSightTrace(Entity spawnpoint, Vector3 origin, Vector3 end)
        {
            Function.Call(ScriptNames.FunctionList.spawnsighttrace, spawnpoint, origin, end);
            return (float)Function.GetReturns();
        }

        public static float PhysicsTraceNormal(Vector3 start, Vector3 end)
        {
            Function.Call(ScriptNames.FunctionList.physicstracenormal, start, end);
            return (float)Function.GetReturns();
        }

        public static float AverageNormal(Array normals)
        {
            throw new NotImplementedException();
        }

        public static bool WorldPointInReticle_Circle(this Entity entity, Vector3 origin, int width, int height)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.worldpointinreticle_circle, origin, width, height);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void ClientClaimTrigger(this Entity entity, Entity trigger)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clientclaimtrigger, trigger);
        }

        public static void ClientReleaseTrigger(this Entity entity, Entity trigger)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.clientreleasetrigger, trigger);
        }

        public static void ReleaseClaimedTrigger(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.releaseclaimedtrigger);
        }

        public static void ClearTargetEntity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartargetentity);
        }

        public static Entity GetTurretTarget(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getturrettarget);
            return (Entity)Function.GetReturns();
        }

        public static bool IsFiringTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isfiringturret);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void RestoreDefaultDropPitch(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.restoredefaultdroppitch);
        }

        public static void SetAISpread(this Entity entity, float spread)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setaispread, spread);
        }

        public static void SetBottomArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setbottomarc, angle);
        }

        public static void SetConvergenceTime(this Entity entity, float time, string type = "yaw")
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setconvergencetime, time, type);
        }

        public static void SetDefaultDropPitch(this Entity entity, float pitch)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setdefaultdroppitch, pitch);
        }

        public static void SetLeftArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setleftarc, angle);
        }

        public static void SetMode(this Entity entity, string mode)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setmode, mode);
        }

        public static void SetPlayerSpread(this Entity entity, float spread)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setplayerspread, spread);
        }

        public static void SetRightArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setrightarc, angle);
        }

        public static void SetSupressionTime(this Entity entity, float time)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setsuppressiontime, time);
        }

        public static void SetTargetEntity(this Entity entity, Entity target)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetentity, target);
        }

        public static void SetTopArc(this Entity entity, int angle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.settoparc, angle);
        }

        public static void SetTurretTeam(this Entity entity, string team)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretteam, team);
        }

        public static void ShootTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.shootturret);
        }

        public static void StartFiring(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startfiring);
        }

        public static void StopFiring(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopfiring);
        }

        public static void TurretFireDisable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.turretfiredisable);
        }

        public static void TurretFireEnable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.turretfireenable);
        }

        public static void StartBarrelSpin(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.startbarrelspin);
        }

        public static void StopBarrelSpin(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.stopbarrelspin);
        }

        public static float GetBarrelSpinRate(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getbarrelspinrate);
            return (float)Function.GetReturns();
        }

        public static void RemoteControlTurret(this Entity entity, Entity turret)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolturret, turret);
        }

        public static void RemoteControlTurretOff(this Entity entity, Entity turret)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolturretoff, turret);
        }

        public static Entity GetTurretOwner(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getturretowner);
            return (Entity)Function.GetReturns();
        }

        public static void SetSentryOwner(this Entity entity, Entity owner)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setsentryowner, owner);
        }

        public static void SetSentryCarrier(this Entity entity, Entity carrier)
        {
            Function.SetEntRef(entity.EntRef);
            if (carrier != null)
                Function.Call(ScriptNames.FunctionList.setsentrycarrier, carrier);
            else
                Function.Call(ScriptNames.FunctionList.setsentrycarrier);
        }

        public static void SetTurretMinimapVisible(this Entity entity, bool visible)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretminimapvisible, visible);
        }

        public static void SnapToTargetEntity(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.snaptotargetentity);
        }

        public static void SetConvergenceHeightPercent(this Entity entity, float percent)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setconvergenceheightpercent, percent);
        }

        public static void MakeTurretSolid(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketurretsolid);
        }

        public static void MakeTurretOperable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketurretoperable);
        }

        public static void MakeTurretInOperable(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.maketurretinoperable);
        }

        public static void SetTurretAccuracy(this Entity entity, float accuracy)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretaccuracy, accuracy);
        }

        public static void SetAutoRotationDelay(this Entity entity, float delay)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setautorotationdelay, delay);
        }

        public static void SetTurretModeChangeWait(this Entity entity, bool wait)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.setturretmodechangewait, wait);
        }

        public static void RemoteControlVehicle(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolvehicle, vehicle);
        }

        public static void RemoteControlVehicleOff(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.remotecontrolvehicleoff, vehicle);
        }

        public static bool IsFiringVehicleTurret(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.isfiringvehicleturret);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void DriveVehicleAndControlTurret(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.drivevehicleandcontrolturret, vehicle);
        }

        public static void DriveVehicleAndControlTurretOff(this Entity entity, Entity vehicle)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.drivevehicleandcontrolturretoff, vehicle);
        }

        public static string GetMode(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getmode);
            return (string)Function.GetReturns();
        }

        public static bool CanSpawnTurret()
        {
            Function.Call(ScriptNames.FunctionList.canspawnturret);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsDefined(Parameter variable)
        {
            Function.Call(ScriptNames.FunctionList.isdefined, variable);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsString(Parameter variable)
        {
            Function.Call(ScriptNames.FunctionList.isstring, variable);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Array GetArrayKeys(Array array)
        {
            throw new NotImplementedException();
        }

        public static string GetFirstArrayKey(Array array)
        {
            throw new NotImplementedException();
        }

        public static string GetNextArrayKey(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public static Vector3[] SortByDistance(Vector3[] array, Vector3 position)
        {
            return array.OrderBy(x => x.DistanceTo(position)).ToArray();
        }

        public static Vector3 AnglesToForward(Vector3 angles)
        {
            Function.Call(ScriptNames.FunctionList.anglestoforward, angles);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 AnglesToRight(Vector3 angles)
        {
            Function.Call(ScriptNames.FunctionList.anglestoright, angles);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 AnglesToUp(Vector3 angles)
        {
            Function.Call(ScriptNames.FunctionList.anglestoup, angles);
            return (Vector3)Function.GetReturns();
        }

        public static bool Closer(Vector3 reference, Vector3 pointA, Vector3 pointB)
        {
            Function.Call(ScriptNames.FunctionList.closer, reference, pointA, pointB);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static Vector3 CombineAngles(Vector3 anglesA, Vector3 anglesB)
        {
            Function.Call(ScriptNames.FunctionList.combineangles, anglesA, anglesB);
            return (Vector3)Function.GetReturns();
        }

        public static float Distance(Vector3 pointA, Vector3 pointB)
        {
            Function.Call(ScriptNames.FunctionList.distance, pointA, pointB);
            return (float)Function.GetReturns();
        }

        public static float Distance2D(Vector3 pointA, Vector3 pointB)
        {
            Function.Call(ScriptNames.FunctionList.distance2d, pointA, pointB);
            return (float)Function.GetReturns();
        }

        public static float DistanceSquared(Vector3 pointA, Vector3 pointB)
        {
            Function.Call(ScriptNames.FunctionList.distancesquared, pointA, pointB);
            return (float)Function.GetReturns();
        }

        public static float Length(Vector3 vector)
        {
            Function.Call(ScriptNames.FunctionList.length, vector);
            return (float)Function.GetReturns();
        }

        public static float LengthSquared(Vector3 vector)
        {
            Function.Call(ScriptNames.FunctionList.lengthsquared, vector);
            return (float)Function.GetReturns();
        }

        public static Vector3 VectorDot(Vector3 pointA, Vector3 pointB)
        {
            Function.Call(ScriptNames.FunctionList.vectordot, pointA, pointB);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 VectorLerp(Vector3 from, Vector3 to, float fraction)
        {
            Function.Call(ScriptNames.FunctionList.vectorlerp, from, to, fraction);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 VectorNormalize(Vector3 vector)
        {
            Function.Call(ScriptNames.FunctionList.vectornormalize, vector);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 VectorToAngles(Vector3 vector)
        {
            Function.Call(ScriptNames.FunctionList.vectortoangles, vector);
            return (Vector3)Function.GetReturns();
        }

        public static float VectorToYaw(Vector3 vector)
        {
            Function.Call(ScriptNames.FunctionList.vectortoyaw, vector);
            return (float)Function.GetReturns();
        }

        public static Vector3 GetPointInBounds(this Entity entity, Vector3 point)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getpointinbounds, point);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 GetGroundPosition(Vector3 origin, float radius)
        {
            Function.Call(ScriptNames.FunctionList.getgroundposition, origin, radius);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 GetGroundPosition(Vector3 origin, float radius, float traceDistance)
        {
            Function.Call(ScriptNames.FunctionList.getgroundposition, origin, radius, traceDistance);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 GetGroundPosition(Vector3 origin, float radius, float traceDistance, float traceHeight)
        {
            Function.Call(ScriptNames.FunctionList.getgroundposition, origin, radius, traceDistance, traceHeight);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 AveragePoint(Array points)
        {
            throw new NotImplementedException();
        }

        public static void DisableGrenadeTouchDamage(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.disablegrenadetouchdamage);
        }

        public static void EnableGrenadeTouchDamage(this Entity entity)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.enablegrenadetouchdamage);
        }

        public static int GetAmmoCount(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.getammocount, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static string GetWeaponModel(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.getweaponmodel, weapon);
            return (string)Function.GetReturns();
        }

        public static string GetWeaponModel(string weapon, int variant)
        {
            Function.Call(ScriptNames.FunctionList.getweaponmodel, weapon, variant);
            return (string)Function.GetReturns();
        }

        public static int GetWeaponHideTags(string weapon, int variant = 0)
        {
            Function.Call(ScriptNames.FunctionList.getweaponhidetags, weapon, variant);
            return (int)Function.GetReturns();
        }

        public static bool IsWeaponClipOnly(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.isweaponcliponly, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool IsWeaponDetonationTimed(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.isweapondetonationtimed, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void ItemWeaponSetAmmo(this Entity entity, int clipAmmo, int reserveAmmo)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.itemweaponsetammo, clipAmmo, reserveAmmo);
        }

        public static void ItemWeaponSetAmmo(this Entity entity, int clipAmmo, int reserveAmmo, int altWeapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.itemweaponsetammo, clipAmmo, reserveAmmo, altWeapon);
        }

        public static Entity MagicBullet(string weapon, Vector3 start, Vector3 end, Entity owner = null)
        {
            if (owner != null)
                Function.Call(ScriptNames.FunctionList.magicbullet, weapon, start, end, owner);
            else
                Function.Call(ScriptNames.FunctionList.magicbullet, weapon, start, end);
            return (Entity)Function.GetReturns();
        }

        public static string WeaponAltWeaponName(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponaltweaponname, weapon);
            return (string)Function.GetReturns();
        }

        public static string WeaponClass(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponclass, weapon);
            return (string)Function.GetReturns();
        }

        public static int WeaponClipSize(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponclipsize, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static float WeaponFireTime(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponfiretime, weapon);
            return (float)Function.GetReturns();
        }

        public static string WeaponInventoryType(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponinventorytype, weapon);
            return (string)Function.GetReturns();
        }

        public static bool WeaponIsBoltAction(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponisboltaction, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool WeaponIsSemiAutomatic(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponissemiauto, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static int WeaponMaxAmmo(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponmaxammo, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static int WeaponStartAmmo(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponstartammo, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static string WeaponType(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weapontype, weapon);
            return (string)Function.GetReturns();
        }

        public static void KC_RegWeaponForFxRemoval(this Entity entity, string weapon)
        {
            Function.SetEntRef(entity.EntRef);
            Function.Call(ScriptNames.FunctionList.regweaponforfxremoval, weapon);
        }

        public static Array GetWeaponHideTags(string weapon)
        {
            throw new NotImplementedException();
        }

        public static bool WeaponIsAuto(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponisauto, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static bool WeaponInheritsPerks(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponinheritsperks, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static int WeaponBurstCount(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponburstcount, weapon);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static bool WeaponHasThermalScope(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.weaponhasthermalscope, weapon);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static string GetWeaponFlashTag(string weapon)
        {
            Function.Call(ScriptNames.FunctionList.getweaponflashtagname, weapon);
            return (string)Function.GetReturns();
        }

        public static void AttachPath(this Entity vehicle, Entity node)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.attachpath, node);
        }

        public static void ClearGoalYaw(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.cleargoalyaw);
        }

        public static void ClearLookAtEnt(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.clearlookatent);
        }

        public static void ClearTargetYaw(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.cleartargetyaw);
        }

        public static void ClearTurretTarget(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.clearturrettarget);
        }

        public static void FireWeapon(this Entity vehicle, string barrelTag = "", Entity targetEnt = null, Vector3? targetOffset = null)
        {
            Function.SetEntRef(vehicle.EntRef);
            if (barrelTag == "" && targetEnt == null && !targetOffset.HasValue)
                Function.Call(ScriptNames.FunctionList.fireweapon);
            else if (barrelTag != "" && targetEnt == null)
                Function.Call(ScriptNames.FunctionList.fireweapon, barrelTag);
            else if (barrelTag != "" && targetEnt != null && !targetOffset.HasValue)
                Function.Call(ScriptNames.FunctionList.fireweapon, barrelTag, targetEnt);
            else
                Function.Call(ScriptNames.FunctionList.fireweapon, barrelTag, targetEnt, targetOffset.HasValue ? (Parameter)targetOffset.GetValueOrDefault() : null);
        }

        public static void FreeVehicle(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.freevehicle);
        }

        public static Entity GetAttachPos(this Entity vehicle, Entity node)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachpos, node);
            return (Entity)Function.GetReturns();
        }

        public static float GetGoalSpeedMPH(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getgoalspeedmph);
            return (float)Function.GetReturns();
        }

        public static int GetSpeed(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getspeed);
            return Convert.ToInt32(Function.GetReturns());
        }

        public static Entity GetVehicleOwner(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getvehicleowner);
            return (Entity)Function.GetReturns();
        }

        public static string GetWheelSurface(this Entity vehicle, string wheel)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getwheelsurface, wheel);
            return (string)Function.GetReturns();
        }

        public static bool IsTurretReady(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.isturretready);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void JoltBody(this Entity vehicle, Vector3 joltPosition, float intensity, float fraction = 0.0f, float deceleration = 0.0f)
        {
            if (fraction > 1.0)
                fraction = 1f;
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.joltbody, joltPosition, intensity, fraction, deceleration);
        }

        public static void ResumeSpeed(this Entity vehicle, float acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.resumespeed, acceleration);
        }

        public static void SetAcceleration(this Entity vehicle, float acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setacceleration, acceleration);
        }

        public static void SetAirResistance(this Entity vehicle, float maxResistanceSpeed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setairresistance, maxResistanceSpeed);
        }

        public static void SetDeceleration(this Entity vehicle, float deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setdeceleration, deceleration);
        }

        public static void SetGoalYaw(this Entity vehicle, float yaw)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setgoalyaw, yaw);
        }

        public static void SetHoverParams(this Entity vehicle, int radius, float speed, float accel)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.sethoverparams, radius, speed, accel);
        }

        public static void SetJitterParams(this Entity vehicle, Vector3 range, float minPeriod, float maxPeriod)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setjitterparams, range, minPeriod, maxPeriod);
        }

        public static void SetLookAtEnt(this Entity vehicle, Entity entity)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setlookatent, entity);
        }

        public static void SetMaxPitchRoll(this Entity vehicle, float pitch, float roll)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setmaxpitchroll, pitch, roll);
        }

        public static void SetNearGoalNotifyDist(this Entity vehicle, float dist)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setneargoalnotifydist, dist);
        }

        public static void SetSpeed(this Entity vehicle, int speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeed, speed);
        }

        public static void SetSpeed(this Entity vehicle, int speed, int acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeed, speed, acceleration);
        }

        public static void SetSpeed(this Entity vehicle, int speed, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeed, speed, acceleration, deceleration);
        }

        public static void SetSpeedImmediate(this Entity vehicle, int speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeedimmediate, speed);
        }

        public static void SetSpeedImmediate(this Entity vehicle, int speed, int acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeedimmediate, speed, acceleration);
        }

        public static void SetSpeedImmediate(this Entity vehicle, int speed, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setspeedimmediate, speed, acceleration, deceleration);
        }

        public static void SetSwitchNode(this Entity vehicle, Entity sourceNode, Entity destNode)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setswitchnode, sourceNode, destNode);
        }

        public static void SetTargetYaw(this Entity vehicle, float yaw)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.settargetyaw, yaw);
        }

        public static void SetTurningAbility(this Entity vehicle, float ability)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setturningability, ability);
        }

        public static void SetTurretTargetEnt(this Entity vehicle, Entity target, Vector3? offset = null)
        {
            Function.SetEntRef(vehicle.EntRef);
            if (offset.HasValue)
                Function.Call(ScriptNames.FunctionList.setturrettargetent, target, offset.HasValue ? (Parameter)offset.GetValueOrDefault() : null);
            else
                Function.Call(ScriptNames.FunctionList.setturrettargetent, target);
        }

        public static void SetTurretTargetVec(this Entity vehicle, Vector3 target)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setturrettargetvec, target);
        }

        public static void SetVehGoalPos(this Entity vehicle, Vector3 goal, bool stopAtGoal)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setvehgoalpos, goal, stopAtGoal);
        }

        public static void SetVehicleLookAtText(this Entity vehicle, string text1, string text2 = "")
        {
            Function.SetEntRef(vehicle.EntRef);
            if (text2 != "")
                Function.Call(ScriptNames.FunctionList.setvehiclelookattext, text1, text2);
            else
                Function.Call(ScriptNames.FunctionList.setvehiclelookattext, text1);
        }

        public static void SetVehicleTeam(this Entity vehicle, string team)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setvehicleteam, team);
        }

        public static void SetVehWeapon(this Entity vehicle, string weapon)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setvehweapon, weapon);
        }

        public static void SetWaitSpeed(this Entity vehicle, int speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setwaitspeed, speed);
        }

        public static void SetYawSpeed(this Entity vehicle, int speed, int acceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeed, speed, acceleration);
        }

        public static void SetYawSpeed(this Entity vehicle, int speed, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeed, speed, acceleration, deceleration);
        }

        public static void SetYawSpeed(this Entity vehicle, int speed, int acceleration, int deceleration, float overshootPercent)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeed, speed, acceleration, deceleration, overshootPercent);
        }

        public static void SetYawSpeedByName(this Entity vehicle, string name)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.setyawspeedbyname, name);
        }

        public static void StartPath(this Entity vehicle, int nodeIndex)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.startpath, nodeIndex);
        }

        public static void HeliSetAI(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.helisetai);
        }

        public static bool CanTurretGetTargetPoint(this Entity vehicle, Vector3 target)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.canturretgettargetpoint, target);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void VehicleTurretControlOn(this Entity vehicle, Entity player)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicleturretcontrolon, player);
        }

        public static void VehicleTurretControlOff(this Entity vehicle, Entity player)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicleturretcontroloff, player);
        }

        public static void Vehicle_Teleport(this Entity vehicle, Vector3 pos)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_teleport, pos);
        }

        public static Vector3 GetAttachPos(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getattachpos);
            return (Vector3)Function.GetReturns();
        }

        public static void Vehicle_FinishDamage(this Entity vehicle, Entity inflictor, Entity attacker, int damage, int damageFlags, string meansOfDeath, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_finishdamage, inflictor, attacker, damage, damageFlags, meansOfDeath, weapon, point, dir, hitLoc, timeOffset, modelIndex, partName);
        }

        public static void RotateYaw(this Entity vehicle, int yaw, int time, int acceleration, int deceleration)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.rotateyaw, yaw, time, acceleration, deceleration);
        }

        public static Vector3 Vehicle_GetVelocity(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicle_getvelocity);
            return (Vector3)Function.GetReturns();
        }

        public static Vector3 GetBodyVelocity(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getbodyvelocity);
            return (Vector3)Function.GetReturns();
        }

        public static float GetSteering(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getsteering);
            return (float)Function.GetReturns();
        }

        public static float GetThrottle(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.getthrottle);
            return (float)Function.GetReturns();
        }

        public static void TurnEngineOff(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.turnengineoff);
        }

        public static void TurnEngineOn(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.turnengineon);
        }

        public static void DriveTo(this Entity vehicle, Vector3 position, float speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.vehicledriveto, position, speed);
        }

        public static void DoSpawn(this Entity vehicle, string targetName)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.dospawn, targetName);
        }

        public static bool IsPhysVeh(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.isphysveh);
            return (uint)Convert.ToInt32(Function.GetReturns()) > 0U;
        }

        public static void Phys_Crash(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_crash);
        }

        public static void Phys_Launch(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_launch);
        }

        public static void Phys_DisableCrashing(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_disablecrashing);
        }

        public static void Phys_EnableCrashing(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_enablecrashing);
        }

        public static void Phys_SetSpeed(this Entity vehicle, float speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_setspeed, speed);
        }

        public static void Phys_SetConveyerBelt(this Entity vehicle, float speed)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.phys_setconveyerbelt, speed);
        }

        public static void FreeHelicopter(this Entity vehicle)
        {
            Function.SetEntRef(vehicle.EntRef);
            Function.Call(ScriptNames.FunctionList.freehelicopter);
        }
    }
}
