using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda.Frames
{
    public partial class EditPage : Form
    {
        public EditPage(string title)
        {
            InitializeComponent();
            textBox1.Text = title;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Page.updatePage(Program.PreviousPageID.ToString(),textBox1.Text);
            this.Dispose();
            Pages pages = new Pages();
            pages.Show();

        }

        private void EditPage_Load(object sender, EventArgs e)
        {

        }
    }
}
