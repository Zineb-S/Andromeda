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
    public partial class MessageBoxItem : UserControl
    {
        public MessageBoxItem(string sender , string content , string date )
        {
            InitializeComponent();
            label3.Text = content;
            label2.Text = date;
            label1.Text = sender;
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
