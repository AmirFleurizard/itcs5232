using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleShot : MonoBehaviour
{
    public Transform teleObj;
    public static string telekStatus = "n";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//(Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
    Debug.Log("teleShot updated");
        if((Input.GetMouseButtonDown(0)) && (telekStatus == "n")){
            Instantiate(teleObj, transform.position, transform.rotation);
            telekStatus = "wait";
            // Debug.Log("wait");
        }
        if((Input.GetMouseButtonDown(0)) && (telekStatus == "y")){
            // Instantiate(teleObj, transform.position, teleObj.rotation);
            telekStatus = "shoot";
            // Debug.Log("shoot");
            // it probably doesnt shoot because the obj is shooting out at the same time the teleShot is shooting out so
            // the obj is getting shot and brought back at the same time.
        }
    }

}
