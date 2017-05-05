using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {

    public GameObject finalPillarPrefab;
    bool nextPressed = false;
    int final = 0;

    private void Update()
    {
        if(name.Equals("Next"))
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Pressed();
            }
        }

        GameObject gm = GameObject.Find("GameManager");

        int score = 0;

        if (GameObject.Find("ScoreHolder"))
        {
            score = int.Parse(GameObject.Find("ScoreHolder").GetComponent<TextMesh>().text);
        }

        if (nextPressed && GameObject.FindGameObjectWithTag("DeleteCenter").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            switch (GameObject.Find("GameManager").GetComponent<MainMenu>().currentGame)
            {
                case 1:
                    gm.GetComponent<MainMenu>().currentGame++;
                    gm.GetComponent<GameStarted>().score = gm.GetComponent<GameStarted>().score + score;
                    gm.GetComponent<GameStarted>().SecondGamePlay();
                    break;
                case 2:
                    gm.GetComponent<MainMenu>().currentGame++;
                    gm.GetComponent<GameStarted>().score = gm.GetComponent<GameStarted>().score + score;
                    gm.GetComponent<GameStarted>().ThirdGamePlay();
                    break;
                case 3:
                    gm.GetComponent<MainMenu>().currentGame++;
                    gm.GetComponent<GameStarted>().score = gm.GetComponent<GameStarted>().score + score;
                    gm.GetComponent<GameStarted>().FourthGamePlay();
                    break;
                case 4:
                    gm.GetComponent<GameStarted>().score = gm.GetComponent<GameStarted>().score + score;
                    gm.GetComponent<GameStarted>().ClearGames();
                    Instantiate(finalPillarPrefab);
                    break;
            }
        }

        
        if (GameObject.Find("FinalScoreHolder") && final == 1)
        {
            TextMesh mesh = GameObject.Find("FinalScoreHolder").GetComponentInChildren<TextMesh>();
            mesh.text = GameObject.Find("GameManager").GetComponent<GameStarted>().score.ToString();
            Debug.Log(mesh.text);

        }

        if (final < 2)
        {
            final++;
        }
    }

    public void Pressed()
    {
        StartCoroutine(ButtonHit());
    }

    
    IEnumerator ButtonHit()
    {
        Debug.Log("ButtonHit");
        float timeElapsed = 0.0f;

        if(GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().Play();
        }

        if (name.Contains("Cube"))
        {
            while (timeElapsed < 1.5f)
            {
                timeElapsed += Time.deltaTime;
                transform.Translate(0.0f, 0.0f, -0.0001f, Space.Self);

                yield return new WaitForSeconds(0.01f);
            }

            timeElapsed = 0.0f;

            while (timeElapsed < 1.5f)
            {
                timeElapsed += Time.deltaTime;
                transform.Translate(0.0f, 0.0f, 0.0001f, Space.Self);

                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (name.Contains("Cylinder"))
        {
            while (timeElapsed < 1.5f)
            {
                timeElapsed += Time.deltaTime;
                transform.Translate(0.0f, -0.0001f, 0.0f, Space.Self);

                yield return new WaitForSeconds(0.01f);
            }

            timeElapsed = 0.0f;

            while (timeElapsed < 1.5f)
            {
                timeElapsed += Time.deltaTime;
                transform.Translate(0.0f, 0.0001f, 0.0f, Space.Self);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (name.Equals("Next"))
        {
            nextPressed = true;
            GameObject.FindGameObjectWithTag("DeleteCenter").GetComponent<Animator>().SetBool("delete", true);
            MeshRenderer[] a = GameObject.Find("GameFinishedPrefab(Clone)").GetComponentsInChildren<MeshRenderer>();
            
            foreach(MeshRenderer b in a)
            {
                b.enabled = false;
            }

            GameObject.Find("GameFinishedPrefab(Clone)").GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
        else if (name.Equals("Quit"))
        {
            Application.Quit();
        }

        timeElapsed = 0.0f;

        switch (name)
        {
            case "CubeUp":
                while (timeElapsed < 2.0f)
                {
                    timeElapsed += Time.deltaTime;
                    GameObject.Find("AMazeBall").transform.Translate(0.0f, 0.0001f, 0.0f, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case "CubeLeft":
                while (timeElapsed < 2.0f)
                {
                    timeElapsed += Time.deltaTime;
                    GameObject.Find("AMazeBall").transform.Translate(0.0001f, 0.0f, 0.0f, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case "CubeRight":
                while (timeElapsed < 2.0f)
                {
                    timeElapsed += Time.deltaTime;
                    GameObject.Find("AMazeBall").transform.Translate(-0.0001f, 0.0f, 0.0f, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                break;
            case "CubeDown":
                while (timeElapsed < 2.0f)
                {
                    timeElapsed += Time.deltaTime;
                    GameObject.Find("AMazeBall").transform.Translate(0.0f, -0.0001f, 0.0f, 0);
                    yield return new WaitForSeconds(0.01f);
                }
                break;
        }
        
        yield break;
    }  
}
