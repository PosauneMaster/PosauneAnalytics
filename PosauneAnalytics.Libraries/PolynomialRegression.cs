using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

using MathNet.Numerics.LinearAlgebra.Double;


namespace PosauneAnalytics.Libraries
{
    public class PolynominalRegression
    {
        private int _order;
        private Vector<double> _coefs;

        public PolynominalRegression(List<double> xData, List<double> yData)
        {
            DenseVector x_data = new DenseVector(xData.ToArray());
            DenseVector y_data = new DenseVector(yData.ToArray());

            Initialize(x_data, y_data, 2);

        }

        public PolynominalRegression(DenseVector xData, DenseVector yData, int order)
        {
            Initialize(xData, yData, order);
        }

        private void Initialize(DenseVector xData, DenseVector yData, int order)
        {
            _order = order;
            int n = xData.Count;

            var vandMatrix = new DenseMatrix(xData.Count, order + 1);
            for (int i = 0; i < n; i++)
            {
                vandMatrix.SetRow(i, VandermondeRow(xData[i]));
            }

            // var vandMatrixT = vandMatrix.Transpose();
            // 1 variant:
            //_coefs = (vandMatrixT * vandMatrix).Inverse() * vandMatrixT * yData;
            // 2 variant:
            //_coefs = (vandMatrixT * vandMatrix).LU().Solve(vandMatrixT * yData);
            // 3 variant (most fast I think. Possible LU decomposion also can be replaced with one triangular matrix):
            _coefs = vandMatrix.TransposeThisAndMultiply(vandMatrix).LU().Solve(TransposeAndMult(vandMatrix, yData));
        }

        private Vector<double> VandermondeRow(double x)
        {
            double[] result = new double[_order + 1];
            double mult = 1;
            for (int i = 0; i <= _order; i++)
            {
                result[i] = mult;
                mult *= x;
            }
            return new DenseVector(result);
        }

        private static DenseVector TransposeAndMult(Matrix m, Vector v)
        {
            var result = new DenseVector(m.ColumnCount);
            for (int j = 0; j < m.RowCount; j++)
                for (int i = 0; i < m.ColumnCount; i++)
                    result[i] += m[j, i] * v[j];
            return result;
        }

        public double Calculate(double x)
        {
            return VandermondeRow(x) * _coefs;
        }

        public string LeastSquaresFit()
        {
            string x0 = Math.Round(_coefs[0], 4).ToString();
            string x1 = Math.Round(_coefs[1], 4).ToString();
            string x2 = Math.Round(_coefs[2], 4).ToString();

            string fit = String.Format("{0}x^2 + {1}x + {2}", x2, x1, x0);

            return fit;

        }
    }
}
