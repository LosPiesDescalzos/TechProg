using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Node;

public class Node
{
    private TcpClient _client;
    private NetworkStream _stream;
    private TcpListener _listener;

    public string NodePath { get; }

    public Node(string ipAddress, int port, string directory)
    {
        _listener = new TcpListener(IPAddress.Parse(ipAddress), port);
        NodePath = directory;
        Directory.CreateDirectory(directory);
        _listener.Start();
    }

    public void Start()
    {
        _client = _listener.AcceptTcpClient();
        _stream = _client.GetStream();
        GetOptions();
        _stream.Close();
        _client.Close();
    }

    public void GetOptions()
    {
        var data = new byte[sizeof(EnumCommands)];
        _stream.Read(data, 0, sizeof(EnumCommands));
        int option = BitConverter.ToInt32(data, 0);
        if (!Enum.IsDefined(typeof(EnumCommands), option)) return;

        switch ((EnumCommands) option)
        {
            case EnumCommands.AddNode:
                AddNode();
                break;

            case EnumCommands.AddFile:
                AddFile();
                break;

            case EnumCommands.RemoveFile:
                RemoveFile();
                break;
        }
    }

    public void AddNode()
    {
        var size = new byte[sizeof(int)];
        _stream.Read(size, 0, sizeof(int));
        int intSize = BitConverter.ToInt32(size, 0);

        var name = new byte[intSize];
        _stream.Read(name, 0, intSize);
        string nattt = Encoding.ASCII.GetString(name, 0, intSize);

        Directory.CreateDirectory($"{NodePath}/{nattt}");
    }
    
    public void AddFile()
    {
        var sizePart = new byte[sizeof(int)];
        _stream.Read(sizePart, 0, sizeof(int));
        int intSizePart = BitConverter.ToInt32(sizePart, 0);

        var partName = new byte[intSizePart];
        _stream.Read(partName, 0, intSizePart);
        string geo = Encoding.ASCII.GetString(partName, 0, intSizePart);

        var size = new byte[sizeof(int)];
        _stream.Read(size, 0, sizeof(int));
        int intSize = BitConverter.ToInt32(size, 0);
        
        var file = new byte[intSize];
        _stream.Read(file, 0, intSize);
        File.WriteAllBytes($"{NodePath}/{geo}", file);
    }

    public void RemoveFile()
    {
        var sizePart = new byte[sizeof(int)];
        _stream.Read(sizePart, 0, sizeof(int));
        int intSizePart = BitConverter.ToInt32(sizePart, 0);

        var partName = new byte[intSizePart];
        _stream.Read(partName, 0, intSizePart);
        string geo = Encoding.ASCII.GetString(partName, 0, intSizePart);
        
        File.Delete($"{NodePath}/{geo}");
    }
}