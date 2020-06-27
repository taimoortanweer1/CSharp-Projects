using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace crg
{
    public partial class MainForm : Form
    {
        private string mcName;
        SqlConnection mySqlConnection;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string mcName)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.mcName = mcName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductLog Plog = new ProductLog(mcName);
            this.Hide();
            Plog.Show();
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            Update_productLog UPLog = new Update_productLog(mcName);
            this.Hide();
            UPLog.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Issue_form IssueF = new Issue_form(mcName);
            this.Hide();
            IssueF.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Contact con = new Contact(mcName);
            this.Hide();            
            con.Show();
        }

        private void Quitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReportForm1 rp = new ReportForm1(mcName);
            this.Hide();
            rp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("CRG Inventory System \n Version : 1.0 \n For Any Query Contact : 051-8432273-ext(243)","About Us");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new SqlConnection(
                    "Data Source=" + this.mcName + "\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
              // "Data Source=TAIMOOR-PC\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Left -= 1;
            if (label2.Right == 0)
            {
                label2.Left = this.Right;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            mySqlConnection.Close();
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;
            mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[IssuanceForm]"
                                     + "WHERE " + "DueDate" + "= \'" + DateTime.Now.AddDays(1) + "\' OR " + "DueDate" + "= \'" + DateTime.Now.ToShortDateString() + "\'";

            int count = 0;
            try
            {
                
                mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {
                    if (label2.ForeColor == Color.Black)
                        label2.ForeColor = Color.Red;
                    else
                        label2.ForeColor = Color.Black;

                    label2.Text = "**ISSUANCE ALERT**";
                    while (mySqlDataReader.Read())
                    {
                        count = count + 1;

                        label2.Text = label2.Text + " Due Date = " + mySqlDataReader["DueDate"].ToString();
                        label2.Text = label2.Text +"  ****** " + count.ToString();
                        label2.Text = label2.Text + ". Issue ID = "+ mySqlDataReader["Id"].ToString();
                        label2.Text = label2.Text + " Name = "   + mySqlDataReader["IssuedSoldTo"].ToString();
                        label2.Text = label2.Text + " Item Issued = " + mySqlDataReader["ModelNo"].ToString();
                        label2.Text = label2.Text + " ****** "; 
                        /*
                        IssuedToText.Text = mySqlDataReader["IssuedSoldTo"].ToString();
                        Rolltext.Text = mySqlDataReader["RollNo"].ToString();
                        MobileText.Text = mySqlDataReader["MobileNo"].ToString();
                        IssuedDateText.Text = mySqlDataReader["IssuanceSoldDate"].ToString();
                        
                        ReturnText.Text = mySqlDataReader["ReturnDate"].ToString();
                        QuantityText.Text = mySqlDataReader["Quantity"].ToString();
                        PayementText.Text = mySqlDataReader["Payment"].ToString();
                        Issuecombo.Text = mySqlDataReader["IssuedSold"].ToString();
                        StatusText.Text = mySqlDataReader["Status"].ToString();
                         */ 
                    }

                }

                    
                else
                {
                    label2.ForeColor = Color.Black;
                    label2.Text = "CASE Robotics Group - Inventory System";
                    mySqlConnection.Close();
                    mySqlDataReader.Close();
                    return;
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                mySqlConnection.Close();
                mySqlDataReader.Close();
                return;
            }

        }     
    }
}
