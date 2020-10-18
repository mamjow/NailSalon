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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        public DataTable reportr()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/db.accdb;Persist Security Info=True;Jet OLEDB:Database Password=mjm2k4");
            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM report", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            con.Close();
            return table;
        }



        private void report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.dbDataSet.report);

            this.reportViewer1.RefreshReport();
        }

    }
}
