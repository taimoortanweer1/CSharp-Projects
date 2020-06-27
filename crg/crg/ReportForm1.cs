using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
namespace crg
{
    public partial class ReportForm1 : Form
    {
        int check = 0;
        SqlConnection mySqlConnection;
        private string mcName;

        public ReportForm1()
        {
            InitializeComponent();
            try
            {
                mySqlConnection = new SqlConnection(
               "Data Source=TAIMOOR-PC\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);

            }
        }

        public ReportForm1(string mcName)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.mcName = mcName;
            try
            {
                mySqlConnection = new SqlConnection(
               "Data Source=" + this.mcName + "\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);

            }
           
        }

        private void ReportForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.IssuanceForm' table. You can move, or remove it, as needed.
            this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            // TODO: This line of code loads data into the 'DataSet1.IssuanceForm' table. You can move, or remove it, as needed.
           // this.IssuanceFormTableAdapter.Fill(this.DataSet1.IssuanceForm);
            // TODO: This line of code loads data into the 'DataSet1.ProductLog' table. You can move, or remove it, as needed.           
            // TODO: This line of code loads data into the 'DataSet1.IssuanceForm' table. You can move, or remove it, as needed.           
            // TODO: This line of code loads data into the 'DataSet1.ProductLog' table. You can move, or remove it, as needed.
            //this.ProductLogTableAdapter.ShowByManufacturer(this.DataSet1.ProductLog,Entertext.Text);
            //this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportViewer1.Show();
            reportViewer2.Hide();
            reportViewer3.Hide();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "crg.Report1.rdlc";
            if (Entertext.Text != "" || comboBox1.Text != "")
            {
                try
                {
                    if (check == 1)
                    {
                        this.ProductLogTableAdapter.ShowByCat(this.DataSet1.ProductLog, Entertext.Text);
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 2)
                    {
                        this.ProductLogTableAdapter.ShowByManufacturer(this.DataSet1.ProductLog, Entertext.Text);
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 3)
                    {
                        this.ProductLogTableAdapter.ShowByMod(this.DataSet1.ProductLog, Entertext.Text);
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 4)
                    {
                        this.ProductLogTableAdapter.SortByGivenQuantity(this.DataSet1.ProductLog, Convert.ToDecimal(Entertext.Text));
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 5)
                    {
                        this.ProductLogTableAdapter.SortByAcqGreater(this.DataSet1.ProductLog, (Entertext.Text));
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 6)
                    {
                        this.ProductLogTableAdapter.SortByAcqLesser(this.DataSet1.ProductLog, (Entertext.Text));
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 7)
                    {
                        this.ProductLogTableAdapter.SortbyCostGreater(this.DataSet1.ProductLog, Convert.ToDecimal(Entertext.Text));
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 8)
                    {
                        this.ProductLogTableAdapter.SortByCostLesser(this.DataSet1.ProductLog, Convert.ToDecimal(Entertext.Text));
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 9)
                    {
                        this.ProductLogTableAdapter.SortBySaleGreater(this.DataSet1.ProductLog, Convert.ToDecimal(Entertext.Text));
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 10)
                    {
                        this.ProductLogTableAdapter.SortBySaleLesser(this.DataSet1.ProductLog, Convert.ToDecimal(Entertext.Text));

                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                    if (check == 11)
                    {
                        this.ProductLogTableAdapter.ShowAllProductLog(this.DataSet1.ProductLog);
                        this.reportViewer1.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer1.RefreshReport();
                        
                        return;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Necessary Fields", "Error");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            mySqlConnection.Close();
            mySqlConnection.Open();

            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;


            try
            {

            if (comboBox1.Text == "Search By Category")
            {
                check = 1;
                toolTip1.SetToolTip(Entertext, "Enter text");
                mySqlCommand.CommandText = "SELECT DISTINCT Category FROM [CRG_DATABASE].[dbo].[ProductLog]";
            }

            if (comboBox1.Text == "Search By Manufacturer")
            {
                check = 2;
                toolTip1.SetToolTip(Entertext, "Enter text");
                mySqlCommand.CommandText = mySqlCommand.CommandText = "SELECT DISTINCT Manufacturer FROM [CRG_DATABASE].[dbo].[ProductLog]";
            }


            if (comboBox1.Text == "Search By Model No")
            {

                check = 3;
                toolTip1.SetToolTip(Entertext, "Enter text");
                mySqlCommand.CommandText = mySqlCommand.CommandText = "SELECT DISTINCT ModelNo FROM [CRG_DATABASE].[dbo].[ProductLog]";
            }


            if (comboBox1.Text == "Search By Quantity")
            {
                check = 4;
                toolTip1.SetToolTip(Entertext, "Enter Numeric");
            }


            if (comboBox1.Text == "Search By Acquired Date Greater Than")
            {
                check = 5;
                toolTip1.SetToolTip(Entertext, "YYYY-MM-DD");
            }


            if (comboBox1.Text == "Search By Acquired Date Lesser Than")
            {
                toolTip1.SetToolTip(Entertext, "YYYY-MM-DD");
                check = 6;
            }
            if (comboBox1.Text == "Search By Cost Greater Than")
            {
                check = 7;
                toolTip1.SetToolTip(Entertext, "Enter Numeric");
            }

            if (comboBox1.Text == "Search By Cost Lesser Than")
            {
                check = 8;
                toolTip1.SetToolTip(Entertext, "Enter Numeric");
            }

            if (comboBox1.Text == "Search By Sale Greater Than")
            {
                check = 9;
                toolTip1.SetToolTip(Entertext, "Enter Numeric");
            }


            if (comboBox1.Text == "Search By Sale Lesser Than")
            {
                check = 10;
                toolTip1.SetToolTip(Entertext, "Enter Numeric");

            }


            if (comboBox1.Text == "Show All Products")
            {
                check = 11;
                toolTip1.SetToolTip(Entertext, "Show All");

            }

            if (check == 1 || check == 2 || check == 3)
            {
                mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        if (check == 1)
                            listBox1.Items.Add(mySqlDataReader["Category"].ToString());

                        if (check == 2)
                            listBox1.Items.Add(mySqlDataReader["Manufacturer"].ToString());

                        if (check == 3)
                            listBox1.Items.Add(mySqlDataReader["ModelNo"].ToString());
                    }

                }

                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                mySqlConnection.Close();
                mySqlDataReader.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm(this.mcName);
            this.Dispose();
            mf.Show();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Entertext.Text = listBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            mySqlConnection.Close();
            mySqlConnection.Open();

            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;

            try
            {
                

                if (comboBox2.Text == "Search By Category")
                {
                    check = 12;
                    toolTip1.SetToolTip(textBox1, "Enter text");
                    mySqlCommand.CommandText = "SELECT DISTINCT Category FROM [CRG_DATABASE].[dbo].[IssuanceForm]";
                }

               
                if (comboBox2.Text == "Search By Model No")
                {

                    check = 13;
                    toolTip1.SetToolTip(textBox1, "Enter text");
                    mySqlCommand.CommandText = mySqlCommand.CommandText = "SELECT DISTINCT ModelNo FROM [CRG_DATABASE].[dbo].[IssuanceForm]";
                }

                if (comboBox2.Text == "Search By ID")
                {
                    check = 14;
                    toolTip1.SetToolTip(textBox1, "Enter ID");
                    return;
                }

                if (comboBox2.Text == "Search By Name")
                {
                    check = 15;
                    toolTip1.SetToolTip(textBox1, "Enter Name");
                    return;
                }

                if (comboBox2.Text == "Search By Roll")
                {
                    check = 16;
                    toolTip1.SetToolTip(textBox1, "Enter Roll No");
                    return;
                }

                if (comboBox2.Text == "Search By Status")
                {
                    check = 17;
                    listBox2.Items.Add("Sold");
                    listBox2.Items.Add("Issued");
                    toolTip1.SetToolTip(textBox1, "Enter Status");
                    return;
                }
                if (comboBox2.Text == "Show All Products")
                {
                    check = 18;
                    toolTip1.SetToolTip(textBox1, "Enter text");
                    return;
                }


                if (check == 12 || check == 13)
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    if (mySqlDataReader.HasRows)
                    {

                        while (mySqlDataReader.Read())
                        {
                            if (check == 12)
                                listBox2.Items.Add(mySqlDataReader["Category"].ToString());

                            if (check == 13)
                                listBox2.Items.Add(mySqlDataReader["ModelNo"].ToString());
                        }

                    }
                }
                mySqlConnection.Close();
                mySqlDataReader.Close();
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                
            }
            
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listBox2.SelectedItem.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            reportViewer2.Show();
            reportViewer1.Hide();
            reportViewer3.Hide();
            /*
        Show All Products
        Search By Category
        Search By Model No
        Search By ID
        Search By Name
        Search By Roll
        Search By Status
        */ 

            if (textBox1.Text != "" || comboBox2.Text != "")
            {
                try
                {
                    if (check == 12)
                    {

                        this.IssuanceFormTableAdapter.SearchByCategory(this.DataSet1.IssuanceForm, textBox1.Text);                

                        this.reportViewer2.RefreshReport();
                       
                        System.Threading.Thread.Sleep(500);
                        this.IssuanceFormTableAdapter.SearchByCategory(this.DataSet1.IssuanceForm, textBox1.Text); 
                        this.reportViewer2.RefreshReport();
                        return;
                    }
                    if (check == 13)
                    {
                        this.IssuanceFormTableAdapter.SearchByModelNo(this.DataSet1.IssuanceForm, textBox1.Text);
                        
                        this.reportViewer2.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer2.RefreshReport();
                        return;
                    }
                    if (check == 14)
                    {
                        this.IssuanceFormTableAdapter.SearchByID(this.DataSet1.IssuanceForm, Convert.ToDecimal(textBox1.Text));
                        this.reportViewer2.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer2.RefreshReport();
                        return;
                    }
                    if (check == 15)
                    {
                        this.IssuanceFormTableAdapter.SearchByName(this.DataSet1.IssuanceForm, (textBox1.Text+"%"));
                        this.reportViewer2.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer2.RefreshReport();
                        return;
                    }
                    if (check == 16)
                    {
                        this.IssuanceFormTableAdapter.SearchByRoll(this.DataSet1.IssuanceForm, (textBox1.Text+"%"));
                        this.reportViewer2.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer2.RefreshReport();
                        return;
                    }
                    if (check == 17)
                    {

                        if (textBox1.Text.IndexOf("So") != -1 || textBox1.Text.IndexOf("Sold") != -1)
                        {
                            reportViewer2.Show();
                            reportViewer3.Hide();
                            reportViewer1.Hide();
                            this.IssuanceFormTableAdapter.SearchByStatus(this.DataSet1.IssuanceForm, (textBox1.Text + "%"));
                            this.reportViewer2.RefreshReport();
                            System.Threading.Thread.Sleep(500);
                            this.reportViewer2.RefreshReport();
                            return;
                        }
                        if (textBox1.Text.IndexOf("Iss") != -1 || textBox1.Text.IndexOf("Issued") != -1)
                        {
                            reportViewer3.Show();
                            reportViewer2.Hide();
                            reportViewer1.Hide();
                            this.IssuanceFormTableAdapter.SearchByStatus(this.DataSet1.IssuanceForm, (textBox1.Text + "%"));
                            this.reportViewer3.RefreshReport();
                            System.Threading.Thread.Sleep(500);
                            this.reportViewer3.RefreshReport();
                            return;
                        }
                    }
                    if (check == 18)
                    {
                        this.IssuanceFormTableAdapter.ShowAll(this.DataSet1.IssuanceForm);
                        this.reportViewer2.RefreshReport();
                        System.Threading.Thread.Sleep(500);
                        this.reportViewer2.RefreshReport();
                        return;
                    }
                    
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Necessary Fields", "Error");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
