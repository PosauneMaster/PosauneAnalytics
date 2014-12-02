using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosauneAnalytics.Libraries
{
    public class ImpliedVolatility
    {
        private const double _tolerance = 0.05;
        private const double _ceiling = 1.00;
        private const double _floor = 0.01;
        private const int _maxIterations = 55;

        private BlackScholes _blackScholes;

        public double AssetPrice { get; set; }
        public double Strike { get; set; }
        public double TimeToMaturity { get; set; }
        public double RiskFreeRate { get; set; }
        public double CostOfCarry { get; set; }
        public SecurityType PutCall { get; set; }

        public ImpliedVolatility()
        {
            _blackScholes = new BlackScholes();
        }

        public double Bisect(OptionDataObject option, double targetPrice)
        {
            AssetPrice = option.AssetPrice;
            Strike = option.Strike;
            TimeToMaturity = option.TimeToMaturity;
            RiskFreeRate = option.RiskFreeRate;
            CostOfCarry = option.CostOfCarry;
            PutCall = option.PutCall;

            return Bisect(targetPrice);
        }

        public double Bisect(double targetPrice)
        {
            double guess = 0.00;
            double guess1 = 0.00;
            double guess2 = 0.00;

            double min = _floor;
            double max = _ceiling;


            double guessVol1 = _ceiling;
            double guessVol2 = _floor;
            double guessVol3 = guessVol1;


            for (int i = 0; i < _maxIterations; i++ )
            {
                guess2 = _blackScholes.GBlackScholesPrice(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, RiskFreeRate, guessVol2);
                guess1 = _blackScholes.GBlackScholesPrice(PutCall, AssetPrice, Strike, TimeToMaturity, RiskFreeRate, RiskFreeRate, guessVol1);

                double minVol = min;
                double maxVol = max;

                if (guess2 < targetPrice && guess1 > targetPrice)
                {
                    minVol = Math.Max(guessVol2, minVol);
                    maxVol = Math.Min(guessVol1, maxVol);
                    guessVol2 = (guessVol1 + guessVol2) / 2;
                }
                else if(guess2 > targetPrice && guess1 < targetPrice)
                {
                    minVol = Math.Min(guessVol1, guessVol2);
                    guessVol1 = (guessVol2 + min) / 2;
                }
                else if (guess2 > targetPrice && guess1 > targetPrice)
                {
                    maxVol = Math.Min(guessVol1, guessVol2);
                    guessVol1 = guessVol2;
                    guessVol2 = (guessVol2 + min) / 2;
                }
                else if (guess2 < targetPrice && guess1 < targetPrice)
                {
                    maxVol = Math.Min(guessVol1, guessVol2);
                    guessVol1 = (max + Math.Max(guess2, guess1)) / 2;
                }

                min = minVol;
                max = maxVol;
            }

            guess = (guessVol1 + guessVol2) / 2;
            return Math.Round(guess, 4);

        }

    }
}
