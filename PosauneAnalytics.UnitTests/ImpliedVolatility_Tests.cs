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
    public class ImpliedVolatility_Tests
    {
        private ImpliedVolatility InitializeImplied()
        {
            var implied = new ImpliedVolatility();
            implied.PutCall = SecurityType.Put;
            implied.AssetPrice = 60.00;
            implied.Strike = 65.00;
            implied.TimeToMaturity = 0.25;
            implied.RiskFreeRate = 0.08;
            implied.CostOfCarry = 0.08;

            return implied;
        }


        [Test]
        public void Bisect_Test()
        {
            var implied = InitializeImplied();
            double vol = implied.Bisect(5.8463);

            
        }

        [Test]
        public void Bisect_Option_Test()
        {
            var implied = new ImpliedVolatility();
            implied.PutCall = SecurityType.Call;
            implied.AssetPrice = 126343.75;
            implied.Strike = 126000;
            implied.TimeToMaturity = 81.00d/360.00d;
            implied.RiskFreeRate = 0.01;
            implied.CostOfCarry = 0.01;

            double vol = implied.Bisect(1343.75);

        }

    }
}
