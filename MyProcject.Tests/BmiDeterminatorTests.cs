using MyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProcject.Tests
{
    public class BmiDeterminatorTests
    {


        [Fact]

        public void DetermineBmi_ForBmiBelow18_5_ReturnsUderweightClassification()
        {
            //arrange
            BmiDeterminator bmiDeterminator = new BmiDeterminator();
            double bmi = 10;

            // act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            //assert
            Assert.Equal(BmiClassification.Underweight, result);
        }

        [Theory]
        [InlineData(10.0, BmiClassification.Underweight)]
        [InlineData(12.0, BmiClassification.Underweight)]
        [InlineData(14.0, BmiClassification.Underweight)]
        [InlineData(21.0, BmiClassification.Normal)]
        [InlineData(24.8, BmiClassification.Normal)]
        [InlineData(25.9, BmiClassification.Overweight)]
        [InlineData(29.8, BmiClassification.Overweight)]
        [InlineData(30.0, BmiClassification.Obesity)]
        [InlineData(34.0, BmiClassification.Obesity)]
        [InlineData(43.0, BmiClassification.ExtremeObesity)]

        public void DetermineBmi_ForGivenBmi_ReturnsCorrectlyClassification(double bmi, BmiClassification classification)
        {
            //arrange
            BmiDeterminator bmiDeterminator = new BmiDeterminator();

            // act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            //assert
            Assert.Equal(classification, result);
        }
    }
}
