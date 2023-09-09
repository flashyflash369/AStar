using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph 
{

    public List<Edge> edges = new List<Edge>();

    public List<Node> nodes = new List<Node>();
    public List<Node> pathList;

    public Graph() { }


    public bool AStar(GameObject start, GameObject end)
    {
        Node startNode = FindNode(start);
        Node endNode = FindNode(end);

        if(startNode == null || endNode == null)
        {
            return false;
        }

        List<Node> opened = new List<Node>();
        List<Node> closed = new List<Node>();

        float tentative_g_score = 0;
        bool tentatavite_is_better;

        startNode.g = 0;
        startNode.h = distance(startNode, endNode);
        startNode.f = startNode.h; 

        opened.Add(startNode);

        while(opened.Count > 0)
        {
            int i = LowestF(opened);
            Node thisNode = opened[i];

            if(thisNode.GetId() == end)
            {
                //Build path;
                return true;
            }

            opened.RemoveAt(i);
            closed.Add(thisNode);

            Node neighbour;

            foreach(Edge e in thisNode.edgeList)
            {
                neighbour = e.endNode;

                if(opened.IndexOf(neighbour) > -1)
                {
                    continue; // Continue if we have already explored that node
                }

                tentative_g_score = thisNode.g + distance(thisNode, neighbour);

                if(opened.IndexOf(neighbour) == -1)
                {
                    opened.Add(neighbour);
                    tentatavite_is_better = true;
                }
                else if(tentative_g_score < neighbour.g)
                {
                    tentatavite_is_better = true;
                }
                else
                {
                    tentatavite_is_better = false;
                }

                if(tentatavite_is_better)
                {
                    neighbour.cameFrom = thisNode;
                    neighbour.g = tentative_g_score;
                    neighbour.h = distance(neighbour, endNode);
                    neighbour.f = neighbour.g + neighbour.h;
                }
            }
        }

        return false;
    }

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

    public float distance(Node a, Node b)
    {
        return (Vector3.SqrMagnitude(a.GetId().transform.position - b.GetId().transform.position));
    }

    public int LowestF(List<Node> l)
    {
        int count = 0;
        int iteratorCount = 0;
        float lessF = l[0].f;

        for(int i = 0; i < l.Count; i++)
        {
            if(l[i].f < lessF)
            {
                lessF = l[i].f;
                iteratorCount = count;
            }
            count++;
        }

        return iteratorCount;
    }
}
