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
    public partial class SearchPage : Form
    {
        public SearchPage()
        {
            Program.PreviousPage = "Search";
            InitializeComponent();
            SearchResultPanel.FlowDirection = FlowDirection.TopDown;
            SearchResultPanel.WrapContents = false;
            SearchResultPanel.AutoScroll = true;
            SearchResultPanel.Controls.Clear();
            Page.importPages(Program.liOfPages);
           
            for (int i = 0; i < Program.liOfPages.Count; i += 6)
            {
               if (Program.liOfPages[i + 3].ToString().Equals("Event") || Program.liOfPages[i + 3].ToString().Equals("Group") || Program.liOfPages[i + 3].ToString().Equals("Page"))
                    {
                    SearchResultPanel.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfPages[i]), Program.liOfPages[i + 1].ToString(), Program.liOfPages[i + 2].ToString(), Program.liOfPages[i + 3].ToString(), Program.liOfPages[i + 4].ToString(), Program.liOfPages[i + 5].ToString()));

                }





            }
            for (int i = 0; i < Program.liOfUsers.Count; i += 9)
            {

                if (Convert.ToInt32(Program.liOfUsers[i]).Equals(Program.CurrentUserID))
                {
                    continue;
                }
                else
                {
                    SearchResultPanel.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfUsers[i]), Program.liOfUsers[i + 1].ToString(), "", "User", "", ""));
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void SearchPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // li of all pages 
            // li of users 

           
            if (textBox1.Text.Equals(""))
            {
                SearchResultPanel.Controls.Clear();
                for (int i = 0; i < Program.liOfPages.Count; i += 6)
                {
                    if (!Program.liOfPages[i + 3].ToString().Equals("Profile"))
                    {
                        SearchResultPanel.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfPages[i]), Program.liOfPages[i + 1].ToString(), Program.liOfPages[i + 2].ToString(), Program.liOfPages[i + 3].ToString(), Program.liOfPages[i + 4].ToString(), Program.liOfPages[i + 5].ToString()));

                    }





                }
                for (int i = 0; i < Program.liOfUsers.Count; i += 9)
                {

                    if (Convert.ToInt32(Program.liOfUsers[i]).Equals(Program.CurrentUserID))
                    {
                        continue;
                    }
                    else
                    {
                        SearchResultPanel.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfUsers[i]), Program.liOfUsers[i + 1].ToString(), "", "User", "", ""));
                    }
                }


            }
            for (int i = 0; i < Program.liOfPages.Count; i+=6)
            {
                if (Program.liOfPages[i+1].ToString()==textBox1.Text)
                {
                    SearchResultPanel.Controls.Clear();
                    SearchResultPanel.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfPages[i]), Program.liOfPages[i + 1].ToString(), Program.liOfPages[i + 2].ToString(), Program.liOfPages[i + 3].ToString(), Program.liOfPages[i + 4].ToString(), Program.liOfPages[i + 5].ToString()));
                }

            }
            for (int i = 0; i < Program.liOfUsers.Count; i+=9)
            {
                if (Program.liOfUsers[i + 1].ToString() == textBox1.Text)
                {
                    SearchResultPanel.Controls.Clear();
                    SearchResultPanel.Controls.Add(new SearchResult(Convert.ToInt32(Program.liOfUsers[i]), Program.liOfUsers[i + 1].ToString(), "", "User", "", ""));
                }
            }
        }
    }
}
