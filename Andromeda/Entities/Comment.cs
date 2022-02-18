using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda
{
    internal class Comment
    {
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

        public static void importComments() { }
        public static void exportComments() { }
        public static void deleteComment() { }
        public static void updateComment() { }
    }

    


}
