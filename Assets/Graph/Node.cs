using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{

    public GameObject id;
    public List<Edge> edgeList = new List<Edge>();
    public GameObject path = null;   
    public float x;
    public float y;
    public float z;


    public float f, g, h;
    public GameObject cameFrom;


    public Node(GameObject id)
    {
        this.id = id;
        this.x = id.transform.position.x;
        this.y = id.transform.position.y;
        this.z = id.transform.position.z;

    }

    public GameObject GetId()
    {
        return this.id;
    }
}
