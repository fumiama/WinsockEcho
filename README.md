# WinsockEcho
A simple socket ping-pong echo.

![image](https://user-images.githubusercontent.com/41315874/190897249-445ff4f3-58c0-4583-8c04-eba6fd65d010.png)

## C-Binding API
> Minus return value represents an error
```c
int Bind(const char* ip, unsigned short* port); // return socket fd
int Close();
int Receive(void (*f) (const char* msg));
int StopReceive();
int Ping(const char* ip, unsigned short port);
```
