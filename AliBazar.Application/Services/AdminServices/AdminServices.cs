using AliBazar.Application.Abstractions;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;


namespace AliBazar.Application.Services.AdminServices
{
    internal class AdminServices : IAdminServices
    {
        private readonly IAdminRepository _adminRepository;
        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public async Task<ResponseModel> CreateAdmin(AdminDTO Admin)
        {
            var admin = new Admin
            {
                Name = Admin.Name,
                PhoneNumber = Admin.PhoneNumber
            };
            var result = _adminRepository.Create(admin);

            if (result == null)
            {
                return new ResponseModel()
                {
                    Note = "Error",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                Note = "Successful Created Admin",
                IsSuccess = true
            };
        }
       

        public async Task<bool> DeleteAdminById(long id)
        {
            var deleteAdminResult = await _adminRepository.Delete(x => x.Id == id);
            return deleteAdminResult;
        }

        public async Task<Admin> GetAdminById(long id)
        {
            var adminResult = await _adminRepository.GetByAny(x => x.Id == id);
            return adminResult;
        }

        public async Task<Admin> GetAdminByPhoneNumber(string phoneNumber)
        {
            var adminResult =  await _adminRepository.GetByAny(x=>x.PhoneNumber == phoneNumber);
            return adminResult;
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _adminRepository.GetAll();
        }

        public async Task<ResponseModel> UpdateAdminById(long id, AdminDTO Admin)
        {
            var admin = await _adminRepository.GetByAny(x => x.Id == id);
            
            if (admin == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Note = "Admin not found!"
                };
            }
            admin.Name = Admin.Name;
            admin.PhoneNumber = Admin.PhoneNumber;

            var result = await _adminRepository.Update(admin);
            
            return new ResponseModel()
            {
                Note = "Admin updated successfully!",
                IsSuccess = true
            };
        }
    }
}
