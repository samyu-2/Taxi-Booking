using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Booking
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxiManager manager = new TaxiManager(4);
            //,char ,char drop,int pickupTime)
            bool choice = true;
            int customerId = 1;
            while (choice)
            {
                
                Console.WriteLine("Welcome to taxi booking");
                Console.Write("Enter pickup(A-F): ");
                char pickup = Char.ToUpper(Console.ReadLine()[0]) ;
                Console.Write("Enter drop(A-F): ");
                char drop = Char.ToUpper(Console.ReadLine()[0]);
                Console.Write("Enter pickupTime: ");
                int pickupTime = Convert.ToInt32(Console.ReadLine());

                manager.BookTaxi(customerId, pickup, drop, pickupTime);

                Console.Write("Do you want to continue your Journey:(Y/N) ");
                char preference = Char.ToUpper(Console.ReadLine()[0]);
                choice = preference == 'Y' ? true : false;
                customerId++;

            }
            //manager.BookTaxi(1, 'A', 'B', 9);
            //manager.BookTaxi(2, 'B', 'D', 9);
            //manager.BookTaxi(3, 'B', 'C', 12);

            manager.DisplayTaxiDetails();
            Console.ReadLine();
        }
    }
}
