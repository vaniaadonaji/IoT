import serial
import time

# Establece la conexión serial (asegúrate de ajustar el puerto y la velocidad baudios según tu configuración)
puerto_serial = serial.Serial('COM3', 9600, timeout=1)
time.sleep(2)  # Espera a que se establezca la conexión

while True:
    # Solicita al usuario que ingrese el número de servo que desea controlar
    servo_seleccionado = int(input("Ingrese el número del servo que desea mover (0-4): "))

    # Solicita al usuario que ingrese el ángulo deseado
    nuevo_angulo = int(input("Ingrese el ángulo deseado para el servo (0-180): "))

    # Envia el número de servo seleccionado al Arduino
    puerto_serial.write((servo_seleccionado))


    # Envía el nuevo ángulo al Arduino
    puerto_serial.write((nuevo_angulo))


    print("Servo", servo_seleccionado, "movido a", nuevo_angulo, "grados")
