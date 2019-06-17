using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int refCategoryId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescryption { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<ListActivity> ListActivities { get; set; }
    }
}
