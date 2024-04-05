using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Решение_матриц_методом_Жордана_Гаусса
{

    public class MatrixSolver
    {
        public Matrix Matrix { get; set; }

        public MatrixSolver(Matrix matrix)
        {
            Matrix = matrix;
        }
        private bool ChangeLines(int row)
        {
            for (int i = row; i < Matrix.SizeY; i++)
            {
                if (Matrix[row, i] != 0)
                {
                    for (int j = 0; j < Matrix.SizeX; j++)
                    {
                        (Matrix[row, j], Matrix[i, j]) = (Matrix[i, j], Matrix[row, j]);

                    }
                    (Matrix.X[row], Matrix.X[i]) = (Matrix.X[i], Matrix.X[row]);
                    return true;
                }
            }
            return false;
        }
        public List<double> Solve()
        {

            if (!Matrix.IsSquareMatrix())
            {
                throw new Exception("Matrix can't be solved by Jordan-Gauss, it's not a square matrix");
            }

            int n = Matrix.SizeY;

            Matrix currentmatrix = (Matrix)Matrix.Clone();

            List<Matrix> matrixIterations = new List<Matrix>();

            List<double> result = new List<double>();
            /*
             Matrix currentMatrix, List<Matrix> matrixIterations, List<double> matrixSolutions
             */
            // Прямой ход метода Гаусса

            matrixIterations.Add((Matrix)Matrix.Clone());

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Matrix[i, i] == 0 && !ChangeLines(i))
                    {
                        MessageBox.Show("Данная матрица не может быть решена.");
                        return new List<double>();
                    }

                    double factor = Matrix[j, i] / Matrix[i, i];


                    for (int k = i; k < n; k++)
                    {
                        Matrix[j, k] -= factor * Matrix[i, k];
                    }
                    Matrix.X[j] -= factor * Matrix.X[i]; // Учитываем правую часть
                }
                matrixIterations.Add((Matrix)Matrix.Clone());
                //MessageBox.Show("Matrix on iteration " + i + "\n" + Matrix.ToString());
            }

            // Обратный ход метода Гаусса
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += Matrix[i, j] * result[j - (i + 1)]; // Используем правую часть
                }
                result.Insert(0, (Matrix.X[i] - sum) / Matrix[i, i]); // Используем правую часть
            }

            SolvedMatrixLogForm solved = new SolvedMatrixLogForm(currentmatrix, matrixIterations, result);
            solved.Show();
            return result;
        }
    }
}
