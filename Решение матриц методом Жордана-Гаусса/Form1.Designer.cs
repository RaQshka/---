namespace Решение_матриц_методом_Жордана_Гаусса
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MatrixSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.SolveButton = new System.Windows.Forms.Button();
            this.MatrixSizeLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InputByLoad = new System.Windows.Forms.Button();
            this.InputByUserButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SLAYToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixSizeUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MatrixSizeUpDown
            // 
            this.MatrixSizeUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixSizeUpDown.Location = new System.Drawing.Point(1227, 335);
            this.MatrixSizeUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MatrixSizeUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.MatrixSizeUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MatrixSizeUpDown.Name = "MatrixSizeUpDown";
            this.MatrixSizeUpDown.Size = new System.Drawing.Size(169, 30);
            this.MatrixSizeUpDown.TabIndex = 0;
            this.SLAYToolTip.SetToolTip(this.MatrixSizeUpDown, resources.GetString("MatrixSizeUpDown.ToolTip"));
            this.MatrixSizeUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.MatrixSizeUpDown.Visible = false;
            this.MatrixSizeUpDown.ValueChanged += new System.EventHandler(this.MatrixSizeUpDown_ValueChanged);
            // 
            // SolveButton
            // 
            this.SolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SolveButton.Location = new System.Drawing.Point(1113, 252);
            this.SolveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(284, 71);
            this.SolveButton.TabIndex = 1;
            this.SolveButton.Text = "Решить введенную СЛАУ";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Visible = false;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // MatrixSizeLabel
            // 
            this.MatrixSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatrixSizeLabel.Location = new System.Drawing.Point(816, 327);
            this.MatrixSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MatrixSizeLabel.Name = "MatrixSizeLabel";
            this.MatrixSizeLabel.Size = new System.Drawing.Size(403, 44);
            this.MatrixSizeLabel.TabIndex = 2;
            this.MatrixSizeLabel.Text = "Введите размерность квадратной матрицы коэфициентов:";
            this.SLAYToolTip.SetToolTip(this.MatrixSizeLabel, "    Данное поле позволяет настроить размерность матрицы. ");
            this.MatrixSizeLabel.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1415, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьИзФайлаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьИзФайлаToolStripMenuItem
            // 
            this.открытьИзФайлаToolStripMenuItem.Name = "открытьИзФайлаToolStripMenuItem";
            this.открытьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.открытьИзФайлаToolStripMenuItem.Text = "Открыть";
            this.открытьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.открытьИзФайлаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1417, 68);
            this.label2.TabIndex = 4;
            this.label2.Text = "Программа для решения систем линейных алгебрарических уравнений (СЛАУ) методом Га" +
    "усса";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(820, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(577, 68);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите метод ввода СЛАУ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InputByLoad
            // 
            this.InputByLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputByLoad.Location = new System.Drawing.Point(820, 177);
            this.InputByLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InputByLoad.Name = "InputByLoad";
            this.InputByLoad.Size = new System.Drawing.Size(285, 68);
            this.InputByLoad.TabIndex = 6;
            this.InputByLoad.Text = "Загрузить из файла";
            this.InputByLoad.UseVisualStyleBackColor = true;
            this.InputByLoad.Click += new System.EventHandler(this.InputByLoad_Click);
            // 
            // InputByUserButton
            // 
            this.InputByUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputByUserButton.Location = new System.Drawing.Point(1113, 177);
            this.InputByUserButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InputByUserButton.Name = "InputByUserButton";
            this.InputByUserButton.Size = new System.Drawing.Size(284, 68);
            this.InputByUserButton.TabIndex = 7;
            this.InputByUserButton.Text = "Ввод вручную";
            this.InputByUserButton.UseVisualStyleBackColor = true;
            this.InputByUserButton.Click += new System.EventHandler(this.InputByUserButton_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(788, 139);
            this.label4.TabIndex = 8;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(820, 252);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(285, 71);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Сохранить введенную СЛАУ";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Visible = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SLAYToolTip
            // 
            this.SLAYToolTip.IsBalloon = true;
            this.SLAYToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SLAYToolTip.ToolTipTitle = "Размерность матрицы";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(400, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 129);
            this.label1.TabIndex = 11;
            this.label1.Text = "Здесь m — количество уравнений, а n — количество переменных,\r\n x1,x2, … ,xn — неи" +
    "звестные, которые надо определить, \r\nкоэффициенты  и свободные члены b1, b2, …, " +
    "bm предполагаются известными. \r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Решение_матриц_методом_Жордана_Гаусса.Properties.Resources.pic2;
            this.pictureBox1.Location = new System.Drawing.Point(20, 245);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(16, 378);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(792, 240);
            this.label5.TabIndex = 12;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 583);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InputByUserButton);
            this.Controls.Add(this.InputByLoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MatrixSizeLabel);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.MatrixSizeUpDown);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1433, 630);
            this.Name = "Form1";
            this.Text = "Решение СЛАУ методом Гаусса";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MatrixSizeUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MatrixSizeUpDown;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Label MatrixSizeLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button InputByLoad;
        private System.Windows.Forms.Button InputByUserButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ToolTip SLAYToolTip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}

