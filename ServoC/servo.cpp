#include <stdio.h>
#include <Windows.h>

int main() {
    HANDLE hSerial;
    DCB dcbSerialParams = {0};
    COMMTIMEOUTS timeouts = {0};

    hSerial = CreateFile("COM3", GENERIC_READ | GENERIC_WRITE, 0, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
    
    if (hSerial == INVALID_HANDLE_VALUE) {
        if (GetLastError() == ERROR_FILE_NOT_FOUND) {
            printf("Error: Puerto serie no disponible\n");
        } else {
            printf("Error: Fallo al abrir el puerto serie\n");
        }
        return 1;
    }

    dcbSerialParams.DCBlength = sizeof(dcbSerialParams);

    if (!GetCommState(hSerial, &dcbSerialParams)) {
        printf("Error: No se pudo obtener el estado del puerto serie\n");
        CloseHandle(hSerial);
        return 1;
    }

    dcbSerialParams.BaudRate = CBR_9600; // Velocidad de transmisión (9600 bps)
    dcbSerialParams.ByteSize = 8;
    dcbSerialParams.StopBits = ONESTOPBIT;
    dcbSerialParams.Parity = NOPARITY;

    if (!SetCommState(hSerial, &dcbSerialParams)) {
        printf("Error: No se pudo establecer el estado del puerto serie\n");
        CloseHandle(hSerial);
        return 1;
    }

    timeouts.ReadIntervalTimeout = 50;
    timeouts.ReadTotalTimeoutConstant = 50;
    timeouts.ReadTotalTimeoutMultiplier = 10;
    timeouts.WriteTotalTimeoutConstant = 50;
    timeouts.WriteTotalTimeoutMultiplier = 10;

    if (!SetCommTimeouts(hSerial, &timeouts)) {
        printf("Error: No se pudieron establecer los tiempos de espera del puerto serie\n");
        CloseHandle(hSerial);
        return 1;
    }

    char angle[32];
    DWORD bytesWritten;

    while (1) {
        printf("Introduce el ángulo del servo (0-180): ");
        fgets(angle, sizeof(angle), stdin);
        strcat(angle, "\n");
        WriteFile(hSerial, angle, strlen(angle), &bytesWritten, NULL);
        Sleep(100); // Espera para permitir que Arduino procese los datos
    }

    CloseHandle(hSerial);
    return 0;
}
