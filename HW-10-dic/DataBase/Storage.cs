using HW_10.Entities;

namespace HW_10.DataBase
{
    public static class Storage
    {
        public static User? Onlineuser { get; set; }

        public static List<Dictionary<string, string>> dictionary = new List<Dictionary<string, string>>
         {
         new Dictionary<string, string>
        {
        {"--username", "aso@"},
        {"--password", "123"},
        {"--status", "available"}
        },
        new Dictionary<string, string>
        {
        {"--username", "roza@"},
        {"--password", "123"},
        {"--status", "available"}
        },
        new Dictionary<string, string>
        {
        {"--username", "Zahra@"},
        {"--password", "123"},
         {"--status", "available"}
        }
        };






    }
}
