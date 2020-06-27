namespace crg
{
    partial class ProductLog
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
            this.components = new System.ComponentModel.Container();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.Manufacturerlabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.AcqDateLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.SaleLabel = new System.Windows.Forms.Label();
            this.QuantityLable = new System.Windows.Forms.Label();
            this.ownerLabel = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.manufacturerText = new System.Windows.Forms.TextBox();
            this.modelText = new System.Windows.Forms.TextBox();
            this.AcqDateText = new System.Windows.Forms.TextBox();
            this.costText = new System.Windows.Forms.TextBox();
            this.saleText = new System.Windows.Forms.TextBox();
            this.QuantityText = new System.Windows.Forms.TextBox();
            this.ownerText = new System.Windows.Forms.TextBox();
            this.commentsText = new System.Windows.Forms.TextBox();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.Addbutton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(25, 21);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 0;
            this.categoryLabel.Text = "Category";
            // 
            // Manufacturerlabel
            // 
            this.Manufacturerlabel.AutoSize = true;
            this.Manufacturerlabel.Location = new System.Drawing.Point(25, 46);
            this.Manufacturerlabel.Name = "Manufacturerlabel";
            this.Manufacturerlabel.Size = new System.Drawing.Size(70, 13);
            this.Manufacturerlabel.TabIndex = 1;
            this.Manufacturerlabel.Text = "Manufacturer";
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Location = new System.Drawing.Point(25, 68);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(53, 13);
            this.modelLabel.TabIndex = 2;
            this.modelLabel.Text = "Model No";
            // 
            // AcqDateLabel
            // 
            this.AcqDateLabel.AutoSize = true;
            this.AcqDateLabel.Location = new System.Drawing.Point(25, 92);
            this.AcqDateLabel.Name = "AcqDateLabel";
            this.AcqDateLabel.Size = new System.Drawing.Size(75, 13);
            this.AcqDateLabel.TabIndex = 3;
            this.AcqDateLabel.Text = "Acquired Date";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(25, 115);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(55, 13);
            this.CostLabel.TabIndex = 4;
            this.CostLabel.Text = "Cost Price";
            // 
            // SaleLabel
            // 
            this.SaleLabel.AutoSize = true;
            this.SaleLabel.Location = new System.Drawing.Point(25, 139);
            this.SaleLabel.Name = "SaleLabel";
            this.SaleLabel.Size = new System.Drawing.Size(55, 13);
            this.SaleLabel.TabIndex = 5;
            this.SaleLabel.Text = "Sale Price";
            // 
            // QuantityLable
            // 
            this.QuantityLable.AutoSize = true;
            this.QuantityLable.Location = new System.Drawing.Point(25, 162);
            this.QuantityLable.Name = "QuantityLable";
            this.QuantityLable.Size = new System.Drawing.Size(46, 13);
            this.QuantityLable.TabIndex = 6;
            this.QuantityLable.Text = "Quantity";
            // 
            // ownerLabel
            // 
            this.ownerLabel.AutoSize = true;
            this.ownerLabel.Location = new System.Drawing.Point(25, 187);
            this.ownerLabel.Name = "ownerLabel";
            this.ownerLabel.Size = new System.Drawing.Size(38, 13);
            this.ownerLabel.TabIndex = 7;
            this.ownerLabel.Text = "Owner";
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(25, 209);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(56, 13);
            this.commentLabel.TabIndex = 8;
            this.commentLabel.Text = "Comments";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(25, 242);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 9;
            this.DescriptionLabel.Text = "Description";
            // 
            // categoryCombo
            // 
            this.categoryCombo.FormattingEnabled = true;
            this.categoryCombo.Items.AddRange(new object[] {
            "Microcontrollers",
            "Motors and Actuators",
            "Components",
            "Drivers",
            "Sensors",
            "Development Board",
            "Pneumatic kit Items",
            "Miscellaneous",
            "Robotic Base"});
            this.categoryCombo.Location = new System.Drawing.Point(113, 18);
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(120, 21);
            this.categoryCombo.TabIndex = 10;
            // 
            // manufacturerText
            // 
            this.manufacturerText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manufacturerText.Location = new System.Drawing.Point(114, 43);
            this.manufacturerText.Name = "manufacturerText";
            this.manufacturerText.Size = new System.Drawing.Size(121, 20);
            this.manufacturerText.TabIndex = 11;
            // 
            // modelText
            // 
            this.modelText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.modelText.Location = new System.Drawing.Point(114, 65);
            this.modelText.Name = "modelText";
            this.modelText.Size = new System.Drawing.Size(121, 20);
            this.modelText.TabIndex = 12;
            // 
            // AcqDateText
            // 
            this.AcqDateText.Location = new System.Drawing.Point(114, 89);
            this.AcqDateText.Name = "AcqDateText";
            this.AcqDateText.Size = new System.Drawing.Size(121, 20);
            this.AcqDateText.TabIndex = 14;
            this.AcqDateText.Text = "2013-05-24";
            // 
            // costText
            // 
            this.costText.Location = new System.Drawing.Point(114, 112);
            this.costText.Name = "costText";
            this.costText.Size = new System.Drawing.Size(121, 20);
            this.costText.TabIndex = 13;
            this.costText.Text = "0";
            // 
            // saleText
            // 
            this.saleText.Location = new System.Drawing.Point(114, 134);
            this.saleText.Name = "saleText";
            this.saleText.Size = new System.Drawing.Size(121, 20);
            this.saleText.TabIndex = 18;
            this.saleText.Text = "0";
            // 
            // QuantityText
            // 
            this.QuantityText.Location = new System.Drawing.Point(114, 159);
            this.QuantityText.Name = "QuantityText";
            this.QuantityText.Size = new System.Drawing.Size(121, 20);
            this.QuantityText.TabIndex = 17;
            this.QuantityText.Text = "0";
            // 
            // ownerText
            // 
            this.ownerText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ownerText.Location = new System.Drawing.Point(114, 184);
            this.ownerText.Name = "ownerText";
            this.ownerText.Size = new System.Drawing.Size(121, 20);
            this.ownerText.TabIndex = 16;
            this.ownerText.Text = "CRG";
            // 
            // commentsText
            // 
            this.commentsText.Location = new System.Drawing.Point(114, 209);
            this.commentsText.Name = "commentsText";
            this.commentsText.Size = new System.Drawing.Size(121, 20);
            this.commentsText.TabIndex = 15;
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(28, 259);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(205, 52);
            this.descriptionText.TabIndex = 19;
            // 
            // Addbutton
            // 
            this.Addbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbutton.Location = new System.Drawing.Point(25, 326);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(75, 45);
            this.Addbutton.TabIndex = 20;
            this.Addbutton.Text = "Add";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.Location = new System.Drawing.Point(114, 326);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 45);
            this.BackButton.TabIndex = 23;
            this.BackButton.Text = "Close";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "YYYY-MM-DD";
            // 
            // ProductLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 387);
            this.ControlBox = false;
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.saleText);
            this.Controls.Add(this.QuantityText);
            this.Controls.Add(this.ownerText);
            this.Controls.Add(this.commentsText);
            this.Controls.Add(this.AcqDateText);
            this.Controls.Add(this.costText);
            this.Controls.Add(this.modelText);
            this.Controls.Add(this.manufacturerText);
            this.Controls.Add(this.categoryCombo);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.ownerLabel);
            this.Controls.Add(this.QuantityLable);
            this.Controls.Add(this.SaleLabel);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.AcqDateLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.Manufacturerlabel);
            this.Controls.Add(this.categoryLabel);
            this.Name = "ProductLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Log - CRG Inventory Management System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label Manufacturerlabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label AcqDateLabel;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label SaleLabel;
        private System.Windows.Forms.Label QuantityLable;
        private System.Windows.Forms.Label ownerLabel;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.TextBox manufacturerText;
        private System.Windows.Forms.TextBox modelText;
        private System.Windows.Forms.TextBox AcqDateText;
        private System.Windows.Forms.TextBox costText;
        private System.Windows.Forms.TextBox saleText;
        private System.Windows.Forms.TextBox QuantityText;
        private System.Windows.Forms.TextBox ownerText;
        private System.Windows.Forms.TextBox commentsText;
        private System.Windows.Forms.TextBox descriptionText;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

