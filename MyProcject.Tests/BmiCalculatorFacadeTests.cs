using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;


namespace MyProcject.Tests
{
    public class BmiCalculatorFacadeTests
    {

        private const string overweightSummaryResult = "You are a bit overweight";

        [Fact]
        public void GetResult_ForValidInputs_ReturnsCorrectResult()
        {
            //arrange
            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric);

            double weight = 90;
            double height = 190;

            //act 

            BmiResult result = bmiCalculatorFacade.GetResult(weight, height);

            //assert

            //Assert.Equal(24.93, result.Bmi);
            //Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
            //Assert.Equal(overweightSummaryResult, result.Summary);

            // Uzycie paczki fFuentAssertions aby troche uprościć cześć ASSERT

            result.Bmi.Should().Be(24.93);
            result.BmiClassification.Should().Be(BmiClassification.Overweight);
            result.Summary.Should().Be(overweightSummaryResult);


        }

    }
}
