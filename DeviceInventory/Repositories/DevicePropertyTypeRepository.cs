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
    public class DevicePropertyTypeRepository : RepositoryBase, IDevicePropertyTypeRepository
    {
        public async Task<List<ViewModels.DevicePropertyTypeViewModel>> FindAllAsync()
        {
            return await db.PropertyType.Select(e => new DevicePropertyTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).ToListAsync();
        }

        public async Task<ViewModels.DevicePropertyTypeViewModel> FindByIdAsync(int Id)
        {
            return await db.PropertyType.Where(i => i.Id == Id).Select(e => new DevicePropertyTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task<ViewModels.DevicePropertyTypeViewModel> FindByNameAsync(string name)
        {
            return await db.PropertyType.Where(n => n.Name == name).Select(e => new DevicePropertyTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(ViewModels.DevicePropertyTypeViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                var newPropertyType = new PropertyType()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now

                };
                if (model.Name.Any())
                {
                    context.PropertyType.Add(newPropertyType);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Save PropertyType Error: {ex}");
                    }

                }
            }
        }
    }
}
