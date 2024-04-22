using System;
using System.Windows.Forms;

namespace Brazo_robotico_Ctrl
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string puerto = txtPuerto.Text;
            string inicio = txtInicio.Text;
            string fin = txtFin.Text;

            if (esNumero(inicio) && esNumero(fin))
            {
                Form1 form1 = new Form1(puerto, int.Parse(inicio), int.Parse(fin));
                form1.Show();
            }
        }

        public bool esNumero(string cadena)
        {
            return int.TryParse(cadena, out _);
        }
    }
}
