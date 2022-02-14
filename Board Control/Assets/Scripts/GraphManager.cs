using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeLibrary;

public class GraphManager : MonoBehaviour
{
    // update once comfirm, once it is empty, game over
    private List <Node> nodeLeft = new List<Node>(); 

    // update once comfirm
    private List <Node> nodeAvaliable = new List<Node>(); 
    // Start is called before the first frame update
    void Start()
    {
        GameObject graph = GameObject.Find("Graph");
        graph.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeGraph()
    {
        #region Initiate All Nodes
        Node math1 = new Node("math1");
        Node math2 = new Node("math2");
        Node math3 = new Node("math3");
        Node math4 = new Node("math4");
        Node computing = new Node("computing");
        Node circuits = new Node("circuits");
        Node chemistry = new Node("chemistry");
        Node themo = new Node("themo");
        Node systems = new Node("systems");
        Node material = new Node("material");
        Node probability = new Node("probability");
        #endregion

        #region Initiate nodeLeft and nodeAvaliable
        nodeLeft.Add(math1);
        nodeLeft.Add(math2);
        nodeLeft.Add(math3);
        nodeLeft.Add(math4);
        nodeLeft.Add(computing);
        nodeLeft.Add(circuits);
        nodeLeft.Add(chemistry);
        nodeLeft.Add(themo);
        nodeLeft.Add(systems);
        nodeLeft.Add(material);
        nodeLeft.Add(probability);

        nodeAvaliable.Add(math1);
        nodeAvaliable.Add(chemistry);
        #endregion

        #region Modify Node Relation
        // modify NextList
        math1.AddNextList(math2);
        math1.AddNextList(computing);
        math1.AddNextList(math3);
        math3.AddNextList(math4);
        math2.AddNextList(math4);
        math2.AddNextList(themo);
        math2.AddNextList(probability);
        computing.AddNextList(math4);
        math4.AddNextList(circuits);
        chemistry.AddNextList(material);
        chemistry.AddNextList(themo);

        // modify PreviousList
        math3.AddPreviousList(math1, "south-west1", false);
        math2.AddPreviousList(math1, "south-east1", false);
        computing.AddPreviousList(math1, "right1", false);
        math4.AddPreviousList(math3, "south-east2", false);
        math4.AddPreviousList(math2, "south-west2", false);
        circuits.AddPreviousList(math4, "down1", false);
        themo.AddPreviousList(math2, "down3", false);
        probability.AddPreviousList(math2, "down5", false);
        systems.AddPreviousList(computing, "down4", false);
        themo.AddPreviousList(chemistry, "right2", false);
        material.AddPreviousList(chemistry, "down2", false);
        #endregion
    }
}
