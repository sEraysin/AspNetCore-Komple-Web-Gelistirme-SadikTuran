using System.Collections.Generic;
using System.Linq;

namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();

        static Repository()
        {
            _users.Add(new UserInfo
            {
                Id = 1,
                Name = "Ali Kaya",
                Email = "ali.kaya@example.com",
                Phone = "0555 111 22 33",
                WillAttend = true
            });

            _users.Add(new UserInfo
            {
                Id = 2,
                Name = "Ahmet Yilmaz",
                Email = "ahmet.yilmaz@example.com",
                Phone = "0555 222 33 44",
                WillAttend = false
            });

            _users.Add(new UserInfo
            {
                Id = 3,
                Name = "Canan Demir",
                Email = "canan.demir@example.com",
                Phone = "0555 333 44 55",
                WillAttend = true
            });
        }

        public static List<UserInfo> Users
        {
            get
            {
                return _users;
            }
        }

        public static void CreateUser(UserInfo user)
        {
            user.Id = Users.Count + 1;
            _users.Add(user);
        }

        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }
}
