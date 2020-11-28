using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationProblem;

namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelOperations hotelOperations = new HotelOperations();
        [TestMethod]
        public void OnEnteringOneWeekDayAndOneWeekendForRegularCustomerShouldReturnCheapestHotel()
        {
            int numberOfHotels = hotelOperations.FindCheapestHotel("06/12/2020", "07/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(numberOfHotels, 2);
        }        
        [TestMethod]
        public void OnEnteringOneWeekDayAndOneWeekendForRewardCustomerShouldReturnCheapestHotel()
        {
            int numberOfHotels = hotelOperations.FindCheapestHotel("06/12/2020", "07/12/2020", CustomerType.REWARD);
            Assert.AreEqual(numberOfHotels,1);
        }
        [TestMethod]
        public void OnEnteringTwoWeekDaysForRegularCustomersShouldReturnCheapestHotel()
        {
            int numberOfHotels = hotelOperations.FindCheapestHotel("02/12/2020", "03/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(numberOfHotels,1);
        }
        [TestMethod]
        public void OnEnteringTwoWeekDaysForRewardCustomersShouldReturnCheapestHotel()
        {
            int numberOfHotels = hotelOperations.FindCheapestHotel("02/12/2020", "03/12/2020", CustomerType.REWARD);
            Assert.AreEqual(numberOfHotels,1);
        }
        [TestMethod]
        public void OnEnteringTwoWeekEndDaysForRegularCustomersShouldReturnCheapestHotel()
        {
            int numberOfHotels = hotelOperations.FindCheapestHotel("05/12/2020", "06/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(numberOfHotels,1);
        }
        [TestMethod]
        public void OnEnteringTwoWeekEndDaysForRewardCustomersShouldReturnCheapestHotel()
        {
            int numberOfHotels = hotelOperations.FindCheapestHotel("05/12/2020", "06/12/2020", CustomerType.REWARD);
            Assert.AreEqual(numberOfHotels, 1);
        }
        [TestMethod]
        public void OnEnteringDateRangeAndRegularCustomerShouldReturnBestRatedHotel()
        {
            HotelName hotelName = hotelOperations.BestRatedHotel("30/11/2020", "01/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.RIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringDateRangeAndRewardCustomerShouldReturnBestRatedHotel()
        {
            HotelName hotelName = hotelOperations.BestRatedHotel("30/11/2020", "01/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.RIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringOneWeekDayAndOneWeekEndDayForRegularCustomerShouldReturnBestRatedCheapestHotel()
        {
            HotelName hotelName = hotelOperations.BestRatedCheapestHotel("06/12/2020", "07/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.BRIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringOneWeekDayAndOneWeekEndDayForRewardCustomerShouldReturnBestRatedCheapestHotel()
        {
            HotelName hotelName = hotelOperations.BestRatedCheapestHotel("06/12/2020", "07/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.RIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekDaysForRegularCustomersShouldReturnBestRatedCheapestHotels()
        {
            HotelName hotelName = hotelOperations.BestRatedCheapestHotel("07/12/2020", "08/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.LAKEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekDaysForRewardCustomersShouldReturnBestRatedCheapestHotels()
        {
            HotelName hotelName = hotelOperations.BestRatedCheapestHotel("07/12/2020", "08/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.LAKEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekEndDaysForRegularCustomersShouldReturnBestRatedCheapestHotels()
        {
            HotelName hotelName = hotelOperations.BestRatedCheapestHotel("05/12/2020", "06/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.BRIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekEndDaysForRewardCustomersShouldReturnBestRatedCheapestHotels()
        {
            HotelName hotelName = hotelOperations.BestRatedCheapestHotel("05/12/2020", "06/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.RIDGEWOOD);
        }
        [TestMethod]
        public void ValidateRegexPatternForRegularCustomer()
        {
            CustomerType expectedType = hotelOperations.ValidateUsingRegularExpressions("rEgUlAr");
            CustomerType actualType = CustomerType.REGULAR;
            Assert.AreEqual(expectedType, actualType);
        }
        [TestMethod]
        public void ValidateRegexPatternForRewardCustomer()
        {
            CustomerType expectedType = hotelOperations.ValidateUsingRegularExpressions("ReWaRd");
            CustomerType actualType = CustomerType.REWARD;
            Assert.AreEqual(expectedType, actualType);
        }
        [TestMethod]
        public void ShouldThrowExceptionForInvalidDatesEntered()
        {
            HotelData hotelData = new HotelData(HotelName.BRIDGEWOOD, CustomerType.REGULAR);
            string expectedErrorMessage = "Invalid Dates entered";
            string actualErrorMessage = "";
            try
            {
                double costOfHotel = hotelData.CostOfHotel("date1", "date2");
            }
            catch(HotelReservationException u)
            {
                actualErrorMessage = u.Message;
            }
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
        [TestMethod]
        public void ShouldThrowExceptionForIncorrectCustomerType()
        {
            string expectedErrorMessage = "Invalid Customer Type";
            string actualErrorMessage = "";
            try
            {
                CustomerType customerType = hotelOperations.ValidateUsingRegularExpressions("Normal");
            }
            catch(HotelReservationException u)
            {
                actualErrorMessage = u.Message;
            }
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
    }
}
