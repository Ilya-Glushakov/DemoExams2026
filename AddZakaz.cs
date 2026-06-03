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
            string select_zakaz = $@"SELECT number_zakaz, data_zakaza, data_dostavki, adress, fio_users, code_polych, status
	                                        FROM public.zakaz 
                                            WHERE number_zakaz = {NomerZakaza}";
            var commad = new NpgsqlCommand(select_zakaz, connect);
            var reader = commad.ExecuteReader();
            if (reader.Read())
            {
                cmbStatus.SelectedIndex = reader.GetInt32(6) - 1;
                cmdFIO.SelectedIndex = reader.GetInt32(4) - 1;
                cmbAdres.SelectedIndex = reader.GetInt32(3);
                dateTimePicker1.Value = reader.GetDateTime(1);
                dateTimePicker2.Value = reader.GetDateTime(2);
            }
            connect.Close();
            connect.Open();
            string select_zakaz_tovar = $@"SELECT number_zakaz, articule, count_sklad
	                                        FROM public.zakaz_tovar
                                            WHERE number_zakaz = {NomerZakaza}";
            var cmd1 = new NpgsqlCommand(select_zakaz_tovar, connect);
            var reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                Count++;
                numericUpDown1.Value = reader1.GetInt32(2);
                listBox1.Items.Add(reader1.GetString(1) + " " + reader1.GetInt32(2).ToString());
            }
        }
        public void UpdateZakaz()
        {
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string add_zakaz = $@"UPDATE public.zakaz
	SET data_zakaza=@dt, data_dostavki=@dz, adress=@ad, fio_users=@fi,status=@st
	WHERE number_zakaz = {NomerZakaza};";
            var command = new NpgsqlCommand(add_zakaz, connect);
            command.Parameters.AddWithValue("@dt", dateTimePicker1.Value);
            command.Parameters.AddWithValue("@dz", dateTimePicker2.Value);
            command.Parameters.AddWithValue("@ad", cmbAdres.SelectedIndex + 1);
            command.Parameters.AddWithValue("@fi", cmdFIO.SelectedIndex + 1);
            command.Parameters.AddWithValue("@st", cmbStatus.SelectedIndex + 1);
            command.ExecuteNonQuery();
            connect.Close();
            connect.Open();
            string inzert_zakaz_tovar = $@"UPDATE public.zakaz_tovar
	                                    SET articule=@art, count_sklad=@count
	                                    WHERE number_zakaz= {NomerZakaza}";
            var cmd = new NpgsqlCommand(inzert_zakaz_tovar, connect);
            for (int i = Count; i < listBox1.Items.Count; i++)
            {
                cmd.Parameters.AddWithValue("@num", NomerZakaza);
                cmd.Parameters.AddWithValue("@art", listBox1.Items[i].ToString().Split(' ')[0]);
                cmd.Parameters.AddWithValue("@count", Convert.ToInt32(listBox1.Items[i].ToString().Split(' ')[1]));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Заказ успешно обновлен.");
            MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
            main.LoadZakaz();
            this.Close();
        }
        public void AddZakaz1()
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Пожалуйста, добавьте товары в заказ.");
                return;
            }
            else if (dateTimePicker1.Value < DateTime.Now || dateTimePicker2.Value < DateTime.Now)
            {
                MessageBox.Show("Пожалуйста, выберите корректные даты.");
                return;
            }
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string add_zakaz = $@"INSERT INTO public.zakaz(
	                                data_zakaza, data_dostavki, adress, fio_users, status)
	                                VALUES (@dt, @dz, @ad, @fi, @st);";
            var command = new NpgsqlCommand(add_zakaz, connect);
            command.Parameters.AddWithValue("@dt",dateTimePicker1.Value);
            command.Parameters.AddWithValue("@dz", dateTimePicker2.Value);
            command.Parameters.AddWithValue("@ad", cmbAdres.SelectedIndex + 1);
            command.Parameters.AddWithValue("@fi", cmdFIO.SelectedIndex + 1);
            command.Parameters.AddWithValue("@st", cmbStatus.SelectedIndex + 1);
            command.ExecuteNonQuery();
            connect.Close();
            connect.Open();
            string inzert_zakaz_tovar = $@"INSERT INTO public.zakaz_tovar(
	                                        number_zakaz, articule, count_sklad)
	                                        VALUES (@num, @art, @count);";
            var cmd = new NpgsqlCommand(inzert_zakaz_tovar, connect);
            foreach (var item in listBox1.Items)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@num", NomerZakaza);
                cmd.Parameters.AddWithValue("@art", item.ToString().Split(' ')[0]);
                cmd.Parameters.AddWithValue("@count", Convert.ToInt32(item.ToString().Split(' ')[1]));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Заказ успешно добавлен.");
            MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
            main.LoadZakaz();
            this.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbArt.Text == null && numericUpDown1.Value == 0)
            {
                MessageBox.Show("Пожалуйста, выберите товар и количество.");
                return;
            }
            foreach (var item in listBox1.Items)
            {
                if (item.ToString().Split(' ')[0] == cmbArt.Text)
                {
                    MessageBox.Show("Артикул уже добавлен в заказ.");
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
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.");
                return;
            }
            var connect = new NpgsqlConnection(connectDB);
            connect.Open();
            string delete_zakaz_tovar = $@"DELETE FROM public.zakaz_tovar
                                            WHERE number_zakaz = {NomerZakaza} AND articule = '{listBox1.SelectedItem.ToString().Split(' ')[0]}'";
            var command = new NpgsqlCommand(delete_zakaz_tovar, connect);
            command.ExecuteNonQuery();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            connect.Close();
        }
    }
}
