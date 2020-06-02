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
    public partial class ItemsPanel : Form
    {

        Database db = new Database();
        List<Items> items = new List<Items>();
        Items selectedItem;
        int selectedIndex;
        public ItemsPanel()
        {
            InitializeComponent();
        }

        private void ItemsPanel_Load(object sender, EventArgs e)
        {
            
            db.InitializeAdmin();
            RefreshItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.UpdateItems(selectedItem.getID(), itemName.Text, Price.Text, Stock.Text);
            RefreshItems();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = items[listBox1.SelectedIndex];
            selectedIndex = listBox1.SelectedIndex;
            itemName.Text = selectedItem.getName();
            Price.Text = selectedItem.getPrice();
            Stock.Text = selectedItem.getQuantity();
            ImageURL.Text = selectedItem.getImage();
        }

        public void RefreshItems()
        {
            items.Clear();
            listBox1.Items.Clear();
            items = db.GetAdminItems();

            foreach (Items item in items)
            {
                listBox1.Items.Add("ID: " + item.getID() + " | Name: " + item.getName() + " | Stock: " + item.getQuantity() + " | Price: " + item.getPrice());
            }

            if (listBox1.Items.Count - 1 >= selectedIndex)
                listBox1.SelectedIndex = selectedIndex;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            db.RemoveItems(selectedItem.getID());
            RefreshItems();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddProduct product = new AddProduct();
            product.admin = this;
            product.Show();
        }

        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            /*Console.WriteLine("Mouse pos: " + e.X + ", Target position = " + (panel1.Size.Width - 5).ToString());
            if(e.X > panel1.Size.Width - 5 && e.X < panel1.Size.Width + 5)
            {
                this.Cursor = Cursors.SizeWE;
                if(e.Button == MouseButtons.Left)
                {
                    panel1.Size = new Size(e.X, panel1.Size.Height);
                }
                else
                {
                    //Set anchor
                    panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }*/
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
