using System;
using System.Windows.Forms;

namespace Brazo_robotico_Ctrl
{
    public partial class Login : Form
    {
        private bool usuarioHaIniciadoSesion = false;

        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string contraseña = txtPassword.Text;

            SistemaUsuarios sistemaUsuarios = new SistemaUsuarios();
            Usuario usuario = sistemaUsuarios.AutenticarUsuario(nombreUsuario, contraseña);

            if (usuario != null)
            {
                if (usuario.Rol == "Administrador")
                {
                    Principal formAdmin = new Principal();
                    formAdmin.Show();
                }
                else
                {
                    Form1 formUsuario = new Form1();
                    formUsuario.Show();
                }
                usuarioHaIniciadoSesion = true;
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!usuarioHaIniciadoSesion)
            {
                e.Cancel = true; 
            }
        }
    }
}
