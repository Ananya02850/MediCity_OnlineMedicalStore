using MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Models;
using System.Collections.Generic;

namespace MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int userId);
        void SaveChanges();
    }
}
