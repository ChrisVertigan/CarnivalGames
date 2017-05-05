using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour {

    bool respawned = false, sound = false;
    public GameObject bullet;


	void Start () {

        GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().useGravity = true;
	}
	

	void Update () {
        
        if(GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().GraspingHandCount > 0 && !sound)
        {
            sound = true;
            StartCoroutine(PickedUp());
        }

    }

    IEnumerator PickedUp()
    {
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2.0f);

        sound = false;

        yield break;
    }

    private void OnTriggerExit(Collider other)
    {
        int a = GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().GraspingHandCount;

        if (!respawned)
        {
            if (a > 0 && other.tag.Equals("RespawnWall"))
            {
                respawned = true;
                Instantiate(bullet, GameObject.Find("SpawnHole").transform.position + new Vector3(0.0f, 0.2f, 0.05f), Quaternion.Euler(Vector3.zero));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("DeadWalls"))
        {
            Debug.Log("dead");
            if(GameObject.FindGameObjectsWithTag("TargetBall").Length <= 1)
            {
                Instantiate(bullet, GameObject.Find("SpawnHole").transform.position + new Vector3(0.0f, 0.2f, 0.05f), Quaternion.Euler(Vector3.zero));
            }
            Destroy(gameObject);
        }
    }
}
