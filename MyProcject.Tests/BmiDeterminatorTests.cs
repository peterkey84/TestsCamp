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
        [InlineData(10.0)]
        [InlineData(5.0)]
        [InlineData(18.0)]
        [InlineData(21.0)]
        [InlineData(11.75)]

        public void DetermineBmi_ForBmiBelow18_5_ReturnsUderweightClassification_Theory(double bmi)
        {
            //arrange
            BmiDeterminator bmiDeterminator = new BmiDeterminator();

            // act
            BmiClassification result = bmiDeterminator.DetermineBmi(bmi);

            //assert
            Assert.Equal(BmiClassification.Underweight, result);
        }
    }
}
