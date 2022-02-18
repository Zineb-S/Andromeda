using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda
{
    internal class Page
    {
        public int PageID { get; set; }
        public string PageName { get; set; }

        public DateTime PageDate { get; set; }
        public string PageType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }



        public Page() { }
        public Page(int ID, string name , DateTime date,string type , DateTime SDate, DateTime Etime) {
            this.PageID = ID;   
            this.PageName = name;
            this.PageDate = date;
            this.PageType = type;
            this.StartDate = SDate;
            this.EndDate = Etime;
                }
        public static void importPages() { }
        public static void exportPages() { }
        public static void deletePage() { }
        public static void updatePage() { }

    }
}
