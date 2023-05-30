import java.util.*;


class Graph {
    private int V;

    private LinkedList<Integer> adj[];
    private Queue<Integer> queue;

    public Graph(int v) {
        V = v;
        adj = new LinkedList[v];
        for (int i = 0; i < v; ++i) {
            adj[i] = new LinkedList();
        }
        queue = new LinkedList<Integer>();
    }
    void addEdge(int v,int w) {
        adj[v].add(w);
    }

    void BFS(int n)
    {

        boolean nodes[] = new boolean[V];       //initialize boolean array for holding the data
        int a = 0;

        nodes[n]=true;
        queue.add(n);                   //root node is added to the top of the queue

        while (queue.size() != 0)
        {
            n = queue.poll();             //remove the top element of the queue
            System.out.print(n+" ");           //print the top element of the queue

            for (int i = 0; i < adj[n].size(); i++)  //iterate through the linked list and push all neighbors into queue
            {
                a = adj[n].get(i);
                if (!nodes[a])                    //only insert nodes into queue if they have not been explored already
                {
                    nodes[a] = true;
                    queue.add(a);
                }
            }
        }
    }

    void DFSUtil ( int vertex, boolean nodes[]) {

        nodes[vertex] = true;
        System.out.print(vertex + " ");
        int a = 0;

        for (int i = 0; i < adj[vertex].size(); i++)
        {
            a = adj[vertex].get(i);
            if (!nodes[a])
            {
                DFSUtil(a, nodes);
            }
        }
    }

    void DFS ( int v)
    {
        boolean already[] = new boolean[V];
        DFSUtil(v, already);
    }

    public static void main (String args[])
    {
        Graph g = new Graph(6);

        g.addEdge(0, 1);
        g.addEdge(0, 2);
        g.addEdge(1, 0);
        g.addEdge(1, 3);
        g.addEdge(2, 0);
        g.addEdge(2, 3);
        g.addEdge(3, 4);
        g.addEdge(3, 5);
        g.addEdge(4, 3);
        g.addEdge(5, 3);

        System.out.println("DFC: ");

        g.DFS(0);

        System.out.println();

        System.out.println("BFC:");

        g.BFS(0);
    }
}