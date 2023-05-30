namespace Server;

public record Node(string Name, int Port, long MaxSize)
{
    public string Name = Name;
    public long Size = 0;
    public int Port = Port;
    public long MaxSize = MaxSize;

    public List<File> Files = new();
    
    public bool AddFile(File file)
    {
        if (CheckSize(file))
        {
            Files.Add(file);
            Size += file.Size;
            return true;
        }

        return false;
    }
    
    public void RemoveFile(File file)
    {
        Size -= file.Size;
        Files.Remove(file);
    }
    
    public bool CheckSize(File file)
    {
        if (file.Size > MaxSize - Size)
        {
            return false;
        }

        return true;
    }
}


