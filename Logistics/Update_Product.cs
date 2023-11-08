using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    internal class Update_Product
    {
        public static int id;
        public static string prodName;
        public static int Quantity;
        public static string Owner_name;
        public static int Package_id;
        public static string Packed_Date;
        public static string Expected_Date;
        public static int Price;
        public static string Delivery_status;
        public static string From_Location;
        public static string To_Location;

        public static string con_string = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=project_v;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";


        public static void getinput()
        {
            Console.WriteLine("Enter the Product:");
            prodName = Console.ReadLine();

            Console.WriteLine("Enter the Quantity:");
            Quantity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Owner_name:");
            Owner_name = Console.ReadLine();

            Console.WriteLine("Enter the Package_id:");
            Package_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Packed_Date:");
            Packed_Date = Console.ReadLine();

            Console.WriteLine("Enter the Expected_Date:");
            Expected_Date = Console.ReadLine();

            Console.WriteLine("Enter the Price:");
            Price = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Delivery_status:");
            Delivery_status = Console.ReadLine();

            Console.WriteLine("Enter the From_Location:");
            From_Location = Console.ReadLine();

            Console.WriteLine("Enter the To_Location:");
            To_Location = Console.ReadLine();
        }
        public static void Update()
        {
            GetById.getId();
            Console.WriteLine("Please enter the details to be updated");
           getinput();
            using (var con = new SqlConnection(con_string))
            {
                using (var cmd = new SqlCommand("update_data", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Product_name", prodName);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.Parameters.AddWithValue("@Owner_name", Owner_name);
                    cmd.Parameters.AddWithValue("@Package_id", Package_id);
                    cmd.Parameters.AddWithValue("@Packed_Date", Packed_Date);
                    cmd.Parameters.AddWithValue("@Expected_Date", Expected_Date);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Delivery_status", Delivery_status);
                    cmd.Parameters.AddWithValue("@From_Location", From_Location);
                    cmd.Parameters.AddWithValue("@To_Location", To_Location);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Package details successfully updated");


                }
            }
        }

    }
}
