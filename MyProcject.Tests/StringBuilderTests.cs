using System.Text;

namespace MyProcject.Tests
{
    public class StringBuilderTests
    {
        [Fact]
        public void Append_FOrToStrings_ReturnsConcatenatedString()
        {

            //arrange -- inicjalizujemy niezbedne obiekty

            StringBuilder sb = new StringBuilder();

            //act  - wywo�ujemy dan� fukcjonalno�� kt�r� chcemy przetestowa�

            sb.Append("test").Append("test2");

            string result = sb.ToString();

            //assert - sprawdzamy wynik jaki oczekujemy jest taki jak chcemy

            Assert.Equal("testtest2", result);



        }
    }
}