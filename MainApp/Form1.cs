using MainApp.plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PluginManager.LoadPlugins();
            InitControlData();
        }
        void InitControlData()
        {
            lstBoxEvent.DisplayMember = "PluginName";
            lstBoxSub.DisplayMember = "PluginName";

            foreach (IEvent plugin in PluginManager.eventPlugins)
            {
                lstBoxEvent.Items.Add(plugin);
            }
            foreach (ISubscribe plugin in PluginManager.subPlugins)
            {
                lstBoxSub.Items.Add(plugin);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(lstBoxEvent.SelectedIndex != -1)
            {
                IEvent plugin = lstBoxEvent.SelectedItem as IEvent;
                if(plugin != null)
                {
                    string msg = string.Format("[{0}]{1}:{2}", plugin.PluginName, sender, txtInput.Text);
                    txtMessage.AppendText(msg + "\r\n");
                    plugin.OnTestEvent(msg);
                    //txtInput.Text = "";

                }
            }
        }
    }
    public interface IDataConfig
    {
        void Func1();
    }
    interface IDataConfigRevision
    {

    }
}
