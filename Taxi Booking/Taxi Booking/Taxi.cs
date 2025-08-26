using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Booking
{
    class Taxi
    {
        public int TaxiId { get; set; }
        public char CurrentLocation { get; set; }
        public int FreeTime { get; set; }
        public int TotalEarnings { get; set; }
        public List<Booking> Bookings { get; set; }

        public Taxi(int id)
        {
            TaxiId = id;
            CurrentLocation = 'A';
            FreeTime = 0;
            TotalEarnings = 0;
            Bookings = new List<Booking>();
        }

        public void AssignTaxi(Booking booking)
        {
            Bookings.Add(booking);
            TotalEarnings += booking.Amount;
            CurrentLocation = booking.DropPoint;
            FreeTime = booking.DropTime;
        }
    }
}
