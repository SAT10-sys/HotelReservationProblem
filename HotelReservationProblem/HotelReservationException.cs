using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationProblem
{
    public class HotelReservationException:Exception
    {
        // storing different types of expected exception in the enum
        public enum ExceptionType
        {
            INVALID_CUSTOMER_NAME,
            INVALID_CUSTOMER_TYPE,
            INVALID_DATES
        }
        public ExceptionType type;
        public HotelReservationException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
