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
                Color newColor = Color.FromArgb(r.Next(0,255), r.Next(0,255), r.Next(0,255));

                p.Size = new Size(PanelX, PanelY);
                p.BackColor = newColor;

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

        public void AddButtons(Panel panel)
        {
            Button btn = new Button();

            btn.Text = "Add to cart";
            btn.BackColor = Color.Gray;
            btn.Size = new Size(panel.Size.Width, 25);
            btn.Anchor = AnchorStyles.Bottom;
            btn.Location = new Point((panel.Width/2)-(btn.Width/2),panel.Height - btn.Size.Height);
            panel.Controls.Add(btn);
        }

        void Reset()
        {
            ItemCount = 0;
            RowCount = 0;
        }
    }
}
