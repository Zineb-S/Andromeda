using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda
{
    public class Post
    {
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
        public static void importPosts() { }
        public static void exportPosts() { }

        public static void deletePost() { }
        public static void updatePost() { }
    }
}
