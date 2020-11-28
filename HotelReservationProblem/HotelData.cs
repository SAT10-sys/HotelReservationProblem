using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace HotelReservationProblem
{
    public enum CustomerType
    {
        REGULAR,
        REWARD
    }
    public class HotelData
    {
        HotelName nameOfHotel; //name of Hotel 
        public double weekDayRateOfHotel; // weekday rate of hotel
        public double weekEndRateOfHotel; // weekend rate of hotel
        public int ratingOfHotel; // rating of hotels
        public HotelData(HotelName nameOfHotel, CustomerType customerType)
        {
            /* parameterized constructor
             * try-catch block checks for exception thrown by invalid hotel name
             */
            this.nameOfHotel = nameOfHotel;
            try
            {
                /* checking name of hotels
                 * inner try-catch block to handle exceptions for invalid customer type
                 * assigning weekday and weekend rates based on customer type
                 */
                if (nameOfHotel.Equals(HotelName.LAKEWOOD))
                {
                    this.ratingOfHotel = 3;
                    try
                    {
                        if(customerType.Equals(CustomerType.REGULAR))
                        { this.weekDayRateOfHotel = 110; this.weekEndRateOfHotel = 90; }
                        if (customerType.Equals(CustomerType.REWARD))
                        { this.weekDayRateOfHotel = 80; this.weekEndRateOfHotel = 80; }
                    }
                    catch(HotelReservationException)
                    {
                        throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
                    }
                }
                if (nameOfHotel.Equals(HotelName.BRIDGEWOOD))
                {
                    this.ratingOfHotel = 4;
                    try
                    {
                        if (customerType.Equals(CustomerType.REGULAR))
                        { this.weekDayRateOfHotel = 160; this.weekEndRateOfHotel = 50; }
                        if (customerType.Equals(CustomerType.REWARD))
                        { this.weekDayRateOfHotel = 100; this.weekEndRateOfHotel = 50; }
                    }
                    catch (HotelReservationException)
                    {
                        throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
                    }
                }
                if (nameOfHotel.Equals(HotelName.RIDGEWOOD))
                {
                    this.ratingOfHotel = 5;
                    try
                    {
                        if (customerType.Equals(CustomerType.REGULAR))
                        { this.weekDayRateOfHotel = 220; this.weekEndRateOfHotel = 150; }
                        if (customerType.Equals(CustomerType.REWARD))
                        { this.weekDayRateOfHotel = 100; this.weekEndRateOfHotel = 40; }
                    }
                    catch (HotelReservationException)
                    {
                        throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
                    }
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
