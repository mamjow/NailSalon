using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Nailmanager
{
    public partial class SettingForm : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));

        public SettingForm()
        {
            InitializeComponent();


        }

        private void tanzim_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.amar' table. You can move, or remove it, as needed.
            this.amarTableAdapter.Fill(this.dbDataSet.amar);
            // TODO: This line of code loads data into the 'dbDataSet.admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter.Fill(this.dbDataSet.admin);
            // TODO: This line of code loads data into the 'dbDataSet.personel' table. You can move, or remove it, as needed.
            this.personelTableAdapter.Fill(this.dbDataSet.personel);
            // TODO: This line of code loads data into the 'dbDataSet.jobs' table. You can move, or remove it, as needed.
            this.jobsTableAdapter.Fill(this.dbDataSet.jobs);
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView2.RowHeadersVisible = false;
            dataGridView4.Columns[0].Visible = false;
        }
        public void refdate()
        {
            System.Globalization.PersianCalendar pc = new
            System.Globalization.PersianCalendar();
            int mah = pc.GetMonth(DateTime.Now);
            int ruz = pc.GetDayOfMonth(DateTime.Now);
            string maha = pc.GetMonth(DateTime.Now).ToString();
            string ruza = pc.GetDayOfMonth(DateTime.Now).ToString();
            if (mah < 10)
                maha = "0" + mah.ToString();
            if (ruz < 10)
                ruza = "0" + ruz.ToString();
            datetxt.Text = pc.GetYear(DateTime.Now) + "/" + maha + "/" + ruza;
        }
        private void khadadd_Click(object sender, EventArgs e)
        {
            if (khadtext.Text != "" && pricetext.Text != "")
            {
                string vah = "0";
                if (vahedbox.Checked == true)
                    vah = "-1";
                else if (vahedbox.Checked == false)
                    vah = "0";

                con.Open();
                string query = "INSERT INTO jobs (job, price, vahed) VALUES ('" + khadtext.Text + "', '" + pricetext.Text + "', '" + vah.ToString() + "')";

                OleDbCommand myCommand = new OleDbCommand();
                myCommand.CommandText = query;
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();
                //dbref();
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From jobs", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                vahedbox.Checked = false;
                khadtext.Text = "";
                pricetext.Text = "";
            }

        }

        private void padd_Click(object sender, EventArgs e)
        {
            if (ptext.Text != "")
            {
                con.Open();
                string query = "INSERT INTO personel (personel) VALUES ('" + ptext.Text + "')";

                OleDbCommand myCommand = new OleDbCommand();
                myCommand.CommandText = query;
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();
                //dbref();
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From personel", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0].DefaultView;
            }

        }

        private void adminadd_Click(object sender, EventArgs e)
        {
            if (usertext.Text != "" && passtext.Text != "")
            {
                string ad = "0";
                if (adminbox.Checked == true)
                    ad = "-1";
                else if (adminbox.Checked == false)
                    ad = "0";

                con.Open();
                string query = "INSERT INTO admin (username, pass, admins) VALUES ('" + usertext.Text + "', '" + passtext.Text + "', '" + ad + "')";

                OleDbCommand myCommand = new OleDbCommand();
                myCommand.CommandText = query;
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();
                //dbref();
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From admin", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0].DefaultView;
                adminbox.Checked = false;
                usertext.Text = "";
                passtext.Text = "";
            }

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("" + label9.Text + " حذف گردد ؟ ", "اخطار", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM jobs WHERE ID =@id", con);
                cmd.Parameters.AddWithValue("@id", label8.Text);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت حذف شد!");
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From jobs", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            button1.Enabled = false;
            label9.Text = "";
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label11.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            label13.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            button2.Enabled = true;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label14.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            label16.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("" + label16.Text + " حذف گردد ؟ ", "اخطار", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM personel WHERE ID =@id", con);
                cmd.Parameters.AddWithValue("@id", label14.Text);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت حذف شد!");
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From personel", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0].DefaultView;
            }
            button3.Enabled = false;
            label16.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("" + label13.Text + " حذف گردد ؟ ", "اخطار", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM admin WHERE ID =@id", con);
                cmd.Parameters.AddWithValue("@id", label11.Text);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت حذف شد!");
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From admin", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0].DefaultView;
            }
            button2.Enabled = false;
            label13.Text = "";
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                rejcode.Enabled = true;
            else if (checkBox1.Checked == false)
            {
                rejcode.Enabled = false;
                rejcode.Text = "";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                datetxt.Enabled = true;
                tadatetxt.Enabled = true;
                checkBox4.Enabled = true;
                
            }
            else if (checkBox2.Checked == false)
            {
                datetxt.Enabled = false;
                datetxt.Text = "";
                tadatetxt.Text = "";
                tadatetxt.Enabled = false;
                checkBox4.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                personeltxt.Enabled = true;
            else if (checkBox3.Checked == false)
            {
                personeltxt.Text = "";
                personeltxt.Enabled = false;
            }
        }

        private void filterk_Click(object sender, EventArgs e)
        {
            string filteru = "";
            if (checkBox1.Checked == true)
                filteru+="rejcode ='" + rejcode.Text +"' AND " ;
            if (checkBox2.Checked == true && checkBox4.Checked == true)
                filteru += "tarikh BETWEEN'" + datetxt.Text + "' AND '" + tadatetxt.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == false)
                filteru += "tarikh ='" + datetxt.Text + "' AND ";
            if (checkBox3.Checked == true)
                filteru+="personel ='" + personeltxt.Text + "' AND ";
            filteru =  filteru.Remove(filteru.Length - 4);

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM amar WHERE " + filteru ,con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0].DefaultView;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM amar ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0].DefaultView;
        }


        private void datetxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            datetxt.Text = monthCalendarX1.GetSelectedDateInPersianDateTime().ToShortDateString();
            char[] del = { '/' };
            string[] tarikh = datetxt.Text.Split(del);
            int mah = Convert.ToInt32(tarikh[1]);
            if (mah < 10)
                tarikh[1] = "0" + mah.ToString();

            int ruz = Convert.ToInt32(tarikh[2]);
            if (ruz < 10)
                tarikh[2] = "0" + ruz.ToString();
            datetxt.Text = tarikh[0] + "/" + tarikh[1] + "/" + tarikh[2];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int cash = 0;
            con.Open();
            string filteru = "";
            if (checkBox1.Checked == true)
                filteru += "rejcode ='" + rejcode.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == true)
                filteru += "tarikh BETWEEN'" + datetxt.Text + "' AND '" + tadatetxt.Text + "' AND ";
            if (checkBox2.Checked == true && checkBox4.Checked == false)
                filteru += "tarikh ='" + datetxt.Text + "' AND ";
            if (checkBox3.Checked == true)
                filteru += "personel ='" + personeltxt.Text + "' AND ";
            if (filteru != "")
            {
                filteru = filteru.Remove(filteru.Length - 4);

                OleDbCommand myCommand = new OleDbCommand("SELECT * FROM amar WHERE " + filteru, con);
                OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
                DataTable table = new DataTable();
                ad.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    cash = cash + Convert.ToInt32(row["cash"]);
                }
                
                label17.Text = cash.ToString();
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("تغییرات اعمال گردد ؟", "  اخطار", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                string query = "UPDATE amar SET rejcode=@rej, cash=@cash, tarikh=@date, khadamat=@khadamat,personel=@personel WHERE ID =@ID";
                cmd.Parameters.AddWithValue("@rej", rej.Text );
                cmd.Parameters.AddWithValue("@cash", cash.Text);
                cmd.Parameters.AddWithValue("@date", datebox.Text);
                cmd.Parameters.AddWithValue("@khadamat", khadamat.Text);
                cmd.Parameters.AddWithValue("@personel", personel.Text);
                cmd.Parameters.AddWithValue("@ID", label19.Text);
                cmd.CommandText = query;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                rej.Text = "";
                cash.Text = "";
                datebox.Text = "";
                khadamat.Text = "";
                personel.Text = "";
                button4_Click(sender,e);

            }
            groupBox5.Enabled = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label19.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            rej.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            cash.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            datebox.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            khadamat.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            personel.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            groupBox5.Enabled = true;

        }

        private void hazf_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("مورد انتخابی حذف گردد ؟", "اخطار", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                OleDbCommand myCommand = new OleDbCommand();
                string query = "DELETE FROM amar WHERE ID =@ID";
                myCommand.Parameters.AddWithValue("@ID", label19.Text);
                myCommand.CommandText = query;
                myCommand.Connection = con;
                con.Open();
                myCommand.ExecuteNonQuery();
                con.Close();
                rej.Text = "";
                cash.Text = "";
                datebox.Text = "";
                khadamat.Text = "";
                personel.Text = "";
                button4_Click(sender, e);

            }
            groupBox5.Enabled = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            rej.Text = "";
            cash.Text = "";
            datebox.Text = "";
            khadamat.Text = "";
            personel.Text = "";
            groupBox5.Enabled = false;
        }

        private void tadatetxt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tadatetxt.Text = monthCalendarX1.GetSelectedDateInPersianDateTime().ToShortDateString();
            char[] del = { '/' };
            string[] tarikh = tadatetxt.Text.Split(del);
            int mah = Convert.ToInt32(tarikh[1]);
            if (mah < 10)
                tarikh[1] = "0" + mah.ToString();

            int ruz = Convert.ToInt32(tarikh[2]);
            if (ruz < 10)
                tarikh[2] = "0" + ruz.ToString();
            tadatetxt.Text = tarikh[0] + "/" + tarikh[1] + "/" + tarikh[2];
        }


    }
}
