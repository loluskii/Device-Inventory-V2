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
    public class DeviceTypeRepository : RepositoryBase, IDeviceTypeRepository
    {
        public async Task<List<DeviceTypeViewModel>> FindAllAsync()
        {
            return await db.DeviceType.Select(e => new DeviceTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).ToListAsync();
        }

        public async Task<DeviceTypeViewModel> FindByIdAsync(int Id)
        {
            return await db.DeviceType.Where(i => i.Id == Id).Select(e => new DeviceTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task<DeviceTypeViewModel> FindByNameAsync(string name)
        {
            return await db.DeviceType.Where(n => n.Name == name).Select(e => new DeviceTypeViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(DeviceTypeViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                var newDeviceType = new DeviceType()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now

                };
                if (model.Name.Any())
                {
                    context.DeviceType.Add(newDeviceType);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Save Device Type Error: {ex}");
                    }

                }
            }
        }
    }
}
