using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;

    public float speed = 9f;
    public float rotSpeed = 2.0f;
    public float accuracy = 1f;
    
    public GameObject wpManager;
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
        
        Invoke("GoToRuines", 2);
    

    }

    public void GoToHeli()
    {
        graph.AStar(currentNode, wps[1]);
        currentWp = 0;
    }

    public void GoToRuines()
    {
        graph.AStar(currentNode, wps[9]);
        Debug.Log(graph.pathList.Count);
        currentWp = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(graph.pathList.Count == 0 || currentWp == graph.pathList.Count - 1)
        {
            return;
        }

        if(Vector3.Distance(this.transform.position, graph.pathList[currentWp].GetId().transform.position) < accuracy && currentWp<= graph.pathList.Count)
        {
            currentNode = graph.pathList[currentWp].GetId();
            currentWp++;
        }

        if(currentWp < graph.pathList.Count)
        {
            goal = graph.pathList[currentWp].GetId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}
