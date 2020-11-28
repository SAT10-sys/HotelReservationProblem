using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

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
        public double CostOfHotel(string startDate, string endDate)
        {
            /** this method finds the total cost of the hotel
             * Start and end dates are passed as parameters
             * calculations based on regular rates for number of days stayed
             * returns the total cost
             * */
            double costOfHotel = 0;
            try
            {
                CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                DateTime checkInDate = Convert.ToDateTime(startDate);
                DateTime checkOutDate = Convert.ToDateTime(endDate);
                if (checkInDate > checkOutDate)
                    Console.WriteLine("Invalid Dates entered");
                while(checkInDate<=checkOutDate)
                {
                    costOfHotel = costOfHotel + rateOfHotel;
                    checkInDate=checkInDate.AddDays(1);
                }
            }
            catch(HotelReservationException)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATES, "Invalid Dates entered");
            }
            return costOfHotel;
        }
    }
}
