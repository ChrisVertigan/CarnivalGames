using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        GameObject[] g = GameObject.FindGameObjectsWithTag("WaterTarget");

        foreach (ParticleSystem.Particle a in enter)
        {
            float x = Vector3.Distance(a.position, g[0].transform.position);
            float y = Vector3.Distance(a.position, g[1].transform.position);
            float z = Vector3.Distance(a.position, g[2].transform.position);

            if (x < y && x < z)
            {
                g[0].GetComponent<WaterSystem>().water += 1;
            }
            else if (y < x && y < z)
            {
                g[1].GetComponent<WaterSystem>().water += 1;
            }
            else if (z < x && z < y)
            {
                g[2].GetComponent<WaterSystem>().water += 1;
            }

            ParticleSystem.Particle c = a;
            c.remainingLifetime = 0;
        }
        
    }
}
