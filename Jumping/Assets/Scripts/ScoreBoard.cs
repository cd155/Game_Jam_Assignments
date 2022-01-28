using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;
    float positionX = 6.0f;
    float positionY = 9.0f;
    float distance = 1.0f;
    int targetNumber = 4;
    public List<GameObject> targetList;

    // Start is called before the first frame update
    void Start()
    {
        targetList = new List<GameObject>();
        generateScoreBoard();
    }

    private void generateScoreBoard()
    {   
        for(int i = 0; i<targetNumber; i++)
        {
            Vector3 position = new Vector3(positionX, positionY);
            GameObject gameObject = Instantiate
            (
                fruitPrefab[Random.Range(0, fruitPrefab.Length)], 
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
