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
    public partial class report : Form
    {
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public report()
        {
            InitializeComponent();
        }

        public DataTable reportr()
        {
            OleDbConnection con = new OleDbConnection(ConnectionString);
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
