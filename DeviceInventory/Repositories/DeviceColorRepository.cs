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
    public class DeviceColorRepository : RepositoryBase, IDeviceColorRepository
    {
        public async Task<List<DeviceColorViewModel>> FindAllAsync()
        {
           var result = await db.DeviceColor.Select(c => new DeviceColorViewModel { Id = c.Id, Name = c.Name, Description = c.Description, IsActive = c.IsActive }).ToListAsync();
            return result;
        }

        public async Task<DeviceColorViewModel> FindByIdAsync(int Id)
        {
            var result = await db.DeviceColor.Where(i => i.Id == Id).Select(c => new DeviceColorViewModel { Id = c.Id, Name = c.Name, Description = c.Description, IsActive = c.IsActive }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<DeviceColorViewModel> FindByNameAsync(string name)
        {
            var result = await db.DeviceColor.Where(n => n.Name == name).Select(c => new DeviceColorViewModel { Id = c.Id, Name = c.Name, Description = c.Description, IsActive = c.IsActive }).FirstOrDefaultAsync();
            return result;
        }

        public async Task SaveAsync(DeviceColorViewModel model)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var newDeviceColor = new DeviceColor()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };
                if (model.Name.Any())
                {
                    context.DeviceColor.Add(newDeviceColor);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Save Device Color Error: {ex}");
                    }

                }
            }
        }
    }
}
