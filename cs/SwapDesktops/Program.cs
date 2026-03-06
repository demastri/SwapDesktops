using System;
using WindowsDesktop;

namespace SwapDesktops
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
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

        }
    }
}
