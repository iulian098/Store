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
    public partial class AddProduct : Form
    {
        public AdminPanel admin;

        Database db = new Database();
        List<Items> items = new List<Items>();
        int newID = 0;
        bool exists = true;
        List<string> IDs = new List<string>();


        public AddProduct()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            db.InitializeAdmin();
            items = db.GetAdminItems();
            foreach(Items item in items)
            {
                IDs.Add(item.getID());
            }

            while (exists)
            {
                newID++;
                if (!IDs.Contains(newID.ToString()))
                {
                    exists = false;
                }
            }

            ID.Text = newID.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            db.AddItem(ID.Text, NameText.Text, Price.Text, Quantity.Text, Image.Text);
            admin.RefreshItems();
            this.Close();
        }

        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
