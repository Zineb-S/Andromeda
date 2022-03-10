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
    public partial class AddPage : Form
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Page.exportPages(textBox1.Text);
            this.Dispose();
            Pages page = new Pages();
            page.Show();
        }

        private void AddPage_Load(object sender, EventArgs e)
        {

        }
    }
}
