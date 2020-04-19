using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Store
{
    class Cart
    {
        CartForm form;
        Form1 mainForm;
        Panel itemsContainer;
        string username;
        float itemPanelHeight = 50;

        List<Items> items = new List<Items>();
        
        public void Init(List<Items> list, CartForm cf, Form1 mf, Panel container, string _username)
        {
            items = list;
            form = cf;
            mainForm = mf;
            itemsContainer = container;
            username = _username;
            AddItems();
        }

        //Create items
        public void AddItems()
        {
            int counter = 0;
            foreach(Items item in items)
            {

                //Configure itemPanel
                Panel itemPanel = new Panel();
                
                itemPanel.Size = new Size(itemsContainer.Width / 2, (int)itemPanelHeight);
                itemPanel.Anchor = AnchorStyles.Left;
                itemPanel.Location = new Point(0, (int)(itemPanelHeight * counter));
                itemPanel.Dock = DockStyle.Top;

                //Configure pictureBox
                PictureBox picture = new PictureBox();

                picture.Anchor = AnchorStyles.Left;
                picture.ImageLocation = item.getImage();
                picture.Size = new Size(50, 50);
                picture.Location = new Point(0, 0);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                //Configure name
                Label name = new Label();

                name.Text = item.getName();
                name.Size = new Size(100, 15);
                name.Location = new Point(picture.Width + name.Width / 2 + 5, 10);

                //Configure price
                Label price = new Label();

                price.Text = "Price: " + item.getPrice();
                price.Size = new Size(100, 15);
                price.Location = new Point(name.Location.X, 35);

                //Configure button
                Button removeBtn = new Button();

                removeBtn.Text = "Remove";
                removeBtn.Anchor = AnchorStyles.Right;
                removeBtn.Size = new Size(95, 25);
                removeBtn.Location = new Point(itemPanel.Width - removeBtn.Width, itemPanel.Height/2 - removeBtn.Height/2);
                removeBtn.Click += delegate (object sender, EventArgs e)
                {
                    itemsContainer.Controls.Remove(itemPanel);
                    items.Remove(item);
                    form.RemoveItem(item);
                    mainForm.RemoveFromCart(item);

                    form.SetTotalPrice(GetTotalPrice());
                    mainForm.CartNumber();

                };


                //Add items to panel
                itemPanel.Controls.Add(removeBtn);
                itemPanel.Controls.Add(picture);
                itemPanel.Controls.Add(name);
                itemPanel.Controls.Add(price);

                //Add items to main panel
                itemsContainer.Controls.Add(itemPanel);


                counter++;
            }
        }

        public int GetTotalPrice()
        {
            int price = 0;

            foreach(Items item in items)
            {
                price += int.Parse(item.getPrice());
            }

            return price;
        }


    }
}
