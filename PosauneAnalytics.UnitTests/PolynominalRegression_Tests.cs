using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PosauneAnalytics.Libraries;
using System.Diagnostics;

namespace PosauneAnalytics.UnitTests
{
    [TestFixture]
    public class PolynominalRegression_Tests
    {
        [Test]
        public void Calculate_Test()
        {
            DenseVector x_data = new DenseVector(new double[] { 0, 1, 2, 3, 4 });
            DenseVector y_data = new DenseVector(new double[] { 1.0,1.4,1.6,1.3,0.9 });

            var poly = new PolynominalRegression(x_data, y_data, 2);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0,6}{1,9}", "x", "y"));

            for (int i = 0; i < 10; i++)
            {
                double x = (i * 0.5);
                double y = poly.Calculate(x);
                sb.AppendLine(String.Format("{0,6:F2}{1,9:F4}", x, y));
            }

            Debug.WriteLine(sb.ToString());
        }

        [Test]
        public void LeastSquaresFit_Test()
        {
            DenseVector x_data = new DenseVector(new double[] { 0, 1, 2, 3, 4 });
            DenseVector y_data = new DenseVector(new double[] { 1.0, 1.4, 1.6, 1.3, 0.9 });

            var poly = new PolynominalRegression(x_data, y_data, 2);

            string fit = poly.LeastSquaresFit();

            Assert.That("-0.15x^2 + 0.57x + 1" == fit);
        }
    }
}
