using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda
{
    public partial class Pages : Form
    {
        public Pages()
        {
            Program.PreviousPage = "Page";
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            Program.liOfPages.Clear();
            Page.importNormalPages(Program.liOfPages);

            for (int i = 0; i < Program.liOfPages.Count; i+=8)
            {
                flowLayoutPanel1.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfPages[i]), Program.liOfPages[i+1].ToString(), Program.liOfPages[i + 2].ToString(), Program.liOfPages[i + 3].ToString()));
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            AddPage NPage = new AddPage();
            NPage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void Pages_Load(object sender, EventArgs e)
        {

        }
    }
}
