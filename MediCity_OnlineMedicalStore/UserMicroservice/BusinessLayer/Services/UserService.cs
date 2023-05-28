using MediCity_OnlineMedicalStore.UserMicroservice.BusinessLayer.ModelDto;
using MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Models;
using MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediCity_OnlineMedicalStore.UserMicroservice.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public UserDto CreateUser(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber
                // Set other properties as needed
            };

            _userRepository.CreateUser(user);
            _userRepository.SaveChanges();

            userDto.Id = user.Id;
            return userDto;
        }


        public bool DeleteUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return false;
            }

            _userRepository.DeleteUser(user.Id);
            _userRepository.SaveChanges();
            return true;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
                // Map other properties as needed
            });
        }

        public UserDto GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
                // Map other properties as needed
            };
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var user = _userRepository.GetUserById(userDto.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            // Update other properties as needed

            _userRepository.UpdateUser(user);
            _userRepository.SaveChanges();

            return userDto;
        }
    }
}
