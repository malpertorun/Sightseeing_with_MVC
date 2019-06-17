using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy
{
    public class ToDoList
    {
        public int ToDoListId { get; set; }
        public string refUserId { get; set; }
        //public int ToDoListLikeCount { get; set; }
        public bool IsDone { get; set; }
        public string ToDoListName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<ListActivity> ListActivities { get; set; }
    }
}
