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
    public partial class Form1 : Form
    {

        bool LoggedIn = false;

        public List<Panel> panels = new List<Panel>();
        Order o = new Order();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddPanels();
            Console.WriteLine(panels.Count);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            o.GetFromSize();
            o.OrderPanels(panels);
        }

        void AddPanels()
        {
            for (int i = 0; i < 10; i++)
            {
                Panel p = new Panel();
                MainPanel.Controls.Add(p);
                p.Name = "Item" + i;

                panels.Add(p);
                o.AddButtons(p);
            }
            o.OrderPanels(panels);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginF = new LoginForm();
            loginF.Show();

        }
    }
}
