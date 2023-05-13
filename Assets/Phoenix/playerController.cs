using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody _rb;
    public float _moveSpeed = 5f;

    public float jumpForce = 5f;
    public float GroundDistance = .5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] private Transform camFollow;


    private float xInput;
    private float zInput;

    Vector3 forwardRelativeVerticalInput;
    Vector3 rightRelativeVerticalInput;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        CameraFindNewPlayer.instance.FindPlayer(camFollow);
    }


    // Update is called once per frame
    void Update()
    {
        //Inputs
        ProccessInputs();

        Debug.DrawRay(groundCheck.position, -Vector3.up * 0.3f, Color.cyan);
    }

    private void FixedUpdate()
    {
        //movement
        Move();
    }

    private void ProccessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        //testing
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        forwardRelativeVerticalInput = zInput * forward;
        rightRelativeVerticalInput = xInput * right;


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            _rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, -Vector3.up * 0.2f, out hit,0.3f, ground))
        {
            
            
            return true;
        }
        else
        {
            return false;
        }

        
        //return Physics.CheckSphere(groundCheck.position, GroundDistance, ground);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(groundCheck.position, GroundDistance);
    //}

    private void Move()
    {
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput
            + rightRelativeVerticalInput;
        _rb.AddForce(cameraRelativeMovement * _moveSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
