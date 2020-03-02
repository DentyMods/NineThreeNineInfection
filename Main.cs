using EXILED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineThreeNineInfection
{
    public class Main : Plugin
    {
        public override string getName => "NineThreeNine Infection";
        public bool IsEnabled;

        private EventHandlers _eventHandlers;
        private Commands _commands;
        public override void OnDisable()
        {
            Events.PlayerSpawnEvent -= _eventHandlers.Event_PlayerSpawnEvent;
            Events.PlayerDeathEvent -= _eventHandlers.Event_PlayerDeathEvent;

            _eventHandlers = null;

            _commands = new Commands(this);

            Events.RemoteAdminCommandEvent += _commands.Events_RemoteAdminCommandEvent;
        }

        public override void OnEnable()
        {
            NineThreeNineInfection.Config.ReloadConfig();

            IsEnabled = NineThreeNineInfection.Config.EnableByDefault;

            _eventHandlers = new EventHandlers(this);
            Events.PlayerSpawnEvent += _eventHandlers.Event_PlayerSpawnEvent;
            Events.PlayerDeathEvent += _eventHandlers.Event_PlayerDeathEvent;

            _commands = new Commands(this);

            Events.RemoteAdminCommandEvent += _commands.Events_RemoteAdminCommandEvent;
        }

        public override void OnReload()
        {
            Events.PlayerSpawnEvent -= _eventHandlers.Event_PlayerSpawnEvent;
            Events.PlayerDeathEvent -= _eventHandlers.Event_PlayerDeathEvent;

            _eventHandlers = null;
        }
    }
}
