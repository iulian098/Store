using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class LoginForm : Form
    {
        public Form1 MainForm;
        Database db = new Database();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(db.Login(Username.Text, Password.Text))
            {
                MainForm.LoggedIn(Username.Text);
                this.Close();
            }
        }
    }
}
