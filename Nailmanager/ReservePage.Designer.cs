namespace Nailmanager
{
    partial class ReservePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monthCalendarX1 = new BehComponents.MonthCalendarX();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nobatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datenobat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rejcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tozihat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nobatdehiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbDataSet = new Nailmanager.dbDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tozih = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.datelabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rejc = new System.Windows.Forms.TextBox();
            this.nobat = new System.Windows.Forms.TextBox();
            this.nobatdehiTableAdapter = new Nailmanager.dbDataSetTableAdapters.nobatdehiTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nobatdehiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendarX1
            // 
            this.monthCalendarX1.BoldedDayForeColor = System.Drawing.Color.Blue;
            this.monthCalendarX1.BorderColor = System.Drawing.Color.CadetBlue;
            this.monthCalendarX1.CalendarType = BehComponents.CalendarTypes.Persian;
            this.monthCalendarX1.DayRectTickness = 2F;
            this.monthCalendarX1.DaysBackColor = System.Drawing.Color.LightGray;
            this.monthCalendarX1.DaysFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendarX1.DaysForeColor = System.Drawing.Color.DodgerBlue;
            this.monthCalendarX1.EnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.monthCalendarX1.EnglishBoldedDates = new System.DateTime[0];
            this.monthCalendarX1.EnglishHolidayDates = new System.DateTime[0];
            this.monthCalendarX1.EnglishMonthlyBoldedDates = new System.DateTime[0];
            this.monthCalendarX1.HolidayForeColor = System.Drawing.Color.Red;
            this.monthCalendarX1.HolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.monthCalendarX1.LineWeekColor = System.Drawing.Color.Black;
            this.monthCalendarX1.Location = new System.Drawing.Point(371, 213);
            this.monthCalendarX1.Name = "monthCalendarX1";
            this.monthCalendarX1.PersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.PersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.PersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.PersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.monthCalendarX1.ShowToday = true;
            this.monthCalendarX1.ShowTodayRect = true;
            this.monthCalendarX1.ShowToolTips = false;
            this.monthCalendarX1.ShowTrailing = true;
            this.monthCalendarX1.Size = new System.Drawing.Size(209, 162);
            this.monthCalendarX1.Style_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.monthCalendarX1.Style_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.monthCalendarX1.Style_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.monthCalendarX1.Style_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.monthCalendarX1.Style_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.monthCalendarX1.Style_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.monthCalendarX1.TabIndex = 1;
            this.monthCalendarX1.TitleBackColor = System.Drawing.Color.Wheat;
            this.monthCalendarX1.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.monthCalendarX1.TitleForeColor = System.Drawing.Color.Black;
            this.monthCalendarX1.TodayBackColor = System.Drawing.Color.Wheat;
            this.monthCalendarX1.TodayFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendarX1.TodayForeColor = System.Drawing.Color.Black;
            this.monthCalendarX1.TodayRectColor = System.Drawing.Color.Coral;
            this.monthCalendarX1.TodayRectTickness = 2F;
            this.monthCalendarX1.TrailingForeColor = System.Drawing.Color.DarkGray;
            this.monthCalendarX1.WeekDaysBackColor = System.Drawing.Color.Wheat;
            this.monthCalendarX1.WeekDaysFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.monthCalendarX1.WeekDaysForeColor = System.Drawing.Color.OrangeRed;
            this.monthCalendarX1.WeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.monthCalendarX1.SelectedDateChanged += new BehComponents.MonthCalendarX.OnSelectedDateChanged(this.monthCalendarX1_SelectedDateChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SlateBlue;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nobatDataGridViewTextBoxColumn,
            this.datenobat,
            this.rejcodeDataGridViewTextBoxColumn,
            this.tozihat});
            this.dataGridView1.DataSource = this.nobatdehiBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(5, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(360, 363);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nobatDataGridViewTextBoxColumn
            // 
            this.nobatDataGridViewTextBoxColumn.DataPropertyName = "nobat";
            this.nobatDataGridViewTextBoxColumn.HeaderText = "نوبت";
            this.nobatDataGridViewTextBoxColumn.Name = "nobatDataGridViewTextBoxColumn";
            this.nobatDataGridViewTextBoxColumn.Width = 70;
            // 
            // datenobat
            // 
            this.datenobat.DataPropertyName = "datenobat";
            this.datenobat.HeaderText = "تاریخ";
            this.datenobat.Name = "datenobat";
            this.datenobat.Width = 80;
            // 
            // rejcodeDataGridViewTextBoxColumn
            // 
            this.rejcodeDataGridViewTextBoxColumn.DataPropertyName = "rejcode";
            this.rejcodeDataGridViewTextBoxColumn.HeaderText = "کد اشتراک";
            this.rejcodeDataGridViewTextBoxColumn.Name = "rejcodeDataGridViewTextBoxColumn";
            this.rejcodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // tozihat
            // 
            this.tozihat.DataPropertyName = "tozihat";
            this.tozihat.HeaderText = "توضیحات";
            this.tozihat.Name = "tozihat";
            this.tozihat.Width = 160;
            // 
            // nobatdehiBindingSource
            // 
            this.nobatdehiBindingSource.DataMember = "nobatdehi";
            this.nobatdehiBindingSource.DataSource = this.dbDataSet;
            // 
            // dbDataSet
            // 
            this.dbDataSet.DataSetName = "dbDataSet";
            this.dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tozih);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.datelabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rejc);
            this.groupBox1.Controls.Add(this.nobat);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(371, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(209, 173);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "حذف";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tozih
            // 
            this.tozih.Location = new System.Drawing.Point(12, 93);
            this.tozih.Multiline = true;
            this.tozih.Name = "tozih";
            this.tozih.Size = new System.Drawing.Size(117, 71);
            this.tozih.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(135, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "توضیحات :";
            // 
            // datelabel
            // 
            this.datelabel.AutoSize = true;
            this.datelabel.ForeColor = System.Drawing.Color.White;
            this.datelabel.Location = new System.Drawing.Point(48, 70);
            this.datelabel.Name = "datelabel";
            this.datelabel.Size = new System.Drawing.Size(39, 13);
            this.datelabel.TabIndex = 5;
            this.datelabel.Text = "--/--/--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(138, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "در تاریخ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(126, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "شماره اشتراک :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(147, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "نوبت :";
            // 
            // rejc
            // 
            this.rejc.Location = new System.Drawing.Point(12, 41);
            this.rejc.Name = "rejc";
            this.rejc.Size = new System.Drawing.Size(108, 21);
            this.rejc.TabIndex = 1;
            // 
            // nobat
            // 
            this.nobat.Location = new System.Drawing.Point(12, 15);
            this.nobat.Name = "nobat";
            this.nobat.Size = new System.Drawing.Size(108, 21);
            this.nobat.TabIndex = 0;
            // 
            // nobatdehiTableAdapter
            // 
            this.nobatdehiTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // nobatdehi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(592, 389);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.monthCalendarX1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "nobatdehi";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "نوبت دهی";
            this.Load += new System.EventHandler(this.nobatdehi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nobatdehiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BehComponents.MonthCalendarX monthCalendarX1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dbDataSet dbDataSet;
        private System.Windows.Forms.BindingSource nobatdehiBindingSource;
        private dbDataSetTableAdapters.nobatdehiTableAdapter nobatdehiTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rejc;
        private System.Windows.Forms.TextBox nobat;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tozih;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label datelabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nobatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datenobat;
        private System.Windows.Forms.DataGridViewTextBoxColumn rejcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tozihat;
        private System.Windows.Forms.Label label4;
    }
}