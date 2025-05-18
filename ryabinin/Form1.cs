using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ryabinin
{
    public partial class Form1 : Form
    {
        // создаем объект класса контекста Model1
        Model1 db = new Model1();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // передаем промежуточному объекту данные из модели
            priсelistBindingSource.DataSource = db.Priсelist.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // создаем новый объект формы для добавления данных
            Form2 frm = new Form2();
            // передаем в новую форму объект модели DB
            frm.db = db;
            // показываем форму в диалоговом режиме
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            { // если данные были добавлены к БД, то обновляем содержание
              // промежуточного объекта!
                priсelistBindingSource.DataSource = db.Priсelist.ToList();
            }
        }

        private void priсelistBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // создаем новую объект формы для изменения данных
            Form3 frm = new Form3();
            // Находим объект, который выбрал пользователь (текущий)
            Priсelist rl = (Priсelist)priсelistBindingSource.Current;
            // передаем данные в форму
            frm.db = db;
            frm.rl = rl;
            // Показываем форму в диалоговом режиме
            DialogResult dr = frm.ShowDialog();
            // если измененные данные сохранены в БД, то таблицу обновим
            if (dr == DialogResult.OK)
            {
                priсelistBindingSource.DataSource = db.Priсelist.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // находим объект для записи, которую выбрал пользователь
            Priсelist rl = (Priсelist)priсelistBindingSource.Current;
            // показываем диалоговое окно с кнопками Yes и No
            DialogResult dr = MessageBox.Show(
            " Вы действительно хотите удалить роль -" +rl.ID.ToString(),
" Удаление роли", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // если пользователь нажал кнопку «Да», то удаляем данные из БД
            if (dr == DialogResult.Yes)
            {
                // удаление записи из базы данных
                db.Priсelist.Remove(rl);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                priсelistBindingSource.DataSource = db.Priсelist.ToList();
            }
        }
    }
    }

