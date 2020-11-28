using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationProblem
{
    public class HotelOperations
    {
        public void FindCheapestHotel(string checkInDate, string checkOutDate)
        {
            /** this method finds out the cheapest hotel
             * checkin and checkout dates are passed as parameters
             * objects of enum HotelName are created which are passed as parameters to the method finding hotel cost
             * finally they are compared
             */
            HotelName hotelName1;
            HotelName hotelName2;
            HotelName hotelName3;
            HotelName hotelName = HotelName.LAKEWOOD;
            HotelData lakeWood = new HotelData(hotelName);
            double rateOfLakeWood = lakeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.BRIDGEWOOD;
            HotelData bridgeWood = new HotelData(hotelName);
            double rateOfBridgeWood = bridgeWood.CostOfHotel(checkInDate, checkOutDate);
            hotelName = HotelName.RIDGEWOOD;
            HotelData ridgeWood = new HotelData(hotelName);
            double rateOfRidgeWood = ridgeWood.CostOfHotel(checkInDate, checkOutDate);
            if(rateOfLakeWood<rateOfBridgeWood && rateOfLakeWood<rateOfRidgeWood)
            {
                hotelName = HotelName.LAKEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: "+hotelName);
                Console.WriteLine("Total cost for the given date range: "+rateOfLakeWood);
            }
            if(rateOfBridgeWood<rateOfLakeWood && rateOfBridgeWood<rateOfRidgeWood)
            {
                hotelName = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Total cost for the given date range: " + rateOfBridgeWood);
            }
            if(rateOfRidgeWood<rateOfLakeWood && rateOfRidgeWood<rateOfBridgeWood)
            {
                hotelName = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotel for the entered date range: " + hotelName);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood);
            }
            if(rateOfLakeWood==rateOfBridgeWood && rateOfLakeWood<rateOfRidgeWood)
            {
                hotelName1 = HotelName.LAKEWOOD;
                hotelName2 = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1+"\t"+hotelName2);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood+"\t"+rateOfBridgeWood);
            }
            if(rateOfLakeWood==rateOfRidgeWood && rateOfLakeWood<rateOfBridgeWood)
            {
                hotelName1 = HotelName.LAKEWOOD;
                hotelName2 = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1 + "\t" + hotelName2);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood + "\t" + rateOfRidgeWood);
            }
            if(rateOfBridgeWood==rateOfRidgeWood && rateOfBridgeWood<rateOfLakeWood)
            {
                hotelName1 = HotelName.RIDGEWOOD;
                hotelName2 = HotelName.BRIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1 + "\t" + hotelName2);
                Console.WriteLine("Total cost for the given date range: " + rateOfRidgeWood + "\t" + rateOfBridgeWood);
            }
            if(rateOfLakeWood==rateOfBridgeWood && rateOfLakeWood==rateOfRidgeWood)
            {
                hotelName1 = HotelName.LAKEWOOD;
                hotelName2 = HotelName.BRIDGEWOOD;
                hotelName3 = HotelName.RIDGEWOOD;
                Console.WriteLine("Cheapest Hotels for the entered date range: " + hotelName1 + "\t" + hotelName2+"\t"+hotelName3);
                Console.WriteLine("Total cost for the given date range: " + rateOfLakeWood + "\t" + rateOfBridgeWood+"\t"+rateOfRidgeWood);
            }
        }
    }
}
