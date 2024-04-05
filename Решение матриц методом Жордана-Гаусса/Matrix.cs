using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Решение_матриц_методом_Жордана_Гаусса
{
    public class Matrix :ICloneable
    {
        private int sizeX;
        private int sizeY;
        public int SizeX {
            get
            {
                return sizeX;
            }
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
            get
            {
                return sizeY;
            }
            private set
            {
                if (value < 2)
                {
                    throw new Exception("Matrix size cannot be less than two");
                }
                sizeY = value;
            }
        }
        public double[][] Values { get; set; }
        public double[] X { get; }

        public Matrix(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Values = new double[sizeY][];
            this.X = new double[sizeY];
            for (int i = 0; i < sizeY; i++)
            {
                this.Values[i] = new double[sizeX];
            }
        }
        public Matrix(int sizeX, int sizeY, double[][] values)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            Values = new double[sizeY][];

            int maxY = sizeY;
            int maxX = sizeX;

            if (values[0].Length < sizeX)
            {
                maxX = values[0].Length;
            }
            if (values.Length < sizeY)
            {
                maxY = values.Length;
            }

            for (int i = 0; i < maxY; i++)
            {
                this.Values[i] = new double[sizeX];
                for (int j = 0; j < maxX; j++)
                {
                    this.Values[i][j] = values[i][j];
                }
            }
        }
        public Matrix(int sizeX, int sizeY, double[][] values, double[] x)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            Values = new double[sizeY][];
            X = new double[sizeY];

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

        public bool IsHaveX()
        {
            return (X != null) ? true : false;
        }
        public bool IsSquareMatrix()
        {
            return SizeX == SizeY;
        }

        public double this[int keyX, int keyY]
        {
            get => Values[keyX][keyY];
            set => Values[keyX][keyY] = value;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                {
                    sb.Append(Convert.ToString(Math.Round(Values[i][j], 3)));
                    sb.Append("\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public object Clone()
        {
            return new Matrix(sizeX, sizeY, Values, X);
        }
    }
}
