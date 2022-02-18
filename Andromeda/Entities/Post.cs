using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");
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
        public static void importPosts(ArrayList postsList) 
        
        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `posts` ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    postsList.Add(Convert.ToString(arr[i]));
                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);
        }
        public static void exportPosts(string title , string content ) {

            // create profile page if user doesn't have one and then add post to it 
            //MySqlCommand command2 = new MySqlCommand("INSERT INTO page(Page_ID	Page_Name	Page_Date	Page_Type	Start_Date	End_Date	) VALUES(@usn, @fn, @ln, @email, @pass,@year, @gender)", db.getConnection());
            //MySqlCommand command3 = new MySqlCommand("INSERT INTO profile_page(Page_ID,User_ID) VALUES(@pageID, @userID)", db.getConnection());

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
