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
    public partial class MainMenu : Form
    {
        public MainMenu()

        {

            Program.liOfProfilePosts.Clear();
            Page.CreateProfilePage();
            Page.importUserPages(Program.liOfUserPages);
            Page.importPages(Program.liOfPages);
            Post.importProfilePosts(Program.liOfProfilePosts, Program.CurrentUserID, Program.CurrentUserProfileID);
            InitializeComponent();
            label3.Text = (Program.liOfProfilePosts.Count/7).ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inbox DMs = new Inbox();
            DMs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pages pagesList = new Pages();
            pagesList.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome logout = new Welcome();
            logout.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FriendsRequestList FQlist = new FriendsRequestList();
            FQlist.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FriendsList friends = new FriendsList();
            friends.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewsFeed feed = new NewsFeed();
            feed.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            PostsList posts = new PostsList();
            posts.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsList events = new EventsList();
            events.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            GroupsList groups = new GroupsList();
            groups.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchPage search = new SearchPage();
            search.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile prof = new Profile();
            prof.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
