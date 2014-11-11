using NUnit.Framework;
using PosauneAnalytics.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.UnitTests
{
    [TestFixture]
    public class BlackScholes_Tests
    {
        [Test]
        public void CND_Test()
        {
            var calc = new BlackScholes();

            double cnd = calc.CND(1d);
            string result = cnd.ToString("N8");
            Assert.That(result == "0.84134474");

            cnd = calc.CND(1.1d);
            result = cnd.ToString("N8");
            Assert.That(result == "0.86433390");

            cnd = calc.CND(0.9d);
            result = cnd.ToString("N8");
            Assert.That(result == "0.81593991");

        }

        [Test]
        public void BlackScholesPrice_Test()
        {
            var calc = new BlackScholes();
            calc.PutCall = SecurityType.Call;
            calc.AssetPrice = 60.00;
            calc.Strike = 65.00;
            calc.TimeToMaturity = 0.25;
            calc.RiskFreeRate = 0.08;
            calc.Volatility = .30;

            var price = calc.BlackScholesPrice();
        }

    }
}
