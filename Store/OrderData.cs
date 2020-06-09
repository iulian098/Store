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
    public partial class OrderData : Form
    {
        public OrdersForm ordersForm;
        OrderItem order;
        UserData user;
        List<Items> items;
        List<int> stock = new List<int>();
        string[] orderItemsIDs;
        public OrderData()
        {
            InitializeComponent();
        }

        private void OrderData_Load(object sender, EventArgs e)
        {

        }

        public void Init(UserData _user, OrderItem _order)
        {
            items = Database.instance.GetItems();
            user = _user;
            order = _order;

            orderID_Text.Text = order.getID();
            Email_Text.Text = user.email;
            Address_Text.Text = user.address;
            User_Text.Text = user.username;

            orderItemsIDs = order.getItemsID().Split(',');

            foreach (string id in orderItemsIDs)
            {
                foreach(Items item in items)
                {
                    if(item.getID() == id)
                    {
                        itemsList.Items.Add(item.getID() + " | " + item.getName() + " | " + item.getPrice());
                    }
                }
            }

            for(int i =0; i<items.Count; i++)
            {
                stock.Add(Convert.ToInt32(items[i].getQuantity()));
            }
        }

        public void AcceptOrder()
        {
            List<string> ids = new List<string>();

            for(int i = 0; i < items.Count; i++)
            {
                if (!ids.Contains(items[i].getID()))
                    ids.Add(items[i].getID());
            }

            foreach (string id in orderItemsIDs)
            {
                for (int j =0; j < items.Count; j++)
                {
                    if (items[j].getID() == id)
                    {
                        stock[j]--;

                        if (stock[j] < 0)
                        {
                            MessageBox.Show("Out of stock", "Out of stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }

            for(int k = 0; k < items.Count; k++)
            {
                Database.instance.UpdateStock(items[k].getID(), stock[k].ToString());
            }

            Database.instance.RemoveOrder(order.getID());

            Console.WriteLine("Order accepted");
            ordersForm.RefreshOrders();
            this.Close();
        }

        void DeclineOrder()
        {
            Database.instance.RemoveOrder(order.getID());
            ordersForm.RefreshOrders();
            this.Close();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            AcceptOrder();
        }

        private void DeclineBtn_Click(object sender, EventArgs e)
        {
            DeclineOrder();
        }
    }
}
