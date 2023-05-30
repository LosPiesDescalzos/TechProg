namespace Generator;

class Program
{
    static void Main()
    {
        StreamWriter sw = new StreamWriter("/Users/kate/Desktop/Study/TechProg/FileSystem/nodes/files/commands_10000.txt");
        sw.WriteLine("add-node node1 1111 1000000000");
        sw.WriteLine("add-node node2 1112 1000000000");
        sw.WriteLine("add-node node3 1113 1000000000");
        for (int i = 0; i < 10000; i++)
        {
            if (i < 4000)
            {
                sw.WriteLine($"add-file /Users/kate/Desktop/Study/TechProg/FileSystem/nodes/files/file{i}.txt node1/file{i}.txt");
            }
            else if (i < 8000)
            {
                sw.WriteLine($"add-file /Users/kate/Desktop/Study/TechProg/FileSystem/nodes/files/file{i}.txt node2/file{i}.txt");
            }
            else
            {
                sw.WriteLine($"add-file /Users/kate/Desktop/Study/TechProg/FileSystem/nodes/files/file{i}.txt node3/file{i}.txt");
            }
        }
        sw.WriteLine("clean-node node1");
        sw.WriteLine("balance-node");
        sw.Close();
    }
}