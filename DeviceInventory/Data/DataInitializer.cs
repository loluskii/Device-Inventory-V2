using DeviceInventory.Models;
using DeviceInventory.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory.Data
{
    public class DataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager, 
            ISubsidiaryRepository subsidiary, 
            IEmployeeTypeRepository employeeType, 
            IDevicePropertyTypeRepository devicePropertyType,
            IDeviceColorRepository deviceColor,
            IDeviceModelRepository deviceModel,
            IDeviceTypeRepository deviceType
            )
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedSubsidiary(subsidiary);
            SeedEmployeeType(employeeType);
            SeedDevicePropertyType(devicePropertyType);
            SeedDeviceColor(deviceColor);
            SeedDeviceModel(deviceModel);
            SeedDeviceType(deviceType);
          
        }

        public static void SeedDevicePropertyType(IDevicePropertyTypeRepository devicePropertyType)
        {
            if (devicePropertyType.FindByNameAsync("default").Result == null)
            {
                DevicePropertyTypeViewModel defaultDevicePropertyType = new DevicePropertyTypeViewModel()
                {
                    Name = "default",
                    Description = "default Device Color",
                };

                try
                {

                    devicePropertyType.SaveAsync(defaultDevicePropertyType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void SeedDeviceColor(IDeviceColorRepository deviceColor)
        {
            if (deviceColor.FindByNameAsync("default").Result == null)
            {
                DeviceColorViewModel defaultDeviceColor = new DeviceColorViewModel()
                {
                    Name = "default",
                    Description = "default Device Color",
                };

                try
                {

                    deviceColor.SaveAsync(defaultDeviceColor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void SeedDeviceModel(IDeviceModelRepository deviceModel)
        {
            if (deviceModel.FindByNameAsync("default").Result == null)
            {
                DeviceModelViewModel defaultDeviceModel = new DeviceModelViewModel()
                {
                    Name = "default",
                    Description = "default Device Model",
                };

                try
                {

                    deviceModel.SaveAsync(defaultDeviceModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        public static void SeedDeviceType(IDeviceTypeRepository deviceType)
        {
            if (deviceType.FindByNameAsync("default").Result == null)
            {
                DeviceTypeViewModel defaultDeviceType = new DeviceTypeViewModel()
                {
                    Name = "default",
                    Description = "default Device Type",
                };

                try
                {

                    deviceType.SaveAsync(defaultDeviceType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void SeedSubsidiary(ISubsidiaryRepository subsidiary)
        {
            if (subsidiary.FindByNameAsync("default").Result == null)
            {
                SubsidiaryViewModel defaultSubsidiary = new SubsidiaryViewModel()
                {
                    Name = "default",
                    Description = "default subsidiary",


                };

                try
                {

                    subsidiary.SaveAsync(defaultSubsidiary);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public static void SeedEmployeeType(IEmployeeTypeRepository employeeType)
        {
            if (employeeType.FindByNameAsync("default").Result == null)
            {
                EmployeeTypeViewModel defaultEmployeeType = new EmployeeTypeViewModel()
                {
                    Name = "default",
                    Description = "default employeetype",
                };

                try
                {

                    employeeType.SaveAsync(defaultEmployeeType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public static void SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("superAdmin").Result)
            {
                ApplicationRole adminRole = new ApplicationRole();

                adminRole.Name = "superAdmin";
                adminRole.NormalizedName = "SUPERADMIN";
                IdentityResult adminRoleResult = roleManager.CreateAsync(adminRole).Result;
            }

            if (!roleManager.RoleExistsAsync("administrator").Result)
            {
                ApplicationRole apiUserRole = new ApplicationRole();

                apiUserRole.Name = "administrator";
                apiUserRole.NormalizedName = "ADMINISTRATOR";
                IdentityResult apiUserRoleResult = roleManager.CreateAsync(apiUserRole).Result;
            }
            if (!roleManager.RoleExistsAsync("frontdesk").Result)
            {
                ApplicationRole apiUserRole = new ApplicationRole();

                apiUserRole.Name = "frontdesk";
                apiUserRole.NormalizedName = "FRONTDESK";
                IdentityResult apiUserRoleResult = roleManager.CreateAsync(apiUserRole).Result;
            }
            if (!roleManager.RoleExistsAsync("user").Result)
            {
                ApplicationRole apiUserRole = new ApplicationRole();

                apiUserRole.Name = "user";
                apiUserRole.NormalizedName = "USER";
                IdentityResult apiUserRoleResult = roleManager.CreateAsync(apiUserRole).Result;
            }
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {

            if (userManager.FindByNameAsync("admin").Result == null)
            {

                ApplicationUser adminUser = new ApplicationUser();
                adminUser.UserName = "admin";
                adminUser.Email = "admin@admin.com";
                adminUser.EmailConfirmed = true;

                try
                {
                    IdentityResult adminUserResult = userManager.CreateAsync(adminUser, "admin123").Result;
                    if (adminUserResult.Succeeded)
                    {

                        userManager.AddToRoleAsync(adminUser, "superAdmin").Wait();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }


        }
    }
}
