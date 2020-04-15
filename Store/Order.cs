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

        public void AddItems(Panel panel)
        {
            Button btn = new Button();
            PictureBox img = new PictureBox();
            
            btn.Text = "Add to cart";
            //btn.BackColor = Color.LightGray;
            btn.Size = new Size(panel.Size.Width/2, 25);
            btn.Anchor = AnchorStyles.Bottom;
            btn.Location = new Point((panel.Width/2)-(btn.Width/2),panel.Height - btn.Height);

            img.Anchor = AnchorStyles.Top;
            img.ImageLocation = @"C:\Users\KoKo\Pictures\Uplay\The Crew\The Crew2020-3-1-18-46-28.jpg";
            img.Size = new Size(panel.Width/2, panel.Height - btn.Height);
            img.Location = new Point(panel.Width/2 - img.Width/2, 0);
            img.SizeMode = PictureBoxSizeMode.StretchImage;

            panel.Controls.Add(img);
            panel.Controls.Add(btn);
        }

        void Reset()
        {
            ItemCount = 0;
            RowCount = 0;
        }
    }
}
