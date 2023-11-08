//using Azure;
//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Logistics
//{
//    internal class Crud
//    {
//        public static int id;
//        public static string prodName;
//        public static int Quantity;
//        public static string Owner_name;
//        public static int Package_id;
//        public static string Packed_Date;
//        public static string Expected_Date;
//        public static int Price;
//        public static string Delivery_status;
//        public static string From_Location;
//        public static string To_Location;

//        public static string con_string= "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=project_v;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";


//        //public static void getProp()
//        //{
//        //    Console.WriteLine("_____________________________________________");
//        //    using (var con = new SqlConnection(con_string))
//        //    {
//        //        using (var cmd = new SqlCommand("get_details", con))
//        //        {
//        //            cmd.CommandType = CommandType.StoredProcedure;
//        //            con.Open();
//        //            using (var reader = cmd.ExecuteReader())
//        //            {
//        //                while (reader.Read())
//        //                {
//        //                    Console.WriteLine($"Product Id:{reader["Id"]}," + "\n" +
//        //                        $"Product Name:{reader["Product_name"]}," + "\n" +
//        //                        $"Quantity:{reader["Quantity"]}," + "\n" +
//        //                        $"Owner Name:{reader["Owner_name"]}," + "\n" +
//        //                        $"Package id :{reader["Package_id"]}," + "\n" +
//        //                        $"Packed Date:{reader["Packed_Date"]}," + "\n" +
//        //                        $"Expected_Date:{reader["Expected_Date"]}," + "\n" +
//        //                        $"Price:{reader["Price"]}," + "\n" +
//        //                        $"Delivery status:{reader["Delivery_status"]}," + "\n" +
//        //                        $"From:{reader["From_Location"]}," + "\n" +
//        //                        $"To: {reader["To_Location"]}");
//        //                    Console.WriteLine("_____________________________________________");
//        //                }
//        //            }


//        //        }
//        //    }


//        //}

//        public static void getinput()
//        {
//            Console.WriteLine("Enter the Product:");
//            prodName = Console.ReadLine();

//            Console.WriteLine("Enter the Quantity:");
//            Quantity = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("Enter the Owner_name:");
//            Owner_name =Console.ReadLine();

//            Console.WriteLine("Enter the Package_id:");
//            Package_id = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("Enter the Packed_Date:");
//            Packed_Date = Console.ReadLine(); 

//            Console.WriteLine("Enter the Expected_Date:");
//            Expected_Date = Console.ReadLine();

//            Console.WriteLine("Enter the Price:");
//            Price = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("Enter the Delivery_status:");
//            Delivery_status = Console.ReadLine();

//            Console.WriteLine("Enter the From_Location:");
//            From_Location = Console.ReadLine();

//            Console.WriteLine("Enter the To_Location:");
//            To_Location = Console.ReadLine();
//        }

//        public static void insert()
//        {
//            //SqlConnection con = null;
//            // Creating Connection  
//            // SqlConnection con = new SqlConnection("Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=project_v;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
//            // writing sql query  
//            // SqlCommand cm = new SqlCommand("insert into iProperty (propname,ownername,propage,propprice,posteddate)\r\nvalues ('1 bhk ','Mary',2,100000,'11/2/2023')", con);
//            getinput();
//            using (var con = new SqlConnection(con_string))
//            {
//                using (var cmd = new SqlCommand("insert_data", con))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@Product_name", prodName);
//                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
//                    cmd.Parameters.AddWithValue("@Owner_name", Owner_name);
//                    cmd.Parameters.AddWithValue("@Package_id", Package_id);
//                    cmd.Parameters.AddWithValue("@Packed_Date", Packed_Date);
//                    cmd.Parameters.AddWithValue("@Expected_Date", Expected_Date);
//                    cmd.Parameters.AddWithValue("@Price", Price);
//                    cmd.Parameters.AddWithValue("@Delivery_status", Delivery_status);
//                    cmd.Parameters.AddWithValue("@From_Location", From_Location);
//                    cmd.Parameters.AddWithValue("@To_Location", To_Location);
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    Console.WriteLine("Property details successfully added");
//                    //GetPropertyDetails();


//                }
//            }
//            //getProp();
//        }
//        public static void getId()
//        {
//            Console.WriteLine("Enter the property Id :");
//            id = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("*************************************************");
//            Console.WriteLine("Please find the property details below :");
//            using (var con = new SqlConnection(con_string))
//            {
//                using (var cmd = new SqlCommand("getid", con))
//                {
//                    con.Open();
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@id", id);

//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            Console.WriteLine($"Product Id:{reader["Id"]}," + "\n" +
//                                 $"Product Name:{reader["Product_name"]}," + "\n" +
//                                 $"Quantity:{reader["Quantity"]}," + "\n" +
//                                 $"Owner Name:{reader["Owner_name"]}," + "\n" +
//                                 $"Package id :{reader["Package_id"]}," + "\n" +
//                                 $"Packed Date:{reader["Packed_Date"]}," + "\n" +
//                                 $"Expected_Date:{reader["Expected_Date"]}," + "\n" +
//                                 $"Price:{reader["Price"]}," + "\n" +
//                                 $"Delivery status:{reader["Delivery_status"]}," + "\n" +
//                                 $"From:{reader["From_Location"]}," + "\n" +
//                                 $"To: {reader["To_Location"]}");
//                        }
//                    }
//                }
//            }
//        }

//        public static void Update()
//        {
//            GetById.getId();
//            Console.WriteLine("Please enter the details to be updated");
//            getinput();
//            using (var con = new SqlConnection(con_string))
//            {
//                using (var cmd = new SqlCommand("update_data", con))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@id", id);
//                    cmd.Parameters.AddWithValue("@Product_name", prodName);
//                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
//                    cmd.Parameters.AddWithValue("@Owner_name", Owner_name);
//                    cmd.Parameters.AddWithValue("@Package_id", Package_id);
//                    cmd.Parameters.AddWithValue("@Packed_Date", Packed_Date);
//                    cmd.Parameters.AddWithValue("@Expected_Date", Expected_Date);
//                    cmd.Parameters.AddWithValue("@Price", Price);
//                    cmd.Parameters.AddWithValue("@Delivery_status", Delivery_status);
//                    cmd.Parameters.AddWithValue("@From_Location", From_Location);
//                    cmd.Parameters.AddWithValue("@To_Location", To_Location);
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    Console.WriteLine("Package details successfully updated");


//                }
//            }
//        }


//        public static void delete()
//        {

//            getId();
//            Console.WriteLine("Are you sure that you want to delete this property ? (Y /N)");
//            char choice = Convert.ToChar(Console.ReadLine());
//            if (choice == 'Y')
//            {
//                using (var con = new SqlConnection(con_string))
//                {
//                    using (var cmd = new SqlCommand("delete_data", con))
//                    {
//                        cmd.CommandType = CommandType.StoredProcedure;
//                        cmd.Parameters.AddWithValue("@id", id);
//                        con.Open();
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//                Console.WriteLine("Property successfully deleted");
//            }
//            else
//            {
//                Console.WriteLine("Property not deleted ");
//                Get.getProp();
//            }

//        }

//    }

    
//}
