using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float delay = 8.0f;
    public void EndGame()
    {   
        //Freeze Movement
        FreezeAll();

        //Show winning animation
        GameObject.Find("Snail").GetComponent<SnailAnimation>().isLose = true;

        //Move to the next level
        Invoke("Restart", delay);
    }

    public void Winning()
    {   
        //Freeze Movement
        FreezeAll();

        //Show winning animation
        GameObject.Find("Snail").GetComponent<SnailAnimation>().isWin = true;

        //Move to the next level
        Invoke("Restart", delay);
    }

    private void FreezeAll()
    {
        //Stop Spawn
        GameObject.Find("Fruit").GetComponent<FruitSpawn>().isSpawn = false;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
