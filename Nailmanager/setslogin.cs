using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace Nailmanager
{
    public partial class setslogin : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public setslogin()
        {
            InitializeComponent();


        }

        private void Login_Click(object sender, EventArgs e)
        {

            int i = 0;
            try
            {

                if ((userbox.Text == string.Empty) || (passbox.Text == string.Empty))
                {
                    MessageBox.Show("لطفا نام کاربری و رمز عبور را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM admin WHERE username =@UserName AND  pass =@Password AND admins=@ad", con);
                cmd.Parameters.AddWithValue("@UserName", userbox.Text);
                cmd.Parameters.AddWithValue("@Password", passbox.Text);
                cmd.Parameters.AddWithValue("@ad", "-1");

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    i = (int)cmd.ExecuteScalar();

                }//end if

                con.Close();

                if (i > 0)
                {
                    this.Hide();
                    SettingForm x = new SettingForm();
                    x.ShowDialog();
                }
                else
                    MessageBox.Show("نام کاربری و یا رمز عبور اشتباه می باشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                i = 0;
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void passbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Login_Click(sender, e);
            }
        }


    }
}
