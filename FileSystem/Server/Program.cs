namespace Server;

public class Program
{
    static void Main()
    {
        var ip = "127.0.0.1";
        Commands commands = new Commands(ip);
        commands.Exec(@"/Users/kate/Desktop/Study/TechProg/FileSystem/nodes/files/commands_10000.txt");
    }
}