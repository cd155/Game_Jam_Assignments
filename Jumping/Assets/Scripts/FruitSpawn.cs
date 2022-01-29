using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn: MonoBehaviour
{
    public GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 40.0f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    private float minThrust = 6.50f;
    private float maxThrust = 12.50f;
    private float time = 15.0f;
    List<float>  boxOne;
    List<float>  boxTwo;
    bool isBoxOne = true;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateValues();

        // state Fruitspawn frame by frame
        StartCoroutine(StartFruitSpawn());
    }

    private IEnumerator StartFruitSpawn()
    {
        while(true)
        {
            var wanted = randomRange();
            var position = new Vector3(transform.position.x, wanted);
            GameObject gameObject = Instantiate
            (
                fruitPrefab[Random.Range(0, fruitPrefab.Length)], 
                position, 
                Quaternion.identity
            );
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(minThrust, maxThrust));
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, time);
        }
    }

    private float randomRange()
    {
        if(isBoxOne)
        {
            var select = boxOne[Random.Range(0, boxOne.Count)];
            boxOne.Remove(select);
            boxTwo.Add(select);

            if(boxOne.Count == 0)
            {
                isBoxOne = false;
            }
            return select;
        }
        else
        {
            var select = boxTwo[Random.Range(0, boxTwo.Count)];
            boxTwo.Remove(select);
            boxOne.Add(select);

            if(boxTwo.Count == 0)
            {
                isBoxOne = true;
            }
            return select;
        }
    }

    private void InstantiateValues()
    {
        boxOne = new List<float>()
        {
            0.5f,
            2.9f,
            5.3f,
            7.7f,
        };
        boxTwo = new List<float>();
    }
}
