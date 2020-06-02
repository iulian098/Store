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
    public partial class CartForm : Form
    {
        Form1 mainForm;
        string username;
        List<Items> items = new List<Items>();
        Cart cart = new Cart();
        Database db = new Database();
        int userID;
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            
        }

        public void SetItems(List<Items> list, Form1 f, string _username)
        {
            items = list;
            username = _username;
            Console.WriteLine("Items in cart : " + items.Count);
            cart.Init(list, this, f, panel1, _username);
            SetTotalPrice(cart.GetTotalPrice());
            userID = db.getUserID(username);
        }

        public void SetTotalPrice(int price)
        {
            TotalPrice.Text = "Total price: " + cart.GetTotalPrice();
        }

        public void RemoveItem(Items item)
        {
            items.Remove(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string items_id = "";

            for(int i = 0; i < items.Count; i++)
            {
                if (i < items.Count - 1)
                {
                    items_id += items[i].getID() + ",";
                }
                else
                {
                    items_id += items[i].getID();
                }
            }

            db.AddOrder(items_id, userID);
            this.Close();
        }



        
    }
}
