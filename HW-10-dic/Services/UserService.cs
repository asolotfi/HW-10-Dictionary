using HW_10.Entities;
using HW_10.Repository;

namespace HW_10.UserService
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        public Result Register(string username, string password)
        {


            var result = userRepository.AddUser(username, password);
            if (result.IsSucces)
            {
                return new Result(true);
            }
            else
            {
                return new Result(false);
            }



        }

        public Result login(string username, string password)
        {


            var users = userRepository.GetUsers(username);
            if (users.IsSucces)
            {
                userRepository.login(username, password);
                return new Result(true, "login is successfull");
            }

            return new Result(false, "login is unsuccessfull");
        }

        public Result ChhangePassword(string newpass, string oldpass)
        {
            var result = userRepository.ChangePassword(newpass, oldpass);
            if (result.IsSucces)
            {

                return new Result(true, "change password is successfull");
            }
            else
            {
                return new Result(true, "change password is unsuccessfull");
            }
        }
        public Result ChangeStatus(string status)
        {
            var result = userRepository.ChangeStatus(status);
            if (result.IsSucces)
            {


                return new Result(true, "changestatus is successfull");
            }
            else
            {
                return new Result(true, "change status is unsuccessfull");
            }

        }
        public Result seartch(string username)
        {
            var result = userRepository.seartch(username);
            if (result.Count > 0)
            {
                foreach (User user in result)
                {
                    Console.WriteLine($"{user.UserName}  Status:{user.Status}");
                }
            }

            return new Result(true, "change status is unsuccessfull");
        }
    }
}
