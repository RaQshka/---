using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Решение_матриц_методом_Жордана_Гаусса
{
    public class MatrixSolver
    {
        // Матрица, которую нужно решить.
        public Matrix Matrix { get; set; }

        // Конструктор, принимающий объект матрицы.
        public MatrixSolver(Matrix matrix)
        {
            this.Matrix = matrix;
        }

        // Метод для изменения строк, если ведущий элемент нулевой.
        private bool ChangeLines(int row)
        {
            for (int i = row; i < Matrix.SizeY; i++)
            {
                if (Matrix[row, i] != 0)
                {
                    // Перестановка строк в матрице
                    for (int j = 0; j < Matrix.SizeX; j++)
                    {
                        (Matrix[row, j], Matrix[i, j]) = (Matrix[i, j], Matrix[row, j]); // Обмен значениями
                    }
                    (Matrix.X[row], Matrix.X[i]) = (Matrix.X[i], Matrix.X[row]); //

                }
                // Перестановка значений вектора свободных членов
                return true; // Перестановка успешна
            }

            return false; // Если перестановка не удалась
        }

        // Метод Solve() выполняет решение матрицы методом Гаусса.
        public List<double> Solve()
        {
            // Проверка, квадратная ли матрица, так как метод Гаусса работает только с квадратными матрицами.
            if (!Matrix.IsSquareMatrix())
            {
                throw new Exception("Matrix can't be solved by Jordan-Gauss, it's not a square matrix");
            }

            int n = Matrix.SizeY;

            // Клонирование матрицы для сохранения текущего состояния.
            Matrix currentMatrix = (Matrix)Matrix.Clone();

            List<Matrix> matrixIterations = new List<Matrix>(); // Список для сохранения состояний матрицы на каждом шаге
            List<double> result = new List<double>(); // Список для хранения решений

            // Прямой ход метода Гаусса
            matrixIterations.Add(currentMatrix); // Добавляем начальное состояние

            for (int i = 0; i < n; i++)
            {
                // Если ведущий элемент нулевой, попробуем переставить строки
                if (Matrix[i, i] == 0 && !ChangeLines(i))
                {
                    MessageBox.Show("Эта матрица не может быть решена."); // Сообщение об ошибке, если перестановка не удалась
                    return new List<double>(); // Выход без решения
                }

                // Обнуление элементов ниже ведущего
                for (int j = i + 1; j < n; j++)
                {
                    double factor = Matrix[j, i] / Matrix[i, i]; // Коэффициент для вычитания

                    for (int k = i; k < n; k++)
                    {
                        Matrix[j, k] -= factor * Matrix[i, k]; // Вычитание строк с учетом коэффициента
                    }

                    // Обновление вектора свободных членов
                    Matrix.X[j] -= factor * Matrix.X[i];
                }

                matrixIterations.Add((Matrix)Matrix.Clone()); // Добавляем текущее состояние матрицы
            }

            int inconsistenceOfMatrix = CheckForInconsistencies(Matrix);
            if (CheckForInconsistencies(Matrix) == 1)
            {
                MessageBox.Show("Система не имеет решения.");
            }

            if (CheckForInconsistencies(Matrix) == 2)
            {
                MessageBox.Show("Система линейно зависима либо имеет бесконечно много решений");
            }

            // Обратный ход метода Гаусса
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;

                // Обратная подстановка
                for (int j = i + 1; j < n; j++)
                {
                    sum += Matrix[i, j] * result[j - (i + 1)]; // Суммирование для обратной подстановки
                }

                // Вычисление значения переменной
                result.Insert(0, (Matrix.X[i] - sum) / Matrix[i, i]);            
            }


            // Показ результатов и промежуточных состояний
            SolvedMatrixLogForm solved = new SolvedMatrixLogForm(currentMatrix, matrixIterations, result);
            solved.Show(); // Отображение формы с результатами

            return result; // Возвращаем решения
        }

        public int CheckForInconsistencies(Matrix matrix)
        {
            int n = matrix.SizeY;

            for (int i = 0; i < n; i++)
            {
                bool isZeroRow = true;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isZeroRow = false;
                        break;
                    }
                }

                if (isZeroRow)
                {
                    if (matrix.X[i] != 0)
                    {
                        // Противоречие, система не имеет решения
                        return 1;
                    }
                    else
                    {
                        // Система линейно зависима, может иметь бесконечно много решений
                        return 2;
                    }
                }
            }

            return 0; // Система линейно независима
        }


    }
}