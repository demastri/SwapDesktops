using System;
using WindowsDesktop;
using System.Threading;

namespace SwapDesktops
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // so this either runs to switch a desktop, or to catch exernally initiated desktops
            // if it switches a desktop it can just exit
            // otherwise it should just hang around and wait
            // (should really be a service, and the switch should be a standalone app)

            var desktops = VirtualDesktop.GetDesktops();
            if( args.Length > 0 ) { 
                string name = args[0];
                foreach( var desktop in desktops )
                {
                    if( desktop.Name == name )
                    {
                        desktop.Switch();
                        break;
                    }
                }
            } else
            {
                Console.WriteLine("Did not specify a target...");
            }


            Console.WriteLine("Starting Desktop Monitor...");
            VirtualDesktop.CurrentChanged += (_, args) =>
            {
                // when this monitor is running, the desktop just needs to switch desktops by calling this app
                // there needs to be "reicon" mapping between desktop name and icon layout ID
                // here, we can find the appropriate mapping and call reicon when a switch is changed.
                // the neat thing is that it no longer matters if the desktop changes from a shortcut or not, the icons update
                Console.WriteLine($"Switched: {args.NewDesktop.Name}");
            };
    
            while(true)
            {
                Thread.Sleep(200);
            }
        }

    }
}
