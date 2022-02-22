using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda.Entities
{
    internal class Vote
    {

        public int UserID { get; set; }

        public int PostID { get; set;}

        public string VoteType { get; set; }

        public bool VoteStatus { get; set; }


        public Vote() { }
        public Vote(int UserID , int PostID,string VoteType , bool VoteStatus) 
        {
            this.UserID = UserID;
            this.PostID = PostID;
            this.VoteType = VoteType;
            this.VoteStatus = VoteStatus;

        }

        public static void importPostVotes(int PostID , int UserID, ArrayList votesList)  // List<Vote>
        {
            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT Post_ID,count(*) VoteNumber , sum(Vote_Like) LikeNumber , sum(Vote_Dislike) DislikeNumber , '1' Like_Current_User , '0' Dislike_Current_User FROM votes GROUP BY Post_ID ", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    votesList.Add(Convert.ToString(arr[i]));
                    sb.Append('\n');
                }
            }
            Console.WriteLine(sb);
        }
    }





}
