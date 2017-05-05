using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStarted : MonoBehaviour {

    public int[] GameNumbers;

    public GameObject MazePrefab;

    public GameObject TargetPrefab;

    public GameObject WaterPrefab;

    public GameObject PuttingPrefab;

    public int score = 0;

    public void FirstGamePlay(int a, int b, int c, int d)
    {
        GameNumbers = new int[4];

        GameNumbers[0] = a;
        GameNumbers[1] = b;
        GameNumbers[2] = c;
        GameNumbers[3] = d;


        switch (GameNumbers[0])
        {
            case 0:
                SpawnMazeGame();
                break;
            case 1:
                SpawnTargetGame();
                break;
            case 2:
                SpawnWaterGame();
                break;
            case 3:
                SpawnPuttingGame();
                break;
        }

    }

    public void SecondGamePlay()
    {
        switch (GameNumbers[1])
        {
            case 0:
                SpawnMazeGame();
                break;
            case 1:
                SpawnTargetGame();
                break;
            case 2:
                SpawnWaterGame();
                break;
            case 3:
                SpawnPuttingGame();
                break;
        }
    }

    public void ThirdGamePlay()
    {
        switch (GameNumbers[2])
        {
            case 0:
                SpawnMazeGame();
                break;
            case 1:
                SpawnTargetGame();
                break;
            case 2:
                SpawnWaterGame();
                break;
            case 3:
                SpawnPuttingGame();
                break;
        }
    }

    public void FourthGamePlay()
    {
        switch (GameNumbers[3])
        {
            case 0:
                SpawnMazeGame();
                break;
            case 1:
                SpawnTargetGame();
                break;
            case 2:
                SpawnWaterGame();
                break;
            case 3:
                SpawnPuttingGame();
                break;
        }
    }

    public void ClearGames()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameSpawner"));

        if(GameObject.FindGameObjectWithTag("GolfBall"))
        {
            GameObject[] a = GameObject.FindGameObjectsWithTag("GolfBall");

            foreach (GameObject b in a)
            {
                Destroy(b);
            }
        }
        if (GameObject.FindGameObjectWithTag("TargetBall"))
        {
            GameObject[] c = GameObject.FindGameObjectsWithTag("TargetBall");

            foreach (GameObject d in c)
            {
                Destroy(d);
            }
        }
    }

    private void SpawnMazeGame()
    {
        ClearGames();

        Instantiate(MazePrefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
        GameObject[] fingers = GameObject.FindGameObjectsWithTag("IndexFingers");

        foreach (GameObject a in fingers)
        {
            Leap.Unity.ProximityDetector[] prox = a.GetComponents<Leap.Unity.ProximityDetector>();

            prox[0].OnProximity.AddListener(delegate { GameObject.Find("CubeRight").GetComponent<ButtonPressed>().Pressed(); });
            prox[1].OnProximity.AddListener(delegate { GameObject.Find("CubeLeft").GetComponent<ButtonPressed>().Pressed(); });
            prox[2].OnProximity.AddListener(delegate { GameObject.Find("CubeUp").GetComponent<ButtonPressed>().Pressed(); });
            prox[3].OnProximity.AddListener(delegate { GameObject.Find("CubeDown").GetComponent<ButtonPressed>().Pressed(); });
        }

    }

    private void SpawnTargetGame()
    {
        ClearGames();

        Instantiate(TargetPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }

    private void SpawnWaterGame()
    {
        ClearGames();

        Instantiate(WaterPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }

    private void SpawnPuttingGame()
    {
        ClearGames();

        Instantiate(PuttingPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero));
    }
}
