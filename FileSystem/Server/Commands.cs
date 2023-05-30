using System.Text;

namespace Server;

public class Commands
{
    private readonly TransferByte _transferByte;
    private readonly List<Node> _nodes;
    private readonly StringBuilder _directoryPath = new("/Users/kate/Desktop/nodes/files/");

    public Commands(string ip)
    {
        _transferByte = new TransferByte(ip);
        _nodes = new List<Node>();
    }
    public void AddNode(string name, int port, int maxSize)
    {
        var node = new Node(name, port, maxSize);
        _nodes.Add(node);
        _transferByte.AddNode(name);
    }
    
    public void AddFile(string path, string partP)
    {
        File file = new File(Path.GetFileName(path), new FileInfo(path).Length);
        Node node = FindNode(partP.Remove(partP.IndexOf('/')));
        _transferByte.AddFile(path, partP);
        node.AddFile(file);
    }

    public void RemoveFile(string path)
    {
        _transferByte.RemoveFile(path);
    }

    public void CleanNode(string name)
    {
        var currentNode = FindNode(name);

        foreach (var node in _nodes)
        {
            if (node.Name == currentNode.Name) continue;
            while (currentNode.Files.Count > 1 && node.AddFile(currentNode.Files[0]))
            {
                StringBuilder path = new StringBuilder()
                    .Append(_directoryPath)
                    .Append('/')
                    .Append(currentNode.Files[0].Name);

                StringBuilder partialPath = new StringBuilder()
                    .Append(node.Name)
                    .Append('/')
                    .Append(currentNode.Files[0].Name);
                
                AddFile(path.ToString(), partialPath.ToString());
                currentNode.RemoveFile(currentNode.Files[0]);

                StringBuilder removeFile = new StringBuilder()
                    .Append(currentNode.Name)
                    .Append('/')
                    .Append(currentNode.Files[0].Name);
                    
                RemoveFile(removeFile.ToString());
            }
        }
    }

    public void BalanceNode()
    {
            foreach (var currentNode in _nodes) 
            {
                foreach (var node in _nodes)
                {
                    if (node.Name == currentNode.Name) continue;

                    for (int i = 0; i < currentNode.Files.Count; i++)
                    {
                        if (node.CheckSize(currentNode.Files[0]) && 
                            node.Size + currentNode.Files[0].Size <= currentNode.Size - currentNode.Files[0].Size)
                        {
                            StringBuilder path = new StringBuilder()
                                .Append(_directoryPath)
                                .Append('/')
                                .Append(currentNode.Files[0].Name);

                            StringBuilder partialPath = new StringBuilder()
                                .Append(node.Name)
                                .Append('/')
                                .Append(currentNode.Files[0].Name);
                
                            AddFile(path.ToString(), partialPath.ToString());
                            currentNode.RemoveFile(currentNode.Files[0]);

                            StringBuilder removeFile = new StringBuilder()
                                .Append(currentNode.Name)
                                .Append('/')
                                .Append(currentNode.Files[0].Name);
                    
                            RemoveFile(removeFile.ToString());
                        }
                    }
                }
            }
    }

    public void Exec(string path)
    {
        string str;
        var file = new StreamReader(path);
        while ((str = file.ReadLine()) != null)
        {
            GoCommand(str); 
        }
        
        file.Close();
    }

    public void GoCommand(string str)
    {
        string command = str.Substring(0,str.IndexOf(' ')).Trim();
        str = str.Remove(0, str.IndexOf(' ')).Trim();
        string nodeName, path, partialPath;

        switch (command)
        {
            case "add-node":
                nodeName = str.Substring(0, str.IndexOf(' ')).Trim();
                str = str.Remove(0, str.IndexOf(' ')).Trim();
                string portStr = str.Substring(0, str.IndexOf(' ')).Trim();
                str = str.Remove(0, str.IndexOf(' ')).Trim();
                int port = Int32.Parse(portStr);
                string sizeStr = str.Trim();
                int size = int.Parse(sizeStr); 
                AddNode(nodeName, port, size);
                break;
            case "add-file":
                path = str.Substring(0, str.IndexOf(' ')).Trim();
                str = str.Remove(0, str.IndexOf(' ')).Trim();
                partialPath = str.Trim();
                Console.WriteLine($"add file {partialPath}");
                AddFile(path, partialPath);
                break;
            case "remove-file":
                path = str.Trim();
                RemoveFile(path);
                break;
            case "clean-node":
                nodeName = str.Trim();
                CleanNode(nodeName);
                break;
            case "balance-node":
                BalanceNode();
                break;
            case "exec":
                path = str.Trim();
                Exec(path);
                break;
            default:
                Console.WriteLine("This command not found");
                break;
        }
    }

    public Node FindNode(string name)
    {
        foreach (var node in _nodes)
        {
            if (node.Name == name)
            {
                return node;
            }
        }

        return null;
    }
}