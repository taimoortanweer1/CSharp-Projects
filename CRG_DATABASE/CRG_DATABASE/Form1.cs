using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; // <- for database methods

namespace CRG_DATABASE
{
    public partial class Form1 : Form
    {
        public OleDbConnection database;
        public Form1()
        {

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Work\database\crg.accdb";
            try
            {
                database = new OleDbConnection(connectionString);
                database.Open();
                MessageBox.Show("connection open");               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            InitializeComponent();
        }
    }
}
