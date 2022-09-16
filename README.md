# WinsockEcho
A simple socket ping-pong echo.

![image](https://user-images.githubusercontent.com/41315874/190673793-2fb8c907-9584-42f0-9642-1967ccb7b696.png)

## C-Binding API
```c
int Bind(const char* ip, unsigned short* port); // return socket fd
void Close(int fd);
void Receive(void (*f) (const char* msg));
void StopReceive();
int Ping(const char* ip, unsigned short port);
```
