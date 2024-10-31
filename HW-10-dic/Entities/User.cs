using HW_10.DataBase;

namespace HW_10.Entities
{
    public class User
    {

        public User(string userName, string password, string status)
        {
            Id = GetId();
            UserName = userName;
            Password = password;
            Status = "available";
        }
    
        public User(string username, string password)
        {
            UserName = username;
            Password = password;
            Status = "available";
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int GetId()
        {
            int x = 0;

            x = Storage.dictionary.Count();
            x++;
            return x;

        }

        public Result checkPassword(string pass)
        {
            if (Password == pass)

                return new Result(true, null);
            else
                return new Result(false, "password Is Incorrect.");

        }

    }
}
