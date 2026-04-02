using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsDesktop;


namespace CatchDesktopSwitch
{
    public partial class CatchSwitch : ServiceBase
    {
        public CatchSwitch()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            VirtualDesktop.CurrentChanged += (_, args) =>
            {
                // when this monitor is running, the desktop just needs to switch desktops by calling this app
                // there needs to be "reicon" mapping between desktop name and icon layout ID
                // here, we can find the appropriate mapping and call reicon when a switch is changed.
                // the neat thing is that it no longer matters if the desktop changes from a shortcut or not, the icons update
                Console.WriteLine($"Switched: {args.NewDesktop.Name}");
            };

        }

        protected override void OnStop()
        {
        }
    }
}
