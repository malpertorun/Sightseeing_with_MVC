using DataAccessLayer;
using Entitiy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class ActivityRepository
    {
        public SightseeingContext _context;

        public ActivityRepository(SightseeingContext ctx)
        {
            _context = ctx;
        }

        public List<Activity> GetAllActivities()
        {
            var activities = _context.Activities.Include(a => a.Category);
            return activities.ToList();
        }

        public Activity FindByActivityId(int? id)
        {
            return _context.Activities.Find(id);
        }

        public bool AvtivityValid(string name)
        {
            bool isValid;
            var act = _context.Activities.FirstOrDefault(x => x.ActivityName != name);
            if (act != null)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }


        public void CreateActivity(Activity activity)
        {
            _context.Activities.Add(activity);
        }

        public void DeleteActivity(Activity activity)
        {
            _context.Activities.Remove(activity);
        }

        public void EditActivity(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
        }
    }
}
