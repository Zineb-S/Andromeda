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
    public partial class EditComment : Form
    {
        public EditComment(string OldContent ,int CommentID,int postID)
        {
            InitializeComponent();
            label2.Text = CommentID.ToString();
            textBox1.Text = OldContent;
            label3.Text = postID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comment.updateComment(textBox1.Text, label2.Text,label3.Text);
            this.Dispose();
            CommentsList n = new CommentsList(Convert.ToInt32(label3.Text));
            n.Show();
        }

        private void EditComment_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
