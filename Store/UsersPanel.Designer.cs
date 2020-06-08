namespace Store
{
    partial class UsersPanel
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BanBtn = new System.Windows.Forms.Button();
            this.Remove_Btn = new System.Windows.Forms.Button();
            this.MakeAdmin_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 26);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(268, 290);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users List:";
            // 
            // BanBtn
            // 
            this.BanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BanBtn.Location = new System.Drawing.Point(12, 353);
            this.BanBtn.Name = "BanBtn";
            this.BanBtn.Size = new System.Drawing.Size(253, 23);
            this.BanBtn.TabIndex = 2;
            this.BanBtn.Text = "Ban";
            this.BanBtn.UseVisualStyleBackColor = true;
            this.BanBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Remove_Btn
            // 
            this.Remove_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_Btn.Location = new System.Drawing.Point(12, 382);
            this.Remove_Btn.Name = "Remove_Btn";
            this.Remove_Btn.Size = new System.Drawing.Size(253, 23);
            this.Remove_Btn.TabIndex = 3;
            this.Remove_Btn.Text = "Remove";
            this.Remove_Btn.UseVisualStyleBackColor = true;
            this.Remove_Btn.Click += new System.EventHandler(this.Remove_Btn_Click);
            // 
            // MakeAdmin_Btn
            // 
            this.MakeAdmin_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MakeAdmin_Btn.Location = new System.Drawing.Point(12, 324);
            this.MakeAdmin_Btn.Name = "MakeAdmin_Btn";
            this.MakeAdmin_Btn.Size = new System.Drawing.Size(253, 23);
            this.MakeAdmin_Btn.TabIndex = 4;
            this.MakeAdmin_Btn.Text = "Make Admin";
            this.MakeAdmin_Btn.UseVisualStyleBackColor = true;
            this.MakeAdmin_Btn.Click += new System.EventHandler(this.MakeAdmin_Btn_Click);
            // 
            // UsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 417);
            this.Controls.Add(this.MakeAdmin_Btn);
            this.Controls.Add(this.Remove_Btn);
            this.Controls.Add(this.BanBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "UsersPanel";
            this.Text = "UsersPanel";
            this.Load += new System.EventHandler(this.UsersPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BanBtn;
        private System.Windows.Forms.Button Remove_Btn;
        private System.Windows.Forms.Button MakeAdmin_Btn;
    }
}