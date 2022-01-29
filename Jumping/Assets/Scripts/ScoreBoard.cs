using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    float positionX = 6.0f;
    float positionY = 9.0f;
    float distance = 1.0f;
    int targetNumber = 4;
    public List<GameObject> targetList;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        targetList = new List<GameObject>();
        generateScoreBoard();
    }

    private void generateScoreBoard()
    {                   
        GameObject[] fruitPrefab = GameObject.Find("Fruit").GetComponent<FruitSpawn>().fruitPrefab;
        Debug.Log(fruitPrefab.Length);
        for(int i = 0; i<targetNumber; i++)
        {
            Vector3 position = new Vector3(positionX, positionY);
            GameObject gameObject = Instantiate
            (
                // rocket is the last one in fruitPrefab 
                fruitPrefab[Random.Range(0, fruitPrefab.Length - 1)], 
                position, 
                Quaternion.identity
            );
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            targetList.Add(gameObject);
            positionX = positionX + distance;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
