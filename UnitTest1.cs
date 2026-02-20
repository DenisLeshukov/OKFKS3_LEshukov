using CinemaTicketSystem;
using System.Runtime.InteropServices;

namespace Tests_LeshukovPrakt3
{
    public class UnitTest1
    {
        [Fact]
        public void CalculatePrice_DefaultTicketPrice ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 30;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(12);
            int price = 300;
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountForChildrenMore6Under17 ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 10;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            var price = 300 - (300* 40/100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_StudentUnder18Age ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 17;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            var price = 300 - (300* 40/100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountForChildrenUnder6 ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 5;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            var price = 0;
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_ChildrenUnder0 ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = -1;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            
            var calculate = new TicketPriceCalculator( );
            Assert.Throws<ArgumentOutOfRangeException>(
                () => calculate.CalculatePrice(cinema)
                );
        }
        [Fact]
        public void CalculatePrice_UserMore120 ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 121;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            var calculate = new TicketPriceCalculator( );
            Assert.Throws<ArgumentOutOfRangeException>(
                () => calculate.CalculatePrice(cinema)
                );
        }
        [Fact]
        public void CalculatePrice_DiscountForStudents ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 19;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            int price = 300 - (300 * 20 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountForStudentAndWednesdayUnderSessionTime ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 19;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Wednesday;
            cinema.SessionTime = TimeSpan.FromHours(12);
            int price = 300 - (300 * 30 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountUnderSessionTime ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 28;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(11);
            int price = 300 - (300 * 15 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountOnWednesdays ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 30;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Wednesday;
            cinema.SessionTime = TimeSpan.FromHours(15);
            int price = 300 - (300 * 30 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_RuleMaxDiscountWithPensionerAndWednesdayAndUnderSessionTime ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 69;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Wednesday;
            cinema.SessionTime = TimeSpan.FromHours(11);
            int price = 300 - (300 * 50 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }

        [Fact]
        public void CalculatePrice_RuleMaxDiscountWithWednesdayAndUnderSessionTime ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 28;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Wednesday;
            cinema.SessionTime = TimeSpan.FromHours(12);
            int price = 300 - (300 * 30 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountWithPensioner ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 69;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300 - (300 * 50 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountVIPWithStudent ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 19;
            cinema.IsStudent = true;
            cinema.IsVip = true;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300*2 - (300*2 * 20 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountVIPWithChildren ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 10;
            cinema.IsStudent = false;
            cinema.IsVip = true;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300*2 - (300*2 * 40 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountVIPunderSessionTime ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 30;
            cinema.IsStudent = false;
            cinema.IsVip = true;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(11);
            int price = 300*2 - (300*2 * 15 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountVIPWithWednesday ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 30;
            cinema.IsStudent = false;
            cinema.IsVip = true;
            cinema.Day = DayOfWeek.Wednesday;
            cinema.SessionTime = TimeSpan.FromHours(14);
            int price = 300*2 - (300*2 * 30 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountVIPWithPensoiner ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 69;
            cinema.IsStudent = false;
            cinema.IsVip = true;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300*2 - (300*2 * 50 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); 
        }
        [Fact]
        public void CalculatePrice_DiscountChildrenMaxAge ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 17;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300 - (300 * 40 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); 
        }
        [Fact]
        public void CalculatePrice_DiscountChildrenMinAge ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 6;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300 - (300 * 40 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountStudentMinAge ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 18;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300 - (300 * 20 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountStudentMaxAge ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 25;
            cinema.IsStudent = true;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300 - (300 * 20 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountPensionerMinAge ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 65;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300 - (300 * 50 / 100);
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_DiscountUnder1PensionerAge ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 64;
            cinema.IsStudent = false;
            cinema.IsVip = false;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300;
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_ClientVIP ()
        {
            var cinema = new TicketRequest( );
            cinema.Age = 30;
            cinema.IsStudent = false;
            cinema.IsVip = true;
            cinema.Day = DayOfWeek.Friday;
            cinema.SessionTime = TimeSpan.FromHours(13);
            int price = 300*2;
            var calculate = new TicketPriceCalculator( );
            Assert.Equal(price, calculate.CalculatePrice( cinema)); ; 
        }
        [Fact]
        public void CalculatePrice_ExceptionRequestShouldNull ()
        {
            var cinema = new TicketRequest( );

            cinema = null;
            var calculate = new TicketPriceCalculator( );
            Assert.Throws<ArgumentNullException>(
                () => calculate.CalculatePrice(cinema)
                );
        }
        


        
    }
}