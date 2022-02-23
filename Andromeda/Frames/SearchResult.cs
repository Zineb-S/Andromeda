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
        public SearchResult(int ID , string Title, string date, string Type)
        {
            T = Title;
            I = ID;
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
                    Pages.ActiveForm.Dispose();
                    EventDetails eventDetails = new EventDetails();
                    eventDetails.Show();
                    break ;
                case "Group":
                    Pages.ActiveForm.Dispose();
                    GroupDetails groupDetails = new GroupDetails();
                    groupDetails.Show();
                    break;

            }
        }

        private void SearchResult_Load(object sender, EventArgs e)
        {

        }
    }
}
