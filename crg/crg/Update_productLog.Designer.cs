namespace crg
{
    partial class Update_productLog
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
            this.label3 = new System.Windows.Forms.Label();
            this.Searchbycombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Searchbutton = new System.Windows.Forms.Button();
            this.Closebutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.modelText = new System.Windows.Forms.TextBox();
            this.modelLabel = new System.Windows.Forms.Label();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.saleText = new System.Windows.Forms.TextBox();
            this.QuantityText = new System.Windows.Forms.TextBox();
            this.AcqDateText = new System.Windows.Forms.TextBox();
            this.costText = new System.Windows.Forms.TextBox();
            this.QuantityLable = new System.Windows.Forms.Label();
            this.SaleLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.AcqDateLabel = new System.Windows.Forms.Label();
            this.Updatebutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Search By";
            // 
            // Searchbycombo
            // 
            this.Searchbycombo.FormattingEnabled = true;
            this.Searchbycombo.Items.AddRange(new object[] {
            "Microcontrollers",
            "Motors and Actuators",
            "Components",
            "Drivers",
            "Sensors",
            "Development Board",
            "Pneumatic kit Items",
            "Miscellaneous",
            "Robotic Base"});
            this.Searchbycombo.Location = new System.Drawing.Point(169, 36);
            this.Searchbycombo.Name = "Searchbycombo";
            this.Searchbycombo.Size = new System.Drawing.Size(168, 21);
            this.Searchbycombo.TabIndex = 6;
            this.Searchbycombo.SelectedIndexChanged += new System.EventHandler(this.Searchbycombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Enter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Searchbutton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(64, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Criteria";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(104, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 68);
            this.listBox1.TabIndex = 1;
            // 
            // Searchbutton
            // 
            this.Searchbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbutton.Location = new System.Drawing.Point(105, 128);
            this.Searchbutton.Name = "Searchbutton";
            this.Searchbutton.Size = new System.Drawing.Size(97, 40);
            this.Searchbutton.TabIndex = 0;
            this.Searchbutton.Text = "Search";
            this.Searchbutton.UseVisualStyleBackColor = true;
            this.Searchbutton.Click += new System.EventHandler(this.Searchbutton_Click);
            // 
            // Closebutton
            // 
            this.Closebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closebutton.Location = new System.Drawing.Point(19, 152);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(97, 40);
            this.Closebutton.TabIndex = 9;
            this.Closebutton.Text = "Back";
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.modelText);
            this.groupBox2.Controls.Add(this.Closebutton);
            this.groupBox2.Controls.Add(this.modelLabel);
            this.groupBox2.Controls.Add(this.Deletebutton);
            this.groupBox2.Controls.Add(this.saleText);
            this.groupBox2.Controls.Add(this.QuantityText);
            this.groupBox2.Controls.Add(this.AcqDateText);
            this.groupBox2.Controls.Add(this.costText);
            this.groupBox2.Controls.Add(this.QuantityLable);
            this.groupBox2.Controls.Add(this.SaleLabel);
            this.groupBox2.Controls.Add(this.CostLabel);
            this.groupBox2.Controls.Add(this.AcqDateLabel);
            this.groupBox2.Controls.Add(this.Updatebutton);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(64, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 196);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Updated Data";
            // 
            // modelText
            // 
            this.modelText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.modelText.Location = new System.Drawing.Point(122, 30);
            this.modelText.Name = "modelText";
            this.modelText.Size = new System.Drawing.Size(176, 24);
            this.modelText.TabIndex = 14;
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelLabel.Location = new System.Drawing.Point(11, 33);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(73, 18);
            this.modelLabel.TabIndex = 13;
            this.modelLabel.Text = "Model No";
            // 
            // Deletebutton
            // 
            this.Deletebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebutton.Location = new System.Drawing.Point(225, 152);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(97, 40);
            this.Deletebutton.TabIndex = 27;
            this.Deletebutton.Text = "Delete";
            this.Deletebutton.UseVisualStyleBackColor = true;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // saleText
            // 
            this.saleText.Location = new System.Drawing.Point(123, 104);
            this.saleText.Name = "saleText";
            this.saleText.Size = new System.Drawing.Size(175, 24);
            this.saleText.TabIndex = 26;
            this.saleText.Text = "0";
            // 
            // QuantityText
            // 
            this.QuantityText.Location = new System.Drawing.Point(123, 129);
            this.QuantityText.Name = "QuantityText";
            this.QuantityText.Size = new System.Drawing.Size(175, 24);
            this.QuantityText.TabIndex = 25;
            this.QuantityText.Text = "0";
            // 
            // AcqDateText
            // 
            this.AcqDateText.Location = new System.Drawing.Point(123, 56);
            this.AcqDateText.Name = "AcqDateText";
            this.AcqDateText.Size = new System.Drawing.Size(175, 24);
            this.AcqDateText.TabIndex = 24;
            // 
            // costText
            // 
            this.costText.Location = new System.Drawing.Point(122, 80);
            this.costText.Name = "costText";
            this.costText.Size = new System.Drawing.Size(176, 24);
            this.costText.TabIndex = 23;
            this.costText.Text = "0";
            // 
            // QuantityLable
            // 
            this.QuantityLable.AutoSize = true;
            this.QuantityLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityLable.Location = new System.Drawing.Point(7, 129);
            this.QuantityLable.Name = "QuantityLable";
            this.QuantityLable.Size = new System.Drawing.Size(62, 18);
            this.QuantityLable.TabIndex = 22;
            this.QuantityLable.Text = "Quantity";
            // 
            // SaleLabel
            // 
            this.SaleLabel.AutoSize = true;
            this.SaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaleLabel.Location = new System.Drawing.Point(7, 106);
            this.SaleLabel.Name = "SaleLabel";
            this.SaleLabel.Size = new System.Drawing.Size(75, 18);
            this.SaleLabel.TabIndex = 21;
            this.SaleLabel.Text = "Sale Price";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostLabel.Location = new System.Drawing.Point(7, 82);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(78, 18);
            this.CostLabel.TabIndex = 20;
            this.CostLabel.Text = "Cost Price";
            // 
            // AcqDateLabel
            // 
            this.AcqDateLabel.AutoSize = true;
            this.AcqDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcqDateLabel.Location = new System.Drawing.Point(7, 59);
            this.AcqDateLabel.Name = "AcqDateLabel";
            this.AcqDateLabel.Size = new System.Drawing.Size(100, 18);
            this.AcqDateLabel.TabIndex = 19;
            this.AcqDateLabel.Text = "Acquired Date";
            // 
            // Updatebutton
            // 
            this.Updatebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Updatebutton.Location = new System.Drawing.Point(122, 152);
            this.Updatebutton.Name = "Updatebutton";
            this.Updatebutton.Size = new System.Drawing.Size(97, 40);
            this.Updatebutton.TabIndex = 0;
            this.Updatebutton.Text = "Update";
            this.Updatebutton.UseVisualStyleBackColor = true;
            this.Updatebutton.Click += new System.EventHandler(this.Updatebutton_Click);
            // 
            // Update_productLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 422);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Searchbycombo);
            this.Controls.Add(this.groupBox1);
            this.Name = "Update_productLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Log Update - CRG Inventory Management System";
            this.Load += new System.EventHandler(this.Update_productLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Searchbycombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.Button Searchbutton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Updatebutton;
        private System.Windows.Forms.TextBox saleText;
        private System.Windows.Forms.TextBox QuantityText;
        private System.Windows.Forms.TextBox AcqDateText;
        private System.Windows.Forms.TextBox costText;
        private System.Windows.Forms.Label QuantityLable;
        private System.Windows.Forms.Label SaleLabel;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label AcqDateLabel;
        private System.Windows.Forms.TextBox modelText;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.ListBox listBox1;
    }
}