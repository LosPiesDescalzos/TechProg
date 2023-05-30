using System;

namespace Parser;

public class MethodDeclaration
{
    public string MethodName { get; set; }
    public string ReturnType { get; set; }
    public List<ArgDeclaration> ArgList { get; set; } = new List<ArgDeclaration>();
    public string Url { get; set; }
    public string HttpMethodName { get; set; }

}