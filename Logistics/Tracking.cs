using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    internal class Tracking
    {
        public static int  package_id;
        public static int count;
        public static string con_string = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=project_v;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        

        public static  void Track()
        {
            Console.WriteLine("Enter the package Id :");
            package_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-----------------------------------");


            using (var con = new SqlConnection(con_string))
            {
                using (var cmd = new SqlCommand("select dbo.track_check(@Pac_id)", con))
                {
                    cmd.Parameters.AddWithValue("@Pac_id", package_id);
                    con.Open();
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }  
            if(count==1)
            {
                using (var con = new SqlConnection(con_string))
                {
                    using (var cmd = new SqlCommand("track", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", package_id);

                        con.Open();
                      
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Delivery status:{reader["Delivery_status"]}," + "\n" +
                                     $"From:{reader["From_Location"]}," + "\n" +
                                     $"To: {reader["To_Location"]}");

                                Console.WriteLine("-----------------------------------");
                            }
                        }
                    }
                }

            }

 
            else
            { 
                Console.WriteLine("Invalid Tracking number"); }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("-----------------------------------");
        }
   
          

    }
}








































