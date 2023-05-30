namespace Node;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("enter port:");
        int port = int.Parse(Console.ReadLine() ?? string.Empty);
        Node node = new Node("127.0.0.1", port, @"/Users/kate/Desktop/Study/TechProg/FileSystem/nodes");

        Console.WriteLine("start");
        while (true)
        {
            node.Start();
        }
    }
}