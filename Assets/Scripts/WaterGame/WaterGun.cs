using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour {

    public GameObject secondFinger;

    private void Start()
    {
        ParticleSystem.TriggerModule t = GetComponentInChildren<ParticleSystem>().trigger;
        GameObject[] g = GameObject.FindGameObjectsWithTag("WaterTarget");
        SphereCollider[] colliders = new SphereCollider[g.Length];

        int i = 0;
        foreach (GameObject a in g)
        {
            colliders[i] = a.GetComponent<SphereCollider>();
            i++;
        }


        i = 0;
        foreach (SphereCollider a in colliders)
        {
            t.SetCollider(i, a);
            i++;
        }

        secondFinger = GameObject.FindGameObjectWithTag("IndexBoneR2");
    }

    void Update() {

        if (transform.parent == null)
        {
            //GetComponentInChildren<ParticleSystem>().Stop();
            //if (GetComponent<Leap.Unity.Interaction.InteractionBehaviour>().GraspingHandCount > 0)
            //{
              //  Shoot();
            //}

            //transform.Rotate(1f, 0.0f, 0.0f);
        }
        else
        {
           
        }


    }

    public void Shoot()
    {
        //TODO - Slow Particles down to something managable and make them smaller, too.
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Debug.Log(ps.isPlaying);
        if (!ps.isStopped)
        {
            Debug.Log("Playing - Stopping Now.");
            ps.Stop(false, 0);
            
        }
        else
        {
            Debug.Log("Stopped - Starting Again.");
            //ps.Play();
        }

    }
}
