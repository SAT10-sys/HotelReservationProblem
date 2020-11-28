using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationProblem
{
    public class HotelData
    {
        HotelName nameOfHotel; //name of Hotel 
        public double rateOfHotel; // rate of hotel
        public HotelData(HotelName nameOfHotel)
        {
            /* parameterized constructor
             * try-catch block checks for exception thrown by invalid hotel name
             */
            this.nameOfHotel = nameOfHotel;
            try
            {
                if (nameOfHotel.Equals(HotelName.LAKEWOOD))
                    this.rateOfHotel = 110;
                if (nameOfHotel.Equals(HotelName.BRIDGEWOOD))
                    this.rateOfHotel = 150;
                if (nameOfHotel.Equals(HotelName.RIDGEWOOD))
                    this.rateOfHotel = 220;
            }
            catch(HotelReservationException)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_HOTEL_NAME, "Invalid Name of Hotel");
            }
        }
    }
}
