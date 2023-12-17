using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<Rigidbody>().velocity = new Vector3 (0,0,-5); // x, y, z
        // GetComponent<Rigidbody>().angularVelocity = new Vector3 (4,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(teleShot.telekStatus == "shoot"){
            // Debug.Log("shoot teleMove");
            GetComponent<Rigidbody>().velocity = new Vector3 (0,0,8);
            teleShot.telekStatus = "n";
        }
    }

    void OnTriggerEnter(Collider other){
        if ( other.name == "buffer"){
            GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
            teleShot.telekStatus = "y";
        }
        if ( other.name == "teleshot"){
            GetComponent<Rigidbody>().velocity = new Vector3 (0,0,-5);
            GetComponent<Rigidbody>().angularVelocity = new Vector3 (4,0,0);
            transform.eulerAngles = new Vector3(0,camControl.camRotate,0);
            // GetComponent<Rigidbody>().AddRelativeForce(0,0,300);
        }
    }
}
