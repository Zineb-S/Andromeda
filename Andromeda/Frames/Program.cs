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
        public static int CurrentUserID = 0;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]

        



        static void Main()
        {
            User.importUsers(liOfUsers);
            Post.importPosts(liOfPosts);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
        }
    }
}
