using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace crg
{
    public partial class IssueReportForm : Form
    {
        private string p;
        private string p_2;
        private string p_3;
        private string p_4;
        private string p_5;
        private string p_6;
        private string p_7;
        private string p_8;
        private string p_9;
        private string p_10;
        private string p_11;
        private string p_12;
        private string p_13;

        public IssueReportForm()
        {
            InitializeComponent();
        
        }

        public IssueReportForm(string p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7, string p_8, string p_9, string p_10, string p_11, string p_12)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            
            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
            this.p_6 = p_6;
            this.p_7 = p_7;
            this.p_8 = p_8;
            this.p_9 = p_9;
            this.p_10 = p_10;
            this.p_11 = p_11;
            this.p_12 = p_12;
             //categoryCombo.Text, ModelText.Text, IssuedToText.Text,
            //Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
            //MOPcombo.Text, Issuecombo.Text, StatusText.Text
           // this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            //this.reportViewer1.Clear();

            this.IssuanceFormTableAdapter.IssuanceReport(this.DataSet1.IssuanceForm, this.p_2
            , this.p_3, this.p_4, this.p_6, this.p_11, this.p, this.p_5,
            this.p_7, Convert.ToDecimal(this.p_8), Convert.ToDecimal(this.p_9), this.p_10);

            this.reportViewer1.RefreshReport();
            System.Threading.Thread.Sleep(500);
            this.reportViewer1.RefreshReport();



            InitializeComponent();

            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
            this.p_6 = p_6;
            this.p_7 = p_7;
            this.p_8 = p_8;
            this.p_9 = p_9;
            this.p_10 = p_10;
            this.p_11 = p_11;
            this.p_12 = p_12;
            //categoryCombo.Text, ModelText.Text, IssuedToText.Text,
            //Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
            //MOPcombo.Text, Issuecombo.Text, StatusText.Text
            // this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            //this.reportViewer1.Clear();

            this.IssuanceFormTableAdapter.IssuanceReport(this.DataSet1.IssuanceForm, this.p_2
            , this.p_3, this.p_4, this.p_6, this.p_11, this.p, this.p_5,
            this.p_7, Convert.ToDecimal(this.p_8), Convert.ToDecimal(this.p_9), this.p_10);

            this.reportViewer1.RefreshReport();
            System.Threading.Thread.Sleep(500);
            this.reportViewer1.RefreshReport();
            
            

        }

        public IssueReportForm(string p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7, string p_8, string p_9, string p_10, string p_11, string p_12, string p_13)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
            this.p_6 = p_6;
            this.p_7 = p_7;
            this.p_8 = p_8;
            this.p_9 = p_9;
            this.p_10 = p_10;
            this.p_11 = p_11;
            this.p_12 = p_12;
            this.p_13 = p_13;
            //categoryCombo.Text, ModelText.Text, IssuedToText.Text,
            //Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
            //MOPcombo.Text, Issuecombo.Text, StatusText.Text
            // this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            //this.reportViewer1.Clear();

            this.IssuanceFormTableAdapter.IssuanceReport(this.DataSet1.IssuanceForm, this.p_2
            , this.p_3, this.p_4, this.p_6, this.p_11, this.p, this.p_5,
            this.p_7, Convert.ToDecimal(this.p_8), Convert.ToDecimal(this.p_9), this.p_10);

            this.reportViewer1.RefreshReport();
            System.Threading.Thread.Sleep(500);
            this.reportViewer1.RefreshReport();



            InitializeComponent();

            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
            this.p_6 = p_6;
            this.p_7 = p_7;
            this.p_8 = p_8;
            this.p_9 = p_9;
            this.p_10 = p_10;
            this.p_11 = p_11;
            this.p_12 = p_12;
            this.p_13 = p_13;
            //categoryCombo.Text, ModelText.Text, IssuedToText.Text,
            //Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
            //MOPcombo.Text, Issuecombo.Text, StatusText.Text
            // this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            //this.reportViewer1.Clear();

            this.IssuanceFormTableAdapter.IssuanceReport(this.DataSet1.IssuanceForm, this.p_2
            , this.p_3, this.p_4, this.p_6, this.p_11, this.p, this.p_5,
            this.p_7, Convert.ToDecimal(this.p_8), Convert.ToDecimal(this.p_9), this.p_10);

            this.reportViewer1.RefreshReport();
            System.Threading.Thread.Sleep(500);
            this.reportViewer1.RefreshReport();
            
            

        }

        private void IssueReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.IssuanceForm' table. You can move, or remove it, as needed.
            this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            // TODO: This line of code loads data into the 'DataSet1.IssuanceForm' table. You can move, or remove it, as needed.
            
            //categoryCombo.Text, ModelText.Text, IssuedToText.Text,
            //Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
            //MOPcombo.Text, Issuecombo.Text, StatusText.Text
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm Mf = new MainForm(this.p_13);
            this.Hide();
            this.Dispose();
            Mf.Show();
            
        }
    }
}
