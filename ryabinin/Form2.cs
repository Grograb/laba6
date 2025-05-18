using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ryabinin
{
    public partial class Form2 : Form
    {
        // свойство для передачи объекта модели
        public Model1 db { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // проверяем, что все требуемые данные введены
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show(" Нужно ввести все требуемые данные!");
                    return;
                }
                // преобразуем данные из textBox1 (поля ID) в целый тип
                int id;
                bool b = int.TryParse(textBox1.Text, out id);
                if (b == false)
                {
                    MessageBox.Show("Неверный формат ID - " + textBox1.Text);
                    return;
                }
                int price;
                bool a = int.TryParse(textBox4.Text, out price);
                if (a == false)
                {
                    MessageBox.Show("Неверный формат цена - " + textBox4.Text);
                    return;
                }
                // добавление новой записи в таблицу БД
                // создаем новый объект для коллекции Roles
                Priсelist rl = new Priсelist();
                // задаем свойства объекта
                rl.ID = id;
                rl.Name = textBox2.Text;
                rl.Color = textBox3.Text;
                rl.Price = price;
                // добавляем новый объект к коллекции
                db.Priсelist.Add(rl);
                try
                {
                    // сохраняем изменения коллекции в БД
                    db.SaveChanges();
                    // задаем свойство DialogResult, чтобы закрыть форму
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                { // сложная конструкция для показа сообщений сервера БД
                    MessageBox.Show(ex.InnerException.InnerException.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

