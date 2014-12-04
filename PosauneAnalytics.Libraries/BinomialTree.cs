using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Libraries
{
    public enum EPutCall
    {
        Call = 0,
        Put = 1
    }

    public class BinomialTree
    {
        #region "Properties"

        public double AssetPrice { get;  set; }
        public double Strike { get;  set; }
        public double TimeStep { get;  set; }
        public double Volatility { get;  set; }
        public EPutCall PutCall { get;  set; }
        public double RiskFreeRate { get;  set; }
        public int Steps { get;  set; }

        #endregion

        #region "Constructors"

        public BinomialTree()
        {
        }

        public BinomialTree(double assetPriceParam, double strikeParam, double timeStepParam, double volatilityParam,
            double riskFreeRateParam, EPutCall putCallParam, int stepsParam)
        {
            AssetPrice = assetPriceParam;
            Strike = strikeParam;
            TimeStep = timeStepParam;
            Volatility = volatilityParam;
            RiskFreeRate = riskFreeRateParam;
            PutCall = putCallParam;
            Steps = stepsParam;
        }
        #endregion

        #region "Binomial Tree"
        private double BinomialCoefficient(int m, int n)
        {
            return Factorial(n) / (Factorial(m) * Factorial(n - m));
        }

        private double BinomialNodeValue(int m, int n, double p)
        {
            return BinomialCoefficient(m, n) * System.Math.Pow(p, (double)m) * System.Math.Pow(1.0 - p, (double)(n - m));
        }

        public double OptionValue()
        {
            double totalValue = 0.0;
            double u = OptionUp(TimeStep, Volatility, Steps);
            double d = OptionDown(TimeStep, Volatility, Steps);
            double p = Probability(TimeStep, Volatility, Steps, RiskFreeRate);
            double nodeValue = 0.0;
            double payoffValue = 0.0;
            for (int j = 0; j <= Steps; j++)
            {
                payoffValue = Payoff(AssetPrice * System.Math.Pow(u, (double)j) * System.Math.Pow(d, (double)(Steps - j)), Strike, PutCall);
                nodeValue = BinomialNodeValue(j, Steps, p);
                totalValue += nodeValue * payoffValue;
            }
            return PresentValue(totalValue, RiskFreeRate, TimeStep);
        }
        #endregion

        #region "Probabilities"
        private double OptionUp(double t, double s, int n)
        {
            return System.Math.Exp(s * System.Math.Sqrt(t / n));
        }

        private double OptionDown(double t, double s, int n)
        {
            return System.Math.Exp(-s * System.Math.Sqrt(t / n));
        }


        private double Probability(double t, double s, int n, double r)
        {

            double d1 = FutureValue(1.0, r, t / n);
            double d2 = OptionUp(t, s, n);
            double d3 = OptionDown(t, s, n);
            //return (d1 - d3) / (d2 - d3);

            double p = ((System.Math.Pow(System.Math.E, r * (t / n))) - d3) / (d2 - d3);
            return p;

        }
        #endregion

        #region "Payoffs"

        private double Payoff(double S, double X, EPutCall PutCall)
        {
            switch (PutCall)
            {
                case EPutCall.Call:
                    return Call(S, X);

                case EPutCall.Put:
                    return Put(S, X);

                default:
                    return 0.0;
            }
        }

        private double Call(double S, double X)
        {
            return System.Math.Max(0.0, S - X);
        }

        private double Put(double S, double X)
        {
            return System.Math.Max(0.0, X - S);
        }
        #endregion

        #region "Financial Math Utility Functions"
        private double Factorial(int n)
        {
            double d = 1.0;
            for (int j = 1; j <= n; j++)
            {
                d *= j;
            }
            return d;
        }

        private double FutureValue(double P, double r, double n)
        {
            return P * System.Math.Pow(1.0 + r, n);
        }

        private double PresentValue(double F, double r, double n)
        {
            return F / System.Math.Exp(r * n);
        }
        #endregion

    }
}
