using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andromeda.Entities
{
    internal class Vote
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=andromeda");
        /*
        public int PostID { get; set; }

        public int VoteNumber { get; set; }

        public int LikeNumber { get; set; }

        public int DislikeNumber { get; set; }

        public bool LikeCurrentUser { get; set; }

        public bool DisLikeCurrentUser { get; set; }


        public Vote() { }
        public Vote(int PostID, int VoteNumber, int LikeNumber, int DislikeNumber, bool LikeCurrentUser, bool DisLikeCurrentUser)
        {

            this.PostID = PostID;
            this.VoteNumber = VoteNumber;
            this.LikeNumber = LikeNumber;
            this.DislikeNumber = DislikeNumber;
            this.LikeCurrentUser = LikeCurrentUser;
            this.DisLikeCurrentUser = DisLikeCurrentUser;

        }

        */
        public static void ImportAllPostsVotes(ArrayList AllVotesList)
        {
            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT " +
                "Post_ID," +
                "count(*) VoteNumber," +
                "sum(Vote_Like) LikeNumber," +
                "sum(Vote_Dislike) DislikeNumber," +
               " SUM(if (User_ID = " + Program.CurrentUserID + ", Vote_Like , 0)) as Like_Current_User ," +
                "SUM(if (User_ID = " + Program.CurrentUserID + ", Vote_Dislike , 0)) as Dislike_Current_User" +
                " FROM votes GROUP BY Post_ID; ", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    AllVotesList.Add(Convert.ToString(arr[i]));
                }
            }
        }
        public static void ImportPostVotes(int PostID, ArrayList PostVotesList)
        {
            Program.AllVotesList.Clear();
            ImportAllPostsVotes(Program.AllVotesList);

            for (int i = 0; i < Program.AllVotesList.Count; i += 6)
            {
                if (Convert.ToInt32(Program.AllVotesList[i]).Equals(PostID))
                {
                    PostVotesList.Add(Program.AllVotesList[i]);
                    PostVotesList.Add(Program.AllVotesList[i + 1]);
                    PostVotesList.Add(Program.AllVotesList[i + 2]);
                    PostVotesList.Add(Program.AllVotesList[i + 3]);
                    PostVotesList.Add(Program.AllVotesList[i + 4]);
                    PostVotesList.Add(Program.AllVotesList[i + 5]);
                    break;
                }
            }

        }
        public static void exportPostVotes(string PostID, string VoteType)
        {
            try
            {
                bool checkUserVoted(int UserID, string PoID)
                {
                    Program.AllVotesList.Clear();
                    Program.VotesList.Clear();
                    ImportPostVotes(Convert.ToInt32(PostID), Program.VotesList);
                    if (Program.VotesList.Count > 0)
                    {
                        for (int i = 0;i < Program.VotesList.Count;i+=6)
                        {
                            if (Convert.ToInt32(Program.VotesList[i]).Equals(PoID) & (Convert.ToInt32(Program.VotesList[i+4]).Equals(1) || Convert.ToInt32(Program.VotesList[i+5]).Equals(1)))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    return false;




                }
                // check if user voted on 0 0 
                if (!checkUserVoted(Program.CurrentUserID, PostID))
                {
                    DB db = new DB();
                    switch (VoteType)
                    {
                        case "Like":

                            MySqlCommand command = new MySqlCommand("INSERT INTO votes(Post_ID,User_ID,Vote_Like,Vote_Dislike) VALUES(@postID, @userID, @VoteL,@VoteDL)", db.getConnection());
                            command.Parameters.Add("@postID", MySqlDbType.Int32).Value = PostID;
                            command.Parameters.Add("@userID", MySqlDbType.Int32).Value = Program.CurrentUserID;
                            command.Parameters.Add("@VoteL", MySqlDbType.Int32).Value = 1;
                            command.Parameters.Add("@VoteDL", MySqlDbType.Int32).Value = 0;
                            db.openConnection();
                            command.ExecuteNonQuery();
                            db.closeConnection();
                            break;

                        case "Dislike":

                            MySqlCommand command2 = new MySqlCommand("INSERT INTO votes(Post_ID,User_ID,Vote_Like,Vote_Dislike) VALUES(@postID, @userID, @VoteL,@VoteDL)", db.getConnection());
                            command2.Parameters.Add("@postID", MySqlDbType.Int32).Value = PostID;
                            command2.Parameters.Add("@userID", MySqlDbType.Int32).Value = Program.CurrentUserID;
                            command2.Parameters.Add("@VoteL", MySqlDbType.Int32).Value = 0;
                            command2.Parameters.Add("@VoteDL", MySqlDbType.Int32).Value = 1;
                            db.openConnection();
                            command2.ExecuteNonQuery();
                            db.closeConnection();
                            break;
                    }
                }
                else
                {
                    DB db = new DB();
                    switch (VoteType)
                    {

                        case "Like":

                            MySqlCommand command = new MySqlCommand("UPDATE  votes SET Vote_Like=1 , Vote_Dislike=0  WHERE Post_ID = " + PostID + " and User_ID= " + Program.CurrentUserID + "", db.getConnection());

                            db.openConnection();
                            command.ExecuteNonQuery();
                            db.closeConnection();

                            break;

                        case "Dislike":

                            MySqlCommand command2 = new MySqlCommand("UPDATE votes SET Vote_Like=0 , Vote_Dislike=1  WHERE Post_ID = " + PostID + " and User_ID= " + Program.CurrentUserID + "", db.getConnection());

                            db.openConnection();
                            command2.ExecuteNonQuery();
                            db.closeConnection();
                            break;
                    }

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("error  "+ex.Message);
            }

        }
    }
}