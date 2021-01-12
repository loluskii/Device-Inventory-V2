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
    public class SubsidiaryRepository : RepositoryBase, ISubsidiaryRepository
    {
        public async Task<List<SubsidiaryViewModel>> FindAllAsync()
        {
            return await db.Subsidiary.Select(s => new SubsidiaryViewModel {Id = s.Id, Name = s.Name, Description = s.Description, IsActive = s.IsActive }).ToListAsync();
        }

        public async Task<SubsidiaryViewModel> FindByNameAsync(string Name)
        {
            return await db.Subsidiary.Where(n => n.Name == Name).Select(s => new SubsidiaryViewModel {Id = s.Id, Name = s.Name, Description = s.Description, IsActive = s.IsActive }).FirstOrDefaultAsync();
        }

        public async Task<SubsidiaryViewModel> FindByIdAsync(int Id)
        {
            return await db.Subsidiary.Where(n => n.Id == Id).Select(s => new SubsidiaryViewModel { Id = s.Id, Name = s.Name, Description = s.Description, IsActive = s.IsActive }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(SubsidiaryViewModel model)
        {
            using(var context = new ApplicationDbContext())
            {
                var newSubsidiary = new Subsidiary()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };
                if (model.Name.Any())
                {
                    context.Subsidiary.Add(newSubsidiary);
                    try
                    {
                        await context.SaveChangesAsync();
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"Save Subsidiary Error:  {ex}");
                    }
                }
            }
        }
    }
}
