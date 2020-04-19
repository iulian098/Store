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

        public string username;
        Database db = new Database();

        private List<string>[] items;

        public List<Panel> panels = new List<Panel>();
        UIOrder o = new UIOrder();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            items = db.GetItems();

            for (int i = 0; i < items[0].Count; i++)
            {
                Panel p = new Panel();
                MainPanel.Controls.Add(p);
                p.Name = "Item" + i;

                panels.Add(p);
                o.AddItems(p,items[0][i], items[1][i], items[3][i], items[2][i], items[4][i]);
            }
            o.OrderPanels(panels);
        }

        void RefreshItems()
        {
            MainPanel.Controls.Clear();
            panels.Clear();
            AddPanels();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginF = new LoginForm();
            loginF.MainForm = this;
            loginF.Show();

        }

        #region Login/Logout

        public void LoggedIn(string _username)
        {
            username = _username;
            Console.WriteLine("Username : " + username);

            if (db.CheckAdmin(_username))
            {
                User.Text = "User: " + _username + "(Admin)";
                AdminBtn.Visible = true;
            }
            else
            {
                User.Text = "User: " + _username;
            }
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
            AdminBtn.Visible = false;
        }

        #endregion

        public void RemoveFromCart(Items item)
        {
            CartItems.Remove(item);
        }

        public void CartNumber()
        {
            CartBtn.Text = "Cart(" + CartItems.Count + ")";
        }


        private void CartBtn_Click(object sender, EventArgs e)
        {
            CartForm cart = new CartForm();
            cart.Show();
            cart.SetItems(CartItems, this, username);
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            AdminPanel admin = new AdminPanel();
            admin.Show();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }
    }
}
