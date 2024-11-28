using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.AdminServices
{
    public interface IAdminServices
    {
        public Task<ResponseModel> CreateAdmin(Admin Admin);
        public Task<ResponseModel> UpdateAdminById(long id, Admin Admin);
        public Task<bool> DeleteAdminById(long id);
        public Task<Admin> GetAdminById(long id);
        public Task<IEnumerable<Admin>> GetAllAdmins();
        public Task<Admin> GetAdminByPhoneNumber(string phoneNumber);
    }
}
