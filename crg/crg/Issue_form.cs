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

    public partial class Issue_form : Form
    {
        SqlConnection mySqlConnection;

        string category;
        string manufacturer;
        string model;
        string acqdate;
        string cost;
        string sale;
        //  string stock;//quantity
        string comment;
        private string mcName;

        public Issue_form()
        {
            InitializeComponent();
        }

        public Issue_form(string mcName)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.mcName = mcName;
        }


        //*************************************************************************************************************
        private void Issuecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Issuecombo.Text == "Sold")
            {
                ReturnText.Enabled = false;
                DueDateText.Enabled = false;
                StatusText.Text = "Sold";
            }
            else if (Issuecombo.Text == "Issued")
            {
                ReturnText.Enabled = true;
                DueDateText.Enabled = true;
                StatusText.Text = "Issued";
            }
        }


        //*************************************************************************************************************
        private void IssueButton_Click(object sender, EventArgs e)
        {

            //check if item has to be issued
            if (Issuecombo.Text == "Issued")
            {


                //check if any field is empty
                if (categoryCombo.Text == "" || ModelText.Text == "" || Issuecombo.Text == "" ||
                   Rolltext.Text == "" || MobileText.Text == "" || IssuedDateText.Text == "" ||
                   DueDateText.Text == "" || QuantityText.Text == "" || PayementText.Text == "" || Issuecombo.Text == "" || MOPcombo.Text == "")
                {
                    MessageBox.Show("Enter Required Fields");
                    return;
                }

                else
                {
                    //**************************************************************
                    mySqlConnection.Close();
                    //Check if required Quantity is available in stock
                    mySqlConnection.Open();
                    SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                    SqlDataReader mySqlDataReader = null;

                    string stock = "0";
                    mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                             + "WHERE " + "ModelNo" + "= \'" + ModelText.Text + "\'";


                    try
                    {
                        mySqlDataReader = mySqlCommand.ExecuteReader();
                        if (mySqlDataReader.HasRows)
                        {

                            while (mySqlDataReader.Read())
                            {
                                category = mySqlDataReader["Category"].ToString();
                                manufacturer = mySqlDataReader["Manufacturer"].ToString();
                                model = mySqlDataReader["ModelNo"].ToString();
                                acqdate = mySqlDataReader["AcquiredDate"].ToString();
                                cost = mySqlDataReader["Cost"].ToString();
                                sale = mySqlDataReader["Sale"].ToString();
                                stock = mySqlDataReader["Quantity"].ToString();
                                comment = mySqlDataReader["Comment"].ToString();
                            }
                            mySqlConnection.Close();
                            mySqlDataReader.Close();

                            if (Convert.ToDecimal(stock) < 0)
                            {
                                MessageBox.Show("Item Out of Stock");
                                mySqlConnection.Close();
                                mySqlDataReader.Close();

                                return;
                            }

                            if (Convert.ToDecimal(QuantityText.Text) > Convert.ToDecimal(stock))
                            {
                                MessageBox.Show("Only " + stock + " items are available", "Insufficient Stock");
                                mySqlConnection.Close();
                                mySqlDataReader.Close();

                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Model/Part Not Found in Inventory");
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



                    mySqlDataReader.Close();
                    mySqlConnection.Close();


                    //**************************************************************
                    //calculate validity of dates
                    DateTime dt1 = Convert.ToDateTime(DueDateText.Text);
                    DateTime dt2 = Convert.ToDateTime(IssuedDateText.Text);
                    TimeSpan ts1 = dt1.Subtract(dt2);

                    if ((int)ts1.Days < 0)
                    {
                        MessageBox.Show("Due Date cant be less than Issued Date", "Date Error");
                        mySqlConnection.Close();
                        mySqlDataReader.Close();
                        return;
                    }
                    else
                    {

                        //if dates are valid then do the following
                        mySqlConnection.Open();
                        mySqlCommand = mySqlConnection.CreateCommand();


                        try
                        {
                            StatusText.Text = "Issued";
                            mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[IssuanceForm]"
                                                          + " VALUES(" + "\'" + categoryCombo.Text + "\',"
                                                                          + "\'" + ModelText.Text + "\',"
                                                                          + "\'" + IssuedToText.Text + "\',"
                                                                          + "\'" + Rolltext.Text + "\',"
                                                                          + "\'" + MobileText.Text + "\',"
                                                                          + "\'" + IssuedDateText.Text + "\',"
                                                                          + "\'" + DueDateText.Text + "\',"
                                                                          + "\'" + ReturnText.Text + "\',"
                                                                          + QuantityText.Text + ","
                                                                          + PayementText.Text + ","
                                                                          + "\'" + MOPcombo.Text + "\',"
                                                                          + "\'" + Issuecombo.Text + "\',"
                                                                          + "\'" + StatusText.Text + "\')";


                            DialogResult dr = MessageBox.Show("Do You Want to Issue the Item ?", "Alert", MessageBoxButtons.YesNo);


                            //if user wants to issue or not    
                            if (dr == DialogResult.Yes)
                            {
                                mySqlCommand.ExecuteNonQuery();
                                MessageBox.Show(ModelText.Text + "is/are successfully Issued to " + IssuedToText.Text + " on " + IssuedDateText.Text);
                                mySqlConnection.Close();
                                mySqlDataReader.Close();

                                //*************************************************************************
                                //Updating Quantity in product log for the specified Model after issuing item
                                mySqlConnection.Open();
                                decimal diffStock = Convert.ToDecimal(stock) - Convert.ToDecimal(QuantityText.Text);
                                mySqlCommand = mySqlConnection.CreateCommand();
                                try
                                {
                                    mySqlCommand.CommandText = "UPDATE [CRG_DATABASE].[dbo].[ProductLog]"
                                                                 + "SET "
                                                                 + "Quantity = " + diffStock.ToString()
                                                                 + " WHERE "
                                                                 + "ModelNo = \'" + ModelText.Text + "\'";

                                    mySqlCommand.ExecuteNonQuery();
                                    mySqlConnection.Close();
                                }
                                catch (Exception e1)
                                {
                                    MessageBox.Show(e1.Message);
                                    mySqlConnection.Close();
                                    return;

                                }

                                //*************************************************************************
                                //Updating Quantity in product log for the specified Model after issuing item     

                                mySqlConnection.Open();
                                mySqlCommand = mySqlConnection.CreateCommand();
                                try
                                {
                                    mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[ProductLogUpdate]"
                                                        + " VALUES(" + "\'" + category + "\',"
                                                                        + "\'" + manufacturer + "\',"
                                                                        + "\'" + model + "\',"
                                                                        + "\'" + acqdate + "\',"
                                                                        + cost + ","
                                                                        + sale + ","
                                                                        + diffStock + ","
                                                                        + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                        + "\'" + "Items Issued" + "\')";


                                    mySqlCommand.ExecuteNonQuery();
                                    mySqlConnection.Close();
                                }
                                catch (Exception e1)
                                {
                                    MessageBox.Show(e1.Message);
                                    mySqlConnection.Close();
                                    return;

                                }

                                //*********************** CREATE REPORT OF ISSUE/Sell Product ***************************8
                                DialogResult RP = MessageBox.Show("Do You Want a Report For this transaction", "Alert", MessageBoxButtons.YesNo);

                                if (RP == DialogResult.Yes)
                                {
                                    IssueReportForm IRF = new IssueReportForm(categoryCombo.Text, ModelText.Text, IssuedToText.Text,
                                   Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
                                   MOPcombo.Text, Issuecombo.Text, StatusText.Text,this.mcName);

                                    this.Hide();
                                    IRF.Show();
                                }

                                //*************************************************************************
                            }//Dialog result yes ends here

                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                            mySqlConnection.Close();
                            return;
                        }
                        mySqlConnection.Close();

                        //****************************************************************************
                        //Adding Contact Details in Contact from which transaction has been done
                        mySqlConnection.Open();
                        mySqlCommand = mySqlConnection.CreateCommand();
                        mySqlDataReader = null;

                        mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[Contacts]"
                                                 + "WHERE " + "RollNo" + "= \'" + Rolltext.Text + "\'";


                        try
                        {
                            mySqlDataReader = mySqlCommand.ExecuteReader();

                            //if contact is already present or not in the list
                            if (!mySqlDataReader.HasRows)
                            {
                                mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[Contacts]"
                                                         + " VALUES(" + "\'" + IssuedToText.Text + "\',"
                                                                         + "\'" + Rolltext.Text + "\',"
                                                                         + "\'" + MobileText.Text + "\',"
                                                                         + "\'" + " " + "\',"
                                                                         + "\'" + DateTime.Now.ToShortDateString() + "\')";

                                try
                                {
                                    mySqlDataReader.Close();

                                    mySqlCommand.ExecuteNonQuery();
                                    MessageBox.Show("Contact Added in Log", "Update");
                                    mySqlConnection.Close();
                                    mySqlDataReader.Close();
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
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                            mySqlConnection.Close();
                            mySqlDataReader.Close();
                            return;

                        }
                        //************************************************************                      
                    }


                }


            }//end of :ISSUE: 


            if (Issuecombo.Text == "Sold")
            {
                //check if any field is empty
                if (categoryCombo.Text == "" || ModelText.Text == "" || Issuecombo.Text == "" ||
                   Rolltext.Text == "" || MobileText.Text == "" || QuantityText.Text == "" || PayementText.Text == "" || Issuecombo.Text == "" || MOPcombo.Text == "")
                {
                    MessageBox.Show("Enter Required Fields");
                    mySqlConnection.Close();
                    return;
                }

                else
                {
                    //**************************************************************
                    //Check if required Quantity is available in stock
                    mySqlConnection.Close();
                    mySqlConnection.Open();
                    SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                    SqlDataReader mySqlDataReader = null;
                    string stock = "0";
                    mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                             + "WHERE [" + "ModelNo" + "]= \'" + ModelText.Text + "\'";


                    try
                    {
                        mySqlDataReader = mySqlCommand.ExecuteReader();
                        if (mySqlDataReader.HasRows)
                        {

                            while (mySqlDataReader.Read())
                            {
                                category = mySqlDataReader["Category"].ToString();
                                manufacturer = mySqlDataReader["Manufacturer"].ToString();
                                model = mySqlDataReader["ModelNo"].ToString();
                                acqdate = mySqlDataReader["AcquiredDate"].ToString();
                                cost = mySqlDataReader["Cost"].ToString();
                                sale = mySqlDataReader["Sale"].ToString();
                                stock = mySqlDataReader["Quantity"].ToString();
                                comment = mySqlDataReader["Comment"].ToString();
                            }
                            mySqlConnection.Close();
                            mySqlDataReader.Close();

                            if (Convert.ToDecimal(stock) < 0)
                            {
                                MessageBox.Show("Item Out of Stock");
                                return;
                            }

                            if (Convert.ToDecimal(QuantityText.Text) > Convert.ToDecimal(stock))
                            {
                                MessageBox.Show("Only " + stock + " items are available", "Insufficient Stock");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Model/Part Not Found in Inventory");
                            mySqlConnection.Close();

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



                    mySqlDataReader.Close();
                    mySqlConnection.Close();


                    //**************************************************************
                    StatusText.Text = "Issued";
                    mySqlConnection.Open();
                    mySqlCommand = mySqlConnection.CreateCommand();


                    try
                    {
                        mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[IssuanceForm]"
                                                      + " VALUES(" + "\'" + categoryCombo.Text + "\',"
                                                                      + "\'" + ModelText.Text + "\',"
                                                                      + "\'" + IssuedToText.Text + "\',"
                                                                      + "\'" + Rolltext.Text + "\',"
                                                                      + "\'" + MobileText.Text + "\',"
                                                                      + "\'" + IssuedDateText.Text + "\',"
                                                                      + "\'" + DueDateText.Text + "\',"
                                                                      + "\'" + ReturnText.Text + "\',"
                                                                      + QuantityText.Text + ","
                                                                      + PayementText.Text + ","
                                                                      + "\'" + MOPcombo.Text + "\',"
                                                                      + "\'" + Issuecombo.Text + "\',"
                                                                      + "\'" + StatusText.Text + "\')";


                        DialogResult dr = MessageBox.Show("Do You Want to Sale the Item ?", "Alert", MessageBoxButtons.YesNo);


                        //if user wants to sale
                        if (dr == DialogResult.Yes)
                        {
                            mySqlCommand.ExecuteNonQuery();
                            MessageBox.Show(ModelText.Text + " is/are successfully sold to " + IssuedToText.Text + " on " + IssuedDateText.Text);
                            mySqlConnection.Close();

                            //*************************************************************************
                            //Updating Quantity in product log for the specified Model after issuing item

                            mySqlConnection.Open();
                            decimal diffStock = Convert.ToDecimal(stock) - Convert.ToDecimal(QuantityText.Text);
                            mySqlCommand = mySqlConnection.CreateCommand();
                            try
                            {
                                mySqlCommand.CommandText = "UPDATE [CRG_DATABASE].[dbo].[ProductLog]"
                                                             + "SET "
                                                             + "Quantity = " + diffStock.ToString()
                                                             + " WHERE "
                                                             + "ModelNo = \'" + ModelText.Text + "\'";

                                mySqlCommand.ExecuteNonQuery();
                                mySqlConnection.Close();
                            }
                            catch (Exception e1)
                            {
                                MessageBox.Show(e1.Message);
                                mySqlConnection.Close();
                                return;

                            }

                            //*************************************************************************
                            //Updating Quantity in product log for the specified Model after issuing item     

                            mySqlConnection.Open();
                            mySqlCommand = mySqlConnection.CreateCommand();
                            try
                            {
                                mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[ProductLogUpdate]"
                                                    + " VALUES(" + "\'" + category + "\',"
                                                                    + "\'" + manufacturer + "\',"
                                                                    + "\'" + model + "\',"
                                                                    + "\'" + acqdate + "\',"
                                                                    + cost + ","
                                                                    + sale + ","
                                                                    + diffStock + ","
                                                                    + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                    + "\'" + "Items Issued" + "\')";


                                mySqlCommand.ExecuteNonQuery();
                                mySqlConnection.Close();
                            }
                            catch (Exception e1)
                            {
                                MessageBox.Show(e1.Message);
                                mySqlConnection.Close();
                                return;

                            }

                            //****************************************************************************
                            //Adding Contact Details in Contact from which transaction has been done
                            mySqlConnection.Open();
                            mySqlCommand = mySqlConnection.CreateCommand();
                            mySqlDataReader = null;

                            mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[Contacts]"
                                                     + "WHERE " + "RollNo" + "= \'" + Rolltext.Text + "\'";


                            try
                            {
                                mySqlDataReader = mySqlCommand.ExecuteReader();
                                //if contact is already present or not in the list
                                if (!mySqlDataReader.HasRows)
                                {
                                    mySqlCommand.CommandText = "INSERT INTO [CRG_DATABASE].[dbo].[Contacts]"
                                                             + " VALUES(" + "\'" + IssuedToText.Text + "\',"
                                                                             + "\'" + Rolltext.Text + "\',"
                                                                             + "\'" + MobileText.Text + "\',"
                                                                             + "\'" + " " + "\',"
                                                                             + "\'" + DateTime.Now.ToShortDateString() + "\')";

                                    try
                                    {
                                        mySqlDataReader.Close();
                                        mySqlConnection.Close();
                                        mySqlConnection.Open();
                                        mySqlCommand.ExecuteNonQuery();
                                        MessageBox.Show("Contact Added in Log", "Update");
                                        mySqlConnection.Close();
                                        mySqlDataReader.Close();

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
                            catch (Exception e1)
                            {
                                MessageBox.Show(e1.Message);
                                mySqlConnection.Close();
                                mySqlDataReader.Close();
                                return;

                            }
                            //************************************************************ 
                            //*********************** CREATE REPORT OF ISSUE/Sell Product ***************************8
                            DialogResult RP = MessageBox.Show("Do You Want a Report For this transaction", "Alert", MessageBoxButtons.YesNo);

                            if (RP == DialogResult.Yes)
                            {
                                IssueReportForm IRF = new IssueReportForm(categoryCombo.Text, ModelText.Text, IssuedToText.Text,
                               Rolltext.Text, MobileText.Text, IssuedDateText.Text, DueDateText.Text, QuantityText.Text, PayementText.Text,
                               MOPcombo.Text, Issuecombo.Text, StatusText.Text,this.mcName);

                                this.Hide();
                                IRF.Show();
                            }

                            //*************************************************************************
                        }//Dialog result yes end

                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show(e1.Message);
                        mySqlConnection.Close();
                        mySqlDataReader.Close();

                        return;
                    }
                    mySqlConnection.Close();
                    mySqlDataReader.Close();


                }
            }

        }
        //*************************************************************************************************************
        private void Issue_form_Load(object sender, EventArgs e)
        {
            try
            {
                mySqlConnection = new SqlConnection(
                    "Data Source=" + this.mcName + "\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
              // "Data Source=TAIMOOR-PC\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
                IssuedDateText.Text = DateTime.Now.ToShortDateString();
                DueDateText.Text = DateTime.Now.ToShortDateString();
                ReturnText.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
        }
        //*************************************************************************************************************
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        //*************************************************************************************************************
        private void BackButton_Click(object sender, EventArgs e)
        {
            MainForm MainF = new MainForm(this.mcName);
            this.Hide();
            MainF.Show();
        }

        //*************************************************************************************************************
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            mySqlConnection.Close();
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            try
            {
                mySqlCommand.CommandText = "UPDATE [CRG_DATABASE].[dbo].[IssuanceForm]"
                                              + " SET "
                                              + "Category"        + "=\'" + categoryCombo.Text   + "\',"
                                              + "ModelNo"          + "=\'" + ModelText.Text       + "\',"
                                              + "IssuedSoldTo"     + "=\'" + IssuedToText.Text    + "\',"
                                              + "RollNo"           + "=\'"   + Rolltext.Text      + "\',"
                                              + "MobileNo"         + "=\'" + MobileText.Text      + "\',"
                                              + "IssuanceSoldDate" + "=\'" + IssuedDateText.Text  + "\',"
                                              + "DueDate"          + "=\'"  + DueDateText.Text    + "\',"
                                              + "ReturnDate"       + "=\'" + ReturnText.Text      + "\',"
                                              + "Quantity"         + "=" + QuantityText.Text      + " , "
                                              + "Payment"          + "= "  + PayementText.Text    + " , "
                                              + "IssuedSold"       + "=\'" + Issuecombo.Text      + "\',"
                                              + "ModeOfPayment"    + "=\'" + MOPcombo.Text        + "\',"
                                              + "Status"           + "=\'"   + StatusText.Text    + "\'"
                                              + " WHERE "
                                              + "Id" + "=" + IDtext.Text;

                DialogResult dr = MessageBox.Show("Do you want to update the record", "Attention", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    mySqlCommand.ExecuteNonQuery();
                    mySqlConnection.Close();
                    MessageBox.Show("Record Updated");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                 mySqlConnection.Close();
            }
        }

        //*************************************************************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        //*************************************************************************************************************
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DueDateText.Text = monthCalendar1.SelectionStart.AddDays(7).ToShortDateString();
            ReturnText.Text = monthCalendar1.SelectionStart.AddDays(7).ToShortDateString();
            IssuedDateText.Text = monthCalendar1.SelectionStart.ToShortDateString();
            monthCalendar1.Visible = true;
        }

//*************************************************************************************************************
        private void categoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            mySqlConnection.Close();
            mySqlConnection.Open();

            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;
            mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                     + "WHERE " + "Category" + "= \'" + categoryCombo.Text + "\'";


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

//*************************************************************************************************************
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

//**************************************************************************************************************
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mySqlConnection.Close();
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;

            int stock = 0;
            string payment = "0";
            mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[ProductLog]"
                                     + "WHERE " + "ModelNo" + "= \'" + listBox1.SelectedItem.ToString() + "\'";


            try
            {
                mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {

                    while (mySqlDataReader.Read())
                    {
                        stock = Convert.ToInt32(mySqlDataReader["Quantity"].ToString());
                        payment = mySqlDataReader["Sale"].ToString();

                    }
                    if (stock < 1)
                    {
                        MessageBox.Show(listBox1.SelectedItem.ToString() + " not available in stock");
                    }
                    else
                    {
                        MessageBox.Show(listBox1.SelectedItem.ToString() + " = " + stock.ToString() + " available in stock");
                        ModelText.Text = listBox1.SelectedItem.ToString();
                        PayementText.Text = payment;
                    }
                    mySqlConnection.Close();
                    mySqlDataReader.Close();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

//**********************************************************************************************************

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            mySqlConnection.Close();
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            SqlDataReader mySqlDataReader = null;
            mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[IssuanceForm]"
                                     + "WHERE " + "Id" + "= \'" + IDtext.Text + "\'";


            try
            {
                mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.HasRows)
                {

                    while (mySqlDataReader.Read())
                    {
                        categoryCombo.Text = mySqlDataReader["Category"].ToString();
                        ModelText.Text = mySqlDataReader["ModelNo"].ToString();
                        IssuedToText.Text = mySqlDataReader["IssuedSoldTo"].ToString();
                        Rolltext.Text = mySqlDataReader["RollNo"].ToString();
                        MobileText.Text = mySqlDataReader["MobileNo"].ToString();
                        IssuedDateText.Text = mySqlDataReader["IssuanceSoldDate"].ToString();
                        DueDateText.Text = mySqlDataReader["DueDate"].ToString();
                        ReturnText.Text = mySqlDataReader["ReturnDate"].ToString();
                        QuantityText.Text = mySqlDataReader["Quantity"].ToString();
                        PayementText.Text = mySqlDataReader["Payment"].ToString();
                        Issuecombo.Text = mySqlDataReader["IssuedSold"].ToString();
                        StatusText.Text = mySqlDataReader["Status"].ToString();
                    }
               
                }


                else
                {
                    MessageBox.Show("No Issue ID Found");
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