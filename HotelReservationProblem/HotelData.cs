using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace HotelReservationProblem
{
    public class HotelData
    {
        HotelName nameOfHotel; //name of Hotel 
        public double weekDayRateOfHotel; // weekday rate of hotel
        public double weekEndRateOfHotel; // weekend rate of hotel
        public int ratingOfHotel; // rating of hotels
        public HotelData(HotelName nameOfHotel)
        {
            /* parameterized constructor
             * try-catch block checks for exception thrown by invalid hotel name
             */
            this.nameOfHotel = nameOfHotel;
            try
            {
                if (nameOfHotel.Equals(HotelName.LAKEWOOD))
                {
                    this.weekDayRateOfHotel = 110;
                    this.weekEndRateOfHotel = 90;
                    this.ratingOfHotel = 3;
                }
                if (nameOfHotel.Equals(HotelName.BRIDGEWOOD))
                {
                    this.weekDayRateOfHotel = 150;
                    this.weekEndRateOfHotel = 50;
                    this.ratingOfHotel = 4;
                }
                if (nameOfHotel.Equals(HotelName.RIDGEWOOD))
                {
                    this.weekDayRateOfHotel = 220;
                    this.weekEndRateOfHotel = 150;
                    this.ratingOfHotel = 5;
                }
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
             * weekday and weekend rates are considered seperately
             * returns the total cost
             */
            double totalcostOfHotel;
            double totalWeekDayCost = 0; //total cost for weekdays only
            double totalweekEndCost = 0; // total cost for weekends only      
            try
            {
                CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                DateTime checkInDate = Convert.ToDateTime(startDate);
                DateTime checkOutDate = Convert.ToDateTime(endDate);
                if (checkInDate > checkOutDate)
                    Console.WriteLine("Invalid Dates entered");
                while(checkInDate<=checkOutDate)
                {
                    if (checkInDate.DayOfWeek == DayOfWeek.Saturday || checkInDate.DayOfWeek == DayOfWeek.Sunday) //checking for weekends
                        totalweekEndCost = totalweekEndCost + weekEndRateOfHotel; 
                    else
                        totalWeekDayCost = totalWeekDayCost + weekDayRateOfHotel;
                    checkInDate=checkInDate.AddDays(1);
                }
                totalcostOfHotel = totalWeekDayCost + totalweekEndCost; //total cost is summation of total weekday and weekend costs
            }           
            catch(Exception)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATES, "Invalid Dates entered");
            }
            return totalcostOfHotel;
        }            
    }
}
