using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn: MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 15.0f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    private float minThrust = 70.0f;
    private float maxThrust = 120.0f;
    private float time = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        // state Fruitspawn frame by frame
        StartCoroutine(StartFruitSpawn());
    }

    private IEnumerator StartFruitSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(transform.position.x, wanted);
            GameObject gameObject = Instantiate(
                fruitPrefab[Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(minThrust, maxThrust));
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, time);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
