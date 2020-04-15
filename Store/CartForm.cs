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
        List<Items> items = new List<Items>();
        Cart cart = new Cart();
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            
        }

        public void SetItems(List<Items> list, Form1 f)
        {
            items = list;
            Console.WriteLine("Items in cart : " + items.Count);
            cart.Init(items, this, f, panel1);
            SetTotalPrice(cart.GetTotalPrice());
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
            this.Close();
        }

        
    }
}
