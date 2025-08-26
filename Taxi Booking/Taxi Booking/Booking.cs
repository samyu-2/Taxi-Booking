using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Booking
{
    class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public char PickupPoint { get; set; }
        public char DropPoint { get; set; }
        public int PickupTime { get; set; }
        public int DropTime { get; set; }
        public int Amount { get; set; }
    }
}
