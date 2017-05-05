using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour {

    public GameObject targetPrefab, gameFinishedPrefab;
    bool timerFinished = false;
    public float Timer = 120.0f;
    public int score = 0;
    int a, b, c;
    public bool change = true;

    void Start ()
    {
        Instantiate(targetPrefab, transform);
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
