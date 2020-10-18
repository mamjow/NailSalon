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
    public partial class Mainpage : Form
    {
        private OleDbConnection con;
        private readonly string ConnectionString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_config.txt"));
        public Mainpage()
        {
            InitializeComponent();
            con = new OleDbConnection(ConnectionString);
        }
        public static void tkp(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.KeyPress += new KeyPressEventHandler(tkp);

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        private void Mainpage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.report' table. You can move, or remove it, as needed.
            this.reportTableAdapter.Fill(this.dbDataSet.report);
            // TODO: This line of code loads data into the 'dbDataSet.rejlist' table. You can move, or remove it, as needed.
            this.rejlistTableAdapter.Fill(this.dbDataSet.rejlist);
            refdate();
            dataview.Columns[4].HeaderText = "ش همراه";
            dataview.Columns[3].Visible = false;
            dataview.Columns[5].Visible = false;
            dataview.Columns[0].Visible = false;
            dataview.Columns[1].HeaderText = "نام";
            dataview.Columns[2].HeaderText = "ن خانوادگی";
            dataview.Columns[6].HeaderText = "کد";
            //dataview.Columns[0].Width = 20;
            dataview.Columns[1].Width = 50;
            dataview.Columns[6].Width = 35;
            dataview.Columns[4].Width = 80;
            dataview.Columns[2].Width = 85;
            dataview.RowHeadersVisible = false;
            del.Visible = false;
            update.Visible = false;
            rejyab();
            loadkhadamat();
            loadpersonel();
            cashbox.Text = "0";
            radioButton1.Checked = true;
        }


        public void loadpersonel()
        {
            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM personel", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            foreach (DataRow row in table.Rows)
            {

                listBox1.Items.Add(row["personel"].ToString());
            }
            con.Close();
        }
        public void loadkhadamat()
        {
            con.Open();
            OleDbCommand myCommand = new OleDbCommand("SELECT * FROM jobs", con);
            OleDbDataAdapter ad = new OleDbDataAdapter(myCommand);
            DataTable table = new DataTable();
            ad.Fill(table);
            foreach (DataRow row in table.Rows)
            {

                checkedListBox1.Items.Add(row["job"].ToString());
            }
            con.Close();

        }
        public void rejyab()
        {
            int i = 0;
            int a = 0;
            OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM rejlist", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();

            }//end if

            con.Close();

            if (i > 0)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT TOP 1 * FROM rejlist ORDER BY ID DESC", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataview.DataSource = ds.Tables[0].DefaultView;
                a = Convert.ToInt32(dataview.CurrentRow.Cells[0].Value.ToString());
            }
            int sabtcd = a + 1001;
            codebox.Text = sabtcd.ToString();
            codebox.Enabled = false;
            dbref();

        }
        public void dbref()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From rejlist", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataview.DataSource = ds.Tables[0].DefaultView;
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
            datebox.Text = pc.GetYear(DateTime.Now) + "/" + maha + "/" + ruza;
            label11.Text = pc.GetYear(DateTime.Now) + "/" + maha + "/" + ruza;
        }

        private void sabt_Click(object sender, EventArgs e)
        {
            if (namebox.Enabled == true && edit.Visible == true)
            {
                if (namebox.Text != "" && familbox.Text != "" && codebox.Text != "")
                {
                    con.Open();
                    string query = "INSERT INTO rejlist (nam, famil, shomare, shomare2,dates, rejcode) VALUES ('" + namebox.Text + "', '" + familbox.Text + "', '" + telbox.Text + "','" + mobilebox.Text + "', '" + datebox.Text + "', '" + codebox.Text + "')";

                    OleDbCommand myCommand = new OleDbCommand();
                    myCommand.CommandText = query;
                    myCommand.Connection = con;
                    myCommand.ExecuteNonQuery();
                    dbref();
                    con.Close();
                    MessageBox.Show("اطلاعات با موفقیت ثبت گردید!");
                    namebox.Text = "";
                    familbox.Text = "";
                    telbox.Text = "";
                    mobilebox.Text = "";
                    datebox.Text = "";
                    rejyab();
                    refdate();
                }
                else
                    MessageBox.Show("موارد لازم را پر کنید !");
            }

            else if (namebox.Enabled == false)
            {
                cncl_Click(sender, e);
            }
        }
        public void disarmtxt()
        {

            namebox.Enabled = false;
            familbox.Enabled = false;
            telbox.Enabled = false;
            mobilebox.Enabled = false;
            datebox.Enabled = false;
            codebox.Enabled = false;
        }
        public void armtxt()
        {
            namebox.Enabled = true;
            familbox.Enabled = true;
            telbox.Enabled = true;
            mobilebox.Enabled = true;
            datebox.Enabled = true;
        }

        private void telbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }


        private void mobilebox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            namebox.Text = dataview.CurrentRow.Cells[1].Value.ToString();
            familbox.Text = dataview.CurrentRow.Cells[2].Value.ToString();
            telbox.Text = dataview.CurrentRow.Cells[3].Value.ToString();
            mobilebox.Text = dataview.CurrentRow.Cells[4].Value.ToString();
            datebox.Text = dataview.CurrentRow.Cells[5].Value.ToString();
            codebox.Text = dataview.CurrentRow.Cells[6].Value.ToString();
            disarmtxt();
        }

        private void cncl_Click(object sender, EventArgs e)
        {
            armtxt();
            namebox.Text = "";
            familbox.Text = "";
            telbox.Text = "";
            mobilebox.Text = "";
            rejyab();
            refdate();
            update.Visible = false;
            del.Visible = false;

        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (familbox.Text != "" || namebox.Text != "")
            {
                update.Visible = true;
                del.Visible = true;
                armtxt();
            }
            else
                MessageBox.Show("موردی برای ویرایش انتخاب نشده!");

        }

        private void del_Click(object sender, EventArgs e)
        {
            if (codebox.Text != "" && namebox.Text != "")
            {
                con.Open();
                string query = "DELETE FROM rejlist WHERE rejcode ='" + codebox.Text + "'";

                OleDbCommand myCommand = new OleDbCommand();
                myCommand.CommandText = query;
                myCommand.Connection = con;
                myCommand.ExecuteNonQuery();

                MessageBox.Show("اطلاعات با موفقیت حذف شد!");
                cncl_Click(sender, e);
                del.Visible = false;
                update.Visible = false;
                con.Close();

                dbref();
            }
            else
                MessageBox.Show("موردی برای حذف انتخاب نشده!");
        }

        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE rejlist SET nam='" + namebox.Text + "', famil='" + familbox.Text + "', shomare= '" + telbox.Text + "', shomare2='" + mobilebox.Text + "',dates= '" + datebox.Text + "' WHERE rejcode ='" + codebox.Text + "'";
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.CommandText = query;
            myCommand.Connection = con;
            myCommand.ExecuteNonQuery();
            dbref();
            MessageBox.Show("اطلاعات با موفقیت به روز شد!");
            cncl_Click(sender, e);
            del.Visible = false;
            update.Visible = false;
            con.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int a = 0;
            int ghimatk = 0;
            int ghimat = 0;
            string vahed = "";
            int selected = checkedListBox1.SelectedIndex;
            if (checkedListBox1.GetItemCheckState(selected).ToString() == "Checked")
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM jobs WHERE job=@job", con);
                cmd.Parameters.AddWithValue("@job", checkedListBox1.Items[selected].ToString());
                OleDbDataReader price = cmd.ExecuteReader();
                price.Read();
                ghimat = Convert.ToInt32(price[2].ToString());
                if (price[3].ToString() == "True")
                {
                    string value = "1";
                    if (InputBox("ورودی", "تعداد واحد وارد کنید", ref value) == DialogResult.OK)
                    {
                        vahed = value;
                        a = Convert.ToInt32(vahed);
                        ghimat = ghimat * a;
                        string query = "UPDATE jobs SET temp='" + a.ToString() + "' WHERE job ='" + checkedListBox1.Items[selected].ToString() + "'";
                        OleDbCommand myCommand = new OleDbCommand();
                        myCommand.CommandText = query;
                        myCommand.Connection = con;
                        myCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        checkedListBox1.SetItemCheckState(selected, CheckState.Unchecked);
                        goto payan;
                    }
                }
                ghimatk = ghimat + Convert.ToInt32(cashbox.Text);

                cashbox.Text = ghimatk.ToString();
            payan:
                con.Close();
            }
            else if (checkedListBox1.GetItemCheckState(selected).ToString() == "Unchecked")
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM jobs WHERE job=@job", con);
                cmd.Parameters.AddWithValue("@job", checkedListBox1.Items[selected].ToString());
                OleDbDataReader price = cmd.ExecuteReader();
                price.Read();
                ghimat = Convert.ToInt32(price[2].ToString());
                if (price[3].ToString() == "True")
                {
                chekup:
                    string value = "1";
                    if (InputBox("حذف", "تعداد واحد حذفی وارد کنید", ref value) == DialogResult.OK)
                    {
                        vahed = value;
                        a = Convert.ToInt32(vahed);
                        int a1 = Convert.ToInt32(price[4].ToString());

                        if (a1 < a)
                        {
                            MessageBox.Show(" تعداد واحد وارد شده ( " + a.ToString() + " )بوده و از تعداد ثبت شده بیشتر است لطفا مجددا تعداد را وارد کنید " + Environment.NewLine + " مقدا ثبت شده  :  " + a1.ToString());
                            goto chekup;
                        }
                        ghimat = ghimat * a;
                        if (a < a1)
                        {
                            checkedListBox1.SetItemCheckState(selected, CheckState.Checked);
                        }
                        a = a1 - a;
                        string query = "UPDATE jobs SET temp='" + a.ToString() + "'WHERE job ='" + checkedListBox1.Items[selected].ToString() + "'";
                        OleDbCommand myCommand = new OleDbCommand();
                        myCommand.CommandText = query;
                        myCommand.Connection = con;
                        myCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        checkedListBox1.SetItemCheckState(selected, CheckState.Checked);
                        goto payan;
                    }
                }
                ghimatk = Convert.ToInt32(cashbox.Text) - ghimat;
                cashbox.Text = ghimatk.ToString();
            payan:
                con.Close();
            }
        }

        private void tanzim_Click(object sender, EventArgs e)
        {
            //this.Hide();
            setslogin x = new setslogin();
            x.ShowDialog();
        }

        private void cash_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            string entekhab = "";
            string kar = "";
            string kard = "";
            con.Open();
            string query = "DELETE * FROM report";
            OleDbCommand mc = new OleDbCommand();
            mc.CommandText = query;
            mc.Connection = con;
            mc.ExecuteNonQuery();
            con.Close();


            if (listBox1.SelectedIndex != -1 && sabtrejcode.Text != "" && cashbox.Text != "0")
            {
                int m = 0;
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM rejlist WHERE rejcode =@code", con);
                cmd.Parameters.AddWithValue("@code", sabtrejcode.Text);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    m = (int)cmd.ExecuteScalar();
                }//end if
                con.Close();
                if (m > 0)
                {
                    con.Open();
                    OleDbCommand camd = new OleDbCommand("SELECT * FROM rejlist WHERE rejcode=@cod", con);
                    camd.Parameters.AddWithValue("@cod", sabtrejcode.Text);
                    OleDbDataReader moshtari = camd.ExecuteReader();
                    moshtari.Read();
                    string nam = moshtari[1].ToString() + " " + moshtari[2].ToString();
                    con.Close();

                    foreach (object itemChecked in checkedListBox1.CheckedItems)
                    {
                        entekhab = itemChecked.ToString();
                        
                        OleDbCommand comd = new OleDbCommand("SELECT * FROM jobs WHERE job=@job", con);
                        comd.Parameters.AddWithValue("@job", entekhab.ToString());
                        con.Open();
                        OleDbDataReader price = comd.ExecuteReader();
                        price.Read();
                        kar = entekhab.ToString();
                        string vahed = "1";
                        if (price[3].ToString() == "True")
                        {
                            kar = price[4].ToString() + " واحد " + entekhab.ToString();
                            vahed = price[4].ToString();
                        }
                        kard = kard.ToString() + " - " + kar.ToString();
                        int chash = Convert.ToInt32(price[2].ToString()) * Convert.ToInt32(vahed);
                        string ghimat = price[2].ToString();
                        con.Close();

                        OleDbCommand myCommanda = new OleDbCommand("INSERT INTO report (khedmat, ghimat, vahed , eshterak , personel , tarikh , moshtari) VALUES (@khedmat, @ghimat, @vahed , @eshterak ,@per ,@tarikh ,@moshtari)", con);
                        myCommanda.Parameters.AddWithValue("@khedmat", entekhab.ToString());
                        myCommanda.Parameters.AddWithValue("@ghimat", ghimat);
                        myCommanda.Parameters.AddWithValue("@vahed", vahed.ToString());
                        myCommanda.Parameters.AddWithValue("@eshterak", chash);
                        myCommanda.Parameters.AddWithValue("@per", listBox1.SelectedItem.ToString());
                        myCommanda.Parameters.AddWithValue("@tarikh", label11.Text);
                        myCommanda.Parameters.AddWithValue("@moshtari", nam);

                        con.Open();
                        myCommanda.ExecuteNonQuery();
                        con.Close();


                    }


                    DialogResult dialogResult = MessageBox.Show("مبلغ  " + cashbox.Text + " بابت " + kard.ToString() + " توسط " + listBox1.SelectedItem.ToString() + " به نام سرکار  " + nam + " ثبت گردد ؟ ", " ثبت هزینه ورودی ", MessageBoxButtons.YesNo);



                    if (dialogResult == DialogResult.Yes)
                    {
                        OleDbCommand myCommand = new OleDbCommand("INSERT INTO amar (rejcode, cash, tarikh, khadamat, personel) VALUES (@rcode , @cash , @date , @khadamat , @personel)", con);
                        myCommand.Parameters.AddWithValue("@rcode", sabtrejcode.Text);
                        myCommand.Parameters.AddWithValue("@cash", cashbox.Text);
                        myCommand.Parameters.AddWithValue("@date", label11.Text);
                        myCommand.Parameters.AddWithValue("@khadamat", kard.ToString());
                        myCommand.Parameters.AddWithValue("@personel", listBox1.SelectedItem.ToString());
                        con.Open();
                        myCommand.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("اطلاعات با موفقیت ثبت گردید!");

                        if (pcheck.Checked == true)
                        {
                            report br = new report();
                            br.ShowDialog();
                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        listBox1.SelectedIndex = -1;
                        sabtrejcode.Text = "";
                        cashbox.Text = "0";
                        foreach (int i in checkedListBox1.CheckedIndices)
                        {
                            checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                    listBox1.SelectedIndex = -1;
                    cashbox.Text = "0";
                    sabtrejcode.Text = "";
                    foreach (int i in checkedListBox1.CheckedIndices)
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                else
                    MessageBox.Show("کد اشتراک موجود نیست", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("لطفا اطلاعات لازم را پر کنید.", "خطا", MessageBoxButtons.OK);

            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM rejlist WHERE rejcode ='" + sbox.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataview.DataSource = ds.Tables[0].DefaultView;
            }
            else if (radioButton2.Checked == true)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM rejlist WHERE shomare2 ='" + sbox.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataview.DataSource = ds.Tables[0].DefaultView;
            }
            else if (radioButton3.Checked == true)
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM rejlist WHERE famil ='" + sbox.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataview.DataSource = ds.Tables[0].DefaultView;
            }
            if (sbox.Text == "")
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM rejlist", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataview.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservePage x = new ReservePage();
            x.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void export_Click(object sender, EventArgs e)
        {
            dbref();
            //FileStream fileStream = new FileStream(@"d:\export.txt", FileMode.Create);
            TextWriter sw = new StreamWriter(@"d:\\export.txt");
            int rowcount = dataview.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                sw.WriteLine(dataview.Rows[i].Cells[4].Value.ToString());
            }
            sw.Close();     //Don't Forget Close the TextWriter Object(sw)

            MessageBox.Show("Data Successfully Exported To Drive '' C: '' ");
        }







    }
}
