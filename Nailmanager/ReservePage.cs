using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Nailmanager
{
    public partial class ReservePage : Form
    {
        private OleDbConnection con;


        public ReservePage()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/db.accdb;Persist Security Info=True;Jet OLEDB:Database Password=mjm2k4");

        }

        private void nobatdehi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.nobatdehi' table. You can move, or remove it, as needed.
            this.nobatdehiTableAdapter.Fill(this.dbDataSet.nobatdehi);
            // TODO: This line of code loads data into the 'dbDataSet.nobatdehi' table. You can move, or remove it, as needed.
            this.nobatdehiTableAdapter.Fill(this.dbDataSet.nobatdehi);
            datelabel.Text = monthCalendarX1.GetSelectedDateInPersianDateTime().ToShortDateString();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From nobatdehi WHERE datenobat ='" + datelabel.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            button2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM rejlist WHERE rejcode =@code", con);
            cmd.Parameters.AddWithValue("@code", rejc.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                m = (int)cmd.ExecuteScalar();
            }//end if
            con.Close();
            if (m > 0)
            {
                con.Open();
                string query = "INSERT INTO nobatdehi (nobat, rejcode, datenobat , tozihat) VALUES ('" + nobat.Text + "', '" + rejc.Text + "', '" + datelabel.Text + "' , '" + tozih.Text + "')";

                OleDbCommand myCommand = new OleDbCommand();
                myCommand.CommandText = query;
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();
                //dbref();
                con.Close();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From nobatdehi WHERE datenobat ='" + datelabel.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                nobat.Text = "";
                rejc.Text = "";
                tozih.Text = "";
            }
            else
                MessageBox.Show("کد اشتراک موجود نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void monthCalendarX1_SelectedDateChanged(DateTime selectedDateTime, BehComponents.PersianDateTime selectedPersianDateTime)
        {
            datelabel.Text = monthCalendarX1.GetSelectedDateInPersianDateTime().ToShortDateString();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From nobatdehi WHERE datenobat ='" + datelabel.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            button2.Enabled = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            nobat.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            rejc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            datelabel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tozih.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM nobatdehi WHERE ID =@id", con);
            cmd.Parameters.AddWithValue("@id", label4.Text);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("اطلاعات با موفقیت حذف شد!");
            con.Close();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From nobatdehi WHERE datenobat ='" + datelabel.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }




    }
}
