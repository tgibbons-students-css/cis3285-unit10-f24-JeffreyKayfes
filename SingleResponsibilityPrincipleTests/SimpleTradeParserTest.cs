using SingleResponsibilityPrinciple;
using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrincipleTests
{
    [TestClass()]
    public class SimpleTradeParserTest
    {
        [TestMethod()]
        public void TestNumberOfPosLine()
        {
            // Arrange
            var positiveValidator = new dummyPositiveTradeValidator();
            var mapper = new dummyTradeMapper();
            var parser = new SimpleTradeParser(positiveValidator, mapper);

            var tradeData = new List<string>
            {
                "USD,EUR,1000,1.5",
                "GBP,USD,2000,1.8",
                "JPY,GBP,3000,1.2"
            };

            // Act
            var result = parser.Parse(tradeData);

            // Assert
            Assert.AreEqual(tradeData.Count, result.Count());

        }

        [TestMethod()]
        public void TestNumberOfNegLines()
        {
            // Arrange
            var negativeValidator = new dummyNegativeTradeValidator();
            var mapper = new dummyTradeMapper();
            var parser = new SimpleTradeParser(negativeValidator, mapper);

            var tradeData = new List<string>
            {
                "USD,EUR,1000,1.5",
                "GBP,USD,2000,1.8",
                "JPY,GBP,3000,1.2"
            };

            // Act
            var result = parser.Parse(tradeData);

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }

    public class dummyPositiveTradeValidator : ITradeValidator
    {
        public bool Validate(string[] tradeData)
        {
            return true;
        }
    }

    public class dummyNegativeTradeValidator : ITradeValidator
    {
        public bool Validate(string[] tradeData)
        {
            return false;
        }
    }

    public class dummyTradeMapper : ITradeMapper
    {
        public TradeRecord Map(string[] fields)
        {
            TradeRecord sampleRec = new TradeRecord();
            sampleRec.DestinationCurrency = "XXX";
            sampleRec.SourceCurrency = "YYY";
            sampleRec.Price = 1.11M;
            sampleRec.Lots = 2.22F;
            return sampleRec;
        }
    }
}
