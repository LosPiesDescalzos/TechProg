using System;
using Parser;

class Program
{
    static void Main(string[] args)
    {
        JavaParser parser =  new JavaParser();
        string path = "/Users/kate/Desktop/demo/src/main/java/com/example/demo/controller/ProjectController.java";

        List<MethodDeclaration> methodDeclarations = parser.ParserController(path);

        foreach (var method in methodDeclarations)
        {
            Console.WriteLine("method:");
            Console.Write("Url: ");
            Console.WriteLine(method.Url);
            Console.WriteLine("    Args:");
            foreach (var arg in method.ArgList)
            {
                Console.Write("    Type: ");
                Console.WriteLine(arg.Type);
                Console.Write("    Name: ");
                Console.WriteLine(arg.Name);
            }
            Console.Write("MethodName: ");
            Console.WriteLine(method.MethodName);
            Console.Write("Return type: ");
            Console.WriteLine(method.ReturnType);
            Console.Write("Http: ");
            Console.WriteLine(method.HttpMethodName);
            Console.WriteLine("");
        }

        List<ArgDeclaration> pets = parser.ParserEntity(@"/Users/kate/Desktop/demo/src/main/java/com/example/demo/entity/Pet.java");
       
        List<ArgDeclaration> owners = parser.ParserEntity(@"/Users/kate/Desktop/demo/src/main/java/com/example/demo/entity/Owner.java");

         foreach (var pet in pets)
         {
           Console.WriteLine(pet.Name);
           Console.WriteLine(pet.Type);
         }
       
         foreach (var owner in owners) 
         {
           Console.WriteLine(owner.Name);
           Console.WriteLine(owner.Type);
         }
        
    }
}