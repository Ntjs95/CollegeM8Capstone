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
                Sleep sleep = new Sleep();
                sleep.UserId = guid;
                sleep.HoursWeekday = 8;
                sleep.HoursWeekend = 8;
                sleep.WakeTimeWeekday = DateTime.Parse("0001-01-01T07:00:00");
                sleep.WakeTimeWeekend = DateTime.Parse("0001-01-01T07:00:00");
                _db.Sleep.Add(sleep);
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
                return GetUser(loginfound.UserId, false);
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

        public NextEvent GetNextEvent(string id)
        {
            NextEvent nextEvent;
            string title;
            string description;
            string dateStr;
            string timeStr;
            Exam exam = _db.Exams.Where(e => e.UserId == id).OrderBy(e => e.StartTime).FirstOrDefault(e => e.StartTime >= DateTime.Now);
            Assignment assignment = _db.Assignments.Where(a => a.UserId == id).OrderBy(a => a.DueDate).FirstOrDefault(a => a.DueDate >= DateTime.Now);
            if(exam == null && assignment == null)
            {
                ScheduleItem item = _db.Schedule.Where(s => s.UserId == id).OrderBy(s => s.StartTime).FirstOrDefault(s => s.StartTime >= DateTime.Now);
                title = item.Title;
                timeStr = item.StartTime.ToString("hh:mm tt");
                dateStr = item.StartTime.ToString("dddd, dd MMMM yyyy");
                nextEvent = new NextEvent(title, null, dateStr, timeStr);
            }
            else if(exam == null || ((DateTime.Now - assignment.DueDate).TotalMinutes > (DateTime.Now - exam.StartTime).TotalMinutes))
            {
                Class _class = _db.Classes.FirstOrDefault(c => c.ClassId == assignment.ClassId);
                title = $"Assignment Due Soon!";
                description = $"The next assignment due for {_class.ClassName} is approaching. This assignment is worth {assignment.GradeWeight}% of your grade.";
                dateStr = assignment.DueDate.ToString("dddd, dd MMMM yyyy");
                nextEvent = new NextEvent(title, description, dateStr, null);
            }
            else
            {
                Class _class = _db.Classes.FirstOrDefault(c => c.ClassId == exam.ClassId);
                title = $"Exam Soon!";
                description = $"The exam for {_class.ClassName} is approaching!";
                dateStr = exam.StartTime.ToString("dddd, dd MMMM yyyy");
                timeStr = exam.StartTime.ToString("hh:mm tt");
                nextEvent = new NextEvent(title, description, dateStr, timeStr);
            }

            return nextEvent;
        }
    }
}
