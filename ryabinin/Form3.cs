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
    public partial class Form3 : Form
    {
        // свойство для передачи объекта модели
        public Model1 db { get; set; }
        // свойство для передачи объекта корректируемой записи
        public Priсelist rl { get; set; }
        // private поле в классе, доступно во всех методах

        public Form3()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;   // Запрет редактирования RoleID
            button1.Text = "Сохранить"; // Настройка кнопок
            button2.Text = "Выйти";
            button2.DialogResult = DialogResult.Cancel;

        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // сохраняем введенное пользователем значение в свойство объекта
            rl.Name = textBox2.Text;
            // если бы свойств было бы больше, то они сохранялись здесь ...
            // теперь пытаемся сохранить измененный объект в БД
            try
            {
                // сохраняем изменения, сделанные в объектах коллекции в БД
                db.SaveChanges();
                // задаем свойство DialogResult, чтобы закрыть форму
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            { // если произошла ошибка - сообщаем
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}
