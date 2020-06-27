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
    public partial class Login_Form : Form
    {
        SqlConnection mySqlConnection;
        string mcName = "";
        public Login_Form()
        {
           
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

             mcName = textBox3.Text =  System.Environment.MachineName.ToString();
            
            try
            {
                mySqlConnection = new SqlConnection(
                 "Data Source="+mcName+"\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
              // "Data Source=TAIMOOR-PC\\SQLEXPRESS;Initial Catalog=CRG_DATABASE;Integrated Security=True");
              
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand mySqlCommand;
            SqlDataReader mySqlDataReader = null;
            try
            {
                mySqlConnection.Open();
              mySqlCommand = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = "SELECT * " + "FROM [CRG_DATABASE].[dbo].[Login]"
                                         + " WHERE UserName = \'" + textBox1.Text + "\' AND Password = \'" + textBox2.Text +"\'";

                 mySqlDataReader = mySqlCommand.ExecuteReader();
                 if (mySqlDataReader.HasRows)
                 {
                     mySqlConnection.Close();
                     mySqlDataReader.Close();
                     MainForm MF = new MainForm(mcName);
                     this.Hide();
                     MF.Show();
                 }
                 else
                 {
                     MessageBox.Show("Incorrect UserName or Password");
                     mySqlConnection.Close();
                     mySqlDataReader.Close();
                 }
                           

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
