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
        public static ArrayList liOfUsers = new ArrayList();
        public static ArrayList liOfPosts = new ArrayList();
        public static ArrayList liOfnonMembers = new ArrayList();
        public static ArrayList liOfGroupMembers = new ArrayList();
        public static ArrayList liOfEventMembers = new ArrayList();
        public static ArrayList liOfPostsComments = new ArrayList();
        public static ArrayList liOfPages = new ArrayList();
        public static ArrayList liOfEvents = new ArrayList();
        public static ArrayList liOfGroups = new ArrayList();
        public static ArrayList liOfNormalPages = new ArrayList();
        public static ArrayList liOfPagesPosts = new ArrayList();
        public static ArrayList liOfEventsPosts = new ArrayList();
        public static ArrayList liOfGroupsPosts = new ArrayList();
        public static ArrayList liOfRequests = new ArrayList();
        public static ArrayList liOfComments = new ArrayList();
        public static ArrayList liOfUserPages = new ArrayList();
        public static ArrayList liOfProfilePosts = new ArrayList();
        public static ArrayList VotesList = new ArrayList();
        public static ArrayList AllVotesList = new ArrayList();


        public static int CurrentUserID = 0;
        public static string CurrentUserUsername = "";
        public static string CurrentUserfname = "";
        public static string CurrentUserlname = "";
        public static string CurrentUserGender = "";
        public static string CurrentUserBirth = "";
        public static string CurrentUserEmail = "";
        public static string CurrentUserPassword = "";
        public static int CurrentPostID = 0;
        public static int PreviousPageID = 0;
        public static int CurrentUserProfileID = 0;
        public static string PreviousPage = "";
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]

        



        static void Main()
        {
            User.importUsers(liOfUsers);
            Console.WriteLine(" ALl users amount : "+liOfUsers.Count/9);
            Page.importPages(Program.liOfPages);
            Console.WriteLine("All pages amount : " + Program.liOfPages.Count/6);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
        }
    }
}
