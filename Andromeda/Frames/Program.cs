using Andromeda.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Andromeda
{
    static class Program
    {
        //USERS
        public static ArrayList liOfUsers = new ArrayList();

        //MEMBERS
        public static ArrayList liOfnonMembers = new ArrayList();
        public static ArrayList liOfGroupMembers = new ArrayList();
        public static ArrayList liOfEventMembers = new ArrayList();

        //POSTS
        public static ArrayList liOfPosts = new ArrayList();
        public static ArrayList liOfPagesPosts = new ArrayList();
        public static ArrayList liOfEventsPosts = new ArrayList();
        public static ArrayList liOfGroupsPosts = new ArrayList();
        public static ArrayList liOfProfilePosts = new ArrayList();

        //COMMENTS
        public static ArrayList liOfPostsComments = new ArrayList();
        public static ArrayList liOfComments = new ArrayList();

        //PAGES
        public static ArrayList liOfPages = new ArrayList();
        public static ArrayList liOfUserPages = new ArrayList();
        public static ArrayList liOfNormalPages = new ArrayList();

        //GROUPS 
        public static ArrayList liOfGroups = new ArrayList();

        //EVENTS

        public static ArrayList liOfEvents = new ArrayList();

        //VOTES
        public static ArrayList VotesList = new ArrayList();
        public static ArrayList AllVotesList = new ArrayList();

        //REQUESTS
        public static ArrayList liOfRequests = new ArrayList();
        public static ArrayList liOfReceivedRequests = new ArrayList();

        //MESSAGES 
        public static ArrayList liOfMessages = new ArrayList();



        //CURRENT USER INFO

        public static int    CurrentUserID = 0;
        public static string CurrentUserUsername = "";
        public static string CurrentUserfname = "";
        public static string CurrentUserlname = "";
        public static string CurrentUserGender = "";
        public static string CurrentUserBirth = "";
        public static string CurrentUserEmail = "";
        public static string CurrentUserPassword = "";
        public static int    CurrentUserProfileID = 0;

        //CURRENT POST INFO

        public static int CurrentPostID = 0;
        
        //CURRENT PAGE INFO

        public static int PreviousPageID = 0;
        public static string PreviousPage = "";
        

        [STAThread]

        



        static void Main()
        {
            User.importUsers(liOfUsers); 
            Page.importPages(Program.liOfPages);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
        }
    }
}
