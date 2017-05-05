using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawn : MonoBehaviour {

    public GameObject waterGun, targetGun;

    public void GunStart (string gunType) {

        GameObject a;
        switch (gunType)
        {
            case "Water":
                a = Instantiate(waterGun, transform);
                a.transform.localPosition = transform.localPosition;
                GameObject.Find("HandModels").GetComponentInChildren<Leap.Unity.FingerDirectionDetector>().OnActivate.AddListener(a.GetComponent<WaterGun>().Shoot);
                break;
            case "Target":
                a = Instantiate(targetGun, transform);
                a.transform.localPosition = transform.localPosition;
                GameObject.Find("HandModels").GetComponentInChildren<Leap.Unity.FingerDirectionDetector>().OnActivate.AddListener(a.GetComponent<TargetGun>().Shoot);
                break;
        }
        
	}
	
}
