using System;


namespace Parser;

public class JavaParser
{
    public List<MethodDeclaration> ParserController(string path)
    {
        List<MethodDeclaration> methodDeclarations = new List<MethodDeclaration>();
        StreamReader file = new StreamReader(path);
        string line;
        while ((line = file.ReadLine()) != null)
        {
            MethodDeclaration method = new MethodDeclaration();
            if (line.IndexOf("@GetMapping") >= 0 )
            {
                method.HttpMethodName = "get";
            }
            else if (line.IndexOf("@PostMapping") >= 0 )
            {
                method.HttpMethodName = "post";
            }

            if (line.IndexOf("@GetMapping") >= 0 || line.IndexOf("@PostMapping") >= 0)
            {
                line =  line.Remove(0,line.IndexOf('"') + 1);
                line = line.Remove(line.IndexOf('"'));
                method.Url = "http://localhost:8080/api/" + line;
                line = file.ReadLine();
                line = line.Remove(line.IndexOf("public"), 7 ).Trim();
                method.ReturnType = line.Substring(0,  line.IndexOf(' '));
                if (method.ReturnType.Contains("Optional"))
                {
                    method.ReturnType = method.ReturnType.Replace("Optional<", "")
                        .Replace(">", "")
                        .Trim();
                }

                line =  line.Remove(0,line.IndexOf(' ')).Trim();
                method.MethodName = line.Substring(0,  line.IndexOf(' '));
                line =  line.Remove(0,line.IndexOf(' ')).Trim();
                line = line.Replace("@RequestBody ", "").Trim();
                ArgDeclaration argDeclarations = new ArgDeclaration();
                if (line.IndexOf(')') - line.IndexOf('(') > 1)
                { 
                    argDeclarations.Type = line.Substring(1,line.IndexOf(' ')).Trim();
                    if (argDeclarations.Type == "String" || argDeclarations.Type == "Long")
                    {
                        argDeclarations.Type = argDeclarations.Type.ToLower();
                    }
                    line = line.Remove(0,line.IndexOf(' ')).Trim();
                    argDeclarations.Name = line.Substring(0,line.IndexOf(')')).Trim();
                    method.ArgList.Add(argDeclarations);
                }
                methodDeclarations.Add(method);
            }
            
        }
        file.Close();
        
        return methodDeclarations;
    }


    public List<ArgDeclaration> ParserEntity(string path)
    {
        List<ArgDeclaration> argDeclarations = new List<ArgDeclaration>();

        StreamReader file = new StreamReader(path);
        string line;
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains("private"))
            {
                ArgDeclaration argDeclaration = new ArgDeclaration();

                line = line.Replace("private", "")
                    .Trim();

                string type = line.Substring(0, line.IndexOf(' '));
                line = line.Substring(line.IndexOf(' '));
                string name = line.Substring(0, line.IndexOf(';')).Trim();
                if (type == "String" || type == "Long")
                {
                    type = type.ToLower();
                }

                argDeclaration.Name = name;
                argDeclaration.Type = type;
                argDeclarations.Add(argDeclaration);
            }
        }

        return argDeclarations;
    }
}

