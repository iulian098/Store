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
    public partial class OrdersForm : Form
    {
        List<UserData> users = new List<UserData>();
        List<OrderItem> orders = new List<OrderItem>();

        OrderItem selectedOrder = null;
        UserData selectedUser = null;
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadingData();
        }

        void LoadingData()
        {
            users = Database.instance.getUsersData();
            orders = Database.instance.getOrders();

            foreach(OrderItem od in orders)
            {
                listBox1.Items.Add(od.getID() + " | " + od.getItemsID());
            }
        }

        private void OpenOrder_btn_Click(object sender, EventArgs e)
        {
            OrderData orderData = new OrderData();
            orderData.Init(selectedUser, selectedOrder);
            orderData.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOrder = orders[listBox1.SelectedIndex];
            selectedUser = getOrderUser(Convert.ToInt32(selectedOrder.getUserID()));
        }

        UserData getOrderUser(int id)
        {
            foreach(UserData ud in users)
            {
                if (ud.ID == id)
                    return ud;
            }

            return null;
        }
    }
}
