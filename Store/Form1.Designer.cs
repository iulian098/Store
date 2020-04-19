namespace Store
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.CartBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.User = new System.Windows.Forms.Label();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.AdminBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoScroll = true;
            this.MainPanel.Location = new System.Drawing.Point(12, 41);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(561, 415);
            this.MainPanel.TabIndex = 0;
            // 
            // CartBtn
            // 
            this.CartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CartBtn.Location = new System.Drawing.Point(502, 12);
            this.CartBtn.Name = "CartBtn";
            this.CartBtn.Size = new System.Drawing.Size(71, 23);
            this.CartBtn.TabIndex = 1;
            this.CartBtn.Text = "Cart(0)";
            this.CartBtn.UseVisualStyleBackColor = true;
            this.CartBtn.Click += new System.EventHandler(this.CartBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(12, 12);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 2;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // User
            // 
            this.User.AutoSize = true;
            this.User.Location = new System.Drawing.Point(93, 17);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(58, 13);
            this.User.TabIndex = 3;
            this.User.Text = "User:asdfg";
            this.User.Visible = false;
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Location = new System.Drawing.Point(12, 12);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(75, 23);
            this.LogoutBtn.TabIndex = 4;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Visible = false;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // AdminBtn
            // 
            this.AdminBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AdminBtn.Location = new System.Drawing.Point(340, 12);
            this.AdminBtn.Name = "AdminBtn";
            this.AdminBtn.Size = new System.Drawing.Size(75, 23);
            this.AdminBtn.TabIndex = 5;
            this.AdminBtn.Text = "Admin panel";
            this.AdminBtn.UseVisualStyleBackColor = true;
            this.AdminBtn.Visible = false;
            this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshBtn.Location = new System.Drawing.Point(421, 12);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshBtn.TabIndex = 6;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 468);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.AdminBtn);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.User);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.CartBtn);
            this.Controls.Add(this.MainPanel);
            this.MinimumSize = new System.Drawing.Size(416, 288);
            this.Name = "Form1";
            this.Text = "Store";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button CartBtn;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label User;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.Button AdminBtn;
        private System.Windows.Forms.Button RefreshBtn;
    }
}

