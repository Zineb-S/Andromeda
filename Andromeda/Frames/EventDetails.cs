using Andromeda.Entities;
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
        public string ID = "";
        public string TITLE = "";
        public string SDATE = "";
        public string EDATE = "";
        public EventDetails(string T , string I , string S , string E)
        {
            ID = I;
            TITLE = T;
            SDATE = S;
            EDATE = E;
            Program.PreviousPageID = Convert.ToInt32(ID);
            InitializeComponent();
            label1.Text = T;
            label4.Text = S;
            label5.Text = E;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Clear();
            
                for (int i = 0; i < Program.liOfEventsPosts.Count; i += 7)
                {

                    Program.VotesList.Clear();
                    Vote.ImportPostVotes(Convert.ToInt32(Program.liOfEventsPosts[i]), Program.VotesList);

                    if (Program.VotesList.Count / 6 == 1)
                    {

                        for (int j = 0; j < Program.VotesList.Count; j += 6)
                        {


                            flowLayoutPanel1.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfEventsPosts[i]), Program.liOfEventsPosts[i + 1].ToString(), Program.liOfEventsPosts[i + 2].ToString(), Program.liOfEventsPosts[i + 3].ToString(), Program.VotesList[j + 2].ToString(), Program.VotesList[j + 3].ToString(), Convert.ToInt32(Program.VotesList[j + 4]), Convert.ToInt32(Program.VotesList[j + 5])));
                        }
                    }
                    else
                    {



                        flowLayoutPanel1.Controls.Add(new PostBox(Convert.ToInt32(Program.liOfEventsPosts[i]), Program.liOfEventsPosts[i + 1].ToString(), Program.liOfEventsPosts[i + 2].ToString(), Program.liOfEventsPosts[i + 3].ToString(), "0", "0", 0, 0));

                    }
                }
                
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
            EditEvent edite = new EditEvent(ID,TITLE,SDATE,EDATE);
            edite.Show();
        }

        private void EventDetails_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Event.deleteEvent(ID);
            this.Dispose();
            EventsList eventsList = new EventsList();
            eventsList.Show();
        }
    }
}
