import serial
import time
ser = serial.Serial("COM3",9600)
time.sleep(2)
def distancia():
    arch=open("hola.txt","w")
    try:
        while True:
            data = ser.readline().decode('utf-8').strip()
            arch.write(data)
            print(data)

    except KeyboardInterrupt:
        ser.close()
        
        print("Puerto serie cerrado")
    arch.close
    