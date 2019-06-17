using DataAccessLayer;
using Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Managers
{
    public class ToDoListManager
    {
        public SightseeingContext _context;

        public ToDoListManager(SightseeingContext ctx)
        {
            _context = ctx;
        }

        public List<ToDoList> GetAllToDoListForUser(string userName)
        {
            return _context.ToDoLists.Where(x => x.ApplicationUser.UserName == userName).ToList();
        }

        public ToDoList FindActiveToDoListForUser(string userName)
        {
            ToDoList tdl = null;
            tdl = _context.ToDoLists.Where(t => t.ApplicationUser.UserName == userName && t.IsDone == false).FirstOrDefault();
            return tdl;
        }

        public void CreateToDoListForUser(string userName, string toDoListName)
        {
            ToDoList toDoList = new ToDoList();
            ApplicationUser usr = _context.Users.FirstOrDefault(x=> x.UserName == userName);
            toDoList.refUserId = usr.Id;
            toDoList.ToDoListName = toDoListName;
            _context.ToDoLists.Add(toDoList);
        }

        public void AddRandomActivityToDoList(string userName)
        {
            ToDoList tdl = FindActiveToDoListForUser(userName);
            
            int CategoryCaunt = _context.Categories.Count();
            int ActivityCount = _context.Activities.Count();
            Random rnd = new Random();
            if (tdl.ListActivities.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Activity act = _context.Activities.Where(a => a.refCategoryId == rnd.Next(CategoryCaunt) && a.ActivityId == rnd.Next(ActivityCount)).FirstOrDefault();

                    ListActivity la = new ListActivity()
                    {
                        refActivityId = act.ActivityId,
                        refToDoListId = tdl.ToDoListId
                    };

                    _context.ListActivities.Add(la);
                }
            }
            
        }

        public List<ListActivity> FindActiveToDoListItems(int toDoListId)
        {
            List<ListActivity> lstAct = _context.ListActivities.Where(x => x.refToDoListId == toDoListId).ToList();
            return lstAct;
        }
    }
}
