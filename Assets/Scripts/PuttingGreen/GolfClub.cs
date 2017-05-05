using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClub : MonoBehaviour {

    public float torque = 2f;
    public float startingY = -0.2f;
    public float tempz = 0.21f;
    Rigidbody rb;
    bool swung = false;

    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {

        Vector3 temp = Input.mousePosition;

        temp.y = startingY;
        temp.z = tempz;

        transform.position = Camera.main.ScreenToWorldPoint(temp);
        transform.position = new Vector3(transform.position.x, startingY, transform.position.z);

        /*Vector3 a = GameObject.Find("HandleJoint").transform.rotation.eulerAngles;
        a = new Vector3((tempy / 8f), a.y, a.z);

        GameObject.Find("HandleJoint").transform.rotation = Quaternion.Euler(a);*/

        if (!swung)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Swing");
                rb.AddTorque(Vector3.right * torque);
                swung = true;
            }
        }
        
        if (transform.rotation.eulerAngles.x >= 80)
        {
            if (swung)
            {
                Debug.Log("SwingFinished");
                rb.AddTorque(Vector3.left * (torque * 2));
                swung = false;
            }
        }

        if(transform.rotation.eulerAngles.x >= 350)
        {
            Debug.Log("Stopping");
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }




            
    }


    
}
