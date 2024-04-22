import serial
import time

def iniciar_serial():
    try:
        ser = serial.Serial('COM3', 9600)
        time.sleep(2)
        return ser
    except serial.SerialException as e:
        print(f"Error al abrir el puerto serie: {e}")
        return None

def encender(ser):
    ser.write(b'e')

def apagar(ser):
    ser.write(b'a')

def cerrar(ser):
    ser.write(b'c')
    ser.close()

def led():
    ser = iniciar_serial()
    if ser:
        try:
            while True:
                c = input("selecciona una letra:    ")
                if c == 'e':
                    encender(ser)
                elif c == 'a':
                    apagar(ser)
                elif c == 'c':
                    cerrar(ser)
                    break
                else:
                    print("intenta otra letra:    ")

        except KeyboardInterrupt:
            cerrar(ser)
            print("Puerto serie cerrado")

def distancia():
    ser = iniciar_serial()
    if ser:
        arch = open("hola.txt", "w")
        try:
            while True:
                data = ser.readline().decode('utf-8').strip()
                arch.write(data + "\n")
                print(data)
        except KeyboardInterrupt:
            cerrar(ser)
            print("Puerto serie cerrado")
        arch.close()

if __name__ == "__main__":
    led()





# import serial
# import time
# ser = serial.Serial('COM3',9600)
# time.sleep(2)
# def encendido():
#     ser.write(b'e')
# def apagado():
#     ser.write(b'a')
# def cerrar():
#     ser.write(b'c')

# def led():
#     while True:
#         c = input("selecciona una letra:    ")
#         if (c == 'e'):
#             encendido()
#         elif(c == 'a'):
#             apagado()
#         elif(c == 'c'):
#             break
#         else:
#             print("intenta otra letra:    ")

# def distancia():
#     arch=open("hola.txt","w")
#     try:
#         while True:
#             data = ser.readline().decode('utf-8').strip()
            
#             arch.write(data+"\n")
            
#             print(data)

#     except KeyboardInterrupt:
#         ser.close()
#         print("Puerto serie cerrado")
#     arch.close
