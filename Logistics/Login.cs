using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    internal class Login
    {
        public static string username;


        public  static string pwd { get; set; }

        static SqlCommand cmd;

        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=project_v;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";

        public static void ShowMenu()
        {

            Start p = new Start();
            p.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' && choice != 'N')
            {
                p.Menu();
            }
        }
        public static void LoginUserInput()
        {
            Console.WriteLine("Enter username");
            username = Console.ReadLine();
            Console.WriteLine("Enter password");
            pwd = Console.ReadLine();
        }


        public  static void logincheck()
        {
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.adminlogincheck(@username,@password_data)", con))
                {


                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_data", pwd);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());


                    //Console.WriteLine(count);
                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                        ShowMenu();


                    }
                    else
                    {
                        Console.WriteLine("User profile not available,Register Yourself");
                        Console.WriteLine("Choose \n 1.Register Yourself \n 2.Exit");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                UserRegister.UserRegistration();
                                break;

                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }
}
