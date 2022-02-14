using System.Collections;
using System.Collections.Generic;

namespace NodeLibrary
{
    public class Node
    {
        public string name;

        //set setter and getter
        public List <Node> nextList = new List<Node>();

        //set setter and getter
        public List <(Node, string, bool)> previousList = new List<(Node, string, bool)>();
    
        public Node(string name)
        {
            this.name = name;
        }

        public void AddNextList(Node node)
        {
            nextList.Add(node);
        }

        public void AddPreviousList(Node node, string name, bool active)
        {
            previousList.Add((node, name, active));
        }
    }
}