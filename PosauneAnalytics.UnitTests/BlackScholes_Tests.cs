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
        private BlackScholes InitialBlackScholes()
        {
            var calc = new BlackScholes();
            calc.PutCall = SecurityType.Put;
            calc.AssetPrice = 60.00;
            calc.Strike = 65.00;
            calc.TimeToMaturity = 0.25;
            calc.RiskFreeRate = 0.08;
            calc.CostOfCarry = 0.08;
            calc.Volatility = .30;

            return calc;
        }

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
        public void ND_Test()
        {
            var calc = new BlackScholes();
            double nd = calc.ND(1.0);
        }

        [Test]
        public void BlackScholes_PriceCall_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Call;

            var price = calc.BlackScholesPrice();
            var strPrice = price.ToString("N4");
            Assert.That("2.1334" == strPrice);
        }

        [Test]
        public void BlackScholes_PricePut_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Put;

            var price = calc.BlackScholesPrice();
            var strPrice = price.ToString("N4");
            Assert.That("5.8463" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_PriceCall_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Call;

            var price = calc.GBlackScholesPrice();
            var strPrice = price.ToString("N4");
            Assert.That("2.1334" == strPrice);
        }


        [Test]
        public void GeneralizedBlackScholes_PricePut_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Put;

            var price = calc.GBlackScholesPrice();
            var strPrice = price.ToString("N4");
            Assert.That("5.8463" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_CallDelta_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Call;

            var delta = calc.GDelta();
            var strPrice = delta.ToString("N4");
            Assert.That("0.3725" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_PutDelta_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Put;

            var delta = calc.GDelta();
            var strPrice = delta.ToString("N4");
            Assert.That("-0.6275" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_CallGamma_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Call;

            var gamma = calc.GGamma();
            var strPrice = gamma.ToString("N4");
            Assert.That("0.0420" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_PutGamma_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Put;

            var gamma = calc.GGamma();
            var strPrice = gamma.ToString("N4");
            Assert.That("0.0420" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_CallTheta_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Call;

            var theta = calc.GTheta();
            var strPrice = theta.ToString("N4");
            Assert.That("-8.4282" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_PutTheta_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Put;

            var theta = calc.GTheta();
            var strPrice = theta.ToString("N4");
            Assert.That("-3.3311" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_CallVega_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Call;

            var vega = calc.GVega();
            var strPrice = vega.ToString("N4");
            Assert.That("11.3515" == strPrice);
        }

        [Test]
        public void GeneralizedBlackScholes_PutVega_Test()
        {
            var calc = InitialBlackScholes();
            calc.PutCall = SecurityType.Put;

            var vega = calc.GVega();
            var strPrice = vega.ToString("N4");
            Assert.That("11.3515" == strPrice);
        }
    }
}
