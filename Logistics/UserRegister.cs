using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    internal class UserRegister
    {
        public static string username;


        public static string pwd { get; set; }

        static SqlCommand cmd;

        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=project_v;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static void LoginUserInput()
        {
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            pwd = Console.ReadLine();
        }
        public static void UserRegistration()
        {
            LoginUserInput();
            using (var con = new SqlConnection(connectionString))
            {


                using (var cmd = new SqlCommand("userregistration", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usd", username);
                    cmd.Parameters.AddWithValue("@pwd ", pwd);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User registration successfull");
                    Login.ShowMenu();

                }
            }
        }
    }
}
