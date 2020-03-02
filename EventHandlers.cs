using EXILED;
using UnityEngine;
using MEC;
using System.Collections.Generic;
using System;
using GameCore;

namespace NineThreeNineInfection
{
    public class EventHandlers
    {
        private Main _main;

        public EventHandlers(Main main)
        {
            _main = main;
        }
        public void Event_PlayerDeathEvent(ref PlayerDeathEvent ev)
        {

 
            if (ev.Killer.characterClassManager.Scp939.iAm939)
            {
                Vector3 deathPos = ev.Killer.plyMovementSync.RealModelPosition;
                ev.Player.characterClassManager.SetClassID(RoleType.Scp93989);
                ev.Player.playerStats.SetHPAmount(Config.InfectedHP);
                Timing.RunCoroutine(DoTeleport(ev.Player, deathPos));
                ev.Player.BroadcastMessage("<color=red>!!!</color><color=yellow>SOMEONE HAS BEEN INFECTED!</color><color=red>!!!</color>");

            }
        }

  

        public void Event_PlayerSpawnEvent(PlayerSpawnEvent ev)
        {
            if (!_main.IsEnabled) return;
            if (ev.Role.IsAnySCP() && ev.Role != RoleType.Scp93989)
            {
                Timing.RunCoroutine(DoChangeScp(ev.Player));
            }
                
        }

        private IEnumerator<float> DoChangeScp(ReferenceHub rh)
        {
            yield return Timing.WaitForSeconds(1f);

            CharacterClassManager cm = PlayerManager.localPlayer.GetComponent<CharacterClassManager>();
            rh.characterClassManager.SetClassID(RoleType.Scp93989);
            rh.playerStats.SetHPAmount(cm.Classes.SafeGet(rh.characterClassManager.CurClass).maxHP);
            rh.plyMovementSync.TargetForcePosition(rh.scp079PlayerScript.connectionToClient, CharacterClassManager.SpawnpointManager.GetRandomPosition(RoleType.Scp93989).transform.position);

            yield break;
        }
        private IEnumerator<float> DoTeleport(ReferenceHub rh, Vector3 pos)
        {
            yield return Timing.WaitForSeconds(1f);
            rh.plyMovementSync.TargetForcePosition(rh.scp079PlayerScript.connectionToClient, pos);
            yield break;
        }
    }
}
