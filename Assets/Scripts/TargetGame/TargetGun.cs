using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGun : MonoBehaviour {

    public GameObject bullet;
    UnityEngine.Events.UnityAction action;

    void Update () {

        if (transform.parent == null)
        {
            if (GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().GraspingHandCount > 0)
            {
                //if (GameObject.Find("HandAttachments-R"))
                    //GameObject.Find("HandAttachments-R").GetComponentInChildren<GunSpawn>().GunStart("Target");
                //else if (GameObject.Find("HandAttachments-L"))
                    //GameObject.Find("HandAttachments-L").GetComponentInChildren<GunSpawn>().GunStart("Target");
                Destroy(gameObject);
            }
            else
            {
                transform.Rotate(1.0f, 0.0f, 0.0f);
            }
        }
        else
        {
            if(transform.parent.gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void Shoot()
    {
        GameObject a = Instantiate(bullet, transform);
        Rigidbody rb = a.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddRelativeForce(transform.parent.forward * 5);
        a.transform.localPosition = Vector3.zero;
        a.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        a.transform.SetParent(null);
    }
}
