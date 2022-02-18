using Andromeda.Frames;
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
    public partial class EventDetails : Form
    {
        public EventDetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPost post = new AddPost();
            post.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MembersList MBlist = new MembersList();
            MBlist.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsList EVlist = new EventsList();
            EVlist.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditEvent edite = new EditEvent();
            edite.Show();
        }
    }
}
