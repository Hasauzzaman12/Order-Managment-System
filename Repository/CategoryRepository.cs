using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;
using System;

namespace OMS.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateData(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteData(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public Task<Category> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> EditData(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            return data;
        }

        public async Task<Category> GetByName(string? name)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);
            return data;
        }
    }
}
