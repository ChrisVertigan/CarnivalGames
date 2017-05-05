using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour {

    public GameObject MazePrefabOne, gameFinishedPrefab;
    public float Timer = 120.0f;
    bool timerFinished = false;
    int score = 0;

    void Start ()
    {
        Instantiate(MazePrefabOne, transform);
        Time.timeScale = 1;
    }
	
    void Update()
    {
        Timer -= Time.deltaTime;

        string minSec = string.Format("{0}:{1:00}", (int)Timer / 60, (int)Timer % 60);

        GameObject.Find("TimeHolder").GetComponent<TextMesh>().text = minSec;
        GameObject.Find("ScoreHolder").GetComponent<TextMesh>().text = score.ToString();

        if (Timer < 0)
        {
            timerFinished = true;
        }

        if (GameObject.Find("GameFinishedPrefab(Clone)"))
        {

        }
        else
        {
            if (timerFinished)
            {
                timerFinished = false;
                Instantiate(gameFinishedPrefab, transform);
            }
        }
        
        GameObject.Find("GameManager").GetComponent<MainMenu>().score = score;
    }
}
