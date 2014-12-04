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
    public class BinomialTree_Tests
    {
        [Test]
        public void BinomialTree_Test()
        {
            var callTree = new BinomialTree();
            callTree.AssetPrice = 126281.25;
            callTree.Strike = 126000.00;
            callTree.PutCall = EPutCall.Call;
            callTree.RiskFreeRate = 0.01d;
            callTree.Volatility = 0.0418d;
            callTree.Steps = 55;
            callTree.TimeStep = .0834d;

            double callOptionPrice = callTree.OptionValue();
            double p1 = (callOptionPrice % 64) / 15.625;

            var putTree = new BinomialTree();
            putTree.AssetPrice = 126281.25;
            putTree.Strike = 126000.00;
            putTree.PutCall = EPutCall.Put;
            putTree.RiskFreeRate = 0.01d;
            putTree.Volatility = 0.0418d;
            putTree.Steps = 55;
            putTree.TimeStep = .0834d;

            double putOptionPrice = callTree.OptionValue();

        }

    }
}
