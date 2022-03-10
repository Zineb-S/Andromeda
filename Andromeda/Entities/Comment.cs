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
    internal class Comment
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");
        
        /*
         public int CommentID { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        public Comment() { }
        public Comment(int ID , string text , DateTime date)
        {
            this.CommentID = ID;
            this.CommentText = text;
            this.CommentDate = date;

        }
        */
        public static void importComments( ArrayList commentsList)
        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `comments`  ", db.getConnection());
            // MySqlCommand command = new MySqlCommand("SELECT * FROM `post` WHERE User_ID	='" + Program.CurrentUserID + "'", db.getConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);

            
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    commentsList.Add(Convert.ToString(arr[i]));
                 
                }
            }
           
        }
        public static void importPostsComments(int PostID, ArrayList commentsList)
        {
            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand(" SELECT ct.Comment_ID , ct.Comment_Text , ct.Comment_Date, cdt.User_ID, us.User_Name FROM `comment_details` cdt INNER JOIN comments ct on ct.Comment_ID = cdt.Comment_ID INNER JOIN users us on cdt.User_ID = us.User_ID WHERE ct.Post_ID ='" + PostID + "' ", db.getConnection());


            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    commentsList.Add(Convert.ToString(arr[i]));
                  
                }
            }
           
        }
        public static void exportComments(string text,int postID) 
        {
            if (text.Equals(""))
            {
                MessageBox.Show(" Please make sure to fill the whole form !");

                AddComment.ActiveForm.Hide();
                AddComment NewComment = new AddComment(postID);
                NewComment.Show();

            }

            DB db = new DB();
            DateTime now = DateTime.Now;
            MySqlCommand command = new MySqlCommand("INSERT INTO comments(Comment_Text,Comment_Date,Post_ID) VALUES(@text, @Date,@ID)", db.getConnection());
            command.Parameters.Add("@text", MySqlDbType.VarChar).Value = text;
            command.Parameters.Add("@Date", MySqlDbType.DateTime).Value = now;
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = postID;

            db.openConnection();
            command.ExecuteNonQuery();
            importComments(Program.liOfComments);
            int index = Convert.ToInt32(Program.liOfComments.Count) - 4;
            string CommentID = Program.liOfComments[index].ToString();
            MySqlCommand command2 = new MySqlCommand("INSERT INTO comment_details(Comment_ID,Post_ID,User_ID) VALUES(@commentID, @postID,@userID)", db.getConnection());
            command2.Parameters.Add("@commentID", MySqlDbType.Int32).Value = CommentID;
            command2.Parameters.Add("@postID", MySqlDbType.Int32).Value = postID;
            command2.Parameters.Add("@userID", MySqlDbType.Int32).Value = Program.CurrentUserID;
            command2.ExecuteNonQuery();
            db.closeConnection();

            MessageBox.Show(" Comment Posted ");
        }
        public static void deleteComment(string commentID)
        {


            DB db = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM comment_details WHERE Comment_ID='" + commentID + "'", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("DELETE FROM comments WHERE Comment_ID	='" + commentID + "'", db.getConnection());


            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show(" Comment succefully Deleted ");

        }
        public static void updateComment(string content,string commentID,string postID)
        {

            if (content.Equals(""))
            {
                MessageBox.Show(" Please make sure to fill the whole form !");

                EditComment.ActiveForm.Hide();
                EditComment NewPost = new EditComment(content,Convert.ToInt32(commentID), Convert.ToInt32(postID));
                NewPost.Show();

            }
            else
            {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE comments SET Comment_Text=@content WHERE Comment_ID	= " + commentID + "", db.getConnection());
            command.Parameters.Add("@content", MySqlDbType.VarChar).Value = content;
            //open the connection
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show(" Comment succefully Edited ");
            }
           


        }
    }

    


}
