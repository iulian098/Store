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
        List<Items> items = new List<Items>();
        Cart cart = new Cart();
        public CartForm()
        {
            InitializeComponent();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            
        }

        public void SetItems(List<Items> list)
        {
            items = list;
            Console.WriteLine("Items in cart : " + items.Count);
            cart.Init(items, this, panel1);

            cart.AddItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
