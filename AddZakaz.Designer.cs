namespace demoExamsGlushakovIlya
{
    partial class AddZakaz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbArt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdFIO = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAdres = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddTovar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbArt
            // 
            this.cmbArt.AutoCompleteCustomSource.AddRange(new string[] {
            "Ботинки",
            "Туфли",
            "Кроссовки",
            "Полуботинки",
            "Кеды",
            "Тапочки",
            "Сапоги"});
            this.cmbArt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArt.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbArt.FormattingEnabled = true;
            this.cmbArt.Items.AddRange(new object[] {
            "B320R5",
            "B431R5",
            "C436G5",
            "D268G5",
            "D329H3",
            "D364R4",
            "D572U8",
            "E482R4",
            "F427R5",
            "F572H7",
            "F635R4",
            "G432E4",
            "G531F4",
            "G783F5",
            "H535R5",
            "H782T5",
            "J384T6",
            "J542F5",
            "K345R4",
            "K358H6",
            "L754R4",
            "M542T5",
            "N457T5",
            "O754F4",
            "P764G4",
            "S213E3",
            "S326R5",
            "S634B5",
            "T324F5",
            "А112Т4",
            "Тест №2"});
            this.cmbArt.Location = new System.Drawing.Point(13, 39);
            this.cmbArt.Margin = new System.Windows.Forms.Padding(4);
            this.cmbArt.Name = "cmbArt";
            this.cmbArt.Size = new System.Drawing.Size(275, 27);
            this.cmbArt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "Артикул";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Статус";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteCustomSource.AddRange(new string[] {
            "Ботинки",
            "Туфли",
            "Кроссовки",
            "Полуботинки",
            "Кеды",
            "Тапочки",
            "Сапоги"});
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Новый",
            "Завершен"});
            this.cmbStatus.Location = new System.Drawing.Point(14, 105);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(275, 27);
            this.cmbStatus.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "Дата заказа";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(19, 171);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(215, 30);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(19, 238);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(215, 30);
            this.dateTimePicker2.TabIndex = 17;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "Дата доставки";
            // 
            // cmdFIO
            // 
            this.cmdFIO.AutoCompleteCustomSource.AddRange(new string[] {
            "Ботинки",
            "Туфли",
            "Кроссовки",
            "Полуботинки",
            "Кеды",
            "Тапочки",
            "Сапоги"});
            this.cmdFIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdFIO.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdFIO.FormattingEnabled = true;
            this.cmdFIO.Items.AddRange(new object[] {
            "Никифорова Весения Николаевна",
            "Сазонов Руслан Германович",
            "Одинцов Серафим Артёмович",
            "Степанов Михаил Артёмович",
            "Ворсин Петр Евгеньевич",
            "Старикова Елена Павловна",
            "Михайлюк Анна Вячеславовна",
            "Ситдикова Елена Анатольевна",
            "Ворсин Петр Евгеньевич",
            "Старикова Елена Павловна",
            "fgfg"});
            this.cmdFIO.Location = new System.Drawing.Point(19, 306);
            this.cmdFIO.Margin = new System.Windows.Forms.Padding(4);
            this.cmdFIO.Name = "cmdFIO";
            this.cmdFIO.Size = new System.Drawing.Size(275, 27);
            this.cmdFIO.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 31);
            this.label5.TabIndex = 18;
            this.label5.Text = "Пользователь";
            // 
            // cmbAdres
            // 
            this.cmbAdres.AutoCompleteCustomSource.AddRange(new string[] {
            "Ботинки",
            "Туфли",
            "Кроссовки",
            "Полуботинки",
            "Кеды",
            "Тапочки",
            "Сапоги"});
            this.cmbAdres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdres.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbAdres.FormattingEnabled = true;
            this.cmbAdres.Items.AddRange(new object[] {
            "420151, г. Лесной, ул. Вишневая, 32",
            "125061, г. Лесной, ул. Подгорная, 8",
            "630370, г. Лесной, ул. Шоссейная, 24",
            "400562, г. Лесной, ул. Зеленая, 32",
            "614510, г. Лесной, ул. Маяковского, 47",
            "410542, г. Лесной, ул. Светлая, 46",
            "620839, г. Лесной, ул. Цветочная, 8",
            "443890, г. Лесной, ул. Коммунистическая, 1",
            "603379, г. Лесной, ул. Спортивная, 46",
            "603721, г. Лесной, ул. Гоголя, 41",
            "410172, г. Лесной, ул. Северная, 13",
            "614611, г. Лесной, ул. Молодежная, 50",
            "454311, г.Лесной, ул. Новая, 19",
            "660007, г.Лесной, ул. Октябрьская, 19",
            "603036, г. Лесной, ул. Садовая, 4",
            "394060, г.Лесной, ул. Фрунзе, 43",
            "410661, г. Лесной, ул. Школьная, 50",
            "625590, г. Лесной, ул. Коммунистическая, 20",
            "625683, г. Лесной, ул. 8 Марта",
            "450983, г.Лесной, ул. Комсомольская, 26",
            "394782, г. Лесной, ул. Чехова, 3",
            "603002, г. Лесной, ул. Дзержинского, 28",
            "450558, г. Лесной, ул. Набережная, 30",
            "344288, г. Лесной, ул. Чехова, 1",
            "614164, г.Лесной,  ул. Степная, 30",
            "394242, г. Лесной, ул. Коммунистическая, 43",
            "660540, г. Лесной, ул. Солнечная, 25",
            "125837, г. Лесной, ул. Шоссейная, 40",
            "125703, г. Лесной, ул. Партизанская, 49",
            "625283, г. Лесной, ул. Победы, 46",
            "614753, г. Лесной, ул. Полевая, 35",
            "426030, г. Лесной, ул. Маяковского, 44",
            "450375, г. Лесной ул. Клубная, 44",
            "625560, г. Лесной, ул. Некрасова, 12",
            "630201, г. Лесной, ул. Комсомольская, 17",
            "190949, г. Лесной, ул. Мичурина, 26"});
            this.cmbAdres.Location = new System.Drawing.Point(19, 372);
            this.cmbAdres.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAdres.Name = "cmbAdres";
            this.cmbAdres.Size = new System.Drawing.Size(275, 27);
            this.cmbAdres.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 337);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 31);
            this.label6.TabIndex = 20;
            this.label6.Text = "Адрес пвз";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(19, 407);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 55);
            this.button2.TabIndex = 26;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(770, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(156, 212);
            this.listBox1.TabIndex = 27;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdate.Location = new System.Drawing.Point(354, 401);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(232, 55);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Сохранить изменения";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddTovar
            // 
            this.btnAddTovar.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnAddTovar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddTovar.Location = new System.Drawing.Point(354, 401);
            this.btnAddTovar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTovar.Name = "btnAddTovar";
            this.btnAddTovar.Size = new System.Drawing.Size(173, 55);
            this.btnAddTovar.TabIndex = 29;
            this.btnAddTovar.Text = "Добавить заказ";
            this.btnAddTovar.UseVisualStyleBackColor = false;
            this.btnAddTovar.Click += new System.EventHandler(this.btnAddTovar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(770, 242);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 60);
            this.button1.TabIndex = 30;
            this.button1.Text = "Добавить позицию";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(348, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 31);
            this.label7.TabIndex = 31;
            this.label7.Text = "Количество";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(354, 43);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(143, 30);
            this.numericUpDown1.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(504, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 31);
            this.label8.TabIndex = 33;
            this.label8.Text = "шт";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(770, 310);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 60);
            this.button3.TabIndex = 34;
            this.button3.Text = "Удалить позицию";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddZakaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 469);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddTovar);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbAdres);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdFIO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbArt);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.Name = "AddZakaz";
            this.Text = "Добавление/Редактирование заказов";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbArt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmdFIO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAdres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddTovar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
    }
}