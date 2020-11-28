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
                HotelOperations hotelOperations = new HotelOperations();
                Console.WriteLine("Enter check-in and check-out dates respectively in the following format:- dd/mm/yyyy");
                string checkInDate = Console.ReadLine();
                string checkOutDate = Console.ReadLine();
                Console.WriteLine("Enter the customer type:- REGULAR or REWARD");
                string customer = Console.ReadLine();
                CustomerType customerType = hotelOperations.ValidateUsingRegularExpressions(customer);
                Regstart:
                Console.WriteLine("Enter the following choices between 1 and ");
                Console.WriteLine("1.DISPLAY HOTELS WITH THEIR RESPECTIVE RATINGS AND RATES\n2.FIND BEST RATED HOTEL\n3.FIND CHEAPEST HOTEL\n4.FIND BEST RATED CHEAPEST HOTEL");
                Console.WriteLine("BASED ON THE DATES ENTERED BY YOU AND TYPE OF CUSTOMER");
                int choiceOfOperation = Convert.ToInt32(Console.ReadLine());
                switch(choiceOfOperation)
                {
                    case 1:
                        hotelOperations.DisplayListOfHotels(customerType);
                        break;
                    case 2:
                        hotelOperations.BestRatedHotel(checkInDate, checkOutDate, customerType);
                        break;
                    case 3:
                        hotelOperations.FindCheapestHotel(checkInDate, checkOutDate, customerType);
                        break;
                    case 4:
                        hotelOperations.BestRatedCheapestHotel(checkInDate, checkOutDate, customerType);
                        break;
                    default:
                        Console.WriteLine("Incorrect Entry. Choose between 1 and 4");
                        goto Regstart;
                }
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}
