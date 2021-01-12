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
    public class DeviceModelRepository : RepositoryBase, IDeviceModelRepository
    {
        public async Task<List<DeviceModelViewModel>> FindAllAsync()
        {
            return await db.DeviceModel.Select(e => new DeviceModelViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).ToListAsync();
        }

        public async Task<DeviceModelViewModel> FindByIdAsync(int Id)
        {
            return await db.DeviceModel.Where(i => i.Id == Id).Select(e => new DeviceModelViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task<DeviceModelViewModel> FindByNameAsync(string name)
        {
            return await db.DeviceModel.Where(n => n.Name == name).Select(e => new DeviceModelViewModel { Id = e.Id, Name = e.Name, Description = e.Description, IsActive = e.IsActive }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(DeviceModelViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                var newDeviceModel = new DeviceModel()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now

                };
                if (model.Name.Any())
                {
                    context.DeviceModel.Add(newDeviceModel);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Save Device Model Error: {ex}");
                    }

                }
            }
        }
    }
}
