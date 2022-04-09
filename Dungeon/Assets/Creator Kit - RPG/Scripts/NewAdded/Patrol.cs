using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float x1;
    public float x2;
    public float y1;
    public float y2;

    public bool dizzed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!dizzed)
        {
            transform.position = Vector3.Lerp(
                new Vector3(x1, x2, 0), new Vector3(y1, y2, 0), 
                Mathf.PingPong(Time.time * 0.5f, 1));    
        } 
    }
}
