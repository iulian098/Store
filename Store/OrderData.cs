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

        OrderItem order;
        UserData user;
        List<Items> items;
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
        }
    }
}
