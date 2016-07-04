using MainApp;
using MainApp.plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberPlugin
{
    public class SubPlugin : ISubscribe
    {
        string name = "SubPlugin";
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

        public void LoadConfig()
        {
           if(PluginManager.eventPlugins != null && PluginManager.eventPlugins.Count>0)
            {
                for(int i = 0;i<PluginManager.eventPlugins.Count;i++)
                {
                    PluginManager.eventPlugins[i].TestEvent += SubPlugin_TestEvent;
                }
            }
        }

        private void SubPlugin_TestEvent(object sender, EventArgs e)
        {
            if(sender!=null)
                Console.WriteLine(sender.ToString());
        }

        public void Test()
        {
            Console.WriteLine("test func");
        }
    }
}
