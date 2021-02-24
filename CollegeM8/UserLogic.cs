using Microsoft.EntityFrameworkCore;
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
                // Hash Password
                login.Password = PasswordHash.Hash(user.Password);
                login.PasswordLastChangedDate = DateTime.Now;
                user.Password = null;
                _db.Users.Add(user);
                _db.Logins.Add(login);
                _db.SaveChanges();
                

            }
            else throw new ServiceException("User Already Exists");
            return GetUser(guid, false);
        }

        public User GetUser(string id, bool expand)
        {
            User user;
            if (expand) {
                user = _db.Users.AsNoTracking().Include(x => x.Terms).ThenInclude(x => x.Classes).ThenInclude(x => x.Exams)
                    .Include(x => x.Terms).ThenInclude(x => x.Classes).ThenInclude(x => x.Assignments)
                    .FirstOrDefault(u => u.UserId == id) ?? throw new ServiceException("User Does Not Exist");
                user.Sleep = _db.Sleep.AsNoTracking().FirstOrDefault(s => s.UserId == id);
            }
            else
            {
                user = _db.Users.AsNoTracking().FirstOrDefault(u => u.UserId == id) ?? throw new ServiceException("User Does Not Exist");
            }
            return user;
        }

        public User UpdateUser(User user)
        {
            User existingUser = _db.Users.FirstOrDefault(u => u.UserId == user.UserId) ?? throw new ServiceException("Could not find user.");
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.SchoolName = user.SchoolName;
            existingUser.ProgramName = user.ProgramName;
            existingUser.BirthDate = user.BirthDate;
            existingUser.EmailAddress = user.EmailAddress;
            _db.Users.Update(existingUser);
            _db.SaveChanges();
            return GetUser(user.UserId, false);
        }

        public User Login(Login login)
        {
            Login loginfound = _db.Logins.FirstOrDefault(l => l.Username == login.Username);
            if (loginfound != null && PasswordHash.Verify(login.Password, loginfound.Password))
            {
                return GetUser(loginfound.UserId, true);
            }
            else
            {
                throw new ServiceException("Login attempt failed.");
            }
        }
        
        public User ChangePassword(ChangePassword loginChangePw)
        {
            Login loginfound = _db.Logins.FirstOrDefault(l => l.Username == loginChangePw.Username);
            if (loginfound != null && PasswordHash.Verify(loginChangePw.OldPassword, loginfound.Password))
            {
                string newPass = PasswordHash.Hash(loginChangePw.NewPassword);
                loginfound.Password = newPass;
                loginfound.PasswordLastChangedDate = DateTime.Now;
                _db.Logins.Update(loginfound);
                _db.SaveChanges();
                return GetUser(loginfound.UserId, false);
            }
            else
            {
                throw new ServiceException("Password Not Changed.");
            }
        }
    }
}
