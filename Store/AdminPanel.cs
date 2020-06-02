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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            UsersPanel users = new UsersPanel();
            users.Show();
        }

        private void ItemsBtn_Click(object sender, EventArgs e)
        {
            ItemsPanel items = new ItemsPanel();
            items.Show();
        }
    }
}
