using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody _rb;
    public float _moveSpeed = 5f;

    public float jumpForce = 5f;

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
        return Physics.CheckSphere(groundCheck.position, .3f, ground);
    }

    private void Move()
    {
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput
            + rightRelativeVerticalInput;
        _rb.AddForce(cameraRelativeMovement * _moveSpeed);
    }
}
