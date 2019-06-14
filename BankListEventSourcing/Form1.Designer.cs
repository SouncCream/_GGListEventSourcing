namespace BankListEventSourcing
{
    partial class Form1
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
            this.ConsoleTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectESBtn = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.CountyTxt = new System.Windows.Forms.TextBox();
            this.SatatusComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.IdTxt = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConsoleTxt
            // 
            this.ConsoleTxt.Location = new System.Drawing.Point(12, 264);
            this.ConsoleTxt.Multiline = true;
            this.ConsoleTxt.Name = "ConsoleTxt";
            this.ConsoleTxt.ReadOnly = true;
            this.ConsoleTxt.Size = new System.Drawing.Size(489, 130);
            this.ConsoleTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Console";
            // 
            // ConnectESBtn
            // 
            this.ConnectESBtn.Location = new System.Drawing.Point(426, 12);
            this.ConnectESBtn.Name = "ConnectESBtn";
            this.ConnectESBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectESBtn.TabIndex = 2;
            this.ConnectESBtn.Text = "Connect";
            this.ConnectESBtn.UseVisualStyleBackColor = true;
            this.ConnectESBtn.Click += new System.EventHandler(this.ConnectESBtn_Click);
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(69, 42);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(121, 20);
            this.nameTxt.TabIndex = 3;
            // 
            // CountyTxt
            // 
            this.CountyTxt.Location = new System.Drawing.Point(69, 68);
            this.CountyTxt.Name = "CountyTxt";
            this.CountyTxt.Size = new System.Drawing.Size(121, 20);
            this.CountyTxt.TabIndex = 4;
            // 
            // SatatusComboBox
            // 
            this.SatatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SatatusComboBox.FormattingEnabled = true;
            this.SatatusComboBox.Location = new System.Drawing.Point(69, 94);
            this.SatatusComboBox.Name = "SatatusComboBox";
            this.SatatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.SatatusComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(115, 121);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 9;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // IdTxt
            // 
            this.IdTxt.AutoSize = true;
            this.IdTxt.Location = new System.Drawing.Point(12, 12);
            this.IdTxt.Name = "IdTxt";
            this.IdTxt.Size = new System.Drawing.Size(43, 13);
            this.IdTxt.TabIndex = 11;
            this.IdTxt.Text = "Id (Edit)";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(69, 12);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(303, 20);
            this.textId.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 406);
            this.Controls.Add(this.IdTxt);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SatatusComboBox);
            this.Controls.Add(this.CountyTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.ConnectESBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConsoleTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ConsoleTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectESBtn;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox CountyTxt;
        private System.Windows.Forms.ComboBox SatatusComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label IdTxt;
        private System.Windows.Forms.TextBox textId;
    }
}

