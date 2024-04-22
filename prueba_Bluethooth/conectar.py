import serial
import keyboard

try:
    ser = serial.Serial("COM3", 9600)
    
    while True:
        if keyboard.is_pressed("y"):
            ser.write(b'y')
            
        elif keyboard.is_pressed("n"):
            ser.write(b'n')
            
        if keyboard.is_pressed("ENTER"):
            ser.close()
            break
        
except serial.serialutil.SerialException:
    print("Error de comunicación serial")
finally:
    print("Hecho")
