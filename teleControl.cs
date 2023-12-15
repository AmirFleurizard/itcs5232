using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "teleshot";
        // GetComponent<Rigidbody>().velocity = new Vector3 (0,0,9);
        GetComponent<Rigidbody>().AddRelativeForce(0,0,300);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
