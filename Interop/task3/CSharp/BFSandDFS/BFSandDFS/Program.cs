﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace BFSandDFS
{
    class Graph
    {
        private int Vertices;
    
        private List<Int32>[] adj;

        public Graph(int v) {
            Vertices = v;
            adj = new List<Int32>[v];
       
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<Int32>();
            }
 
        }
        
        public void AddEdge(int v,int w) {
            adj[v].Add(w);
        }
        
        void BFS(int s) {
            bool[] visited = new bool[Vertices];
            
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count!=0) {
                s = queue.Dequeue();
                Console.WriteLine("next->"+s);
                
                foreach (Int32 next in adj[s]) {
                    if (!visited[next]) {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
 
            }
        }
 

        public void DFS(int s) {
            bool[] visited = new bool[Vertices];
            
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);
 
            while (stack.Count !=0) {
                s = stack.Pop();
                Console.WriteLine("next->"+s);
                foreach (int i in adj[s]) {
                    if (!visited[i]) {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
 
        public void PrintAdjacecnyMatrix() {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i+":[");
                string s = "";
                foreach (var k in adj[i])  {
                    s= s+(k+",");
                }
                s = s.Substring(0,s.Length-1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }
       
        public static void Main() {
            Graph graph = new Graph(4);
            graph.AddEdge(0,1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1,2);
            graph.AddEdge(2,0);
            graph.AddEdge(2,3);
            graph.AddEdge(3,3);

            Console.WriteLine("BFS:");
            graph.BFS(2);
            Console.WriteLine("DFS:");
            graph.DFS(2);
        }
    }
}