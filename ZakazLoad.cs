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
    
    public partial class ZakazLoad : UserControl
    {
        string connectDB = "Host=db.edu.cchgeu.ru;Port=5432;Username=postgres;Password=postgres;Database=demochkaLove";
        public DateTime DataZakaza {  get; set; }
        public DateTime DataDostavki { get; set; }
        public int Code {  get; set; }
        public string FIO { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public int NumberZakaz {  get; set; }
        
        public ZakazLoad()
        {
            InitializeComponent();
        }
        public void labelsss()
        {
            lblNumberZakaz.Text = $"Номер заказа: {NumberZakaz}";
            lbladress.Text = $"Адрес пункта выдачи: {Adress}";
            lblcodepolych.Text = $"Код получения: {Code}";
            lblUsers.Text = $"ФИО пользователя: {FIO}";
            lbldatazakaz.Text = $"Дата заказа: {DataZakaza:dd-MM-yyyy}";
            lbldatadostav.Text = $"Дата доставки: {DataDostavki:dd-MM-yyyy}";
            lblstatus.Text = $"Статус заказа: {Status}";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connect = new NpgsqlConnection(connectDB))
            {
                connect.Open();
               
                string delete_tovar = $@"DELETE FROM public.zakaz
	                                        WHERE number_zakaz = {NumberZakaz};";

                using (var command = new NpgsqlCommand(delete_tovar, connect))
                {
                    MessageBox.Show("Заказ удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                    MainOkno main = (MainOkno)Application.OpenForms["MainOkno"];
                    main.LoadZakaz();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddZakaz add = new AddZakaz(NumberZakaz);
            add.ShowDialog();
        }
    }
}
