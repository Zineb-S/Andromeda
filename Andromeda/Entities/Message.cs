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
    public class Message
    {

        public static void SendMsg(int Receiver , string message )
        {
            if (message.Equals(""))
            {
                MessageBox.Show(" You can't send an empty signal make sure to write something !");
                Send_Message.ActiveForm.Dispose();
                Send_Message msg = new Send_Message(Receiver);
                msg.Show();
            }
            else
            {
                DB db = new DB();

                DateTime now = DateTime.Now;

                MySqlCommand command = new MySqlCommand("INSERT INTO messages(Message_Sender,Message_Receiver,Message_Content,Message_Date) VALUES(@sender, @receiver, @Content, @date)", db.getConnection());
                
                command.Parameters.Add("@Date", MySqlDbType.DateTime).Value = now;
                command.Parameters.Add("@Content", MySqlDbType.VarChar).Value = message;
                command.Parameters.Add("@sender", MySqlDbType.Int32).Value = Program.CurrentUserID;
                command.Parameters.Add("@receiver", MySqlDbType.Int32).Value = Receiver;
               




                //open the connection
                db.openConnection();
                command.ExecuteNonQuery();
                db.closeConnection();

                MessageBox.Show("Message Sent Succefully");

            }
        }

        public static void ImportUserInbox(ArrayList messageslist)
        {

            DB db = new DB();


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT Message_ID,Message_Sender,US.User_Name Sender_Name,Message_Receiver,UR.User_Name Receiver_Name,Message_Content,Message_Date  FROM messages M INNER JOIN users US ON Message_Sender = US.User_ID INNER JOIN users UR ON Message_Receiver = UR.User_ID WHERE Message_Receiver ='" + Program.CurrentUserID + "'", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            foreach (DataRow dr in table.Rows)
            {
                object[] arr = dr.ItemArray;

                for (int i = 0; i < arr.Length; i++)
                {

                    messageslist.Add(Convert.ToString(arr[i]));


                }


            }

        }
    }
}
