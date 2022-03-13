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
    public class Request
    {
        public static void ImportRequests(ArrayList requestslist, ArrayList receivedrequests)
        {


            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT R.request_ID,R.request_Sender,US.User_Name Sender_Name,request_Receiver,UR.User_Name Receiver_Name,request_Status FROM friend_requests R INNER JOIN users US ON R.request_Sender = US.User_ID INNER JOIN users UR ON R.request_Receiver = UR.User_ID WHERE request_Sender='" + Program.CurrentUserID + "' ", db.getConnection());
            MySqlCommand command2 = new MySqlCommand("SELECT R.request_ID,R.request_Sender,US.User_Name Sender_Name,request_Receiver,UR.User_Name Receiver_Name,request_Status  FROM friend_requests R INNER JOIN users US ON R.request_Sender = US.User_ID INNER JOIN users UR ON R.request_Receiver = UR.User_ID WHERE request_Receiver='" + Program.CurrentUserID + "' ", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    requestslist.Add(Convert.ToString(arr[i]));

                }
            }

            adapter.SelectCommand = command2;
            adapter.Fill(table2);

            foreach (DataRow dr in table2.Rows)
            {
                object[] arr = dr.ItemArray;
                for (int i = 0; i < arr.Length; i++)
                {
                    receivedrequests.Add(Convert.ToString(arr[i]));

                }
            }

        }
        public static void SendRequest(string SenderID, string ReceiverID)
        {
            bool found = false;
            ImportRequests(Program.liOfRequests, Program.liOfReceivedRequests);
            for (int i = 0; i < Program.liOfRequests.Count; i += 4)
            {
                if (Program.liOfRequests[i + 1].ToString() == SenderID && Program.liOfRequests[i + 2].ToString() == ReceiverID)
                {
                    MessageBox.Show("You have already sent a friend request to this Alien ");
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("INSERT INTO `friend_requests` (`request_Sender`, `request_Receiver`, `request_Status`) VALUES(@sender, @receiver, @status)", db.getConnection());

                command.Parameters.Add("@sender", MySqlDbType.Int32).Value = Convert.ToInt32(SenderID);
                command.Parameters.Add("@receiver", MySqlDbType.Int32).Value = Convert.ToInt32(ReceiverID);
                command.Parameters.Add("@status", MySqlDbType.Int32).Value = 0;

                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();
                MessageBox.Show(" You've Sent a friend request to this alien *-*  ");
            }





        }

        public static void AcceptRequest(int sender) // take id of current user and the one who sent the request and change the status to 1
        {

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE `friend_requests` SET request_Status = 1 WHERE request_Sender="+sender+" AND request_Receiver="+Program.CurrentUserID+"", db.getConnection());
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Request Accepted , This alien has been added to your humans list :) "); }
        public static void RejectRequest(int sender) // take id of current user and the one who sent the request and change the status to -1
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("UPDATE `friend_requests` SET request_Status = -1 WHERE request_Sender=" + sender + " AND request_Receiver=" + Program.CurrentUserID + "", db.getConnection());
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Request Rejected , This alien will stay in their own planet :( "); 
        
        }
    }
}
