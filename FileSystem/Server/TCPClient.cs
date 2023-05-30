using System.Net.Sockets;

namespace Server;

public record Client
{
    private readonly string _ipAddress;
    private readonly int _port;
    private TcpClient _tcpClient;
    public NetworkStream NetworkStream;

    public Client(string ipAddress, int port)
    {
        _ipAddress = ipAddress;
        _port = port;
        _tcpClient = null;
        NetworkStream = null;
    }
    
    public void Connect()
    {
        _tcpClient = new TcpClient(_ipAddress, _port);
        NetworkStream = _tcpClient.GetStream();
    }
}