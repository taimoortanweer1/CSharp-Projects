namespace crg
{
    partial class Contact
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.MobileLabel = new System.Windows.Forms.Label();
            this.RollLabel = new System.Windows.Forms.Label();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.MobileText = new System.Windows.Forms.TextBox();
            this.RollText = new System.Windows.Forms.TextBox();
            this.NotesText = new System.Windows.Forms.TextBox();
            this.Addbutton = new System.Windows.Forms.Button();
            this.Modifybutton = new System.Windows.Forms.Button();
            this.Backbutton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 24);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(54, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Full Name";
            // 
            // MobileLabel
            // 
            this.MobileLabel.AutoSize = true;
            this.MobileLabel.Location = new System.Drawing.Point(15, 55);
            this.MobileLabel.Name = "MobileLabel";
            this.MobileLabel.Size = new System.Drawing.Size(38, 13);
            this.MobileLabel.TabIndex = 3;
            this.MobileLabel.Text = "Mobile";
            // 
            // RollLabel
            // 
            this.RollLabel.AutoSize = true;
            this.RollLabel.Location = new System.Drawing.Point(16, 83);
            this.RollLabel.Name = "RollLabel";
            this.RollLabel.Size = new System.Drawing.Size(42, 13);
            this.RollLabel.TabIndex = 2;
            this.RollLabel.Text = "Roll No";
            // 
            // NotesLabel
            // 
            this.NotesLabel.AutoSize = true;
            this.NotesLabel.Location = new System.Drawing.Point(18, 119);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(35, 13);
            this.NotesLabel.TabIndex = 5;
            this.NotesLabel.Text = "Notes";
            // 
            // NameText
            // 
            this.NameText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NameText.Location = new System.Drawing.Point(111, 24);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(100, 20);
            this.NameText.TabIndex = 6;
            this.toolTip1.SetToolTip(this.NameText, "Enter Full Name");
            // 
            // MobileText
            // 
            this.MobileText.Location = new System.Drawing.Point(111, 52);
            this.MobileText.Name = "MobileText";
            this.MobileText.Size = new System.Drawing.Size(100, 20);
            this.MobileText.TabIndex = 8;
            this.toolTip1.SetToolTip(this.MobileText, "0092-XXX-XXXXXXX");
            // 
            // RollText
            // 
            this.RollText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RollText.Location = new System.Drawing.Point(111, 83);
            this.RollText.Name = "RollText";
            this.RollText.Size = new System.Drawing.Size(100, 20);
            this.RollText.TabIndex = 9;
            this.toolTip1.SetToolTip(this.RollText, "EXX-XXX");
            // 
            // NotesText
            // 
            this.NotesText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NotesText.Location = new System.Drawing.Point(111, 109);
            this.NotesText.Multiline = true;
            this.NotesText.Name = "NotesText";
            this.NotesText.Size = new System.Drawing.Size(100, 20);
            this.NotesText.TabIndex = 10;
            // 
            // Addbutton
            // 
            this.Addbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Addbutton.Location = new System.Drawing.Point(24, 259);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(51, 23);
            this.Addbutton.TabIndex = 11;
            this.Addbutton.Text = "Add";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // Modifybutton
            // 
            this.Modifybutton.Location = new System.Drawing.Point(81, 259);
            this.Modifybutton.Name = "Modifybutton";
            this.Modifybutton.Size = new System.Drawing.Size(52, 23);
            this.Modifybutton.TabIndex = 12;
            this.Modifybutton.Text = "Modify";
            this.Modifybutton.UseVisualStyleBackColor = true;
            // 
            // Backbutton
            // 
            this.Backbutton.Location = new System.Drawing.Point(139, 259);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(75, 23);
            this.Backbutton.TabIndex = 13;
            this.Backbutton.Text = "Back";
            this.Backbutton.UseVisualStyleBackColor = true;
            this.Backbutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 328);
            this.ControlBox = false;
            this.Controls.Add(this.Backbutton);
            this.Controls.Add(this.Modifybutton);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.NotesText);
            this.Controls.Add(this.RollText);
            this.Controls.Add(this.MobileText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.NotesLabel);
            this.Controls.Add(this.MobileLabel);
            this.Controls.Add(this.RollLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "Contact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact";
            this.Load += new System.EventHandler(this.Contact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label MobileLabel;
        private System.Windows.Forms.Label RollLabel;
        private System.Windows.Forms.Label NotesLabel;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox MobileText;
        private System.Windows.Forms.TextBox RollText;
        private System.Windows.Forms.TextBox NotesText;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Button Modifybutton;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}