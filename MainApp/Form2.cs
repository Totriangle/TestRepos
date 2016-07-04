using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace MainApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBox1.Text);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            response.Close();
            //string msg = HttpUtility.HtmlEncode(html);
            //html = html.Replace("&", "#amp;");
            
            
            
            //doc.Load(textBox1.Text);
            textBox2.Text = html;
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(textBox2.Text);
            HtmlNode root = htmlDoc.DocumentNode;
            //HtmlNode text = root.ChildNodes[0];
            listBox2.Items.Clear();
            foreach(var v in root.ChildNodes)
            {
                listBox2.Items.Add(v.Name);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(textBox2.Text);
            HtmlNode root = htmlDoc.DocumentNode;
            try
            {
                HtmlNodeCollection hNodes = root.SelectNodes(textBox3.Text);
                
                if (hNodes != null)
                    foreach (var v in hNodes)
                    {
                        string str = "";
                        str += v.Name + "  ";
                        for (int i = 0; i < v.Attributes.Count; i++)
                        {
                            str += string.Format("{0}={1},", v.Attributes[i].Name, v.Attributes[i].Value);
                        }
                        
                        if (!string.IsNullOrEmpty(v.InnerText))
                            str += v.InnerText;
                        listBox1.Items.Add(str);
                    }
            }
            catch (Exception)
            {

               throw;
            }
        }
    }
}
