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
    public partial class SearchResult : UserControl
    {
        public string T = "";
        public int I = 0;
        public string S = "";
        public string E = "";
        public SearchResult(int ID , string Title, string date, string Type,string sdate , string edate )
        {
           // Program.PreviousPage = "Search";
            T = Title;
            I = ID;
            S = sdate;
            E = edate;
            InitializeComponent();
            label1.Text = Type;
            label3.Text = Title;
            label2.Text = date;
            label4.Text = ID.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                
            switch (label1.Text)
            {
                case "Page":
                    Program.PreviousPageID = I;
                    Pages.ActiveForm.Dispose();
                    Program.liOfPagesPosts.Clear();
                    Post.importPageposts(Program.liOfPagesPosts, Program.CurrentUserID, Program.PreviousPageID);
                   
                    PageDetails pageDetails = new PageDetails(T,label4.Text);
                    pageDetails.Show();
                    break;
                case "Event":
                    Program.PreviousPageID = I;

                    Pages.ActiveForm.Dispose();
                    Program.liOfEventsPosts.Clear();
                    Post.importPageposts(Program.liOfEventsPosts, Program.CurrentUserID, Program.PreviousPageID);
                    EventDetails eventDetails = new EventDetails(T,I.ToString(),S,E);
                    eventDetails.Show();
                    break ;
                case "Group":
                    Program.PreviousPageID = I;
                    Program.liOfGroupsPosts.Clear();
                    Post.importPageposts(Program.liOfGroupsPosts, Program.CurrentUserID, Program.PreviousPageID);
                    GroupsList.ActiveForm.Dispose();
                    GroupDetails groupDetails = new GroupDetails(T, I.ToString());
                    groupDetails.Show();
                    break;
                case "User":
                    Program.PreviousPageID = I;
                    SearchPage.ActiveForm.Dispose();
                    Aliens aliens = new Aliens(Program.PreviousPageID.ToString(),T);
                    aliens.Show();
                    break ;


            }
        }

        private void SearchResult_Load(object sender, EventArgs e)
        {

        }
    }
}
