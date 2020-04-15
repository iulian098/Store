using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Store
{
    class Order
    {
        public Form1 mainForm;

        float TopMargin = 3f;
        float LeftMargin = 3f;
        int PanelX = 125, PanelY = 150;
        int FormX, FormY;

        int MaxRowItems;

        int ItemCount;
        int RowCount;

        public void OrderPanels(List<Panel> panels)
        {

            GetFromSize();

            foreach(Panel p in panels)
            {

                Random r = new Random();
                
                p.Size = new Size(PanelX, PanelY);

                p.Size = new Size(PanelX, PanelY);

                if(ItemCount == MaxRowItems)
                {
                    ItemCount = 0;
                    RowCount++;
                }

                p.Location = new Point((int)(ItemCount * (PanelX + LeftMargin)),
                    (int)(RowCount * (PanelY + TopMargin)));
                Console.WriteLine(p.Location);
                ItemCount++;
            }

            Reset();
        }

        public void GetFromSize()
        {
            
            Form form1 = Application.OpenForms["Form1"];

            FormX = form1.Size.Width;
            FormY = form1.Size.Height;
            Console.WriteLine("X:" + FormX + " Y:" + FormY);

            float MaxItemsPerRow = FormX / (PanelX + LeftMargin);
            MaxRowItems = (int)MaxItemsPerRow;
            Console.WriteLine("Max items per row:" + MaxRowItems);
        }

        public void AddItems(Panel panel, string name, string image, string price)
        {
            //Create
            Button btn = new Button();
            PictureBox img = new PictureBox();
            Label _name = new Label();
            Label _price = new Label();
            
            //Add button
            btn.Text = "Add to cart";
            btn.Size = new Size(panel.Size.Width/2, 25);
            btn.Anchor = AnchorStyles.Bottom;
            btn.Location = new Point((panel.Width/2)-(btn.Width/2),panel.Height - btn.Height);
            btn.Click += delegate(object sender, EventArgs e) {
                Items itm = new Items(name, price, image);
                mainForm.CartItems.Add(itm);
                Console.WriteLine(itm.getName() + " price:" + itm.getPrice() + " image:" + itm.getImage());
                Console.WriteLine("Items in cart:" + mainForm.CartItems.Count());
                mainForm.CartNumber();
            };

            //Add image
            img.Anchor = AnchorStyles.Top;
            img.ImageLocation = image;
            img.Size = new Size(panel.Width/2, panel.Height - btn.Height);
            img.Location = new Point(panel.Width/2 - img.Width/2, 0);
            img.SizeMode = PictureBoxSizeMode.StretchImage;

            //Add name
            _name.Size = new Size(panel.Width / 2, 15);
            _name.Location = new Point(panel.Width / 2 - _name.Width / 2, panel.Height - 60);
            _name.Text = name;
            _name.TextAlign = ContentAlignment.MiddleCenter;
            _name.Anchor = AnchorStyles.Bottom;

            //Add price
            _price.Size = new Size(panel.Width / 2, 15);
            _price.Location = new Point(panel.Width / 2 - _name.Width / 2, panel.Height - 40);
            _price.Text = "Price:" + price;
            _price.TextAlign = ContentAlignment.MiddleCenter;
            _price.Anchor = AnchorStyles.Bottom;

            //Add to panel
            panel.Controls.Add(_price);
            panel.Controls.Add(_name);
            panel.Controls.Add(img);
            panel.Controls.Add(btn);
        }

        void ButtonEvent(object sender, EventArgs e)
        {
            
        }

        void Reset()
        {
            ItemCount = 0;
            RowCount = 0;
        }
    }
}
