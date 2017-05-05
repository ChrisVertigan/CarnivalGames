using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

    public GameObject golfBall;

    void Start()
    {

    }

    void Update () {
	
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Plays when hit the 
        if(collision.collider.tag.Equals("GolfHole"))
        {
            Instantiate(golfBall);
            collision.collider.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

        //Plays when hit.
        if(collision.collider.name.Contains("bone"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
