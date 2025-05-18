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
    }
}
