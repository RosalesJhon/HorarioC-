using System;
using System.Windows.Forms;

namespace TrabajoFinal
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 principal = new Form1();
            principal.Show();
        }
    }
}
