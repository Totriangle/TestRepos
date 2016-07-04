using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp.plugins
{
    public class PluginManager
    {
        public static List<IEvent> eventPlugins = new List<IEvent>();
        public static List<ISubscribe> subPlugins = new List<ISubscribe>();

        public static void LoadPlugins()
        {
            if (!Directory.Exists("plugins"))
                Directory.CreateDirectory("plugins");
            string path = string.Format(@"{0}\plugins", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName));
            path = string.Format(@"{0}\plugins", Application.StartupPath);
            string[] dlls = System.IO.Directory.GetFiles(path,"*.dll");
            foreach(string item in dlls)
            {
                Assembly asm;
                try
                {
                    asm = Assembly.LoadFile(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Load Error:{0}",ex.Message);

                    continue;
                }
                Type[] myType = asm.GetTypes();
                for(int i = 0;i<myType.Length;i++)
                {
                    if(typeof(IEvent).IsAssignableFrom(myType[i]))
                    {
                        if (myType[i].IsAbstract)
                            break;
                        IEvent iEvent = (IEvent)Activator.CreateInstance(myType[i]);
                        iEvent.LoadConfig();
                        
                        eventPlugins.Add(iEvent);
                    }
                    else if(typeof(ISubscribe).IsAssignableFrom(myType[i]))
                    {
                        if (myType[i].IsAbstract)
                            break;
                        ISubscribe iSub = (ISubscribe)Activator.CreateInstance(myType[i]);
                        iSub.LoadConfig();
                        subPlugins.Add(iSub);
                    }
                }
            }
        }
    }
}
