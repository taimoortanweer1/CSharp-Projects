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


namespace crg
{
    public partial class ProductLog : Form

    {
        SqlConnection mySqlConnection;
        private string mcName;
   
        public ProductLog()
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

        public ProductLog(string mcName)
        {
            // TODO: Complete member initialization

            this.mcName = mcName;
            InitializeComponent();

            try
            {
                mySqlConnection = new SqlConnection(
                    "Data Source=" + this.mcName + "\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
             //  "Data Source=TAIMOOR-PC\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);

            }

        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            mySqlConnection.Open();
            SqlCommand add;
            if (modelText.Text == "" || QuantityText.Text == "" || costText.Text == "" || saleText.Text == "")
            {
                mySqlConnection.Close();
                MessageBox.Show("Enter Necessary Fields");
            }
            else
            {
                //************Adding data in Product Log ************************
                try
                {
                    //add = new SqlCommand("INSERT INTO [CRG_DATABASE].[dbo].[ProductLog] 
                    //(Category,Manufacturer,[Model No],[Acquired Date],Cost,Sale,Quantity,[Owner],Description)"
                    add = new SqlCommand("INSERT INTO [CRG_DATABASE].[dbo].[ProductLog]"
                                                       + " VALUES(" + "\'" + categoryCombo.Text + "\',"
                                                                       + "\'" + manufacturerText.Text + "\',"
                                                                       + "\'" + modelText.Text + "\',"
                                                                       + "\'" + AcqDateText.Text + "\',"
                                                                       +        costText.Text + ","
                                                                       +        saleText.Text + ","
                                                                       +        QuantityText.Text + ","
                                                                       + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                       + "\'" + ownerText.Text + "\',"
                                                                       + "\'" + descriptionText.Text + "\',"
                                                                       + "\'" + commentsText.Text + "\')", mySqlConnection);
                    DialogResult dr = MessageBox.Show("Do You want to add this them in stock", "Alert", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        add.ExecuteNonQuery();

                        //************Adding data in Product Log Update************************

                        add = new SqlCommand("INSERT INTO [CRG_DATABASE].[dbo].[ProductLogUpdate]"
                                                           + " VALUES(" + "\'" + categoryCombo.Text + "\',"
                                                                          + "\'" + manufacturerText.Text + "\',"
                                                                          + "\'" + modelText.Text + "\',"
                                                                          + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                          + costText.Text + ","
                                                                          + saleText.Text + ","
                                                                          + QuantityText.Text + ","
                                                                          + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                          + "\'" + commentsText.Text + "\')", mySqlConnection);

                        add.ExecuteNonQuery();
                        MessageBox.Show("Record Added Successfully");
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                    mySqlConnection.Close();
                    return;
                }
                mySqlConnection.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            MainForm MainF = new MainForm(this.mcName);
            this.Hide();
            this.Dispose();
            MainF.Show();
        } 
    }
}
