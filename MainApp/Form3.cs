using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=(local);database=TestDB;integrated security=SSPI");
                con.Open();
                string str = "";
                using (SqlCommand com = new SqlCommand(str, con))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        str = string.Format("insert into [dbo].[User](ID,Name,Sex,Address) values({0},'Name{1}','{2}','Address{3}')", i + 1, i + 1, i % 2 == 0 ? "male" : "female", i + 100);
                        com.CommandText = str;
                        com.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("insert sucessful");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=(local);database=TestDB;integrated security=SSPI");
            con.Open();
            using (SqlCommand com = new SqlCommand("GetName", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.Add("@id", SqlDbType.Int).Value = 4;
                SqlDataReader reader = com.ExecuteReader();
                
                while(reader.Read())
                {
                    textBox1.Text += reader.GetString(0);
                }
                //textBox1.Text = o.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringReader reader = new StringReader(textBox1.Text);
            /*Action action = new Action(delegate ()
            {
                int i = -1;
                do
                {
                    i = reader.Read();
                    if (i != -1)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            textBox2.AppendText(((char)i).ToString());
                        }));
                        Thread.Sleep(10);
                    }
                } while (i != -1);
                reader.Close();
                
            });
            action.BeginInvoke(null, null);*/
            Action action = () =>
            {
                int i = -1;
                do
                {
                    i = reader.Read();
                    if (i != -1)
                    {
                        this.Invoke(new Action(delegate ()
                        {
                            textBox2.AppendText(((char)i).ToString());
                        }));
                        //Thread.Sleep(10);
                    }
                } while (i != -1);
                reader.Close();

                this.Invoke(new Action(delegate ()
                {
                    textBox2.AppendText("\r\n");
                }));

                Action a = delegate ()
                {

                    this.Invoke(new Action(delegate ()
                    {
                        textBox2.AppendText("\r\n");
                    }));

                    for (int j = 0; j < textBox1.Text.Length; j++)
                    {

                        this.Invoke(new Action(delegate ()
                        {
                            textBox2.AppendText(textBox1.Text[textBox1.Text.Length - 1 - j].ToString());
                        }));
                        //Thread.Sleep(5);
                    }
                    this.Invoke(new Action(delegate ()
                    {
                        textBox2.AppendText("\r\n");
                    }));
                };
                a.BeginInvoke(null, null);
            };
            action.BeginInvoke(null, null);
            
            
        }
        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            /*Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);*/
            Bitmap myNewCursor = new Bitmap(20,20);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, 0,0, 20,
            20);
            this.Cursor = new Cursor(myNewCursor.GetHicon());

            g.Dispose();
            myNewCursor.Dispose();
        }
        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile("1.jpg");
            SetCursor(bmp1, new Point(0, 0));
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile("3.jpg");
            SetCursor(bmp1, new Point(0, 0));
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile("2.jpg");
            SetCursor(bmp1, new Point(0, 0));
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile("3.jpg");
            SetCursor(bmp1, new Point(0, 0));
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile("2.jpg");
            SetCursor(bmp1, new Point(0, 0));
        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp1 = (Bitmap)Bitmap.FromFile("1.jpg");
            SetCursor(bmp1, new Point(0, 0));
        }
    }
}
