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
    public partial class Contact : Form
    {
         SqlConnection mySqlConnection;
         private string mcName;
        public Contact()
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

        public Contact(string mcName)
        {
            // TODO: Complete member initialization
            this.mcName = mcName;
            InitializeComponent();
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

        private void Addbutton_Click(object sender, EventArgs e)
        {
            mySqlConnection.Open();
            SqlCommand add;
            if (NameText.Text == "" || RollText.Text == "" || MobileText.Text == "")
            {
                mySqlConnection.Close();
                MessageBox.Show("Enter Necessary Fields");
            }
            else
            {
                //************Adding data in Contact Table ************************
                try
                {
                    add = new SqlCommand("INSERT INTO [CRG_DATABASE].[dbo].[Contacts]"
                                                       + " VALUES(" + "\'" + NameText.Text + "\',"
                                                                       + "\'" + RollText.Text + "\',"
                                                                       + "\'" + MobileText.Text + "\',"
                                                                       + "\'" + NotesLabel.Text + "\',"
                                                                       + "\'" + DateTime.Now.ToShortDateString() + "\')", mySqlConnection);
                    DialogResult dr = MessageBox.Show("Do You want to add these Details in Contact", "Alert", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        add.ExecuteNonQuery();
                        MessageBox.Show("Contact Updated in Log", "Successful Update");
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

        private void Contact_Load(object sender, EventArgs e)
        {
           
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            MainForm MainF = new MainForm(this.mcName);
            this.Hide();
            MainF.Show();
        }
    }
}
