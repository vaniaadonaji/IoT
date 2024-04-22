using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brazo_robotico_Ctrl
{
    // Clase para representar un usuario
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }

    public class SistemaUsuarios
    {
        private List<Usuario> usuarios;

        public SistemaUsuarios()
        {
            // Inicializar usuarios
            usuarios = new List<Usuario> {
            new Usuario { NombreUsuario = "admin1", Contraseña = "123", Rol = "Administrador" },
            new Usuario { NombreUsuario = "admin2", Contraseña = "456", Rol = "Administrador" },
            new Usuario { NombreUsuario = "admin3", Contraseña = "789", Rol = "Administrador" },
            new Usuario { NombreUsuario = "user1", Contraseña = "abc", Rol = "Usuario" },
            new Usuario { NombreUsuario = "user2", Contraseña = "def", Rol = "Usuario" },
            new Usuario { NombreUsuario = "user3", Contraseña = "ghi", Rol = "Usuario" }
        };
        }

        public Usuario AutenticarUsuario(string nombreUsuario, string contraseña)
        {
            // Buscar el usuario en la lista
            return usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contraseña == contraseña);
        }
    }
}
