using DataAccessLayer;
using Entitiy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;







namespace BusinessLogicLayer.Repositories
{
    public class CategoryRepository
    {

        public SightseeingContext _context;

        public CategoryRepository(SightseeingContext ctx)
        {
            _context = ctx;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category FindByCategoryId(int? id)
        {
            return _context.Categories.Find(id);
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
           _context.Categories.Remove(category);
        }

        public void EditCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }


    }
}
