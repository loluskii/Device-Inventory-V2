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
    enum StatusEnum
    {
        CHECKEDIN,
        CHECKEDOUT,
        PRESCHEDULED

    }
    public class VisitorRepository : RepositoryBase, IVisitorRepository
    {
        public string DateStringFormat { get; set; } = "dddd, dd MMMM yyyy";

        public async Task UpdateVisitorStatusAsync(UpdateStatusViewModel model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = await context.Visitor.FirstOrDefaultAsync(v => v.Id == model.Id);
                if (entity != null)
                {
                    entity.Status = model.Status;
                 

                    context.Visitor.Update(entity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<VisitorViewModel>> FindAllAsync()
        {
            return await db.Visitor
                .Select(v => new VisitorViewModel {
                    Id = v.Id, Email = v.Email,
                    PhoneNumber = v.PhoneNumber,
                    FullName = v.FullName,
                    HostId = v.HostId,
                    HostEmail = v.Profile.ApplicationUser.Email,
                    HostName = v.Profile.FullName,
                    ExpectedTime = v.ExpectedTime,
                    DateString = v.Date.ToString(DateStringFormat),
                    Status = v.Status,
                    Reason = v.Reason,
                    CheckedIn = v.Status.ToLower() == StatusEnum.CHECKEDIN.ToString().ToLower()? true :false,
                    CheckedOut = v.Status.ToLower() == StatusEnum.CHECKEDOUT.ToString().ToLower()? true :false,
                    PreScheduled = v.Status.ToLower() == StatusEnum.PRESCHEDULED.ToString().ToLower()? true :false,
                   

                }).ToListAsync();
        }

        public async Task<List<VisitorViewModel>> FindTodayAsync()
        {
            return await db.Visitor
                .Where(d => d.Date == DateTime.Now.Date)
                .Select(v => new VisitorViewModel
                {
                    Id = v.Id,
                    Email = v.Email,
                    PhoneNumber = v.PhoneNumber,
                    FullName = v.FullName,
                    HostId = v.HostId,
                    HostEmail = v.Profile.ApplicationUser.Email,
                    HostName = v.Profile.FullName,
                    ExpectedTime = v.ExpectedTime,
                    DateString = v.Date.ToString(DateStringFormat),
                    Status = v.Status,
                    Reason = v.Reason,
                    CheckedIn = v.Status.ToLower() == StatusEnum.CHECKEDIN.ToString().ToLower() ? true : false,
                    CheckedOut = v.Status.ToLower() == StatusEnum.CHECKEDOUT.ToString().ToLower() ? true : false,
                    PreScheduled = v.Status.ToLower() == StatusEnum.PRESCHEDULED.ToString().ToLower() ? true : false,


                }).ToListAsync();
        }

        public async Task<List<VisitorViewModel>> FindByHostIdAsync(string HostId)
        {
            return await db.Visitor
                .Where(h => h.Profile.UserId == HostId && h.Date == DateTime.Now.Date)
               .Select(v => new VisitorViewModel
               {
                   Id = v.Id,
                   Email = v.Email,
                   PhoneNumber = v.PhoneNumber,
                   FullName = v.FullName,
                   HostId = v.HostId,
                   HostEmail = v.Profile.ApplicationUser.Email,
                   HostName = v.Profile.FullName,
                   ExpectedTime = v.ExpectedTime,
                   DateString = v.Date.ToString(DateStringFormat),
                   Status = v.Status,
                   Reason = v.Reason
               }).ToListAsync();
        }

        public async Task<VisitorViewModel> FindByIdAsync(int Id)
        {
            return await db.Visitor
                .Where(i => i.Id == Id)
                .Select(v => new VisitorViewModel
                {
                    Id = v.Id,
                    Email = v.Email,
                    PhoneNumber = v.PhoneNumber,
                    FullName = v.FullName,
                    HostId = v.HostId,
                    HostEmail = v.Profile.ApplicationUser.Email,
                    HostName = v.Profile.FullName,
                    ExpectedTime = v.ExpectedTime,
                    DateString = v.Date.ToString(DateStringFormat),
                    Status = v.Status,
                    Reason = v.Reason
                })
                    .FirstOrDefaultAsync();
        }

        public async Task<VisitorViewModel> FindByNameAsync(string name)
        {
            return await db.Visitor
                .Where(n => n.FullName == name)
                .Select(v => new VisitorViewModel
                {
                    Id = v.Id,
                    Email = v.Email,
                    PhoneNumber = v.PhoneNumber,
                    FullName = v.FullName,
                    HostId = v.HostId,
                    HostEmail = v.Profile.ApplicationUser.Email,
                    HostName = v.Profile.FullName,
                    ExpectedTime = v.ExpectedTime,
                    DateString = v.Date.ToString(DateStringFormat),
                    Status = v.Status,
                    Reason = v.Reason

                })
                    .FirstOrDefaultAsync();
        }

        public async Task<VisitorViewModel> FindByPhoneNumberAsync(string phone)
        {
            return await db.Visitor
                .Where(p => p.PhoneNumber  == phone)
                .Select(v => new VisitorViewModel
                {
                    Id = v.Id,
                    Email = v.Email,
                    PhoneNumber = v.PhoneNumber,
                    FullName = v.FullName,
                    HostId = v.HostId,
                    HostEmail = v.Profile.ApplicationUser.Email,
                    HostName = v.Profile.FullName,
                    ExpectedTime = v.ExpectedTime,
                    DateString = v.Date.ToString(DateStringFormat),
                    Status = v.Status,
                    Reason = v.Reason

                })
                    .FirstOrDefaultAsync();
        }

        public async Task<List<VisitorViewModel>> FindByStatusNameAsync(string statusName)
        {
            return await db.Visitor
                           .Where(h => h.Status.ToLower() == statusName.ToLower() && h.Date == DateTime.Now.Date)
                          .Select(v => new VisitorViewModel
                          {
                              Id = v.Id,
                              Email = v.Email,
                              PhoneNumber = v.PhoneNumber,
                              FullName = v.FullName,
                              HostId = v.HostId,
                              HostEmail = v.Profile.ApplicationUser.Email,
                              HostName = v.Profile.FullName,
                              ExpectedTime = v.ExpectedTime,
                              DateString = v.Date.ToString(DateStringFormat),
                              Status = v.Status,
                              Reason = v.Reason
                          }).ToListAsync();
        }

        public async Task SaveAsync(VisitorViewModel model)
        {
            using( var context = new ApplicationDbContext())
            {
                var newVisitor = new Visitor()
                {
                    PhoneNumber = model.PhoneNumber,
                    FullName = model.FullName,
                    Email = model.Email,
                    HostId = model.HostId,
                    Status = "PreScheduled",
                    Reason = model.Reason,
                    ExpectedTime = model.ExpectedTime,
                    Date = model.Date,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now


                };

                if(model.PhoneNumber.Any())
                {
                    context.Visitor.Add(newVisitor);
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine($"\n\n Save Visitor Error: {ex} \n\n");
                    }
                }
            }
        }
    }
}
