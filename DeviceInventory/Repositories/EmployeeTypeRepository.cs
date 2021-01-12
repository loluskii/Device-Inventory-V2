using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceInventory.Data;
using DeviceInventory.Models;
using DeviceInventory.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DeviceInventory.Repositories
{
    public class EmployeeTypeRepository : RepositoryBase, IEmployeeTypeRepository
    {
        public async Task<List<EmployeeTypeViewModel>> FindAllAsync()
        {
          return await  db.EmployeeType.Select(e => new EmployeeTypeViewModel {Id= e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).ToListAsync();
        }

        public async Task<EmployeeTypeViewModel> FindByNameAsync(string Name)
        {
            return await db.EmployeeType
                .Where(n => n.Name == Name)
                .Select(e => new EmployeeTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task<EmployeeTypeViewModel> FindByIdAsync(int Id)
        {
            return await db.EmployeeType
             .Where(n => n.Id == Id)
             .Select(e => new EmployeeTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(EmployeeTypeViewModel model)
        {
            using(var context = new ApplicationDbContext())
            {
                var newEmployeeType = new EmployeeType()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now

                };
                if (model.Name.Any())
                {
                    context.EmployeeType.Add(newEmployeeType);
                    try
                    {
                        await context.SaveChangesAsync();
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"Save EmployeeType Error: {ex}");
                    }

                }
            }
        }
    }
}
