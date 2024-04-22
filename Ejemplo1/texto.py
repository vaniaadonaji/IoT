print("hola cual es tu nombre ")
n = (input(""))
print("tu edad?")
e=(input(""))
arch=open("dato.txt","w")
arch.write(n+"\n" + e)
arch.close