using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Booking
{
    class TaxiManager
    {
        List<Taxi> taxis = new List<Taxi>();
        int bookingCounter = 1;

        public TaxiManager(int taxiCount)
        {
            for(int i = 1; i <= taxiCount; i++)
            {
                taxis.Add(new Taxi(i));
            }
        }

        private int CalculateFare(char pickup,char drop)
        {
            int distance = Math.Abs(pickup - drop) * 15;
            if (distance <= 5) return 100;
            return 100 + (distance - 5) * 10;
        }

        public void BookTaxi(int customerId,char pickup,char drop,int pickupTime)
        {
            Taxi selectedTaxi = null;
            int minDistance = int.MaxValue;

            foreach(var taxi in taxis)
            {
                if(taxi.FreeTime <= pickupTime)
                {
                    int distance = Math.Abs(taxi.CurrentLocation - pickup) * 15;
                    if(distance < minDistance || (distance == minDistance && taxi.TotalEarnings < (selectedTaxi?.TotalEarnings ?? int.MaxValue)))
                    {
                        minDistance = distance;
                        selectedTaxi = taxi;
                    }
                }
            }
            if(selectedTaxi == null)
            {
                Console.WriteLine("No Taxi can be alloted");
                return;
            }

            int amount = CalculateFare(pickup, drop);
            int dropTime = pickupTime + (Math.Abs(pickup - drop)) * 1;

            Booking booking = new Booking
            {
                BookingId = bookingCounter++,
                CustomerId = customerId,
                PickupPoint = pickup,
                DropPoint = drop,
                PickupTime = pickupTime,
                DropTime = dropTime,
                Amount = amount
            };
            selectedTaxi.AssignTaxi(booking);
            Console.WriteLine($"Taxi - {selectedTaxi.TaxiId} is alloted");
        }

        public void DisplayTaxiDetails()
        {
            foreach(var taxi in taxis)
            {
                Console.WriteLine($"\nTaxi - {taxi.TaxiId} Total Earnings: Rs.{taxi.TotalEarnings}");
                Console.WriteLine("BookingID  CustomerID  From  To  PickupTime  DropTime  Amount");
                foreach (var b in taxi.Bookings)
                {
                    Console.WriteLine($"{b.BookingId}           {b.CustomerId}           {b.PickupPoint}     {b.DropPoint}       {b.PickupTime}          {b.DropTime}        {b.Amount}");
                }
            }
        }
    }
}
