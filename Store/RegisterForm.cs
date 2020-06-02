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
    public partial class RegisterForm : Form
    {
        Database db = new Database();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Username.Text == "" || Password.Text == "" || Email.Text == "" || Address.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }else if (!Email.Text.Contains("@") || !Email.Text.Contains("."))
            {
                MessageBox.Show("Please enter an valid email address.");
                return;
            }

            db.Register(Username.Text, Password.Text, Email.Text, Address.Text);

            MessageBox.Show("Now you can login");

            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
