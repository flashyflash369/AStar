using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{

    public List<Edge> edges = new List<Edge>();

    public List<Node> nodes = new List<Node>();
    public List<Node> pathList;

    public Graph() { }

    public void AddEdge(GameObject startNode, GameObject endNode)
    {
        Node from = FindNode(startNode);
        Node to = FindNode(endNode);
        
        if(from == null || to == null)
        {
            return;
        }


        Edge edge = new Edge(from, to);
        edges.Add(edge);
        from.edgeList.Add(edge);
        
    }

    public void AddNode(GameObject id)
    {
        Node node = new Node(id);
        nodes.Add(node);
    }

    public Node FindNode(GameObject node)
    {
        foreach(Node n in nodes)
        {
            if(n.GetId() == node)
            {
                return n;
            }
        }

        return null;
    }
}
