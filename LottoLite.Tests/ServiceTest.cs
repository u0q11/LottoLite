using LottoLite.Interfaces.Entities;
using LottoLite.Interfaces.Logger;
using LottoLite.Interfaces.Repository;
using LottoLite.Interfaces.Services;
using LottoLite.Services;
using LottoLite.Web.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LottoLite.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void Winning_Numbers_Validation_Test()
        {

            var mockSearchSvc = new Mock<ILotteryDrawSearchService>();
            var mockReadonlyRepo = new Mock<IReadOnlyRepository<ILotteryDraw>>();
            var mockWriteOnlyRepo = new Mock<IWriteOnlyRepository<ILotteryDraw>>();
            var mockLogger = new Mock<ILogger>();

            var service = new WinningNumbersService(mockSearchSvc.Object, mockReadonlyRepo.Object, mockWriteOnlyRepo.Object, mockLogger.Object);

            var draw = new Mock<ILotteryDraw>();
            var winningNumbers = new Mock<IWinningNumbers>();
            var results = ValidationFactory.CreateCollection();
            
            draw.Setup(x => x.PrimaryNumbersMin).Returns(2);
            draw.Setup(x => x.PrimaryNumbersMax).Returns(49);
            draw.Setup(x => x.SecondaryNumbersMin).Returns(1);
            draw.Setup(x => x.SecondaryNumbersMax).Returns(10);

            winningNumbers.Setup(x => x.PrimaryWinningNumbers).Returns(new System.Collections.Generic.List<int>() { 1, 2, 3, 4, 5 });
            winningNumbers.Setup(x => x.SecondaryWinningNumbers).Returns(new System.Collections.Generic.List<int>() { 1, 11 });
            
            var result = service.ValidateWinningNumbers(draw.Object, winningNumbers.Object, results);

            Assert.AreEqual(2, result.Count); // should return 2 validation errors (min primary number, max Secondary number)
        }

        [TestMethod]
        public void Get_Draw_By_Date_Test()
        {
            var mockReadonlyRepo = new Mock<IReadOnlyRepository<ILotteryDraw>>();
            var mockWriteOnlyRepo = new Mock<IWriteOnlyRepository<ILotteryDraw>>();
            var mockLogger = new Mock<ILogger>();

            var service = new LotteryDrawService(mockReadonlyRepo.Object, mockWriteOnlyRepo.Object, mockLogger.Object);

            DateTime drawDate = DateTime.Now.Date;
            var draw = new Mock<ILotteryDraw>();
            draw.Setup(x => x.DateOfDraw).Returns(drawDate);
            draw.Setup(x => x.Name).Returns("Test draw");

            var draw2 = new Mock<ILotteryDraw>();
            draw2.Setup(x => x.DateOfDraw).Returns(drawDate.AddDays(1));
            draw2.Setup(x => x.Name).Returns("Test draw 2");

            var draw3 = new Mock<ILotteryDraw>();
            draw3.Setup(x => x.DateOfDraw).Returns(drawDate.AddDays(-1));
            draw3.Setup(x => x.Name).Returns("Test draw 3");

            mockReadonlyRepo.Setup(x => x.FindAll()).Returns(new List<ILotteryDraw>() { draw.Object, draw2.Object, draw3.Object });

            var result = service.GetDrawsByDate(drawDate);

            Assert.AreEqual("Test draw", result.First().Name); // should return only "Test draw"
        }
    }
}
