using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSushi.Database.Entities;
using ProjectSushi.Database.ProjectSushiDbContext;

namespace ProjectSushi.Database.Services
{
    public class UseDatabaseService : IUseDatabaseService
    {
        private readonly ProjectSushiContext _context;
        public UseDatabaseService(ProjectSushiContext context) => _context = context;


        public async Task<(bool IsSuccess, List<Roll> RollsList, string ErrorMessage)> GetAllRolls()
        {
            try
            {
                var rolls = await _context.Rolls
                    .Include(roll => roll.Category) // Загружаем связанный объект Category
                    .Select(roll => new Roll
                    {
                        Id = roll.Id,
                        CategoryId = roll.CategoryId,
                        Name = roll.Name,
                        Composition = roll.Composition,
                        Weight = roll.Weight,
                        Price = roll.Price,
                        ImageId = roll.ImageId,
                        Category = new Category
                        {
                            CategoryName = roll.Category.CategoryName // Здесь только CategoryName
                        }
                    })
                    .ToListAsync();
                return rolls != null ? (true, rolls, string.Empty) : (false, new List<Roll>(), "List was empty");
            }
            catch (Exception e)
            {
                return (false, new List<Roll>(),e.Message);
            }
        }
    }
}
