using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.plugins
{
    public interface ISubscribe
    {
        void Test();
        void LoadConfig();
        string PluginName { get; set; }
    }
}
