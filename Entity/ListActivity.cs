using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy
{
    public class ListActivity
    {
        public int ListActivityId { get; set; }
        public int refActivityId { get; set; }
        public int refToDoListId { get; set; }
        public bool IsChecked { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual ToDoList ToDoList { get; set; }

        public virtual ActivityExtension ActivityExtension { get; set; }
    }
}
