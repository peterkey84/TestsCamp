using FluentAssertions;
using Moq;
using MyProject;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyProcject.Tests.Service
{
    public class ResultServiceTests
    {



        [Fact]
        public void SetRecentSetRecentOverweightResult_ForOverweightResult_UpdateProperty()
        {
            //arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Overweight };

            var resultService = new ResultService(new ResultRepository());

            //act 

            resultService.SetRecentOverweightResult(result);

            //assert

            resultService.RecentOverweightResult.Should().Be(result);

        }


        [Fact]
        public void SetRecentSetRecentOverweightResult_ForOverweightResult_DoesntUpdateProperty()
        {
            //arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Obesity };

            var resultService = new ResultService(new ResultRepository());

            //act 

            resultService.SetRecentOverweightResult(result);

            //assert

            resultService.RecentOverweightResult.Should().BeNull();

        }


        [Fact]
        public async Task SaveUnderweightResultAsync_ForUderweightResult_InvokesSaveResultAsync()
        {

            //arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Underweight };
            var repoMock = new Mock<IResultRepository>();
            var resultService = new ResultService(repoMock.Object);

            //act 

            resultService.SaveUnderweightResultAsync(result);


            //assert

            repoMock.Verify(mock =>mock.SaveResultAsync(result), Times.Once);

        }

        [Fact]
        public async Task SaveUnderweightResultAsync_ForNonUderweightResult_DosentInvokesSaveResultAsync()
        {

            //arrange
            var result = new BmiResult { BmiClassification = BmiClassification.Overweight };

            var repoMock = new Mock<IResultRepository>();

            var resultService = new ResultService(repoMock.Object);

            //act
            resultService.SaveUnderweightResultAsync(result);

            //assert

            repoMock.Verify(mock => mock.SaveResultAsync(result), Times.Never);

        }


    }
}
