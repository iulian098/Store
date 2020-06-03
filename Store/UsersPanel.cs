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
    public partial class UsersPanel : Form
    {
        byte ban = 0b0;
        List<string> users = new List<string>();
        public UsersPanel()
        {
            InitializeComponent();
        }

        private void UsersPanel_Load(object sender, EventArgs e)
        {
            RefreshUsersList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                if (listBox1.SelectedItem.ToString().Contains("(Banned)"))
                {
                    Console.WriteLine(listBox1.SelectedItem.ToString() + " Unbanned");
                    Database.instance.BanUser(listBox1.SelectedItem.ToString().Replace(" (Banned)", ""), 0b0);
                }
                else
                {
                    Console.WriteLine(listBox1.SelectedItem.ToString() + " Banned");
                    Database.instance.BanUser(listBox1.SelectedItem.ToString(), 0b1);
                }
                
            }
            RefreshUsersList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Contains("(Banned)"))
                BanBtn.Text = "Unban";
            else
                BanBtn.Text = "Ban";
        }

        private void RefreshUsersList()
        {
            Database.instance.InitializeAdmin();
            users = Database.instance.getUsers();
            listBox1.Items.Clear();
            foreach (string s in users)
            {
                Console.WriteLine("User : " + s);
                listBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
