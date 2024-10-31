using HW_10.Cantract;
using HW_10.DataBase;
using HW_10.Entities;
using Newtonsoft.Json;


namespace HW_10.Repository
{
    public class UserRepository : IUserRepository
    {
        string path = @"c:\Botkamp Sharif\Hw-10\UsersList.json";
        public Result AddUser(string username, string password)
        {
            var date = File.ReadAllText(path);
            var userlist = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(date);
            bool check = false;

            foreach (var dict in userlist)
            {
                if (dict.ContainsKey("--username") && dict["--username"] == username)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                return new Result(false);
            }
            else
            {
                var newdictionary = new Dictionary<string, string>()
                    {
                        { "--username" , username },
                        { "--password" , password }
                    };
                userlist.Add(newdictionary);
                var resultF = JsonConvert.SerializeObject(userlist);
                File.WriteAllText(path, resultF);

                return new Result(true);
            }
        }
        public Result GetUsers(string username)
        {
            var date = File.ReadAllText(path);
            var userlist = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(date);
            bool check = false;
            foreach (var dict in userlist)
            {
                if (dict.ContainsKey("--username") && dict["--username"] == username)
                {
                    return new Result(true);
                }
            }
            return new Result(false);

        }
        public Result ChangePassword(string oldpass, string newpass)
        {
            try
            {
                var date = File.ReadAllText(path);
                var userlist = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(date);

                if (Storage.Onlineuser.UserName != null)
                {

                    bool check = false;

                    foreach (var dict in userlist)
                    {
                        if (dict.ContainsKey("--username") && dict["--username"] == Storage.Onlineuser.UserName)
                        {
                            dict["--password"] = newpass;
                            var resultF = JsonConvert.SerializeObject(userlist);
                            File.WriteAllText(path, resultF);

                            return new Result(true);
                        }
                    }


                }

            }
            catch (Exception)
            {
                return new Result(true, "change password is unsuccessfull");
            }
            return new Result(false);
        }
        public Result ChangeStatus(string status)
        {
            var date = File.ReadAllText(path);
            var userlist = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(date);
            if (Storage.Onlineuser.UserName != null)
            {

                bool check = false;

                foreach (var dict in userlist)
                {
                    if (dict.ContainsKey("--username") && dict["--username"] == Storage.Onlineuser.UserName)
                    {
                        dict["--status"] = status;
                        var resultF = JsonConvert.SerializeObject(userlist);
                        File.WriteAllText(path, resultF);

                        return new Result(true, "change status is unsuccessfull");
                    }
                }


            }
            return new Result(false, "change status is unsuccessfull");
        }
        public List<User> seartch(string username)
        {
            var date = File.ReadAllText(path);
            var userlist = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(date);
           

            List<User> result = new List<User>();
            foreach (var dict in userlist)
            {
                if (dict.ContainsKey("--username") && dict["--username"].Substring(0, 2) == username)
                {
                    int i = username.Count();
                    if (dict["--username"].Substring(0, i) == username)
                    {
                        string resultusername = dict["--username"];
                        string resultpasword = dict["--password"];
                        string resultstatus = dict["--status"];


                        result.Add(new User( resultusername,  resultpasword,  resultstatus));
                     
                    }
                }
            }
            return result;
        }

        public void login(string username, string password)
        {
            User user = new User(username, password);
            Storage.Onlineuser = user;

        }
    }
}

