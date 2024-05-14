using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Решение_матриц_методом_Жордана_Гаусса
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveMatrixFile(matrixSize, matrixTextBoxArray, XTextBoxArray);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private TextBox[,] matrixTextBoxArray;
        private TextBox[] XTextBoxArray;
        private Label[,] matrixLabels;
        private int matrixSize
        {
            get { return (int)MatrixSizeUpDown.Value; }
        }
        private int lastMatrixSize;
        private void InitializeMatrixTextBoxArray()
        {
            matrixTextBoxArray = new TextBox[matrixSize, matrixSize];
            XTextBoxArray = new TextBox[matrixSize];
            matrixLabels = new Label[matrixSize, matrixSize];
            var BiasOfTB = new Point(MatrixSizeLabel.Location.X, MatrixSizeLabel.Location.Y + MatrixSizeLabel.Height + 13);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(BiasOfTB.X + j * 85, BiasOfTB.Y + i * 30); // Установите позицию каждого элемента
                    textBox.Width = 50; // Установите ширину текстового поля
                    textBox.TextAlign = HorizontalAlignment.Right; // Выравнивание по правому краю
                    textBox.KeyPress += TextBox_KeyPress; // Добавление обработчика события KeyPress
                    textBox.Text = "0";
                    matrixTextBoxArray[i, j] = textBox;
                    Controls.Add(textBox); // Добавьте элемент на форму

                    Label label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(BiasOfTB.X + j * 85 + 55, BiasOfTB.Y + i * 30);
                    label.Width = 20;
                    label.Height = 20;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    
                    label.Text = $"X{j+1}";
                    matrixLabels[i,j] = label;
                    Controls.Add(label);
                }
                TextBox XBox = new TextBox();
                XBox.Location = new Point(BiasOfTB.X + matrixSize * 85, BiasOfTB.Y + i * 30); // Установите позицию каждого элемента
                XBox.Width = 50; // Установите ширину текстового поля
                XBox.TextAlign = HorizontalAlignment.Right; // Выравнивание по правому краю
                XBox.KeyPress += TextBox_KeyPress; // Добавление обработчика события KeyPress
                XBox.Text = "0";
                XTextBoxArray[i] = XBox;
                Controls.Add(XBox); // Добавьте элемент на форму
            }
            if(BiasOfTB.X + 15 + (matrixSize + 1) * 85 > Width)
                Width = BiasOfTB.X + 15 + (matrixSize + 1) * 85;
            if(BiasOfTB.Y + 15 + (matrixSize + 1) * 30 > Height)
                Height = BiasOfTB.Y + 15 + (matrixSize + 1) * 30;

            lastMatrixSize = matrixSize;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешить ввод только цифр и точки
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if(e.KeyChar == '.')
                Debug.WriteLine(((sender as TextBox).Text.IndexOf('.') > -1));
            if(e.KeyChar == '-')
                Debug.WriteLine(((sender as TextBox).Text.IndexOf('-') > -1));
            // Разрешить только одну точку
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)||
                (e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }            
            

        }

        private void MatrixSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lastMatrixSize; i++)
            {
                for (int j = 0; j < lastMatrixSize; j++)
                {
                    Controls.Remove(matrixTextBoxArray[i, j]);
                    matrixTextBoxArray[i, j].Dispose();

                    Controls.Remove(matrixLabels[i, j]);
                    matrixLabels[i, j].Dispose();
                }
                Controls.Remove(XTextBoxArray[i]);
                XTextBoxArray[i].Dispose();
            }
            InitializeMatrixTextBoxArray();
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            // Проверка, валидны ли введенные данные
            if (!IsValidMatrixInput())
            {
                return; // Если данные недействительны, выход из функции
            }

            // Создаем объект Matrix размером matrixSize x matrixSize
            Matrix matrix = new Matrix(matrixSize, matrixSize);

            // Заполняем матрицу коэффициентов и вектор свободных членов
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    // Конвертируем строковое значение в число, учитывая русскую локализацию (точка или запятая)
                    matrix[i, j] = Convert.ToDouble(matrixTextBoxArray[i, j].Text.Replace('.', ','), new CultureInfo("ru"));
                }

                // Заполняем вектор свободных членов
                matrix.X[i] = Convert.ToDouble(XTextBoxArray[i].Text, new CultureInfo("ru"));
            }

            // Создаем объект MatrixSolver для решения системы линейных уравнений
            MatrixSolver matrixSolver = new MatrixSolver(matrix);

            // Решаем систему линейных уравнений методом Гаусса
            var result = matrixSolver.Solve();
        }


        private void открытьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadMatrixFile();
        }
        private void сохранитьРешениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsValidMatrixInput())
                return;
            SaveMatrixFile(matrixSize, matrixTextBoxArray, XTextBoxArray);
        }
        private bool IsValidMatrixInput()
        {
            // Проверка всех текстовых полей для вектора свободных членов
            for (int i = 0; i < matrixSize; i++)
            {
                // Если поле пустое или содержит только точку, выводим сообщение об ошибке
                if (string.IsNullOrEmpty(XTextBoxArray[i].Text) || XTextBoxArray[i].Text == ".")
                {
                    MessageBox.Show("Не все поля заполнены.");
                    return false; // Возвращаем false, чтобы указать на недействительные данные
                }

                // Проверка текстовых полей для матрицы коэффициентов
                for (int j = 0; j < matrixSize; j++)
                {
                    if (string.IsNullOrEmpty(matrixTextBoxArray[i, j].Text) || matrixTextBoxArray[i, j].Text == ".")
                    {
                        MessageBox.Show("Не все поля заполнены.");
                        return false;
                    }
                }
            }

            // Если все поля заполнены корректно, возвращаем true
            return true;
        }


        private void InputByUserButton_Click(object sender, EventArgs e)
        {
            MatrixSizeLabel.Visible = true;
            MatrixSizeUpDown.Visible = true;
            SolveButton.Visible = true;
            SaveButton.Visible = true;

            MatrixSizeUpDown_ValueChanged(this, new EventArgs());

        }

        public static void SaveMatrixFile(int matrixSize, TextBox[,] matrixTextBoxArray, TextBox[] XTextBoxArray)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Сохранить условие матрицы как...";
            sfd.DefaultExt = ".mtx";
            sfd.SupportMultiDottedExtensions = false;
            sfd.Filter = "Файлы с матрицей (*.mtx)|*.mtx";
            sfd.ShowDialog();

            string pathToFile = sfd.FileName;

            if (string.IsNullOrEmpty(pathToFile))
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(pathToFile))
            {
                sw.WriteLine($"size={matrixSize}");
                sw.WriteLine();
                sw.WriteLine("Values=");
                StringBuilder valuesBuilder = new StringBuilder();
                foreach (var tb in matrixTextBoxArray)
                {
                    valuesBuilder.Append(tb.Text + " ");
                }
                sw.WriteLine(valuesBuilder.ToString());
                sw.WriteLine();
                sw.WriteLine("Solutions=");
                StringBuilder solutionsBuilder = new StringBuilder();
                foreach (var tb in XTextBoxArray)
                {
                    solutionsBuilder.Append(tb.Text + " ");
                }
                sw.WriteLine(solutionsBuilder.ToString());
            }
        }

        public void LoadMatrixFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Файлы с матрицей (*.mtx)|*.mtx";
            ofd.Multiselect = false;
            ofd.Title = "Открыть файл с условием...";
            ofd.CheckFileExists = true;
            ofd.ShowDialog();

            string pathToFile = ofd.FileName;
            if (string.IsNullOrEmpty(pathToFile))
            {
                return;
            }

            bool IsValidFile = true;

            int sizeOfOpenedMatrix;
            double[,] valuesOfOpenedMatrix;
            double[] solutionsOfOpenedMatrix;


            using (StreamReader stream = new StreamReader(pathToFile))
            {
                #region парсим размер
                string firstString = String.Empty;

                //пропускаем пустые строки
                do
                {
                    firstString = stream.ReadLine();
                }
                while (string.IsNullOrEmpty(firstString));

                //находим значение размера матрицы

                string sizeString = firstString.Remove(0, firstString.LastIndexOf('=') + 1);

                var matrixSize = Int32.Parse(sizeString);

                if (matrixSize < 2 || matrixSize > 20)
                {
                    IsValidFile = false;
                }
                sizeOfOpenedMatrix = matrixSize;

                #endregion
                #region парсим значения
                string valuesString = String.Empty;

                //пропускаем пустые строки
                do
                {
                    valuesString = stream.ReadLine();
                }
                while (string.IsNullOrEmpty(valuesString));

                valuesString = stream.ReadLine();

                //разделяем массив строк в которых находятся числа
                var stringValuesArray = valuesString.Trim().Split(' ');
                //проверяем размерность матрицы
                if (stringValuesArray.Length != matrixSize * matrixSize)
                {
                    IsValidFile = false;
                }
                //создаем массив для чисел
                var valuesArray = new double[matrixSize, matrixSize];

                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        if (!Double.TryParse(stringValuesArray[i * matrixSize + j], NumberStyles.Any, new CultureInfo("en"), out valuesArray[i, j]))
                        {
                            IsValidFile = false;
                        }
                    }
                }
                valuesOfOpenedMatrix = valuesArray;

                #endregion
                #region парсим решения
                string solutionsString = String.Empty;

                //пропускаем пустые строки
                do
                {
                    solutionsString = stream.ReadLine();
                }
                while (string.IsNullOrEmpty(solutionsString));

                solutionsString = stream.ReadLine();

                //разделяем массив строк в которых находятся числа
                var solutionsStringArray = solutionsString.Trim().Split(' ');
                //проверяем размерность матрицы
                if (solutionsStringArray.Length != matrixSize)
                {
                    IsValidFile = false;
                }
                //создаем массив для чисел
                var solutionsArray = new double[matrixSize];

                for (int i = 0; i < matrixSize; i++)
                {
                    if (!Double.TryParse(solutionsStringArray[i], NumberStyles.Any, new CultureInfo("en"), out solutionsArray[i]))
                    {
                        IsValidFile = false;
                    }
                }
                solutionsOfOpenedMatrix = solutionsArray;
                #endregion
            }
            if(!IsValidFile)
            {
                MessageBox.Show("При загрузке файла произошла ошибка считывания. Пожалуйста, выберите другой файл.");
                return;
            }
            InputByUserButton_Click(this, new EventArgs());

            //initializing new textboxes
            MatrixSizeUpDown.Value = (decimal)sizeOfOpenedMatrix;

            MatrixSizeUpDown_ValueChanged(null, new EventArgs());

            for (int i = 0; i < valuesOfOpenedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < valuesOfOpenedMatrix.GetLength(1); j++)
                {
                    matrixTextBoxArray[i, j].Text = valuesOfOpenedMatrix[i, j].ToString();
                }
                XTextBoxArray[i].Text = solutionsOfOpenedMatrix[i].ToString();
            }
            SolveButton.PerformClick();
        }

        private void InputByLoad_Click(object sender, EventArgs e)
        {
            LoadMatrixFile();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveMatrixFile(matrixSize, matrixTextBoxArray, XTextBoxArray);
        }

        
    }
}