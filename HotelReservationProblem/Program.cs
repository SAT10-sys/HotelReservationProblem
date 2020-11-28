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
                //hotelOperations.BestRatedCheapestHotel(checkInDate, checkOutDate);
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
