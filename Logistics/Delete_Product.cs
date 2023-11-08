using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    internal class Delete_Product
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


        public static void getId()
        {
            Console.WriteLine("Enter the Id :");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("*************************************************");
            Console.WriteLine("Please find the property details below :");
            using (var con = new SqlConnection(con_string))
            {
                using (var cmd = new SqlCommand("getid", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Product Id:{reader["Id"]}," + "\n" +
                                 $"Product Name:{reader["Product_name"]}," + "\n" +
                                 $"Quantity:{reader["Quantity"]}," + "\n" +
                                 $"Owner Name:{reader["Owner_name"]}," + "\n" +
                                 $"Package id :{reader["Package_id"]}," + "\n" +
                                 $"Packed Date:{reader["Packed_Date"]}," + "\n" +
                                 $"Expected_Date:{reader["Expected_Date"]}," + "\n" +
                                 $"Price:{reader["Price"]}," + "\n" +
                                 $"Delivery status:{reader["Delivery_status"]}," + "\n" +
                                 $"From:{reader["From_Location"]}," + "\n" +
                                 $"To: {reader["To_Location"]}");
                        }
                    }
                }
            }
        }

        public static void delete()
        {

            getId();
            Console.WriteLine("Are you sure that you want to delete this property ? (Y /N)");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'Y')
            {
                using (var con = new SqlConnection(con_string))
                {
                    using (var cmd = new SqlCommand("delete_data", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Property successfully deleted");
            }
            else
            {
                Console.WriteLine("Property not deleted ");
                Get.getProp();
            }

        }
    }
}
