using Logistics;
using System.Data;

class Start
{

    public void Menu()
    {
        Console.WriteLine("Choose \n 1.View All product \n 2.Insert product \n 3.Update product \n 4.Delete product \n 5.Track your package \n 6.Exit");
        Console.WriteLine("What do you Need ????");
        int options = Convert.ToInt32(Console.ReadLine());
      
        

        switch (options)
        {

            case 1:
                Get.getProp();
                break;
            case 2:
                Insert_Product.insert();
                break;
            case 3:
                Update_Product.Update();
                break;
            case 4:
                Delete_Product.delete();
                break;
            case 5:
                Tracking.Track();

                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }
    public static void Main()
    {

        //Login lg = new Login();
        Login.logincheck();
        //Crud.getProp();
        //Crud.insert();
        //Crud.Update();
        //Crud.getId();
        //Crud.delete();



    }
}