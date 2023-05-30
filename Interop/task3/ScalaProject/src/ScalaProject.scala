object Main {
  def main(args: Array[String]): Unit = {
    val g = new Graph(6)

    g.addEdge(0, 1)
    g.addEdge(0, 2)
    g.addEdge(1, 0)
    g.addEdge(1, 3)
    g.addEdge(2, 0)
    g.addEdge(2, 3)
    g.addEdge(3, 4)
    g.addEdge(3, 5)
    g.addEdge(4, 3)
    g.addEdge(5, 3)

    println("DFS: ")
    g.DFS(0)
    println()
    println("BFS:")
    g.BFS(0)
  }
}