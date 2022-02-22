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
    public partial class AddComment : Form
    {
        public AddComment(int PostID)
        {
            InitializeComponent();
            label2.Text = PostID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Comment.exportComments(CommentBox.Text, Int32.Parse(label2.Text));
            this.Hide();
            CommentsList menu  = new CommentsList(Int32.Parse(label2.Text));
            menu.Show();

        }

        private void AddComment_Load(object sender, EventArgs e)
        {

        }
    }
}
