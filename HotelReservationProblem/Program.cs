using System;

namespace HotelReservationProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Welcome to Hotel Reservation Program ");
            try
            {
                Console.WriteLine("Enter check-in and check-out dates respectively in the following format: dd/mm/yyyy");
                string checkInDate = Console.ReadLine();
                string checkOutDate = Console.ReadLine();
                HotelOperations hotelOperations = new HotelOperations();
                //hotelOperations.FindCheapestHotel(checkInDate, checkOutDate);
                //hotelOperations.BestRatedHotel(checkInDate, checkOutDate);
                Console.WriteLine("Enter Customer Type: (Regular or Reward)");
                string customer = Console.ReadLine();
                CustomerType customerType = hotelOperations.ValidateUsingRegularExpressions(customer);
                Console.WriteLine("Finding for {0} Customer Type",customerType);
                hotelOperations.BestRatedCheapestHotel(checkInDate, checkOutDate, customerType);
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
