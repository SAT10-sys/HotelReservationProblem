using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HotelReservationProblem
{
    public class HotelOperations
    {
        public string REGEX_REGULAR = "^[Rr][Ee][Gg][Uu][Ll][Aa][Rr]$";
        public string REGEX_REWARD = "^[Rr][Ee][Ww][Aa][Rr][Dd]$";
        public void DisplayListOfHotels(CustomerType customerType)
        {
            /** this method helps us display list of hotels along with details
             * customer type is passed as parameters
             * objects of enum are created which are passed along with customertype to the invoked constructor of HotelData class
             */
            Console.WriteLine("\n");
            Console.WriteLine("Displaying for {0} Customer type",customerType);
            Console.WriteLine("HOTEL NAME\tRATING\tWEEKDAY RATES\tWEEKEND RATES");
            HotelName hotelName = HotelName.LAKEWOOD;
            HotelData lakeWood = new HotelData(hotelName, customerType);
            Console.WriteLine(hotelName+"\t"+lakeWood.ratingOfHotel+"\t\t"+lakeWood.weekDayRateOfHotel+"\t\t"+lakeWood.weekEndRateOfHotel);
            hotelName = HotelName.BRIDGEWOOD;
            HotelData bridgeWood = new HotelData(hotelName, customerType);
            Console.WriteLine(hotelName+"\t"+bridgeWood.ratingOfHotel+"\t\t"+bridgeWood.weekDayRateOfHotel+"\t\t"+bridgeWood.weekEndRateOfHotel);
            hotelName = HotelName.RIDGEWOOD;
            HotelData ridgeWood = new HotelData(hotelName, customerType);
            Console.WriteLine(hotelName+"\t"+ridgeWood.ratingOfHotel+"\t\t"+ridgeWood.weekDayRateOfHotel+"\t\t"+ridgeWood.weekEndRateOfHotel);
        }
        public void FindCheapestHotel(string checkInDate, string checkOutDate, CustomerType customerType)
        {
             /*this method finds out the cheapest hotel
             * checkin and checkout dates along with customer type are passed as parameters
             * objects of enum HotelName are created which are passed as parameters to the method finding hotel cost
             * finally they are compared
             */
            HotelName hotelName1;
            HotelName hotelName2;
            HotelName hotelName3;
            HotelName hotelName = HotelName.LAKEWOOD;
            HotelData lakeWood = new HotelData(hotelName, customerType);
            double rateOfLakeWood = lakeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.BRIDGEWOOD;
            HotelData bridgeWood = new HotelData(hotelName, customerType);
            double rateOfBridgeWood = bridgeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.RIDGEWOOD;
            HotelData ridgeWood = new HotelData(hotelName, customerType);
            double rateOfRidgeWood = ridgeWood.CostOfHotel(checkInDate, checkOutDate);
            if(rateOfLakeWood<rateOfBridgeWood && rateOfLakeWood<rateOfRidgeWood)
            {
                hotelName = HotelName.LAKEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: "+hotelName);
                Console.WriteLine("Rating of the hotel: " + lakeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: "+rateOfLakeWood);
            }
            if(rateOfBridgeWood<rateOfLakeWood && rateOfBridgeWood<rateOfRidgeWood)
            {
                hotelName = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + bridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfBridgeWood);
            }
            if(rateOfRidgeWood<rateOfLakeWood && rateOfRidgeWood<rateOfBridgeWood)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood);
            }
            if(rateOfLakeWood==rateOfBridgeWood && rateOfLakeWood<rateOfRidgeWood)
            {
                hotelName1 = HotelName.LAKEWOOD;
                hotelName2 = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1+"\t"+hotelName2);
                Console.WriteLine("Rating of the hotel: " + lakeWood.ratingOfHotel+"\t"+bridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood+"\t"+rateOfBridgeWood);
            }
            if(rateOfLakeWood==rateOfRidgeWood && rateOfLakeWood<rateOfBridgeWood)
            {
                hotelName1 = HotelName.LAKEWOOD;
                hotelName2 = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1 + "\t" + hotelName2);
                Console.WriteLine("Rating of the hotel: " + lakeWood.ratingOfHotel+"\t"+ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood + "\t" + rateOfRidgeWood);
            }
            if(rateOfBridgeWood==rateOfRidgeWood && rateOfBridgeWood<rateOfLakeWood)
            {
                hotelName1 = HotelName.RIDGEWOOD;
                hotelName2 = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1 + "\t" + hotelName2);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel+"\t"+bridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood + "\t" + rateOfBridgeWood);
            }
            if(rateOfLakeWood==rateOfBridgeWood && rateOfLakeWood==rateOfRidgeWood)
            {
                hotelName1 = HotelName.LAKEWOOD;
                hotelName2 = HotelName.BRIDGEWOOD;
                hotelName3 = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1 + "\t" + hotelName2+"\t"+hotelName3);
                Console.WriteLine("Rating of the hotel: " + lakeWood.ratingOfHotel+"\t"+bridgeWood.ratingOfHotel+"\t"+ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood + "\t" + rateOfBridgeWood+"\t"+rateOfRidgeWood);
            }
        }
        public void BestRatedHotel(string checkInDate, string checkOutDate, CustomerType customerType)
        {
            /** this method helps us find the best rated hotel
             * checkin and checkout dates along with customer types are passed as parameters     
             * */
            HotelName hotelName = HotelName.LAKEWOOD;
            HotelData lakeWood = new HotelData(hotelName,customerType);
            double rateOfLakeWood = lakeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.BRIDGEWOOD;
            HotelData bridgeWood = new HotelData(hotelName, customerType);
            double rateOfBridgeWood = bridgeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.RIDGEWOOD;
            HotelData ridgeWood = new HotelData(hotelName, customerType);
            double rateOfRidgeWood = ridgeWood.CostOfHotel(checkInDate, checkOutDate);
            if(lakeWood.ratingOfHotel>bridgeWood.ratingOfHotel && lakeWood.ratingOfHotel>ridgeWood.ratingOfHotel)
            {
                hotelName = HotelName.LAKEWOOD;
                Console.WriteLine("Best rated hotel is: "+hotelName);
                Console.WriteLine("Rating of the hotel: "+ lakeWood.ratingOfHotel);
                Console.WriteLine("Total Cost: "+rateOfLakeWood);
            }
            if (bridgeWood.ratingOfHotel > lakeWood.ratingOfHotel && bridgeWood.ratingOfHotel > ridgeWood.ratingOfHotel)
            {
                hotelName = HotelName.BRIDGEWOOD;
                Console.WriteLine("Best rated hotel is: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + bridgeWood.ratingOfHotel);
                Console.WriteLine("Total Cost: " + rateOfBridgeWood);
            }
            if (ridgeWood.ratingOfHotel > bridgeWood.ratingOfHotel && ridgeWood.ratingOfHotel > bridgeWood.ratingOfHotel)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Best rated hotel is: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel);
                Console.WriteLine("Total Cost: " + rateOfRidgeWood);
            }
        }
        public void BestRatedCheapestHotel(string checkInDate, string checkOutDate, CustomerType customerType)
        {
            /* this method finds best rated cheapest hotels
             * check-in and check-out dates along with customer types are passed as parameters
             * first the cheapest hotels are found 
             * then details of the hotel having highest rating is printed
             */
            HotelName hotelName = HotelName.LAKEWOOD;
            HotelData lakeWood = new HotelData(hotelName, customerType);
            double rateOfLakeWood = lakeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.BRIDGEWOOD;
            HotelData bridgeWood = new HotelData(hotelName, customerType);
            double rateOfBridgeWood = bridgeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.RIDGEWOOD;
            HotelData ridgeWood = new HotelData(hotelName, customerType);
            double rateOfRidgeWood = ridgeWood.CostOfHotel(checkInDate, checkOutDate);
            if (rateOfLakeWood < rateOfBridgeWood && rateOfLakeWood < rateOfRidgeWood)
            {
                hotelName = HotelName.LAKEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + lakeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood);
            }
            if (rateOfBridgeWood < rateOfLakeWood && rateOfBridgeWood < rateOfRidgeWood)
            {
                hotelName = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + bridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfBridgeWood);
            }
            if (rateOfRidgeWood < rateOfLakeWood && rateOfRidgeWood < rateOfBridgeWood)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood);
            }
            if (rateOfLakeWood == rateOfBridgeWood && rateOfLakeWood < rateOfRidgeWood)
            {
                hotelName = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest and Best Rated Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + bridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfBridgeWood);
            }
            if (rateOfLakeWood == rateOfRidgeWood && rateOfLakeWood < rateOfBridgeWood)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood);
            }
            if (rateOfBridgeWood == rateOfRidgeWood && rateOfBridgeWood < rateOfLakeWood)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood);
            }
            if (rateOfLakeWood == rateOfBridgeWood && rateOfLakeWood == rateOfRidgeWood)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName);
                Console.WriteLine("Rating of the hotel: " + ridgeWood.ratingOfHotel);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood);
            }
        }
        public CustomerType ValidateUsingRegularExpressions(string customerType)
        {
            /* passing customertype as string type variable as parameter
             * validated with the pre-defined Regular Expressions
             * if not matched then Invalid Customer Type Exception is thrown
             */
            if (Regex.IsMatch(customerType, REGEX_REGULAR))
                return CustomerType.REGULAR;
            else if (Regex.IsMatch(customerType, REGEX_REWARD))
                return CustomerType.REWARD;
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
        }
    }
}
