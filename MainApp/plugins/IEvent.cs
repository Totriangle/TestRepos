using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.plugins
{
    public interface IEvent
    {
        void LoadConfig();
        string PluginName { get; set; }
        event EventHandler TestEvent;
        void OnTestEvent(object sender);
    }
}
