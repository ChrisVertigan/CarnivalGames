using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour {
    
	void Start () {
        

    }
	
	void Update () {

        transform.Translate(-0.001f, 0.0f, 0.0f, Space.Self);

        if(GameObject.Find("WaterSpawner(Clone)") || GameObject.Find("TargetSpawner(Clone)"))
        {
            if(transform.localPosition.x < -1.968043f)
            {
                GameObject a = Instantiate(gameObject, GameObject.Find("ScrollHolder").transform);
                a.transform.localPosition = new Vector3(0.0f, 0.03f, -0.2f);
                Destroy(gameObject);
            }
        }
        else if (GameObject.Find("PuttingSpawner(Clone)"))
        {
            if (transform.localPosition.x < -0.541f)
            {
                GameObject a = Instantiate(gameObject, GameObject.Find("ScrollHolder").transform);
                a.transform.localPosition = new Vector3(0.0f, -0.1f, -0.0045f);
                Destroy(gameObject);
            }
        }
    }
}
