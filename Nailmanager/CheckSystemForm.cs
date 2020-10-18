using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Data.OleDb;
using System.IO;

namespace Nailmanager
{
    public partial class Formload : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public Formload()
        {
            InitializeComponent();
            
            //timer1.Start();
            con = new OleDbConnection(ConnectionString);

            sabt();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X + 5, label1.Location.Y);
            int xprog = label1.Location.X;
            if (xprog % 3 == 0)
            {
                label1.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.DarkBlue;
            }
            if (progressBar1.Value < progressBar1.Maximum )
            {

            progressBar1.Value = progressBar1.Value + 5;
            perc.Text = progressBar1.Value.ToString() + " %";
            if (progressBar1.Maximum == 90 && progressBar1.Value == 90 )
                {
                        timer1.Stop();
                        progressBar1.Value = 90;
                }
        }

            if (label1.Location.X > this.Width)
            {
                label1.Location = new Point(0 - label1.Width, label1.Location.Y);
               
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value.Equals(100))
            {
                this.Hide();
                loginform x = new loginform();
                x.ShowDialog();
            }
            else
                MessageBox.Show("سیستم شما مجاز به استفاده از برنامه نمیباشد " + Environment.NewLine + " با پشتیبانی برنامه تماس بگیرید" + Environment.NewLine + " شماره تماس : 09354968918", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        public string GetCPUId()
    {
        string cpuInfo = String.Empty;
        //create an instance of the Managemnet class with the
        //Win32_Processor class
        ManagementClass mgmt = new ManagementClass("Win32_Processor");
        //create a ManagementObjectCollection to loop through
        ManagementObjectCollection objCol = mgmt.GetInstances();
        //start our loop for all processors found
        foreach (ManagementObject obj in objCol)
        {
            if (cpuInfo == String.Empty)
            {
                // only return cpuInfo from first CPU
                cpuInfo = obj.Properties["ProcessorId"].Value.ToString();
            }
       }
       return cpuInfo;
    }

        public void sabt()
        {
            int a = 0;
            OleDbCommand camd = new OleDbCommand("SELECT COUNT(*) FROM hard", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                a = (int)camd.ExecuteScalar();
                con.Close();
            }
            if (a > 0)
            {
                int i = 0;
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM hard WHERE hardware=@hard", con);
                cmd.Parameters.AddWithValue("@hard", GetCPUId().ToString());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    i = (int)cmd.ExecuteScalar();
                }
                con.Close();

                if (i > 0)
                {
                    progressBar1.Maximum = 100;
                    label2.Text = " Registered Hardware ID ";
                }
                else
                {
                    progressBar1.Maximum = 90;
                    label2.Text = " Unregistered Hardware ID ";
                }
            }
            else
            {
                
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string query = "INSERT INTO hard (hardware) VALUES ('" + GetCPUId().ToString() + "')";
                    OleDbCommand myCommand = new OleDbCommand();
                    myCommand.CommandText = query;
                    myCommand.Connection = con;
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Registered to Hardware ID : " + GetCPUId().ToString());
                    label2.Text = " Registered Hardware ID ";

                }
                con.Close();
            }
        }

 

    }
}
