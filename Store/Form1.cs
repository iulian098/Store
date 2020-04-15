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
    public partial class Form1 : Form
    {

        public List<Items> CartItems = new List<Items>();

        string username;
        Database db = new Database();

        private List<string>[] items;

        public List<Panel> panels = new List<Panel>();
        Order o = new Order();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            items = db.GetItems();
            AddPanels();
            Console.WriteLine(panels.Count);
            o.mainForm = this;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            o.GetFromSize();
            o.OrderPanels(panels);
        }

        void AddPanels()
        {
            for (int i = 0; i < items[0].Count; i++)
            {
                Panel p = new Panel();
                MainPanel.Controls.Add(p);
                p.Name = "Item" + i;

                panels.Add(p);
                o.AddItems(p, items[1][i], items[3][i], items[2][i]);
            }
            o.OrderPanels(panels);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginF = new LoginForm();
            loginF.MainForm = this;
            loginF.Show();

        }

        public void LoggedIn(string _username)
        {
            username = _username;
            User.Text = "User: " + _username;
            User.Visible = true;
            LoginBtn.Visible = false;
            LoginBtn.Enabled = false;
            LogoutBtn.Visible = true;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            username = "";
            User.Text = "";
            User.Visible = false;
            LoginBtn.Visible = true;
            LoginBtn.Enabled = true;
            LogoutBtn.Visible = false;
        }

        private void CartBtn_Click(object sender, EventArgs e)
        {
            CartForm cart = new CartForm();
            cart.Show();
            cart.SetItems(CartItems);
        }
    }
}
