using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeM8
{
    public class UserLogic : IUserLogic
    {
        CollegeM8Context _db;
        public UserLogic(CollegeM8Context db)
        {
            _db = db;
        }

        public User CreateUser(User user)
        {
            string guid = Guid.NewGuid().ToString();
            if (!_db.Logins.Any(u => u.Username == user.Username))
            {
                user.UserId = guid;

                Login login = new Login();
                login.AccountCreatedDate = DateTime.Now;
                login.UserId = guid;
                login.Username = user.Username;
                login.Password = user.Password;

                _db.Users.Add(user);
                _db.Logins.Add(login);
                _db.SaveChanges();

            }
            else throw new ServiceException("User Already Exists");
            return GetUser(guid);
        }

        public User GetUser(string id)
        {
            User user;
            user = _db.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                throw new ServiceException("User Does Not Exist");
            }
            return user;
        }

        public User UpdateUser(User user)
        {
            User existingUser = _db.Users.FirstOrDefault(u => u.UserId == user.UserId);
            existingUser.EmailAddress = user.EmailAddress;
            _db.Users.Update(existingUser);

            if (!string.IsNullOrEmpty(user.Password))
            {
                Login existingLogin = _db.Logins.FirstOrDefault(l => l.Username == user.Username);
                existingLogin.Password = user.Password;
                _db.Update(existingLogin);
            }

            _db.SaveChanges();
            return GetUser(user.UserId);
        }

        public User Login(Login login)
        {
            Login loginfound = _db.Logins.FirstOrDefault(l => l.Username == login.Username && l.Password == login.Password);
            if (loginfound != null && login.Password == loginfound.Password) // Must check password because LINQ is not case sensitive.
            {
                return GetUser(loginfound.UserId);
            }
            else
            {
                throw new ServiceException("Login attempt failed.");
            }
        }
    }
}
