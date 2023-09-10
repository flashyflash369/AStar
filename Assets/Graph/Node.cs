using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{

    public GameObject id;
    public List<Edge> edgeList = new List<Edge>();
    public GameObject path = null;   
    
    //the xyz coordinates are optional because a GameObject
    //contained all these informations;

    public float x;
    public float y;
    public float z;

    public float f, g, h;
    public Node cameFrom;


    public Node(GameObject id)
    {
        this.id = id;

        //optional cause game objects have the xyz coordinates
        //this.x = id.transform.position.x;
        //this.y = id.transform.position.y;
        //this.z = id.transform.position.z;

    }

    public GameObject GetId()
    {
        return this.id;
    }
}
