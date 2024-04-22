import tkinter as tk
import serial
import time

# Inicializar la conexión serial con Arduino
arduino = serial.Serial('COM3', 9600)  # Ajusta el puerto COM según tu configuración

# Función para encender el LED
def encender_led():
    arduino.write(b'e')  # Enviar 'e' a Arduino para encender el LED

# Función para apagar el LED
def apagar_led():
    arduino.write(b'a')  # Enviar 'a' a Arduino para apagar el LED

# Crear ventana principal
root = tk.Tk()
root.title("Control de LED")

# Crear botones para encender y apagar el LED
button_encender = tk.Button(root, text="Encender LED", command=encender_led)
button_encender.pack(pady=10)

button_apagar = tk.Button(root, text="Apagar LED", command=apagar_led)
button_apagar.pack(pady=10)

# Función para cerrar la conexión serial antes de cerrar la ventana
def cerrar_ventana():
    arduino.close()  # Cerrar la conexión serial
    root.destroy()   # Cerrar la ventana

root.protocol("WM_DELETE_WINDOW", cerrar_ventana)

# Ejecutar la aplicación
root.mainloop()
