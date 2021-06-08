# RennTek-Networking

## RennTek Networking
INET Networking is a easy to use light weight networking solution created for easy for beginner and expert developers.

## Currently supported client languages:
 - C#

## How to use INET Networking

### The server...

- The server comes with variables, 'OnPlayerConnected' and 'OnPlayerConnected', these will trigger automatically.

```cs
static void Main(string[] _args)
{
r_NetworkServer.OnPlayerConnected += delegate {//code};
r_NetworkServer.OnPlayerDisconnected += delegate {//code};
r_NetworkServer.InitializeServer(PORT) //5555
}
```

### Callbabacks

```cs
r_NetworkCallback.RegisterCallback("event_name", function);
```

Or

```cs
r_NetworkCallback.RegisterCallback("event_name", delegate { //code });
```

Or

```cs
r_NetworkCallback.r_NetworkCallback("event_name", (id, packet) =>
{
//code
});
```

Default callbacks that could help you in the late future

```cs
r_NetworkCallback.RegisterCallback("Log", delegate { //code });
r_NetworkCallback.RegisterCallback("Alert", delegate { //code });
r_NetworkCallback.RegisterCallback("Error", delegate { //code });
```


### The client...


```cs
static void Main(string[] _args)
{
r_NetworkClient.OnLog += delegate{//log};
r_NetworkClient.InitializeClient(SERVER_ADDRESS, SERVER_PORT, ON_CONNECT_CALLBACK, ON_DISCONNECT_CALLBACK);
}
```

### Sending
```cs
r_NetworkClient.Emit("packet/event_name", PACKET_DATA, RPCTARGET)//ALL, OTHERS, SERVER
```