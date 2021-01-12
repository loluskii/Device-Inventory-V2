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
    public class DeviceRepository : RepositoryBase, IDeviceRepository
    {
        public async Task<List<DeviceViewModel>> FindAllAsync()
        {
            return await db.Device
                .Select(e => new DeviceViewModel {
                    Id = e.Id,
                    EmployeeName = e.Profile.FullName,
                    SerialNumber = e.SerialNumber,
                    EmployeeId = e.Profile.EmployeeId,
                    Email = e.Profile.ApplicationUser.Email,
                    PropertyTypeName = e.PropertyType.Name,
                    DeviceColorName = e.DeviceColor.Name,
                    DeviceModelName = e.DeviceModel.Name,
                    DeviceTypeName = e.DeviceType.Name
                }).ToListAsync();

        }

        public async Task<DeviceViewModel> FindByIdAsync(int Id)
        {
            return await db.Device
                .Where(i => i.Id == Id)
               .Select(e => new DeviceViewModel
               {
                   Id = e.Id,
                   EmployeeName = e.Profile.FullName,
                   SerialNumber = e.SerialNumber,
                   PropertyTypeName = e.PropertyType.Name,
                   DeviceColorName = e.DeviceColor.Name,
                   DeviceModelName = e.DeviceModel.Name,
                   DeviceTypeName = e.DeviceType.Name
               }).FirstOrDefaultAsync();
        }

        public Task<DeviceViewModel> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(DeviceViewModel model)
        {
           using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var newDevice = new Device()
                {
                    EmployeeId = model.EmployeeId,
                    ProfileId = model.ProfileId,
                    SerialNumber = model.SerialNumber,
                    PropertyTypeId = model.PropertyTypeId,
                    DeviceColorId = model.DeviceColorId,
                    DeviceModelId = model.DeviceModelId,
                    DeviceTypeId = model.DeviceTypeId,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };

                if (model.SerialNumber.Any())
                {
                    context.Device.Add(newDevice);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Save Device Error: {ex}");
                    }

                }
            }
        }
    }
}
