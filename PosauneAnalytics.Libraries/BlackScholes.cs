using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Libraries
{
    public enum SecurityType
    {
        Put,
        Call,
        Future,
        Other
    };

    /// <summary>
    ///The Black and Scholes (1973) Stock option formula
    /// S:	Underlying Price
    /// X:	Strike Price
    /// r:	Risk Free Rate
    /// T:	Time to expiration (in years)
    /// v:	Volatility
    /// b:  Cost of Carry
    /// </summary>
    public class BlackScholes
    {

        public double AssetPrice { get; set; }
        public double Strike { get; set; }
        public double TimeToMaturity { get; set; }
        public double RiskFreeRate { get; set; }
        public double CostOfCarry { get; set; }
        public double Volatility { get; set; }
        public SecurityType PutCall { get; set; }

        public double ND(double X)
        {
            return 1 / Math.Sqrt(2 * Math.PI) * Math.Exp(-X * X / 2);
        }

        public double CND(double X)
        {
            double L = 0.0;
            double K = 0.0;
            double dCND = 0.0;
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;
            L = Math.Abs(X);
            K = 1.0 / (1.0 + 0.2316419 * L);
            dCND = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) *
                Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) +
                a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

            if (X < 0)
            {
                return 1.0 - dCND;
            }
            else
            {
                return dCND;
            }
        }

         /* The Black and Scholes (1973) Stock option formula
         S:	Underlying Price
         X:	Strike Price
         r:	Risk Free Rate
         T:	Time to expiration (in years)
         v:	Volatility
        */
        public double BlackScholesPrice(SecurityType CallPutFlag, double S, double X, double T, double r, double v)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            double dBlackScholes = 0.0;

            d1 = (Math.Log(S / X) + (r + Math.Pow(v,2) / 2.0) * T) / (v * Math.Sqrt(T));
            d1 = -0.325284717823576;

            d2 = d1 - v * Math.Sqrt(T);
            if (CallPutFlag == SecurityType.Call)
            {
                dBlackScholes = S * CND(d1) - X * Math.Exp(-r * T) * CND(d2);
            }
            else if (CallPutFlag == SecurityType.Put)
            {
                dBlackScholes = X * Math.Exp(-r * T) * CND(-d2) - S * CND(-d1);
            }
            return dBlackScholes;
        }

        public double BlackScholesPrice()
        {
            return BlackScholesPrice(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, Volatility);
        }

        public double GBlackScholesPrice(SecurityType CallPutFlag, double S, double X, double T, double r, double b, double v)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            double dBlackScholes = 0.0;

            d1 = (Math.Log(S / X) + (b + Math.Pow(v, 2) / 2.0) * T) / (v * Math.Sqrt(T));
            d1 = -0.325284717823576;

            d2 = d1 - v * Math.Sqrt(T);
            if (CallPutFlag == SecurityType.Call)
            {
                dBlackScholes = S * Math.Exp((b - r) * T) * CND(d1) - X * Math.Exp(-r * T) * CND(d2);
            }
            else if (CallPutFlag == SecurityType.Put)
            {
                dBlackScholes = X * Math.Exp(-r * T) * CND(-d2) - S * Math.Exp((b - r) * T) * CND(-d1);
            }
            return dBlackScholes;
        }

        public double GBlackScholesPrice()
        {
            return GBlackScholesPrice(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, CostOfCarry, Volatility);
        }

        public double GDelta(SecurityType CallPutFlag, double S, double X, double T, double r, double b, double v)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            double gDelta = 0.0;

            d1 = (Math.Log(S / X) + (b + Math.Pow(v, 2) / 2.0) * T) / (v * Math.Sqrt(T));

            if (CallPutFlag == SecurityType.Call)
            {
                gDelta = Math.Exp((b - r) * T) * CND(d1);
            }
            else if (CallPutFlag == SecurityType.Put)
            {
                gDelta = Math.Exp((b - r) * T) * (CND(d1) - 1);
            }
            return gDelta;
        }

        public double GDelta()
        {
            return GDelta(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, CostOfCarry, Volatility);
        }

        public double GGamma(SecurityType CallPutFlag, double S, double X, double T, double r, double b, double v)
        {
            double d1 = 0.0;
            d1 = (Math.Log(S / X) + (b + Math.Pow(v, 2) / 2.0) * T) / (v * Math.Sqrt(T));
            return Math.Exp((b - r) * T) * ND(d1) / (S * v * Math.Sqrt(T));

        }

        public double GGamma()
        {
            return GGamma(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, CostOfCarry, Volatility);
        }

        public double GTheta(SecurityType CallPutFlag, double S, double X, double T, double r, double b, double v)
        {
            double d1 = 0.0;
            double d2 = 0.0;
            double gTheta = 0.0;

            d1 = (Math.Log(S / X) + (b + Math.Pow(v, 2) / 2.0) * T) / (v * Math.Sqrt(T));
            d2 = d1 - v * Math.Sqrt(T);

            if (CallPutFlag == SecurityType.Call)
            {
                gTheta = -S * Math.Exp((b - r) * T) * ND(d1) * v / (2 * Math.Sqrt(T)) - (b - r) * S * Math.Exp((b - r) * T) * CND(d1) - r * X * Math.Exp(-r * T) * CND(d2);

            }
            else if (CallPutFlag == SecurityType.Put)
            {
                gTheta = -S * Math.Exp((b - r) * T) * ND(d1) * v / (2 * Math.Sqrt(T)) + (b - r) * S * Math.Exp((b - r) * T) * CND(-d1) + r * X * Math.Exp(-r * T) * CND(-d2);

            }

            return gTheta;
        }

        public double GTheta()
        {
            return GTheta(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, CostOfCarry, Volatility);
        }

        public double GVega(SecurityType CallPutFlag, double S, double X, double T, double r, double b, double v)
        {
            double d1 = 0.0;
            double gVega = 0.0;

            d1 = (Math.Log(S / X) + (b + Math.Pow(v, 2) / 2.0) * T) / (v * Math.Sqrt(T));
            gVega = S * Math.Exp((b - r) * T) * ND(d1) * Math.Sqrt(T);

            return gVega;
        }

        public double GVega()
        {
            return GVega(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, CostOfCarry, Volatility);
        }
    }
}
