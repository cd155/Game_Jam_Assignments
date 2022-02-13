using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject graph = GameObject.Find("Graph");
        graph.SetActive(false);
        Debug.Log("here");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
