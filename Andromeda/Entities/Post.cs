using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda
{
    public class Post
    {
        public string PostId { get; set; }
        public string PostTitle { get; set; }
        public DateTime PostDate { get; set; }
        public string PostContent { get; set; }
        public int PostUpVotes { get; set; }
        public int PostDownVotes { get; set; }

        public Post() { }

        public Post(string ID,string title , DateTime date, string content , int upvotes , int downvotes)
        {
            this.PostId = ID;
            this.PostTitle = title;
            this.PostDate = date;
            this.PostContent = content;
            this.PostUpVotes = upvotes;
            this.PostDownVotes = downvotes;

        }
        public static void importPosts() { }
        public static void exportPosts(string title , string content ) {

            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DateTime now = DateTime.Now;
            MySqlCommand command = new MySqlCommand("INSERT INTO post(Post_Title,Post_Date,Post_Content,Post_Up_Votes,Post_Down_Votes,User_ID) VALUES(@title, @Date, @Content, @UpV, @DownV,@ID)", db.getConnection());
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@Date", MySqlDbType.DateTime).Value = now;
            command.Parameters.Add("@Content", MySqlDbType.VarChar).Value = content;
            command.Parameters.Add("@UpV", MySqlDbType.Int32).Value = 0;
            command.Parameters.Add("@DownV", MySqlDbType.Int32).Value = 0;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;



            //open the connection
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Post created");

            }
            else
            {

                MessageBox.Show("ERROR");
            }




            //close connection
            db.closeConnection();



        }

        public static void deletePost() { }
        public static void updatePost() { }
    }
}
