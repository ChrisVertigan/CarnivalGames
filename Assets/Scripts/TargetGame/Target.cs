using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public bool lit, sequence, swapped = false;
    
    private void Start()
    {
        int rand = Random.Range(0, 2);
        if(rand.Equals(0))
        {
            swapped = true;
        }
        else
        {
            swapped = false;
        }
        
    }

    void Update () {
		
        if(transform.parent.parent.GetComponent<Animator>().GetBool("Hit"))
        {
            if(transform.parent.parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HitAnim"))
            {
                transform.parent.parent.GetComponent<Animator>().SetBool("Hit", false);
            }
        }

        if (sequence && !lit)
        {
            transform.parent.GetComponentInChildren<Light>().intensity = 1;
            lit = true;
        }

        TargetMovement();
        
    }

    void TargetMovement()
    {
        if (!swapped)
        {
            transform.parent.parent.Translate(0.0f, 0.0f, 0.008f);
        }
        else
        {
            transform.parent.parent.Translate(0.0f, 0.0f, -0.008f);
        }

        if(transform.position.x >= 0.76)
        {
            swapped = true;
        }
        else if (transform.position.x <= -0.8)
        {
            swapped = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag.Equals("TargetBall"))
        {
            transform.parent.parent.GetComponent<Animator>().SetBool("Hit", true);
            GameObject.Find("TargetSpawner(Clone)").GetComponent<TargetSpawner>().score += 1;
            if(GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
