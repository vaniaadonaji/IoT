#selector 
from led import led
from led import distancia
import tkinter as tk
#import texto
#def distancia():
 #   print("Hola")

input(" Que deas hacer hoy ")
print(" 1 Controlar led ")
print(" 2 Revisar distancia ")
opcion = input(" Selecciona una opcion ")
if(opcion == "1"):
    led()
elif(opcion == "2"):
    distancia()
else:
    
    print("Seleccione una opcion valida")
