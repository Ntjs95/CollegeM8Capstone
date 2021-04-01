namespace CollegeM8
{
    public interface IUserLogic
    {
        public User CreateUser(User user);
        public User GetUser(string id, bool expand);
        public User UpdateUser(User user);
        public User Login(Login login);
        public User ChangePassword(ChangePassword login);
        public NextEvent GetNextEvent(string id);
    }
}
