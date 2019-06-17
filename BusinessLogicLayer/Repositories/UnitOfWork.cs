using BusinessLogicLayer.Managers;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories
{
    public class UnitOfWork
    {
        SightseeingContext _context = new SightseeingContext();

        public CategoryRepository _categoryRepository;
        public ActivityRepository _activityRepository;
        public ToDoListManager _toDoListManager;

        public UnitOfWork()
        {
            _categoryRepository = new CategoryRepository(_context);
            _activityRepository = new ActivityRepository(_context);
            _toDoListManager = new ToDoListManager(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
