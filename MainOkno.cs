using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoExamsGlushakovIlya
{
  
    public partial class MainOkno : Form
    {
        string connectDB = "Host=localhost;Port=5432;Username=postgres;Password=Glushak228;Database=demochkaLove";
        public string FIO { get; set; }
        public string Rolename { get; set; }
        public string sort = "ASC";
        public string filter = null;
        public MainOkno(string fio, string role)
        {
            InitializeComponent();
            FIO = fio;
            Rolename = role;
            LoadTovar();
            lblUsers.Text = fio;
            textBox1.TextChanged += (s, e) => LoadTovar();
            if (Rolename == "Менеджер")
            {
                btnAddTovar.Visible = false;
                btnAddZakaz.Visible = false;
            }
            else if (Rolename == "Авторизованный клиент" || Rolename == "")
            {
                btnAddTovar.Visible = false;
                btnAddZakaz.Visible = false;
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                comboBox1.Visible = false;
                label3.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                button1.Visible = false;
                button3.Visible = false;
            }
        }
        public void LoadZakaz()
        {
            lblTovar.Text = "Заказы: ";
            flowLayoutPanel1.Controls.Clear();
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open();
                string tovars = $@"SELECT number_zakaz, data_zakaza, data_dostavki, pvz.pvz_adress, users.fio, code_polych, status.status_name
	                                FROM public.zakaz
	                                JOIN public.pvz ON pvz.pvz_id = zakaz.adress
	                                JOIN public.status ON status.status_id = zakaz.status
	                                JOIN public.users ON users.user_id = zakaz.fio_users";

                using (var command = new NpgsqlCommand(tovars, connect))
                {
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ZakazLoad zakazLoad = new ZakazLoad();
                            zakazLoad.NumberZakaz = reader.GetInt32(0);
                            zakazLoad.DataDostavki = reader.GetDateTime(2);
                            zakazLoad.DataZakaza = reader.GetDateTime(1);
                            zakazLoad.Code = reader.GetInt32(5);
                            zakazLoad.FIO = reader.GetString(4);
                            zakazLoad.Adress  = reader.GetString(3);
                            zakazLoad.Status = reader.GetString(6);
                            zakazLoad.labelsss();
                            zakazLoad.ComboBox();
                            flowLayoutPanel1.Controls.Add(zakazLoad);
                        }
                    }
                }
            }
        }
        public void LoadTovar()
        {
            lblTovar.Text = "Товары: ";
            flowLayoutPanel1.Controls.Clear();
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open();
                string tovars = $@"SELECT articule,name_tovar.tovar_names, ed_izmer, price, postavshik.postav_names, proizvoditel.proiz_names, categori_tovar.categori_name, skidka, count_sklad, opisanie, picture
	                                FROM public.tovars
	                                JOIN public.categori_tovar ON categori_tovar.categori_id = tovars.category
	                                JOIN public.name_tovar ON name_tovar.name_tovar_id = tovars.name_tovar
	                                JOIN public.postavshik ON postavshik.postav_id = tovars.postavshik_
	                                JOIN public.proizvoditel ON proizvoditel.proiz_id = tovars.proizvoditel_
                                    WHERE (name_tovar.tovar_names ILIKE '%{textBox1.Text}%' OR ed_izmer ILIKE '%{textBox1.Text}%' OR postavshik.postav_names ILIKE '%{textBox1.Text}%' OR  proizvoditel.proiz_names ILIKE '%{textBox1.Text}%' OR categori_tovar.categori_name ILIKE '%{textBox1.Text}%' OR opisanie ILIKE'%{textBox1.Text}%')
                                    AND ('%{filter}%' IS NULL OR postavshik.postav_names ILIKE '%{filter}%') ORDER BY count_sklad {sort}";
                                    
                using (var command = new NpgsqlCommand(tovars,connect))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TovarLoad tovar = new TovarLoad(Rolename);
                            tovar.Art = reader.GetString(0);
                            tovar.NameTovar = reader.GetString(1);
                            tovar.ED = reader.GetString(2);
                            tovar.Price = reader.GetDecimal(3);
                            tovar.Postavshik = reader.GetString(4);
                            tovar.Proizvoditel = reader.GetString(5);
                            tovar.Categori = reader.GetString(6);
                            tovar.Skidka = reader.GetInt32(7);
                            tovar.CountSkald = reader.GetInt32(8);
                            tovar.Opisanie = reader.GetString(9);
                            tovar.Photo = reader.IsDBNull(10)? "picture.png" :reader.GetString(10);
                            tovar.labelsss();
                            flowLayoutPanel1.Controls.Add(tovar);
                        }
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Все поставщики")
            {
                LoadTovar();
            }
            else if (comboBox1.SelectedItem.ToString() == "Kari")
            {
                filter = "Kari";
                LoadTovar();
            }
            else if (comboBox1.SelectedItem.ToString() == "Обувь для вас")
            {
                filter = "Обувь для вас";
                LoadTovar();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadTovar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sort = "ASC";
            LoadTovar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sort = "DESC";
            LoadTovar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization auth = new Authorization();
            auth.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddTovar add = new AddTovar();
            add.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadZakaz();
        }
        private void btnAddZakaz_Click(object sender, EventArgs e)
        {
            AddZakaz addZakaz = new AddZakaz();
            addZakaz.ShowDialog();
        }
    }
}
