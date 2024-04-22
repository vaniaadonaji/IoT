using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; 



namespace Brazo_robotico_Ctrl
{
    public partial class Form1 : Form
    {
        SerialPort port; // Objeto para comunicación serial
        Configuracion configuracion;
        int inicio = 0;
        int fin = 180;


        public Form1(string puerto, int inicio, int fin)
        {
            InitializeComponent();
            this.inicio = inicio;
            this.fin = fin;
            configuracion = new Configuracion();
            Init(puerto);
        }
        public Form1()
        {
            InitializeComponent();
            configuracion = new Configuracion();
            Init();
        }
        // Método para configurar la comunicacion serial
        private void Init()
        {
            port = new SerialPort(); // Crea un nuevo objeto SerialPort
            port.PortName = "COM3"; // Asigna el nombre del puerto COM
            port.BaudRate = 9600; // Asigna la velocidad de baudios

            try // Intenta abrir el puerto serial
            {
                port.Open(); // Abre el puerto serial
            }
            catch (Exception e1) // Captura cualquier excepción
            {
                MessageBox.Show(e1.Message); // Muestra un mensaje de error en caso de excepción
            }
        }
        private void Init(string puerto)
        {
            port = new SerialPort(); 
            port.PortName = puerto; 
            port.BaudRate = 9600;

            try // Intenta abrir el puerto serial
            {
                port.Open(); // Abre el puerto serial
            }
            catch (Exception e1) // Captura cualquier excepción
            {
                MessageBox.Show(e1.Message); // Muestra un mensaje de error en caso de excepción
            }
        }
        // Método para enviar datos al servo SendData
        private void SendData(int servoIndex, int value) 
        {
        //    if (port == null || !port.IsOpen) // Verifica si el puerto serial está cerrado
        //    {
        //        Init(); // Si el puerto está cerrado llama al metodo de inicializacion 
        //    }

            if (port.IsOpen) 
            {
                string message = $"{servoIndex},{value},{inicio},{fin}";
                port.WriteLine(message);

                // Actualiza el texto de los Labels según el índice del servo
                switch (servoIndex)
                {
                    case 1: // Para el servo 1
                        lblGradosParaServo1.Text = $"Servo 1: {value} grados"; 
                        break;
                    case 2: // Para el servo 2
                        lblGradosParaServo2.Text = $"Servo 2: {value} grados";
                        break;
                    case 3: // Para el servo 3
                        lblGradosParaServo3.Text = $"Servo 3: {value} grados";
                        break;
                    case 4: // Para el servo 4
                        lblGradosParaServo4.Text = $"Servo 4: {value} grados"; 
                        break;
                    case 5: // Para el servo 5
                        lblGradosParaServo5.Text = $"Servo 5: {value} grados";
                        break;
                    default:
                        break;
                }
            }
        }

        // Asegúrate de cerrar el puerto serial cuando se cierre el formulario
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
            }
        }


        private void btnEnviarDatosServo1_Click(object sender, EventArgs e)
        {
            // Si el campo de texto "txtDatosServo1" NO está vacío entonces:
            if (!string.IsNullOrEmpty(txtDatosServo1.Text)) 
            {
                int value = int.Parse(txtDatosServo1.Text); // Convierte el texto del campo "txtDatosServo1" a un entero y lo asigna a la variable "value"
                SendData(1, value); // Llama al método "SendData" para enviar los datos al servo 1 con el valor obtenido del campo de texto
            }
        }

        private void btnEnviarDatosServo2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDatosServo2.Text))
            {
                int value = int.Parse(txtDatosServo2.Text);
                SendData(2, value);
            }
        }

        private void btnEnviarDatosServo3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDatosServo3.Text))
            {
                int value = int.Parse(txtDatosServo3.Text);
                SendData(3, value);
            }
        }

        private void btnEnviarDatosServo4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDatosServo4.Text))
            {
                int value = int.Parse(txtDatosServo4.Text);
                SendData(4, value);
            }
        }

        private void btnEnviarDatosServo5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDatosServo5.Text))
            {
                int value = int.Parse(txtDatosServo5.Text);
                SendData(5, value);
            }
        }

    }
}
