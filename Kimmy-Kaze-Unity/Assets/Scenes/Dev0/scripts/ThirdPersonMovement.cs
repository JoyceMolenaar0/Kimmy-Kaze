using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    //GroundDetect GroundDetect;

    public CharacterController controller;

    public float speed = 6;
    //GroundDetect isGrounded;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;

    //Jump Stuff
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;
    
    public float jumpHeight = 3;

    //new ground detect

    private float rayLength = 2.1f;  // De lengte van de ray (iets langer dan de afstand van het object tot de grond)
    public LayerMask groundLayer;   // De laag van de grond (optioneel, kan gebruikt worden om specifiek te controleren op de grond)
    [SerializeField] private bool isGrounded;        // Variabele om te controleren of het object op de grond staat




    //Dash & Movement
    public Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfGrounded();

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Jump
        /*
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        } 
        */

        
    {
        
    }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void CheckIfGrounded()
    {
        // Raycast vanaf het midden van het object, recht naar beneden
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength, groundLayer))
        {
            isGrounded = true;
            Debug.Log("Op de grond!");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Niet op de grond.");
        }
        // Debugging Ray om te zien waar de Raycast gaat
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
    }



}
