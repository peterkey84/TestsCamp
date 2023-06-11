using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProcject.Tests
{
    public class MetricBmiCalculatorTests
    {

        [Theory]
        [InlineData(100,170,34.6)]
        [InlineData(57, 170, 19.72)]
        [InlineData(70, 170, 24.22)]
        [InlineData(80, 190, 22.16)]
        [InlineData(90, 190, 24.93)]

        public void CalculateBmi_ForGivenWeightAndHight_ReturnCorrectBmi(double weight, double height, double bmiResult)
        {
            //arrange
            MetricBmiCalculator calculator = new MetricBmiCalculator();

            //act 
            double result  = calculator.CalculateBmi(weight, height);

            //assert 

            Assert.Equal(bmiResult, result);

        }

        [Theory]
        [InlineData(0, 170)]
        [InlineData(-5, 170)]
        [InlineData(-11, 170)]
        [InlineData(100, 0)]
        [InlineData(100, -130)]
        [InlineData(0, 0)]


        public void CalculateBmi_ForInvalidArgument_ThrowsArgumentException(double weight, double height)
        {

            //arrange
            MetricBmiCalculator calculator = new MetricBmiCalculator();

            //act

            Action action = () => calculator.CalculateBmi(weight, height); // przypisanie wyniku pod delegatą

            // assert

            Assert.Throws<ArgumentException>(action);


        }
    }
}
