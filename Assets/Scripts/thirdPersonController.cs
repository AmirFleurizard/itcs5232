using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thirdPersonController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    private Animator animator;
    

    public float normalSpeed = 6f;
    public float boostedSpeed = 10f;
    private float currentSpeed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
        
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = boostedSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
        

        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        if (!isMoving)
        {
            animator.SetFloat("Speed_f", 0f);
        }else{
            animator.SetFloat("Speed_f", currentSpeed/10);
        }


        if (Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene("LoseScene");
        }
        if (Input.GetKey(KeyCode.K))
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy_HoverBot"))
    //     {
    //         Debug.Log("Player collided with Enemy_HoverBot");
    //         SceneManager.LoadScene("LoseScene");
    //     }
    // }
}
