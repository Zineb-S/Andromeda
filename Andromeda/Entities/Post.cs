using Andromeda.Frames;
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
        /*
        
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
        */
        public static void importPosts(ArrayList postsList) 
        
        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `post` ", db.getConnection());
           // MySqlCommand command = new MySqlCommand("SELECT * FROM `post` WHERE User_ID	='" + Program.CurrentUserID + "'", db.getConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);
                
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    postsList.Add(Convert.ToString(arr[i]));
                }
            }
        }

        public static void importProfilePosts(ArrayList postsList, int CurrentUserID, int CurrentUserPfpID)
        {

            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT P.`Post_ID`, `Post_Title`, `Post_Date`, `Post_Content`,Post_Up_Votes,Post_Down_Votes, P.`User_ID` FROM post P INNER JOIN post_informations PI ON p.Post_ID = pi.Post_ID AND pi.User_ID ='" + CurrentUserID + "' AND pi.Page_ID='" + CurrentUserPfpID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            importPosts(Program.liOfPosts);
            Console.WriteLine(Program.liOfPosts.Count);
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;

                for (int i = 0; i < arr.Length; i++)
                {

                    postsList.Add(Convert.ToString(arr[i]));


                }


            }




        }
        public static void importPageposts(ArrayList pagePostsList, int CurrentUserID, int PreviousPageID)
        {

            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT P.`Post_ID`, `Post_Title`, `Post_Date`, `Post_Content`,Post_Up_Votes,Post_Down_Votes, P.`User_ID` FROM post P INNER JOIN post_informations PI ON p.Post_ID = pi.Post_ID  AND pi.Page_ID='" + PreviousPageID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            importPosts(Program.liOfPosts);
            Console.WriteLine(Program.liOfPosts.Count);
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;

                for (int i = 0; i < arr.Length; i++)
                {

                    pagePostsList.Add(Convert.ToString(arr[i]));


                }


            }




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
                DB db = new DB();


                DateTime now = DateTime.Now;
                // switch case depends on previous page // find solution on how to get ID of previous page
                switch (Program.PreviousPage)
                {
                    case "Profile": // in this case the post will be added to the User profile 
                        // when we login we check if the user has a profile or not this way we can get the Users profile page ID 
                        // and put it in a global variable called CurrentUserProfileID
                        
                        
                        
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


                   
                        
                        MySqlCommand command5 = new MySqlCommand("INSERT INTO post(Post_Title,Post_Date,Post_Content,Post_Up_Votes,Post_Down_Votes,User_ID) VALUES(@title, @Date, @Content, @UpV, @DownV,@ID)", db.getConnection());
                        command5.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
                        command5.Parameters.Add("@Date", MySqlDbType.DateTime).Value = now;
                        command5.Parameters.Add("@Content", MySqlDbType.VarChar).Value = content;
                        command5.Parameters.Add("@UpV", MySqlDbType.Int32).Value = 0;
                        command5.Parameters.Add("@DownV", MySqlDbType.Int32).Value = 0;
                        command5.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;




                        //open the connection
                        db.openConnection();
                        if (command5.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Post created");

                        }
                        else
                        {

                            MessageBox.Show("ERROR in creating post");
                        }
                        db.openConnection();
                        importPosts(Program.liOfPosts);
                        int index2 = Convert.ToInt32(Program.liOfPosts.Count) - 7;

                        string PostID4 = Program.liOfPosts[index2].ToString();
                        MySqlCommand command4 = new MySqlCommand("INSERT INTO post_informations(Page_ID,Post_ID,User_ID) VALUES(@pgID, @psID, @usID)", db.getConnection());
                        command4.Parameters.Add("@pgID", MySqlDbType.Int32).Value = Program.PreviousPageID;
                        command4.Parameters.Add("@psID", MySqlDbType.Int32).Value = Int32.Parse(PostID4);
                        command4.Parameters.Add("@usID", MySqlDbType.Int32).Value = Program.CurrentUserID;

                        command4.ExecuteNonQuery();
                        //close connection
                        db.closeConnection();








                        break;


                        
                        // because if need to dispaly the details of that event we will absolutely need that specific page ID 
                              // so once we get it put it in a global variable called Previous page ID 
                    case "Page": //in this case the post will be added to the page details 

                        
                        MySqlCommand command6 = new MySqlCommand("INSERT INTO post(Post_Title,Post_Date,Post_Content,Post_Up_Votes,Post_Down_Votes,User_ID) VALUES(@title, @Date, @Content, @UpV, @DownV,@ID)", db.getConnection());
                        command6.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
                        command6.Parameters.Add("@Date", MySqlDbType.DateTime).Value = now;
                        command6.Parameters.Add("@Content", MySqlDbType.VarChar).Value = content;
                        command6.Parameters.Add("@UpV", MySqlDbType.Int32).Value = 0;
                        command6.Parameters.Add("@DownV", MySqlDbType.Int32).Value = 0;
                        command6.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;




                        //open the connection
                        db.openConnection();
                        if (command6.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Post created");

                        }
                        else
                        {

                            MessageBox.Show("ERROR in creating post");
                        }
                        db.openConnection();
                        importPosts(Program.liOfPosts);
                        int index3 = Convert.ToInt32(Program.liOfPosts.Count) - 7;

                        string PostID5 = Program.liOfPosts[index3].ToString();
                        MySqlCommand command7 = new MySqlCommand("INSERT INTO post_informations(Page_ID,Post_ID,User_ID) VALUES(@pgID, @psID, @usID)", db.getConnection());
                        command7.Parameters.Add("@pgID", MySqlDbType.Int32).Value = Program.PreviousPageID;
                        command7.Parameters.Add("@psID", MySqlDbType.Int32).Value = Int32.Parse(PostID5);
                        command7.Parameters.Add("@usID", MySqlDbType.Int32).Value = Program.CurrentUserID;

                        command7.ExecuteNonQuery();
                        //close connection
                        db.closeConnection();
                        break;
                    case "Group": //in this case the post will be added to the group details 
                        
                        MySqlCommand command8 = new MySqlCommand("INSERT INTO post(Post_Title,Post_Date,Post_Content,Post_Up_Votes,Post_Down_Votes,User_ID) VALUES(@title, @Date, @Content, @UpV, @DownV,@ID)", db.getConnection());
                        command8.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
                        command8.Parameters.Add("@Date", MySqlDbType.DateTime).Value = now;
                        command8.Parameters.Add("@Content", MySqlDbType.VarChar).Value = content;
                        command8.Parameters.Add("@UpV", MySqlDbType.Int32).Value = 0;
                        command8.Parameters.Add("@DownV", MySqlDbType.Int32).Value = 0;
                        command8.Parameters.Add("@ID", MySqlDbType.Int32).Value = Program.CurrentUserID;




                        //open the connection
                        db.openConnection();
                        if (command8.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Post created");

                        }
                        else
                        {

                            MessageBox.Show("ERROR in creating post");
                        }
                        db.openConnection();
                        importPosts(Program.liOfPosts);
                        int index4 = Convert.ToInt32(Program.liOfPosts.Count) - 7;

                        string PostID6 = Program.liOfPosts[index4].ToString();
                        MySqlCommand command9 = new MySqlCommand("INSERT INTO post_informations(Page_ID,Post_ID,User_ID) VALUES(@pgID, @psID, @usID)", db.getConnection());
                        command9.Parameters.Add("@pgID", MySqlDbType.Int32).Value = Program.PreviousPageID;
                        command9.Parameters.Add("@psID", MySqlDbType.Int32).Value = Int32.Parse(PostID6);
                        command9.Parameters.Add("@usID", MySqlDbType.Int32).Value = Program.CurrentUserID;

                        command9.ExecuteNonQuery();
                        //close connection
                        db.closeConnection();
                        break;




                }

            }
                   


                
                



        }
        public static void deletePost(int postID , int userID) 
        {

            DB db = new DB();
           
            MySqlCommand command = new MySqlCommand("DELETE FROM post_informations WHERE  User_ID	='" + userID+ "' and POST_ID	='" + postID + "'", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("DELETE FROM post WHERE  User_ID	='" + userID + "' and POST_ID	='" + postID+ "'", db.getConnection());


            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show(" Post succefully Deleted ");


        }
        public static void updatePost(int postID, string title, string content)
        {
            if (title.Equals("") || content.Equals(""))
            {
                MessageBox.Show(" Please make sure to fill the whole form !");

                EditPost.ActiveForm.Hide();
                EditPost NewPost = new EditPost(postID, title, content);
                NewPost.Show();

            }
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE post SET Post_Title =@title , Post_Content  =@content  WHERE POST_ID	= " + postID + "", db.getConnection());
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
            command.Parameters.Add("@content", MySqlDbType.VarChar).Value = content;
            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show(" Post succefully Edited ");


        }
        public static void UpVote(int postID, int currentVote) 
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE post SET Post_Up_Votes ='" + (currentVote+1 )+ "' WHERE POST_ID	='" + postID + "'", db.getConnection());
           


            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
        }
        public static void DownVote(int postID , int currentVote) 
        {

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE post SET Post_Down_Votes ='" + (currentVote + 1) + "' WHERE POST_ID	='" + postID + "'", db.getConnection());

            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();   
        }
       
    }
}
