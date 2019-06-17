using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy
{
    public class ActivityExtension
    {
        public int ActivityExtensionId { get; set; }
        public string ActivityExtensionArticle { get; set; }
        public string ActivityExtensionUrl { get; set; }

        public virtual ListActivity ListActivity { get; set; }
    }
}
