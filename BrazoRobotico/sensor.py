import serial
import time
ser = serial.Serial("COM3",9600)
time.sleep(2)
def servo1():
    arch=open("servo.txt","w")
    try:
        while True:
            data = ser.readline().decode('utf-8').strip()
            arch.write(data)
            print(data)

    except KeyboardInterrupt:
        ser.close()
        
        print("Puerto serie cerrado")
    arch.close

def servo2():
    arch=open("servo.txt","w")
    try:
        while True:
            data = ser.readline().decode('utf-8').strip()
            arch.write(data)
            print(data)

    except KeyboardInterrupt:
        ser.close()
        
        print("Puerto serie cerrado")
    arch.close

def servo3():
    arch=open("servo.txt","w")
    try:
        while True:
            data = ser.readline().decode('utf-8').strip()
            arch.write(data)
            print(data)

    except KeyboardInterrupt:
        ser.close()
        
        print("Puerto serie cerrado")
    arch.close

def servo4():
    arch=open("servo.txt","w")
    try:
        while True:
            data = ser.readline().decode('utf-8').strip()
            arch.write(data)
            print(data)

    except KeyboardInterrupt:
        ser.close()
        
        print("Puerto serie cerrado")
    arch.close

def servo5():
    arch=open("servo.txt","w")
    try:
        while True:
            data = ser.readline().decode('utf-8').strip()
            arch.write(data)
            print(data)

    except KeyboardInterrupt:
        ser.close()
        
        print("Puerto serie cerrado")
    arch.close
