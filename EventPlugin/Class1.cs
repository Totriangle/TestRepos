using MainApp.plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlugin
{
    public class EventPlugin : IEvent
    {
        string name = "EventPlugin";
        public string PluginName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public event EventHandler TestEvent;

        public void LoadConfig()
        {
            
        }

        public void OnTestEvent(object sender)
        {
            if (TestEvent != null)
                TestEvent(sender, null);
        }
    }
}
