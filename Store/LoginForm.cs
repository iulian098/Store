using System;
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
                if (MainForm.AutoLogin)
                    MainForm.SaveData(Username.Text, Password.Text);
                MainForm.LoggedIn(Username.Text);
                this.Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void RememberCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.AutoLogin = RememberCheckbox.Checked;
        }
    }
}
