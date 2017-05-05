using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystem : MonoBehaviour
{
    public GameObject waterScale;

    public int water = 0;
    bool done = false;
    public Material doneMaterial;

    private void Update()
    {

        waterScale.transform.localScale = new Vector3(1.0f, 2.0f * ((float)water / 100.00f), 1.0f);

        if (water >= 1000)
        {
            water = 1000;

            if (!done)
            {
                done = true;
                //Add effect for finishing the bubble. Green light or something similar.
                waterScale.GetComponentInChildren<MeshRenderer>().material = doneMaterial;
                waterScale.GetComponent<AudioSource>().Play();
            }

        }
        
    }

}

