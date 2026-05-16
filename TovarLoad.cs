using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoExamsGlushakovIlya
{
    public partial class TovarLoad : UserControl
    {
        string connectDB = "Host=db.edu.cchgeu.ru;Port=5432;Username=postgres;Password=postgres;Database=demochkaLove";
        public string Art {  get; set; }
        public string Categori {  get; set; }
        public string Opisanie { get; set; }
        public string NameTovar { get; set; }
        public string ED {  get; set; }
        public string Postavshik { get; set; }
        public string Proizvoditel { get; set; }
        public decimal Price { get; set; }
        public int Skidka { get; set; }
        public string Photo { get; set; }
        public int CountSkald { get; set; }
        public string Role { get; set; }
        public TovarLoad(string role)
        {
            InitializeComponent();
            Role = role;
            if (Role != "Администратор") { button1.Visible = false; button2.Visible = false; }
        }
        public void labelsss()
        {
            lblTovar.Text = $"Категория товара: {Categori} | Наименование товара: {NameTovar}";
            lblOpisanie.Text = $"Описание: {Opisanie}";
            lblPostavshik.Text = $"Поставщик: {Postavshik}";
            lblProiz.Text = $"Производитель: {Proizvoditel}";
            lblPrice.Text = $"Цена: {Price}руб";
            lblEdIzmer.Text = $"Единица измерения: {ED}";
            lblSkidka.Text = $"Действующая скидка: {Skidka}";
            lblCountSklad.Text = $"Количество на складе: {CountSkald}";
            pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "import") + "\\" + Photo;
            if (CountSkald <= 0)
            {
                lblCountSklad.BackColor = Color.Blue;
            }
            if (Skidka <= 0)
            {
                lblNewPrice.Visible = false;
            }
            if (Skidka > 0) { decimal newprice = Price * (100 - Skidka) / 100; lblPrice.Font = new Font("Times New Roman", 10, FontStyle.Regular); lblNewPrice.Text = $"{newprice}руб"; }
            if (Skidka > 15) { lblSkidka.BackColor = Color.SeaGreen; }
        }

        private void lblSkidka_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open();
                string check_tovar = $@"SELECT number_zakaz, articule, count_sklad
	                                    FROM public.zakaz_tovar
                                        WHERE articule = '{Art}'";
                string delete_tovar = $@"DELETE FROM public.tovars
	                                    WHERE articule = '{Art}';";
                using (var command = new NpgsqlCommand(check_tovar,connect))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show("Удалить товар нельзя, он находиться в заказе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                connect.Close();
                connect.Open();
                using (var command = new NpgsqlCommand(delete_tovar, connect))
                {
                    MessageBox.Show("Товар удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                    MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
                    main.LoadTovar();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTovar addTovar = new AddTovar(Art, Photo);
            addTovar.ShowDialog();
        }
    }
}
