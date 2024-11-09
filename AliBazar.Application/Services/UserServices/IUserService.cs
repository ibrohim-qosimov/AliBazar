using AliBazar.Application.ViewModels;
using AliBazar.Domain.DTOs;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;

namespace AliBazar.Application.Services.UserServices
{
    public interface IUserService
    {
        public Task<ResponseModel> CreateUser(RegisterDTO userDTO);
        public Task<ResponseModel> UpdateUserById(long id, UserUpdateDTO userDTO);
        public Task<bool> DeleteUserById(long id);
        public Task<User> GetUserById(long id);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
