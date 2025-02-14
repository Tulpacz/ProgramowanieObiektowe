using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using Microsoft.Data.SqlClient;
using SerwisRowerowy;
class Program
{
    static void Main(string[] args)
    {
        //string connectionString = "Server=localhost;Database=BikeShop;User Id=sa;Password=your_password;";
        string connectionString = "Server=localhost;Database=serwis_rowerowy_w70934;Trusted_Connection=True;TrustServerCertificate=True;";

        DatabaseManager dbManager = new DatabaseManager(connectionString);
        BikeShopApp app = new BikeShopApp(dbManager);
        app.Run();
    }
}
