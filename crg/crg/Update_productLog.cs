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
    public partial class Update_productLog : Form
    {
        SqlDataReader mySqlDataReader = null;
        SqlConnection mySqlConnection;
        bool found = false;
        string category;
        string manufacturer;
        string model;
        string acqdate;
        string cost;
        string sale;
        string quantity;
        string comment;
        private string mcName;

        public Update_productLog()
        {
            InitializeComponent();
        }

        public Update_productLog(string mcName)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.mcName = mcName;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            MainForm MainF = new MainForm(this.mcName);
            this.Hide();
            this.Dispose();
            MainF.Show();

        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {

            if (listBox1.Text != "" || Searchbycombo.Text != "")
            {

                mySqlConnection.Close();
                mySqlConnection.Open();
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                try
                {
                    mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                         + "WHERE " + "ModelNo" + "= \'" + listBox1.SelectedItem.ToString() + "\'";

                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    if (mySqlDataReader.HasRows)
                    {
                        found = true;
                        while (mySqlDataReader.Read())
                        {
                            category = mySqlDataReader["Category"].ToString();
                            manufacturer = mySqlDataReader["Manufacturer"].ToString();
                            model = modelText.Text = mySqlDataReader["ModelNo"].ToString();
                            acqdate = AcqDateText.Text = mySqlDataReader["AcquiredDate"].ToString();
                            cost = costText.Text = mySqlDataReader["Cost"].ToString();
                            sale = saleText.Text = mySqlDataReader["Sale"].ToString();
                            quantity = QuantityText.Text = mySqlDataReader["Quantity"].ToString();
                        }

                    }
                    else
                    {
                        found = false;
                        modelText.Text = "";
                        AcqDateText.Text = "";
                        costText.Text = "0";
                        saleText.Text = "0";
                        QuantityText.Text = "0";
                        MessageBox.Show("Record Not Found");
                    }

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }



                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
           
        }

        private void Updatebutton_Click(object sender, EventArgs e)
        {
            
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlConnection.Open();
            if (found == true)
            {
                if (!model.Equals(modelText.Text))
                {
                    comment = "Model No changed";
                }

                if (!quantity.Equals(QuantityText.Text))
                {
                    comment = "Quantity Changed";
                }

                if (!cost.Equals(costText.Text))
                {
                    comment = "cost price changed";
                }

                if (!sale.Equals(saleText.Text))
                {
                    comment = "Sale price Changed";
                }

                if (!acqdate.Equals(AcqDateText.Text))
                {
                    comment = "Acquired Date Changed";
                }

                if ((!sale.Equals(saleText.Text)) && (!cost.Equals(costText.Text)))
                {
                    comment = "Cost and Sale Changed";
                }

                if ((!model.Equals(modelText.Text)) && (!acqdate.Equals(AcqDateText.Text)))
                {
                    comment = "Model No and Acq Date Changed";
                }

                if ((!sale.Equals(saleText.Text)) && (!cost.Equals(costText.Text)) && (!acqdate.Equals(AcqDateText.Text)))
                {
                    comment = "Cost, Sale and Acq Date Changed";
                }

                if ((!sale.Equals(saleText.Text)) && (!cost.Equals(costText.Text)) && (!quantity.Equals(QuantityText.Text)))
                {
                    comment = "Cost,Sale and quantity Changed";
                }

                if ((!sale.Equals(saleText.Text)) && (!cost.Equals(costText.Text)) && (!quantity.Equals(QuantityText.Text)) && (!acqdate.Equals(AcqDateText.Text)))
                {
                    comment = "Cost,Sale,quantity,Acq Date Changed";
                }

                if ((!sale.Equals(saleText.Text)) && (!cost.Equals(costText.Text)) && (!quantity.Equals(QuantityText.Text)) && (!model.Equals(modelText.Text)))
                {
                    comment = "Cost,Sale,model and quantity Changed";
                }

                if ((!sale.Equals(saleText.Text)) && (!cost.Equals(costText.Text)) && (!quantity.Equals(QuantityText.Text)) && (!model.Equals(modelText.Text)) && (!acqdate.Equals(AcqDateText.Text)))
                {
                    comment = "Cost,Sale,model,Acq Date and quantity Changed";
                }


                try
                {

                    mySqlCommand.CommandText = "UPDATE [CRG_DATABASE].[dbo].[ProductLog]"
                                                 + "SET "
                                                 + "ModelNo"      + "=\'" + modelText.Text   + "\', "
                                                 + "AcquiredDate" + "=\'" + AcqDateText.Text + "\', "
                                                 + "Cost"         + "= " + costText.Text     + ","
                                                 + "Sale"         + "= " + saleText.Text     + ","
                                                 + "Quantity"     + "= " + QuantityText.Text + ","
                                                 + "Comment"      + "=\'" + comment          + "\', "
                                                 + "LastUpdate"   + "=\'" + DateTime.Now.ToShortDateString() + "\' "
                                                 + "WHERE "
                                                 + "ModelNo"      +"=\'" + listBox1.SelectedItem.ToString() +"\'";


                    DialogResult dr = MessageBox.Show("Do you want to update the record", "Attention", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        mySqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Record Updated");
                    }
                    mySqlConnection.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                    mySqlConnection.Close();
                }
                try
                {
                    mySqlConnection.Open();
                    mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[ProductLogUpdate]"
                                                   + " VALUES("    + "\'" + category          + "\',"
                                                                   + "\'" + manufacturer      + "\',"
                                                                   + "\'" + modelText.Text    + "\',"
                                                                   + "\'" + AcqDateText.Text  + "\',"
                                                                   +        costText.Text     + ","
                                                                   +        saleText.Text     + ","
                                                                   +        QuantityText.Text + ","
                                                                   + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                   + "\'" + comment + "\')";
                                                                   

                    mySqlCommand.ExecuteNonQuery();   
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
                mySqlConnection.Close();
            }   
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            mySqlConnection.Close();
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            if (found == true)
            {
                try
                {
                    mySqlCommand.CommandText = "DELETE FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                             + "WHERE ModelNo = \'" + listBox1.SelectedItem.ToString() + "\'";

                    DialogResult dr = MessageBox.Show("Do You want to delete the record", "Attention", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        mySqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted");            
                    }

                }
                catch(Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }

                mySqlConnection.Close();
            }
        }

        private void Update_productLog_Load(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new SqlConnection(
                      "Data Source=" + this.mcName + "\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
                    //"Data Source=TAIMOOR-PC\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Searchbycombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            mySqlConnection.Close();
            mySqlConnection.Open();

            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;
            mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                     + "WHERE " + "Category" + "= \'" + Searchbycombo.Text + "\'";


            try
            {
                mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {

                    while (mySqlDataReader.Read())
                    {
                        listBox1.Items.Add(mySqlDataReader["ModelNo"].ToString());

                    }
                    mySqlConnection.Close();

                }
            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                mySqlConnection.Close();
            }
            mySqlConnection.Close();
        }
        
    }
}
