using EXILED;
using EXILED.Extensions;
namespace NineThreeNineInfection
{
    public class Commands
    {
        private Main _main;

        public Commands(Main main)
        {
            _main = main;
        }

        public void Events_RemoteAdminCommandEvent(ref RACommandEvent ev)
        {
            if (ev.Command.StartsWith("NineThreeNineInfection"))
            {
                string[] args = ev.Command.Split(' ');

                if(args.Length <= 1)
                {
                    ev.Allow = false;
                    ev.Sender.RAMessage($"Gamemode is : {(_main.IsEnabled ? "<color=green>enabled</color>" : "<color=red>disabled</color>")}");
                    ev.Sender.RAMessage("NineThreeNineInfection <on | enable | off | disable>.");
                    return;
                }

                switch (args[1].ToLower())
                {
                    case "enable":
                        ev.Allow = false;
                        _main.IsEnabled = true;
                        ev.Sender.RAMessage("The gamemode has been <color=green>enabled</color>.");
                        break;
                    case "on":
                        ev.Allow = false;
                        _main.IsEnabled = true;
                        ev.Sender.RAMessage("The gamemode has been <color=green>enabled</color>.");
                        break;

                    case "disable":
                        ev.Allow = false;
                        _main.IsEnabled = false;
                        ev.Sender.RAMessage("The gamemode has been <color=red>disabled</color>.");
                        break;

                    case "off":
                        ev.Allow = false;
                        _main.IsEnabled = false;
                        ev.Sender.RAMessage("The gamemode has been <color=red>disabled</color>.");
                        break;
                }
            }
        }
    }
}
