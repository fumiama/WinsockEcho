# WinsockEcho
A simple socket ping-pong echo.

![image](https://user-images.githubusercontent.com/41315874/190897249-445ff4f3-58c0-4583-8c04-eba6fd65d010.png)

## C-Binding API
```c
int Bind(const char* ip, unsigned short* port); // return socket fd
void Close(int fd);
void Receive(void (*f) (const char* msg));
void StopReceive();
int Ping(const char* ip, unsigned short port);
```
