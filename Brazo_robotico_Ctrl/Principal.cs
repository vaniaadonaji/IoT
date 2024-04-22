using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brazo_robotico_Ctrl
{
    public partial class Principal : Form
    {
        Form1 form1 = null;
        Configuracion configuracion = null;
        public Principal()
        {
            InitializeComponent();
            form1 = new Form1();
            configuracion = new Configuracion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            configuracion.Visible = true;
        }
    }
}
