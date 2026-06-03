using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string tovars = $@"SELECT articule, name_tovar, ed_izmer, price, postavshik_, proizvoditel_, category, skidka, count_sklad, opisanie, picture
	                            FROM public.tovars
                                WHERE articule = '{Art}'";
            var cmd = new NpgsqlCommand(tovars, connect);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtArt.Text = reader.GetString(0);
                cmbNameTovar.SelectedIndex = reader.GetInt32(1) - 1;
                cmbCat.SelectedIndex = reader.GetInt32(6) - 1;
                cmbPostav.SelectedIndex = reader.GetInt32(4)- 1;
                cmbProiz.SelectedIndex = reader.GetInt32(5) - 1;
                numericUpDown1.Value = reader.GetInt32(3);
                numericUpDown2.Value = reader.GetInt32(7);
                numericUpDown3.Value = reader.GetInt32(8);
                textBox1.Text = reader.GetString(9);
                pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "import") + "\\" + Photo;
            }
        }
        public void UpdateTovar()
        {
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string update_script = $@"UPDATE public.tovars
	                                SET name_tovar=@n,price=@pr, postavshik_=@po, proizvoditel_=@pro, category=@c, skidka=@s, 
                                    count_sklad=@count, opisanie=@opis, picture=@png
	                                WHERE articule = '{Art}';";
            var cmd = new NpgsqlCommand(update_script,connect);
            cmd.Parameters.AddWithValue("@n",cmbNameTovar.SelectedIndex +1);
            cmd.Parameters.AddWithValue("@pr",numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@po",cmbPostav.SelectedIndex +1);
            cmd.Parameters.AddWithValue("@pro",cmbProiz.SelectedIndex +1);
            cmd.Parameters.AddWithValue("@c",cmbCat.SelectedIndex +1);
            cmd.Parameters.AddWithValue("@s",numericUpDown2.Value);
            cmd.Parameters.AddWithValue("@count",numericUpDown3.Value);
            cmd.Parameters.AddWithValue("@opis",textBox1.Text);
            cmd.Parameters.AddWithValue("@png",Photo);
            cmd.ExecuteNonQuery();
            this.Hide();
            MessageBox.Show("Товар успешно обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MainOkno mainOkno = (MainOkno)Application.OpenForms["MainOkno"];
            mainOkno.LoadTovar();
            this.Close();

        }
        public void AddTovars()
        {
            try
            {
                var connect = new NpgsqlConnection(connectDB);
                connect.Open();
                string update_script = $@"INSERT INTO public.tovars(
	articule, name_tovar, ed_izmer, price, postavshik_, proizvoditel_, category, skidka, count_sklad, opisanie, picture)
	VALUES (@art, @n, @ed, @pr, @po, @pro, @c, @s, @count, @opis, @png);";
                var cmd = new NpgsqlCommand(update_script, connect);
                cmd.Parameters.AddWithValue("@art", txtArt.Text);
                cmd.Parameters.AddWithValue("@n", cmbNameTovar.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@pr", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@ed", "шт");
                cmd.Parameters.AddWithValue("@po", cmbPostav.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@pro", cmbProiz.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@c", cmbCat.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@s", numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@count", numericUpDown3.Value);
                cmd.Parameters.AddWithValue("@opis", textBox1.Text);
                cmd.Parameters.AddWithValue("@png", string.IsNullOrEmpty(Photo) ? "picture.png" : Photo);
                cmd.ExecuteNonQuery();
                this.Hide();
                MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainOkno mainOkno = (MainOkno)Application.OpenForms["MainOkno"];
                mainOkno.LoadTovar();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении товара: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }
        private void AddTovar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog png = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png" };
            if (png.ShowDialog() == DialogResult.OK)
            {
                var path = Path.Combine(Application.StartupPath, "import", png.SafeFileName);
                System.IO.File.Copy(png.FileName,path,true);
                pictureBox1.Image = Image.FromFile(path);
                Photo = png.SafeFileName;
                MessageBox.Show("Картинка успешно добалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
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
