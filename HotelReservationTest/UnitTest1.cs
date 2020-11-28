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
            HotelName hotelName = hotelOperations.FindCheapestHotel("06/12/2020", "07/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.LAKEWOOD);
        }
        [TestMethod]
        public void OnEnteringOneWeekDayAndOneWeekendForRewardCustomerShouldReturnCheapestHotel()
        {
            HotelName hotelName = hotelOperations.FindCheapestHotel("06/12/2020", "07/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.RIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekDaysForRegularCustomersShouldReturnCheapestHotel()
        {
            HotelName hotelName = hotelOperations.FindCheapestHotel("02/12/2020", "03/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.LAKEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekDaysForRewardCustomersShouldReturnCheapestHotel()
        {
            HotelName hotelName = hotelOperations.FindCheapestHotel("02/12/2020", "03/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.LAKEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekEndDaysForRegularCustomersShouldReturnCheapestHotel()
        {
            HotelName hotelName = hotelOperations.FindCheapestHotel("05/12/2020", "06/12/2020", CustomerType.REGULAR);
            Assert.AreEqual(hotelName, HotelName.BRIDGEWOOD);
        }
        [TestMethod]
        public void OnEnteringTwoWeekEndDaysForRewardCustomersShouldReturnCheapestHotel()
        {
            HotelName hotelName = hotelOperations.FindCheapestHotel("05/12/2020", "06/12/2020", CustomerType.REWARD);
            Assert.AreEqual(hotelName, HotelName.RIDGEWOOD);
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
