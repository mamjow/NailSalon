using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Nailmanager
{
    public partial class loginform : Form
    {
        private OleDbConnection con;
        public loginform()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/db.accdb;Persist Security Info=True;Jet OLEDB:Database Password=mjm2k4");

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
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM admin WHERE username =@UserName AND  pass =@Password", con);
                cmd.Parameters.AddWithValue("@UserName", userbox.Text);
                cmd.Parameters.AddWithValue("@Password", passbox.Text);
          
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    i = (int)cmd.ExecuteScalar();
                    
                }//end if

                con.Close();

                if (i > 0)
                {
                    //MessageBox.Show("done");
                    this.Hide();
                    Mainpage x = new Mainpage();
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
            Application.Exit();
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
