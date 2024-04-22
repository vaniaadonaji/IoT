using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Brazo_robotico_Ctrl
{
    public partial class FormBluetooth : Form
    {
        private SerialPort bluetoothPort;

        public FormBluetooth()
        {
            InitializeComponent();
            InicializarBluetooth();
        }

        private void InicializarBluetooth()
        {
            bluetoothPort = new SerialPort();
            bluetoothPort.PortName = "COM3"; // Elige el puerto COM correcto donde está conectado tu módulo Bluetooth
            bluetoothPort.BaudRate = 9600;

            try
            {
                bluetoothPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto Bluetooth: " + ex.Message);
            }
        }

        private void EnviarDatosBluetooth(string datos)
        {
            if (bluetoothPort.IsOpen)
            {
                bluetoothPort.Write(datos);
            }
        }

        private void MoverServo(int posicion)
        {
            string comando = $"1,{posicion}"; // Envía el comando al servo 1
            EnviarDatosBluetooth(comando);
        }

        private void joystickControl_MovimientoCambiado(object sender, EventArgs e)
        {
            // Maneja el evento cuando el joystick se mueve
            // Obtén las posiciones X e Y del control de joystick (o simula su lectura)
            int posX = ObtenerPosicionXDelJoystick();
            int posY = ObtenerPosicionYDelJoystick();

            // Calcula la posición del servo a partir de las posiciones X e Y del joystick (o cualquier otra lógica deseada)
            int posicionServo = ConvertirPosicionJoystickAServos(posX, posY);

            // Mueve el servo
            MoverServo(posicionServo);
        }

        // Método simulado para obtener la posición X del joystick
        private int ObtenerPosicionXDelJoystick()
        {
            // Simulación de la posición X del joystick
            return 90; // Posición central
        }

        // Método simulado para obtener la posición Y del joystick
        private int ObtenerPosicionYDelJoystick()
        {
            // Simulación de la posición Y del joystick
            return 90; // Posición central
        }

        // Método simulado para convertir la posición del joystick a la posición del servo
        private int ConvertirPosicionJoystickAServos(int posX, int posY)
        {
            // Aquí puedes implementar la lógica para convertir las posiciones X e Y del joystick en la posición deseada del servo
            // Por simplicidad, aquí solo se retorna una posición fija
            return 90; // Posición central
        }

        // Asegúrate de cerrar el puerto Bluetooth cuando se cierre el formulario
        private void FormularioControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bluetoothPort != null && bluetoothPort.IsOpen)
            {
                bluetoothPort.Close();
            }
        }
    }
}