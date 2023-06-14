using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;

namespace MyProcject.Tests
{
    public class BmiCalculatorFacadeTests
    {

        private const string overweightSummaryResult = "You are a bit overweight";
        private const string normalSummaryResult = "Your weight is normal, keep it up";
       

        [Fact]
        public void GetResult_ForValidInputs_ReturnsCorrectSummary()
        {

            //arrange

            var bmiDeteminatorMock = new Mock<IBmiDeterminator>();

            bmiDeteminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>()))
                .Returns(BmiClassification.Overweight);

            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeteminatorMock.Object);


            //używająć Moq nie musimy już hardkodować tych danych. Zrobi to za nas moq
            //double weight = 90;
            //double height = 190;

            //act 

            BmiResult result = bmiCalculatorFacade.GetResult(1, 1);

            //assert

            //Assert.Equal(24.93, result.Bmi);
            //Assert.Equal(BmiClassification.Overweight, result.BmiClassification);
            //Assert.Equal(overweightSummaryResult, result.Summary);

            // <-- Uzycie paczki fFuentAssertions aby troche uprościć cześć ASSERT -->

            //result.Bmi.Should().Be(24.93);
            //result.BmiClassification.Should().Be(BmiClassification.Overweight);

            // mając moq i to że już wcześniej sprawdzilismy testami jednostkowymi pozostale czesci tego obiektu, wystarczy ze sprawdzimy summary czy jest porawne.
            result.Summary.Should().Be(overweightSummaryResult);


        }

        [Theory]
        [InlineData(BmiClassification.Overweight, overweightSummaryResult)]
        [InlineData(BmiClassification.Normal, normalSummaryResult)]

        public void GetResult_ForValidInputs_ReturnsCorrectSummaryTheory(BmiClassification bmiClassification, string expectedResult)
        {

            //arrange

            var bmiDeteminatorMock = new Mock<IBmiDeterminator>();

            bmiDeteminatorMock.Setup(m => m.DetermineBmi(It.IsAny<double>()))
                .Returns(bmiClassification);

            BmiCalculatorFacade bmiCalculatorFacade = new BmiCalculatorFacade(UnitSystem.Metric, bmiDeteminatorMock.Object);

            //act 

            BmiResult result = bmiCalculatorFacade.GetResult(1, 1);

            //assert

            result.Summary.Should().Be(expectedResult);


        }

    }
}
