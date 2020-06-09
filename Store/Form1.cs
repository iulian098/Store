using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace Store
{
    public partial class Form1 : Form
    {
        public bool AutoLogin;
        public List<Items> CartItems = new List<Items>();

        public string username;
        Database db = new Database();

        private List<Items> items;

        public List<Panel> panels = new List<Panel>();
        UIOrder o = new UIOrder();
        int ordersCount;

        public bool LoggedInStatus;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddPanels();
            Console.WriteLine(panels.Count);
            o.mainForm = this;

            string[] userData = LoadData();

            if (userData != null && Convert.ToBoolean(userData[0]) && db.Login(userData[1], userData[2]))
            {
                Console.WriteLine("Auto logged in.");
                LoggedIn(userData[1]);
            }
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            o.GetFromSize();
            o.OrderPanels(panels);
        }


        void AddPanels()
        {
            items = db.GetItems();

            for (int i = 0; i < items.Count; i++)
            {
                Panel p = new Panel();
                MainPanel.Controls.Add(p);
                p.Name = "Item" + i;

                panels.Add(p);
                o.AddItems(p,items[i].getID(),items[i].getName(), items[i].getImage(), items[i].getPrice(), items[i].getQuantity());
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
                OrdersBtn.Visible = true;
                RefreshOrdersTimer.Enabled = true;
            }
            else
            {
                User.Text = "User: " + _username;
                RefreshOrdersTimer.Enabled = false;
            }
            User.Visible = true;
            LoginBtn.Visible = false;
            LoginBtn.Enabled = false;
            LogoutBtn.Visible = true;
            LoggedInStatus = true;
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
            OrdersBtn.Visible = false;
            AutoLogin = false;
            RefreshOrdersTimer.Enabled = false;
            LoggedInStatus = false;
            SaveData("", "");
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

        public void SaveData(string user, string password)
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string _file = CurrentDirectory + "/data.dat";

            File.WriteAllText(_file, AutoLogin + "," + user + "," + password);
        }

        public string[] LoadData()
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string _file = CurrentDirectory + "/data.dat";
            if (File.Exists(_file))
            {
                string _FileData = File.ReadAllText(_file);
                string[] _data = _FileData.Split(',');
                foreach(string d in _data)
                    Console.WriteLine(d);
                return _data;
            }
            return null;
        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.Show();
        }

        private void RefreshOrdersTimer_Tick(object sender, EventArgs e)
        {
            ordersCount = Database.instance.GetOrdersCount();
            OrdersBtn.Text = "Orders(" + ordersCount.ToString() + ")";
        }
    }
}
