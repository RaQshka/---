using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Решение_матриц_методом_Жордана_Гаусса
{
    public partial class SolvedMatrixLogForm : Form
    {
        public Matrix CurrentMatrix;
        public List<Matrix> MatrixIterations;
        public List<double> MatrixSolutions;
        private Dictionary<int, string> iterationsDescription = new Dictionary<int, string>();
        public SolvedMatrixLogForm(Matrix currentMatrix, List<Matrix> matrixIterations, List<double> matrixSolutions)
        {
            InitializeComponent();
            CurrentMatrix = currentMatrix;
            MatrixIterations = matrixIterations;
            MatrixSolutions = matrixSolutions;
        }

        private void SolvedMatrixLogForm_Load(object sender, EventArgs e)
        {

            var BiasOfTB = new Point(13, 40);
            var SizeOfTB = 85;

            for (int i = 0; i < CurrentMatrix.SizeY; i++)
            {
                for (int j = 0; j < CurrentMatrix.SizeX; j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(BiasOfTB.X + j * SizeOfTB, BiasOfTB.Y + i * 30); // Установите позицию каждого элемента
                    textBox.Width = 50; // Установите ширину текстового поля
                    textBox.TextAlign = HorizontalAlignment.Right; // Выравнивание по правому краю
                    textBox.Text = CurrentMatrix.Values[i][j].ToString();
                    textBox.ReadOnly = true;
                    Controls.Add(textBox); // Добавьте элемент на форму

                    Label label = new Label();
                    label.AutoSize = false;
                    label.Location = new Point(BiasOfTB.X + j * SizeOfTB + 55, BiasOfTB.Y + i * 30);
                    label.Width = 20;
                    label.Height = 20;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    label.Text = $"X{j + 1}";
                    Controls.Add(label);
                }
                TextBox XBox = new TextBox();
                XBox.Location = new Point(BiasOfTB.X + CurrentMatrix.SizeY * SizeOfTB, BiasOfTB.Y + i * 30); // Установите позицию каждого элемента
                XBox.Width = 50; // Установите ширину текстового поля
                XBox.TextAlign = HorizontalAlignment.Right; // Выравнивание по правому краю
                XBox.Text = CurrentMatrix.X[i].ToString();
                XBox.ReadOnly = true;
                Controls.Add(XBox); // Добавьте элемент на форму
            }

            if (BiasOfTB.Y + 50 + (CurrentMatrix.SizeY + 1) * 30 != Height)
                Height = BiasOfTB.Y + 50 + (CurrentMatrix.SizeY + 1) * 30;

/*            if (MatrixIterations == null || MatrixSolutions == null)
            {
                Label noSolutionLabel = new Label();
                noSolutionLabel.Text = "Данная СЛАУ не имеет решений.";
                noSolutionLabel.Font = new Font(FontFamily.GenericSansSerif, emSize: 12.0f);
                noSolutionLabel.Location = new Point(BiasOfTB.X, BiasOfTB.Y + CurrentMatrix.SizeY * SizeOfTB + 20);
                Controls.Add(noSolutionLabel);
                return;
            }*/

            Label solutionLabel = new Label();
            solutionLabel.Text = "Поэтапное решение: ";
            solutionLabel.Font = new Font(FontFamily.GenericSansSerif, 12);
            solutionLabel.Location = new Point(SizeOfTB * (CurrentMatrix.SizeX + 1) + 50, 13);
            solutionLabel.Height = 20;
            solutionLabel.Width = solutionLabel.PreferredWidth;
            Controls.Add(solutionLabel);

            IterationsListBox.Location = new Point(solutionLabel.Location.X, solutionLabel.Location.Y + 25);

            IterationsListBox.Height = Size.Height - IterationsListBox.Location.Y - 50;

            Width = IterationsListBox.Location.X + 300;

            Button saveButton = new Button();
            saveButton.Text = "Сохранить решение в файл...";
            saveButton.Font = new Font(FontFamily.GenericSerif, 12);
            saveButton.Width = IterationsListBox.Location.X;
            saveButton.Height = 30;

            for (int iterations = 0; iterations < MatrixSolutions.Count; iterations++)
            {
                StringBuilder builder = new StringBuilder($"Этап {iterations + 1}:");
                builder.AppendLine(); 
                IterationsListBox.Items.Add(builder.ToString());

                for (int i = 0; i < CurrentMatrix.SizeY; i++)
                {
                    for (int j = 0; j < CurrentMatrix.SizeX; j++)
                    {
                        builder.Append($"{Math.Round(MatrixIterations[iterations].Values[i][j], 6)} x{j+1};\t");
                    }
                    builder.Append($"{MatrixIterations[iterations].X[i]}");
                    builder.AppendLine();
                }
                iterationsDescription.Add(iterations, builder.ToString());
            }

            StringBuilder sb = new StringBuilder("Решения:");
            sb.AppendLine();
            IterationsListBox.Items.Add(sb.ToString());

            for (int i = 0; i<MatrixSolutions.Count; i++)
            {
                sb.AppendLine($"x{i + 1} = {Math.Round(MatrixSolutions[i], 6)}");
            }
            iterationsDescription.Add(MatrixSolutions.Count, sb.ToString());

        }
        RichTextBox lastWrittenDescription = new RichTextBox();
        private void IterationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (sender as ListBox);
            Controls.Remove(lastWrittenDescription);

            if (iterationsDescription.TryGetValue(listBox.SelectedIndex, out string description))
            {
                RichTextBox label = new RichTextBox();
                label.Anchor = AnchorStyles.Top|AnchorStyles.Bottom | AnchorStyles.Left |AnchorStyles.Right;
                label.Multiline = true;
                label.Text = description;
                label.AutoSize = false;
                label.Location = new Point(listBox.Location.X + listBox.Width + 15, listBox.Location.Y);
                label.ReadOnly = true;
                label.ScrollBars = RichTextBoxScrollBars.Both;
                label.WordWrap = false;
                label.Width = Size.Width-label.Location.X - 25;
                label.Height = Size.Height - label.Location.Y - 50;
                lastWrittenDescription = label;
                Controls.Add(label);
            }
        }

    }
}
