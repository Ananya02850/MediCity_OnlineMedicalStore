using MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Data;
using MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace MediCity_OnlineMedicalStore.UserMicroservice.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            return user;
        }

        public bool DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
