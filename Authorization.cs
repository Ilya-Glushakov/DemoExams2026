using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using demoExamsGlushakovIlya.Properties;
namespace demoExamsGlushakovIlya
{
    public partial class Authorization : Form
    {
        string connectDB = "Host=localhost;Port=5432;Username=postgres;Password=Glushak228;Database=demochkaLove";
        public Authorization()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { textBox2.UseSystemPasswordChar = false; }
            else { textBox2.UseSystemPasswordChar = true; }
        }
        public void Aut() // метод для автоизации пользователя 
        {
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open(); 
                string select_user = $@"SELECT roles.names_role, fio
	                                    FROM public.users
	                                    JOIN public.roles ON roles.role_id = users.role_user
	                                    WHERE logins = '{textBox1.Text}' AND passwords = '{textBox2.Text}'";
                using (var command = new NpgsqlCommand(select_user,connect))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            MessageBox.Show("Авторизация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            MainOkno main = new MainOkno(reader.GetString(1),reader.GetString(0));
                            main.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль. Возможно у вас пустые поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Aut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainOkno main = new MainOkno("Гость", "");
            main.ShowDialog();
            this.Close();
        }
    }
}
