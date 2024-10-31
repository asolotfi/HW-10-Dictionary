using HW_10.DataBase;
using HW_10.UserService;
using Newtonsoft.Json;
using System.IO;


UserService userService = new UserService();
string directoryPath = @"c:\Botkamp Sharif\Hw-10";
string filePath = "UsersList.json";
string fullpath = Path.Combine(directoryPath, filePath);

if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}
string jsonData = JsonConvert.SerializeObject(Storage.dictionary);
try
{
    File.WriteAllText(fullpath, jsonData);
    Console.WriteLine("Data saved to file sucssecfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Data saved to file unsucssecfully");
}
while (true)
{
    Console.Clear();
    Console.WriteLine("Enter command for Example --> Register --username aso@ --password 123");
    Console.WriteLine("Enter command for Example --> login --username aso@ --password 123");
    Console.WriteLine("Enter command for Example --> changepassword --old 123 --new 1234");
    Console.WriteLine("Enter command for Example --> update --status  notavailable");
    Console.WriteLine("Enter command for Example --> seartch --username  as");
    Console.WriteLine("Enter command for Example --> logout");


    string command = Console.ReadLine();
    var parts = command.Split(' ');
    string action = parts[0];


    var username = "";
    var password = "";
    var status = "";
    //delete space
    
    switch (action.ToLower().Trim())
    {
        case "register":
            username = parts[2];
            password = parts[4];
            var results = userService.Register(username, password);
            if (results.IsSucces)
            {
                Console.WriteLine("register is successfull");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("register is unsuccessfull");
                Console.ReadLine();      
            }
            break;
        case "login":
            username = parts[2];
            password = parts[4];
           var resultl = userService.login(username, password);
            if (resultl.IsSucces)
            {
                Console.WriteLine("login is successfull");
                Console.ReadLine();           
            }
            else
            {
                Console.Write("login failed! username already exists.");
                Console.ReadLine();
            }
            break;
        case "changepassword":
            if (Storage.Onlineuser != null)
            {
                username = parts[2];
                password = parts[4];
                var resultch = userService.ChhangePassword(username, password);
                if (resultch.IsSucces)
                {
                    Console.WriteLine("change password is successfull");
                    Console.ReadLine();
                
                }
            }
            else
            {
                Console.Write("login.");
                Console.ReadLine();
            }         
            break;
        case "update":
            if (Storage.Onlineuser != null)
            {
                status = parts[3];
                var resultch = userService.ChangeStatus(status);
                if (resultch.IsSucces)
                {
                    Console.WriteLine("change password is successfull");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("login.");
                Console.ReadLine();
            }
            break;
        case "seartch":
            if (Storage.Onlineuser != null)
            {
                username = parts[3];
                var resultch = userService.seartch(username);
                if (resultch.IsSucces)
                {
                    Console.WriteLine(" successfull");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("login.");
                Console.ReadLine();
            }
            break;
        case "logout":
            Storage.Onlineuser.Status = null;

            break;
        default:
            Console.WriteLine("unknown");
            break;

    }
}
