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
            MySqlCommand command = new MySqlCommand("SELECT * FROM `post` ", db.getConnection());
           // MySqlCommand command = new MySqlCommand("SELECT * FROM `post` WHERE User_ID	='" + Program.CurrentUserID + "'", db.getConnection());


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



   
                if (title.Equals("") || content.Equals("") )
                {
                    MessageBox.Show(" Please make sure to fill the whole form !");

                    AddPost.ActiveForm.Hide();
                    AddPost NewPost = new AddPost();
                    NewPost.Show();
                   
                }

            else
            {
                // switch case depends on previous page // find solution on how to get ID of previous page
                switch (Program.PreviousPage)
                {
                    case "Profile": // in this case the post will be added to the User profile 
                        // when we login we check if the user has a profile or not this way we can get the Users profile page ID 
                        // and put it in a global variable called CurrentUserProfileID
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

                            MessageBox.Show("ERROR in creating post");
                        }
                        db.openConnection();
                        importPosts(Program.liOfPosts);
                        int index = Convert.ToInt32(Program.liOfPosts.Count) - 7;

                        string PostID = Program.liOfPosts[index].ToString();
                        MySqlCommand command2 = new MySqlCommand("INSERT INTO post_informations(Page_ID,Post_ID,User_ID) VALUES(@pgID, @psID, @usID)", db.getConnection());
                        command2.Parameters.Add("@pgID", MySqlDbType.Int32).Value = Program.CurrentUserProfileID;
                        command2.Parameters.Add("@psID", MySqlDbType.Int32).Value = Int32.Parse(PostID);
                        command2.Parameters.Add("@usID", MySqlDbType.Int32).Value = Program.CurrentUserID;

                        command2.ExecuteNonQuery();
                        //close connection
                        db.closeConnection();
                        break;
                    case "Event": // in this case the post will be added to the event details / we already gonna have the ID 
                        break;// because if need to dispaly the details of that event we will absolutely need that specific page ID 
                              // so once we get it put it in a global variable called Previous page ID 
                    case "Page": //in this case the post will be added to the page details 
                        break;
                    case "Group": //in this case the post will be added to the group details 
                        break;




                }

            }
                   


                
                



        }

        public static void importProfilePosts( ArrayList postsList , int CurrentUserID , int CurrentUserPfpID)
        {

            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT Post_ID FROM `post_informations` WHERE User_ID	='" + Program.CurrentUserID + "' and Page_ID	='" + Program.CurrentUserProfileID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            importPosts(Program.liOfPosts);
            Console.WriteLine(Program.liOfPosts.Count);
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                Console.WriteLine("HERE");
                for (int i = 0; i < arr.Length; i++)
                {
                   
                    for (int j = 0;j<Program.liOfPosts.Count; j+=7)
                    {
                       
                        if (Program.liOfPosts[j].Equals(Convert.ToString(arr[i])))
                        {

                            Console.WriteLine("FOUND IT");
                            Console.WriteLine(Program.liOfPosts[j+1]);
                            postsList.Add(Program.liOfPosts[j]);
                            postsList.Add(Program.liOfPosts[j + 1]);
                            postsList.Add(Program.liOfPosts[j + 2]);
                            postsList.Add(Program.liOfPosts[j + 3]);
                            postsList.Add(Program.liOfPosts[j + 4]);
                            postsList.Add(Program.liOfPosts[j + 5]);
                            postsList.Add(Program.liOfPosts[j + 6]);
                            sb.Append('\n');
                            break;
                        }
                       
                    }
                    
                }
            }


            
        }
        public static void deletePost() { }
        public static void updatePost() { }
    }
}
