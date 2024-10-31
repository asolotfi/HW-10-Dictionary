using HW_10.Entities;

namespace HW_10.Cantract
{
    public interface IUserRepository
    {
        Result AddUser(string username, string password);

        Result ChangePassword(string newpass, string oldpass);
        Result ChangeStatus(string status);
        List<User> seartch(string username);
        void login(string username, string password);
        Result GetUsers(string username);
    }
}
