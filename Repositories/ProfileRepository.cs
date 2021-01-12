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
    public class ProfileRepository : RepositoryBase, IProfileRepository
    {
        public async Task<List<ProfileViewModel>> FindAllAsync()
        {
          return await  db.Profile
                .Select(p => new ProfileViewModel
                { Id = p.Id, Email = p.ApplicationUser.Email,
                
                    RoleId = p.ApplicationUser.UserRoles.Select(u => u.Role.Id).FirstOrDefault(),
                    RoleName = p.ApplicationUser.UserRoles.Select(u => u.Role.Name).FirstOrDefault(),
                    EmployeeId = p.EmployeeId, FullName = p.FullName,
                    Gender = p.Gender,
                    UserId = p.UserId,
                    SubsidiaryId = p.SubsidiaryId,
                    SubsidiaryName = p.Subsidiary.Name,
                    EmployeeTypeId = p.EmployeeTypeId,
                    EmployeeTypeName = p.EmployeeType.Name,
                    ProfilePicture = p.ProfilePicture,
                    isActive = p.IsActive,
                   
                }).ToListAsync();
        }

        public async Task<ProfileViewModel> FindByIdAsync(int Id)
        {
            return await db.Profile.Where(i => i.Id == Id )
                .Select(p => new ProfileViewModel
                {
                    Id = p.Id,
                    Email = p.ApplicationUser.Email,

                    RoleId = p.ApplicationUser.UserRoles.Select(u => u.Role.Id).FirstOrDefault(),
                    RoleName = p.ApplicationUser.UserRoles.Select(u => u.Role.Name).FirstOrDefault(),
                    EmployeeId = p.EmployeeId,
                    FullName = p.FullName,
                    Gender = p.Gender,
                    UserId = p.UserId,
                    SubsidiaryId = p.SubsidiaryId,
                    SubsidiaryName = p.Subsidiary.Name,
                    EmployeeTypeId = p.EmployeeTypeId,
                    EmployeeTypeName = p.EmployeeType.Name,
                    ProfilePicture = p.ProfilePicture,
                    isActive = p.IsActive,
                }).FirstOrDefaultAsync();

           
        }

        public async Task<ProfileViewModel> FindByEmailAsync(string Email)
        {
            return await db.Profile.Where(i => i.ApplicationUser.Email == Email)
             .Select(p => new ProfileViewModel
             {
                 Id = p.Id,
                 Email = p.ApplicationUser.Email,

                 RoleId = p.ApplicationUser.UserRoles.Select(u => u.Role.Id).FirstOrDefault(),
                 RoleName = p.ApplicationUser.UserRoles.Select(u => u.Role.Name).FirstOrDefault(),
                 EmployeeId = p.EmployeeId,
                 FullName = p.FullName,
                 Gender = p.Gender,
                 UserId = p.UserId,
                 SubsidiaryId = p.SubsidiaryId,
                 SubsidiaryName = p.Subsidiary.Name,
                 EmployeeTypeId = p.EmployeeTypeId,
                 EmployeeTypeName = p.EmployeeType.Name,
                 ProfilePicture = p.ProfilePicture,
                 isActive = p.IsActive,
             }).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(ProfileViewModel model)
        {
            using(ApplicationDbContext context = new ApplicationDbContext())
            {
                var newProfile = new Profile()
                {
                    UserId = model.UserId,
                    FullName = model.FullName,
                    EmployeeId = model.EmployeeId,
                    SubsidiaryId = model.SubsidiaryId,
                    EmployeeTypeId = model.EmployeeTypeId,
                    ProfilePicture = model.ProfilePicture,
                    Gender = model.Gender,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now


                };
                if (model.UserId.Any())
                {
                    context.Profile.Add(newProfile);
                    try
                    {
                        await context.SaveChangesAsync();
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"Save Profile Error: {ex}");
                    }
                 
                }
            }
           
        }

        public async Task<ProfileViewModel> FindByUserIdAsync(string UserId)
        {
            return await db.Profile.Where(i => i.UserId == UserId)
              .Select(p => new ProfileViewModel { Id = p.Id, Email = p.ApplicationUser.Email, EmployeeId = p.EmployeeId, FullName = p.FullName }).FirstOrDefaultAsync();
        }
    }
}
