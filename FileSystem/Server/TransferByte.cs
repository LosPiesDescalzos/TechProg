using System.Buffers;
using System.Text;
using Node;

namespace Server;

public class TransferByte
{

    public Client Client { get; set; }
    public string IpAddress { get; }

    public TransferByte(string ipAddress)
    {
        IpAddress = ipAddress;
        Client = new Client(IpAddress, 1111);
    }
    
    public void AddNode(string nodeName)
    {
        Client.Connect();
        CreateNodeBytes(nodeName);
    }

    public void AddFile(string path, string partP)
    {
        Client.Connect();
        CreateFileBytes(path, partP);
    }
    
    public void RemoveFile(string partP)
    {
        Client.Connect();
        RemoveFileBytes(partP);
    }
    
    private void CreateNodeBytes(string nodeName)
    {
        byte[] command = BitConverter.GetBytes((int) EnumCommands.AddNode);
        byte[] size = BitConverter.GetBytes(nodeName.Length);
        byte[] name = Encoding.ASCII.GetBytes(nodeName);
        
        Client.NetworkStream.Write(command, 0, sizeof(EnumCommands));
        Client.NetworkStream.Write(size, 0, sizeof(int));
        Client.NetworkStream.Write(name, 0, name.Length);
    }
    
    private void CreateFileBytes(string path, string partP)
    {
        byte[] command = BitConverter.GetBytes((int) EnumCommands.AddFile);
        byte[] sizePart = BitConverter.GetBytes(partP.Length);
        byte[] partName = Encoding.ASCII.GetBytes(partP);

        var sizeFile = new FileInfo(path).Length;
        byte[] sizeFileBytes = BitConverter.GetBytes(sizeFile);

        var dataBytes = ArrayPool<byte>.Shared.Rent((int) sizeFile);

        using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            int numBytesToRead = (int) fsSource.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                int n = fsSource.Read(dataBytes, numBytesRead, numBytesToRead);
                if (n == 0)
                    break;
                
                numBytesRead += n;
                numBytesToRead -= n;
            }
        }

        Client.NetworkStream.Write(command, 0, sizeof(EnumCommands));
        Client.NetworkStream.Write(sizePart, 0, sizeof(int));
        Client.NetworkStream.Write(partName, 0, partName.Length);
        
        Client.NetworkStream.Write(sizeFileBytes, 0, sizeof(long));
        Client.NetworkStream.Write(dataBytes, 0, dataBytes.Length);
        
        ArrayPool<byte>.Shared.Return(dataBytes);
    }
    
    private void RemoveFileBytes(string partP)
    {
        byte[] command = BitConverter.GetBytes((int) EnumCommands.RemoveFile);
        byte[] sizePart= BitConverter.GetBytes(partP.Length);
        byte[] partName= Encoding.ASCII.GetBytes(partP);
        
        Client.NetworkStream.Write(command, 0, sizeof(EnumCommands));
        Client.NetworkStream.Write(sizePart, 0, sizeof(int));
        Client.NetworkStream.Write(partName, 0, partName.Length);
        
    }
}