using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;

    public float speed = 9f;
    public float rotSpeed = 2.0f;
    public float accuracy = 1f;
    
    GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWp;
    Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        graph = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[1];
    }

    public void GoToHeli()
    {
        graph.AStar(currentNode, wps[2]);
        currentWp = 0;
    }

    public void GoToRuines()
    {
        graph.AStar(currentNode, wps[10]);
        currentWp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
