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
using static System.Net.WebRequestMethods;

namespace demoExamsGlushakovIlya
{
    public partial class AddTovar : Form
    {
        string connectDB = "Host=localhost;Port=5432;Username=postgres;Password=Glushak228;Database=demochkaLove";
        public string Photo {  get; set; }
        public string Art {  get; set; }
        public AddTovar(string art, string photo)
        {
            InitializeComponent();
            Photo = photo;
            Art = art;
            btnAddTovar.Visible = false;
            LoadTovar();


        }
        public AddTovar()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
        }
        public void LoadTovar()
        {
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open();
                string tovars = $@"SELECT articule,name_tovar, ed_izmer, price, postavshik_, proizvoditel_, category, skidka, count_sklad, opisanie, picture
	                                FROM public.tovars";

                using (var command = new NpgsqlCommand(tovars, connect))
                {


                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtArt.Text = reader.GetString(0);
                            txtArt.ReadOnly = true;
                            cmbNameTovar.SelectedIndex = reader.GetInt32(1) - 1;
                            numericUpDown1.Value = reader.GetInt32(3);
                            cmbPostav.SelectedIndex = reader.GetInt32(4) - 1;
                            cmbProiz.SelectedIndex = reader.GetInt32(5) - 1;
                            cmbCat.SelectedIndex = reader.GetInt32(6) - 1;
                            numericUpDown2.Value = reader.GetInt32(7);
                            numericUpDown3.Value = reader.GetInt32(8);
                            textBox1.Text = reader.GetString(9);
                            pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "import", Photo);

                        }
                    }
                }
            }
        }
        public void UpdateTovar()
        {
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open();
                string update = $@"UPDATE public.tovars
                                    SET name_tovar =@na , price = @price, postavshik_ = @po, 
                                    proizvoditel_ = @pr, category =@c, skidka = @skidka, count_sklad = @count, opisanie = @opis, picture = @photo
                                    WHERE articule = @art";
                var command = new NpgsqlCommand(update, connect);
                command.Parameters.AddWithValue("@art", Art);
                command.Parameters.AddWithValue("@na", cmbNameTovar.SelectedIndex + 1);
                command.Parameters.AddWithValue("@price", numericUpDown1.Value);
                command.Parameters.AddWithValue("@po", cmbPostav.SelectedIndex + 1);
                command.Parameters.AddWithValue("@pr", cmbProiz.SelectedIndex + 1);
                command.Parameters.AddWithValue("@c", cmbCat.SelectedIndex + 1);
                command.Parameters.AddWithValue("@skidka", numericUpDown2.Value);
                command.Parameters.AddWithValue("@count", numericUpDown3.Value);
                command.Parameters.AddWithValue("@opis", textBox1.Text);
                command.Parameters.AddWithValue("@photo", Photo);
                MessageBox.Show("Товар обновлен!", "Успех,", MessageBoxButtons.OK, MessageBoxIcon.Information);
                command.ExecuteNonQuery();
                this.Hide();
                MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
                main.LoadTovar();
                this.Close();
            }
        }
        public void AddTovars()
        {
            foreach(Control control in this.Controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (control is ComboBox comboBox && comboBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите значение для всех полей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                using (var connect = new NpgsqlConnection(connectDB))
                {
                    connect.Open();
                    string insert = $@"INSERT INTO public.tovars(
	            articule, name_tovar, ed_izmer, price, postavshik_, proizvoditel_, category, skidka, count_sklad, opisanie, picture)
	            VALUES (@art, (SELECT name_tovar_id from name_tovar WHERE tovar_names = @name), @ed, @price, (SELECT postav_id from postavshik WHERE postav_names = @postav), 
                (SELECT proiz_id from proizvoditel WHERE proiz_names = @proiz), (SELECT categori_id from categori_tovar WHERE categori_name = @cat), @skidka, @count, @opis, @photo);";
                    using (var command = new NpgsqlCommand(insert, connect))
                    {
                        command.Parameters.AddWithValue("@art", textBox1.Text);
                        command.Parameters.AddWithValue("@name", cmbNameTovar.SelectedItem);
                        command.Parameters.AddWithValue("@ed", "шт");
                        command.Parameters.AddWithValue("@price", (int)numericUpDown1.Value);
                        command.Parameters.AddWithValue("@postav", cmbPostav.SelectedItem);
                        command.Parameters.AddWithValue("@proiz", cmbProiz.SelectedItem);
                        command.Parameters.AddWithValue("@cat", cmbCat.SelectedItem);
                        command.Parameters.AddWithValue("@skidka", (int)numericUpDown2.Value);
                        command.Parameters.AddWithValue("@count", (int)numericUpDown3.Value);
                        command.Parameters.AddWithValue("@opis", textBox1.Text);
                        command.Parameters.AddWithValue("@photo", string.IsNullOrEmpty(Photo) ? (object)DBNull.Value : Photo);
                        command.ExecuteNonQuery();
                        
                        MessageBox.Show("Товар добавлен!");
                        this.Hide();
                        MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
                        main.LoadTovar();
                        this.Close();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
        private void AddTovar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images *.jpg|";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.Combine(Application.StartupPath, "import");
                System.IO.File.Copy(path, ofd.FileName, true);
                pictureBox1.Image = Image.FromFile(path);
                Photo = ofd.SafeFileName;
                MessageBox.Show("Фото добавлено!", "Успех", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
            main.ShowDialog();
            this.Close();
        }

        private void btnAddTovar_Click(object sender, EventArgs e)
        {
            AddTovars();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateTovar();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
