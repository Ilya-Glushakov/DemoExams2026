using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoExamsGlushakovIlya
{
    public partial class AddZakaz : Form
    {
        string connectDB = "Host=localhost;Port=5432;Username=postgres;Password=Glushak228;Database=demochkaLove";
        public int NomerZakaza { get; set; }
        public int Count { get; set; }
        public AddZakaz(int nomer)
        {
            InitializeComponent();
            NomerZakaza = nomer;
            LoadZakaz();
            btnAddTovar.Visible = false;
        }
        public AddZakaz()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
        }
        
        /*
         *  Снизу описаны методы для загрузки и обновления заказа
         */
        public void LoadZakaz()
        {
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string zakaz = $@"SELECT number_zakaz, data_zakaza, data_dostavki, adress, fio_users, status
	                            FROM public.zakaz
                                WHERE number_zakaz = {NomerZakaza}";
            var cmd = new NpgsqlCommand(zakaz,connect);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dateTimePicker1.Value = reader.GetDateTime(1);
                dateTimePicker2.Value = reader.GetDateTime(2);
                cmbAdres.SelectedIndex = reader.GetInt32(3) - 1;
                cmdFIO.SelectedIndex = reader.GetInt32(4) - 1;
                cmbStatus.SelectedIndex = reader.GetInt32(5) - 1;
            }
            connect.Close();
            connect.Open();
            string zakaz_tovar = $@"SELECT articule, count_sklad
	                                FROM public.zakaz_tovar
                                    WHERE number_zakaz = {NomerZakaza}";
            var cmd2 = new NpgsqlCommand(zakaz_tovar, connect);
            var reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Count++;
                listBox1.Items.Add(reader2.GetString(0) + " " + reader2.GetInt32(1).ToString());
            }
        }
        public void UpdateZakaz()
        {
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string zakaz = $@"UPDATE public.zakaz
	                            SET data_zakaza = @dt, data_dostavki = @dd, adress = @ad, fio_users = @f,status = @st
                                WHERE number_zakaz = {NomerZakaza}";
            var cmd = new NpgsqlCommand(zakaz, connect);

            cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@dd", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@ad", cmbAdres.SelectedIndex +1);
            cmd.Parameters.AddWithValue("@f", cmdFIO.SelectedIndex +1);
            cmd.Parameters.AddWithValue("@st", cmbStatus.SelectedIndex +1);
            cmd.ExecuteNonQuery();
            connect.Close();
            connect.Open();
            string zakaz_tovar = $@"INSERT INTO public.zakaz_tovar
	                                (number_zakaz,articule, count_sklad)
                                VALUES (@num,@art, @count)";
            var cmd2 = new NpgsqlCommand(zakaz_tovar, connect);
            if (Count < listBox1.Items.Count)
            {
                for (int i = Count; i < listBox1.Items.Count; i++)
                {
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@num", NomerZakaza);
                    cmd2.Parameters.AddWithValue("@art", listBox1.Items[i].ToString().Split(' ')[0]);
                    cmd2.Parameters.AddWithValue("@count", Convert.ToInt32(listBox1.Items[i].ToString().Split(' ')[1]));
                    cmd2.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Заказ обновлен");
            MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
            main.LoadZakaz();
            this.Close();
        }
        public void AddZakaz1()
        {
            if (cmbAdres.Text == null||cmbAdres.Text == null||
                cmbStatus.Text == null||cmdFIO.Text == null|| listBox1.Items.Count == 0)
            {
                MessageBox.Show("У вас пустые поля, нужно заполнить все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker1.Value < DateTime.Now || dateTimePicker2.Value < DateTime.Now)
            {
                MessageBox.Show("Дата заказа не может быть в прошлом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string zakaz = $@"INSERT INTO public.zakaz(
	data_zakaza, data_dostavki, adress, fio_users,status)
	VALUES (@dt, @dd, @ad, @f, @st)
RETURNING number_zakaz";
            
            var cmd = new NpgsqlCommand(zakaz, connect);
            cmd.Parameters.AddWithValue("@dt", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@dd", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@ad", cmbAdres.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@f", cmdFIO.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@st", cmbStatus.SelectedIndex + 1);
            int orderId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();

            string zakaz_tovar = $@"INSERT INTO public.zakaz_tovar
                                    (number_zakaz,articule, count_sklad)
                                VALUES (@num,@art, @count)";
            var cmd2 = new NpgsqlCommand(zakaz_tovar, connect);
            foreach (var item in listBox1.Items)
            {
                cmd2.Parameters.AddWithValue("@num", orderId);
                cmd2.Parameters.AddWithValue("@art", item.ToString().Split(' ')[0]);
                cmd2.Parameters.AddWithValue("@count", Convert.ToInt32(item.ToString().Split(' ')[1]));
                cmd2.ExecuteNonQuery();
            }
            MessageBox.Show("Заказ добавлен");
            MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
            main.LoadZakaz();
            connect.Close();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbArt.Text == null
                && numericUpDown1.Value > 0)
            {
                MessageBox.Show("Выберите товар и количество");
                return;
            }

            foreach (var item in listBox1.Items)
            {
                if (item.ToString().Split(' ')[0] == cmbArt.Text)
                {
                    MessageBox.Show("Артикул уже добавлен");
                    return;
                }
            }
            listBox1.Items.Add(cmbArt.Text + " " + numericUpDown1.Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateZakaz();
        }

        private void btnAddTovar_Click(object sender, EventArgs e)
        {
            AddZakaz1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedIndex;
            if (selectedItem <0)
            {
                MessageBox.Show("Выберите артикул, который хотите удалить!");
                return;
            }
            var item = listBox1.SelectedItems.ToString().Split(' ')[0];
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string zakaz = $@"DELETE FROM public.zakaz_tovar WHERE number_zakaz = {NomerZakaza} AND articule = @art";
            var cmd = new NpgsqlCommand(zakaz, connect);
            cmd.Parameters.AddWithValue("@art", item);
            cmd.ExecuteNonQuery();
            listBox1.Items.RemoveAt(selectedItem);
            connect.Close();
        }
    }
}
