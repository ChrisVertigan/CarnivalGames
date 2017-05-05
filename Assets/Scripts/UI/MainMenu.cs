using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public int GameOne = 0, GameTwo = 0, GameThree = 0, GameFour = 0, score = 0;
    public int currentGame = 1;
    public GameObject GameUI, charPrefab;
    bool TestingBool = false; //REMOVE when Leap returned.
    

	void Start ()
    {
        Time.timeScale = 0;
	}
	
	void Update ()
    {
        if (!TestingBool)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TestingBool = true;
                PlayClicked();
            }
        }
	}

    public void PlayClicked()
    {
        StartCoroutine(PlayCoroutine());
    }

    IEnumerator PlayCoroutine()
    {
        Time.timeScale = 1;
        float MenuTimeElapsed = 0.0f;
        GameObject modelWrapper = GameObject.Find("MenuModelWrapper");

        while (MenuTimeElapsed < 3.0f)
        {
            MenuTimeElapsed += Time.deltaTime;

            modelWrapper.transform.Translate(0.0f, -0.01f, 0.0f, 0);

            yield return new WaitForSeconds(0.01f);
        }

        Destroy(modelWrapper);

        GameOne = Random.Range(0, 4);
        GameTwo = Random.Range(0, 4);
        while (GameTwo.Equals(GameOne))
        {
            GameTwo = Random.Range(0, 4);
        }

        GameThree = Random.Range(0, 4);

        while (GameThree.Equals(GameOne) || GameThree.Equals(GameTwo))
        {
            GameThree = Random.Range(0, 4);
        }

        GameFour = Random.Range(0, 4);

        while(GameFour.Equals(GameOne) || GameFour.Equals(GameTwo) || GameFour.Equals(GameThree))
        {
            GameFour = Random.Range(0, 4);
        }

        Debug.Log(GameOne + " " + GameTwo + " " + GameThree + " " + GameFour);

        GetComponent<GameStarted>().FirstGamePlay(GameOne, GameTwo, GameThree, GameFour);

        yield break;
    }

    public void OptionsClicked()
    {

    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    public void ScrollingText(string temp)
    {
        Debug.Log("ScrollingText");
        StartCoroutine(CreateScrollingText(temp));
    }

    IEnumerator CreateScrollingText(string temp)
    {
        char[] characters = new char[temp.Length];
        int i = 0;

        foreach (char a in temp)
        {
            characters[i] = a;
            i++;
        }

        i = 0;

        foreach (char a in characters)
        {
            GameObject b = Instantiate(charPrefab, GameObject.Find("ScrollHolder").transform);
            b.GetComponent<TextMesh>().text = characters[i].ToString();

            if(GameObject.Find("PuttingSpawner(Clone)"))
            {
                b.transform.localPosition = new Vector3(0.0f, -0.1f, -0.0045f);
                b.GetComponent<TextMesh>().characterSize = b.GetComponent<TextMesh>().characterSize / 3;
                yield return new WaitForSeconds(0.7f);
            }
            else
            {
                b.transform.localPosition = new Vector3(0.0f, 0.03f, -0.2f);
                b.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
                b.GetComponent<TextMesh>().characterSize = b.GetComponent<TextMesh>().characterSize / 4;
                yield return new WaitForSeconds(0.7f);
            }
            i++;

        }

        yield break;
    }
}
