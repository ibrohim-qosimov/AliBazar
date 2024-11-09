using AliBazar.Application.Abstractions;
using AliBazar.Application.Services.CategoryServices;
using AliBazar.Application.Services.PasswrodHashing;
using AliBazar.Application.ViewModels;
using AliBazar.Domain.DTOs;
using AliBazar.Domain.Entities;
using AliBazar.Domain.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace AliBazar.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IWebHostEnvironment webHostEnvironment, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _webHostEnvironment = webHostEnvironment;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseModel> CreateUser(RegisterDTO userDTO)
        {
            var user = new User()
            {
                Name = userDTO.Name,
                Password = _passwordHasher.Hash(userDTO.Password),
                PhoneNumber = userDTO.PhoneNumber,
                Role = "User"
            };

            var result = await _userRepository.Create(user);

            if (result == null)
            {
                return new ResponseModel()
                {
                    ErrorNote = "Error",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                ErrorNote = "Successful Created User",
                IsSuccess = true
            };
        }

        public async Task<bool> DeleteUserById(long id)
        {
            var deleteUserResult = await _userRepository.Delete(x => x.Id == id);

            return deleteUserResult;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(long id)
        {
            var userResult = await _userRepository.GetByAny(x => x.Id == id);
            return userResult;
        }

        public async Task<ResponseModel> UpdateUserById(long id, UserUpdateDTO userDTO)
        {

            var user = await _userRepository.GetByAny(x => x.Id == id);

            if (user == null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    ErrorNote = "User not found!"
                };
            }

            var file = userDTO.ImageUrl;
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UserPhotos");
            string fileName = "";

            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                    Debug.WriteLine("UserPhoto created successfully.");
                }

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UserPhotos", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    ErrorNote = "Exception while saving picture.",
                    IsSuccess = false
                };
            }


            user.Name = userDTO.Name;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.Password = _passwordHasher.Hash(userDTO.Password);
            user.ImageUrl = "/UserPhotos/" + fileName;

            var result = await _userRepository.Update(user);

            if (result == null)
            {
                return new ResponseModel()
                {
                    ErrorNote = "Exception while saving picture.",
                    IsSuccess = false
                };
            }

            return new ResponseModel()
            {
                ErrorNote = "User updated successfully!",
                IsSuccess = true
            };
        }
    }
}
