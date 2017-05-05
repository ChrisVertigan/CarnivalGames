using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public GameObject charPrefab;
    MainMenu mainMenu;
    public int score = 0;
    public int Score
    {
        get
        {
            return Score;
        }
        set
        {
            Score = value;
            if(GameObject.Find("ScoreUI"))
                GameObject.Find("ScoreUI").GetComponent<Text>().text = "Score: " + Score.ToString();
        }
    }

    public float timeLeft = 120.0f;
    public float Timer
    {
        get
        {
            return timeLeft;
        }
        set
        {
            timeLeft = value;
            string temp = timeLeft.ToString();
            if(GameObject.Find("TimeUI"))
                GameObject.Find("TimeUI").GetComponent<Text>().text = "Time: " + temp.Remove(temp.IndexOf('.'));
        }
    }

    public GameObject GamePanel;

    private void Start()
    {
        Instantiate(GamePanel);

        mainMenu = GameObject.Find("GameManager").GetComponent<MainMenu>();

        string temp = "";
        
        if (mainMenu.currentGame == 1)
        {
            temp = CreateTips(mainMenu.GameOne);
        }
        else if(mainMenu.currentGame == 2)
        {
            temp = CreateTips(mainMenu.GameTwo);
        }
        else if(mainMenu.currentGame == 3)
        {
            temp = CreateTips(mainMenu.GameThree);
        }
        else
        {
            Debug.LogError("GameUIStartProblem");
        }

        //StartCoroutine(CreateScrollingText(temp));
    }

    string CreateTips(int currentGameType)
    {
        string temp = "";

        switch (currentGameType)
        {
            //Maze Game.
            case 0:
                temp = "Grab the Ball and drag it through the maze!";
                break;
            //Target Game.
            case 1:
                temp = "Grab the Gun and shoot at the targets by pulling your index finger into your palm.";
                break;
            //Water Game.
            case 2:
                temp = "Grab the water gun and start the water flow by pulling your index finger into your palm.";
                break;
            //Putting Game.
            case 3:
                temp = "Grab the putter and whack the golf ball!";
                break;
        }
        
        return temp;
    }

    IEnumerator CreateScrollingText(string temp)
    {
        char[] characters = temp.ToCharArray();

        foreach (char a in characters)
        {
            GameObject b = Instantiate(charPrefab, GameObject.Find("CharSpawn").transform);
            b.GetComponent<Text>().text = a.ToString();
            yield return new WaitForSeconds(1.0f);
        }

        yield break;
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {

    }
}
