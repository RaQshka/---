using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Решение_матриц_методом_Жордана_Гаусса
{
    public class Matrix : ICloneable
    {
        // Размеры матрицы по горизонтали (SizeX) и вертикали (SizeY).
        // Установка этих значений через свойства с проверками.
        private int sizeX;
        private int sizeY;

        // Свойства для доступа к размерам матрицы с проверкой на минимальный размер (>=2).
        public int SizeX
        {
            get => sizeX;
            private set
            {
                if (value < 2)
                {
                    throw new Exception("Matrix size cannot be less than two");
                }
                sizeX = value;
            }
        }

        public int SizeY
        {
            get => sizeY;
            private set
            {
                if (value < 2)
                {
                    throw new Exception("Matrix size cannot be less than two");
                }
                sizeY = value;
            }
        }

        // Двумерный массив значений матрицы и одномерный массив вектора свободных членов.
        public double[][] Values { get; set; }
        public double[] X { get; } // Вектор свободных членов

        // Конструктор, создающий матрицу с заданными размерами и инициализацией пустыми значениями.
        public Matrix(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Values = new double[sizeY][];
            this.X = new double[sizeY];
            for (int i = 0; i < sizeY; i++)
            {
                this.Values[i] = new double[sizeX]; // Инициализация строк матрицы
            }
        }

        // Конструктор, создающий матрицу с заданными значениями.
        public Matrix(int sizeX, int sizeY, double[][] values)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Values = new double[sizeY][];

            int maxY = sizeY;
            int maxX = sizeX;

            // Проверка на длину переданных значений
            if (values[0].Length < sizeX)
            {
                maxX = values[0].Length;
            }
            if (values.Length < sizeY)
            {
                maxY = values.Length;
            }

            // Инициализация значений матрицы
            for (int i = 0; i < maxY; i++)
            {
                this.Values[i] = new double[sizeX];
                for (int j = 0; j < maxX; j++)
                {
                    this.Values[i][j] = values[i][j];
                }
            }
        }

        // Конструктор, принимающий значения матрицы и вектора свободных членов
        public Matrix(int sizeX, int sizeY, double[][] values, double[] x)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Values = new double[sizeY][];
            this.X = new double[sizeY];

            // Заполнение матрицы значениями и вектора свободных членов
            for (int i = 0; i < sizeY; i++)
            {
                this.X[i] = x[i];
                this.Values[i] = new double[sizeX];
                for (int j = 0; j < sizeX; j++)
                {
                    this.Values[i][j] = values[i][j];
                }
            }
        }

        // Проверяет, существует ли вектор свободных членов.
        public bool IsHaveX()
        {
            return (X != null);
        }

        // Проверяет, квадратная ли матрица (SizeX == SizeY).
        public bool IsSquareMatrix()
        {
            return SizeX == SizeY;
        }

        // Индексатор для доступа к значениям матрицы.
        public double this[int keyX, int keyY]
        {
            get => Values[keyX][keyY];
            set => Values[keyX][keyY] = value;
        }

        // Переопределение метода ToString() для вывода матрицы в текстовом виде.
        public override String ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                {
                    sb.Append(Convert.ToString(Math.Round(Values[i][j], 3))); // Округление значений
                    sb.Append("\t");
                }
                sb.AppendLine(); // Новая строка после каждой строки матрицы
            }
            return sb.ToString();
        }

        // Метод Clone() для создания копии матрицы.
        public object Clone()
        {
            return new Matrix(SizeX, SizeY, Values, X);
        }
    }


}
