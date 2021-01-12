using DeviceInventory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceInventory
{
    public interface IProfileRepository
    {
        Task<List<ProfileViewModel>> FindAllAsync();
        Task SaveAsync(ProfileViewModel model);
        Task<ProfileViewModel> FindByIdAsync(int Id);
        Task<ProfileViewModel> FindByUserIdAsync(string UserId);
        Task<ProfileViewModel> FindByEmailAsync(string FullName);
    }
    public interface ISubsidiaryRepository
    {
        Task<List<SubsidiaryViewModel>> FindAllAsync();
        Task SaveAsync(SubsidiaryViewModel model);
        Task<SubsidiaryViewModel> FindByIdAsync(int Id);
        Task<SubsidiaryViewModel> FindByNameAsync(string name);
    }
    public interface IEmployeeTypeRepository
    {
        Task<List<EmployeeTypeViewModel>> FindAllAsync();
        Task SaveAsync(EmployeeTypeViewModel model);
        Task<EmployeeTypeViewModel> FindByIdAsync(int Id);
        Task<EmployeeTypeViewModel> FindByNameAsync(string name);
    }
    public interface IDeviceColorRepository
    {
        Task<List<DeviceColorViewModel>> FindAllAsync();
        Task SaveAsync(DeviceColorViewModel model);
        Task<DeviceColorViewModel> FindByIdAsync(int Id);
        Task<DeviceColorViewModel> FindByNameAsync(string name);
    }
    public interface IDeviceTypeRepository
    {
        Task<List<DeviceTypeViewModel>> FindAllAsync();
        Task SaveAsync(DeviceTypeViewModel model);
        Task<DeviceTypeViewModel> FindByIdAsync(int Id);
        Task<DeviceTypeViewModel> FindByNameAsync(string name);
    }
    public interface IDeviceModelRepository
    {
        Task<List<DeviceModelViewModel>> FindAllAsync();
        Task SaveAsync(DeviceModelViewModel model);
        Task<DeviceModelViewModel> FindByIdAsync(int Id);
        Task<DeviceModelViewModel> FindByNameAsync(string name);
    }
    public interface IDevicePropertyTypeRepository
    {
        Task<List<DevicePropertyTypeViewModel>> FindAllAsync();
        Task SaveAsync(DevicePropertyTypeViewModel model);
        Task<DevicePropertyTypeViewModel> FindByIdAsync(int Id);
        Task<DevicePropertyTypeViewModel> FindByNameAsync(string name);
    }
    public interface IDeviceRepository
    {
        Task<List<DeviceViewModel>> FindAllAsync();
        Task SaveAsync(DeviceViewModel model);
        Task<DeviceViewModel> FindByIdAsync(int Id);
        Task<DeviceViewModel> FindByNameAsync(string name);
    }
    public interface IVisitorRepository
    {
        Task<List<VisitorViewModel>> FindAllAsync();
        Task<List<VisitorViewModel>> FindTodayAsync();
        Task SaveAsync(VisitorViewModel model);
        Task UpdateVisitorStatusAsync(UpdateStatusViewModel model);
        Task<VisitorViewModel> FindByIdAsync(int Id);
        Task<VisitorViewModel> FindByNameAsync(string name);
        Task<VisitorViewModel> FindByPhoneNumberAsync(string phone);
        //hostid is the same thing as the string for user id
        Task<List<VisitorViewModel>> FindByHostIdAsync(string HostId);
        Task<List<VisitorViewModel>> FindByStatusNameAsync(string statusName);
        
    }





}
