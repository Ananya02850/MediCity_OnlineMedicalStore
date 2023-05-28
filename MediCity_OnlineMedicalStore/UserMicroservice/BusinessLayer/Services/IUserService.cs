using MediCity_OnlineMedicalStore.UserMicroservice.BusinessLayer.ModelDto;
using System.Collections.Generic;

namespace MediCity_OnlineMedicalStore.UserMicroservice.BusinessLayer.Services
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);

        IEnumerable<UserDto> GetAllUsers();

        UserDto CreateUser(UserDto userDto);

        UserDto UpdateUser(UserDto userDto);

        bool DeleteUser(int userId);
    }
}
