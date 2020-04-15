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
        Panel itemsContainer;
        float itemPanelHeight = 50;

        List<Items> items = new List<Items>();
        
        public void Init(List<Items> list, CartForm cf, Panel container)
        {
            items = list;
            form = cf;
            itemsContainer = container;
            Console.WriteLine("Get " + items.Count + " from " + list.Count + " items");
            AddItems();
        }

        public void AddItems()
        {
            int counter = 0;
            foreach(Items item in items)
            {

                //Configure itemPanel
                Panel itemPanel = new Panel();
                
                itemPanel.Size = new Size(itemsContainer.Width / 2, (int)itemPanelHeight);
                itemPanel.Anchor = AnchorStyles.Left;
                itemPanel.Location = new Point(itemsContainer.Width / 2, (int)(itemPanelHeight * counter));

                //Configure pictureBox
                PictureBox picture = new PictureBox();

                picture.Anchor = AnchorStyles.Left;
                picture.ImageLocation = item.getImage();
                picture.Size = new Size(50, 50);
                picture.Location = new Point(-(itemPanel.Width/2), 0);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                //Configure name
                Label name = new Label();

                name.Text = item.getName();
                name.Size = new Size(50, 15);
                name.Location = new Point(picture.Width + name.Width / 2 + 5, 10);

                //Configure price
                Label price = new Label();

                price.Text = item.getPrice();
                price.Size = new Size(50, 15);
                price.Location = new Point(name.Location.X, 35);

                //Add items to panel
                itemPanel.Controls.Add(picture);
                itemPanel.Controls.Add(name);
                itemPanel.Controls.Add(price);

                //Add items to main panel
                itemsContainer.Controls.Add(itemPanel);


                counter++;
                Console.WriteLine("Item " + item.getName() + " with price " + item.getPrice() + " image:" + item.getImage() +  " added");
            }

            counter = 0;
        }
    }
}
