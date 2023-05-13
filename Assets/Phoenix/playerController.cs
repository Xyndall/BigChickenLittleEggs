using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody _rb;
    public float _moveSpeed = 5f;

    public float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    private float xInput;
    private float zInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
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

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            _rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void Move()
    {
        _rb.AddForce(new Vector3(xInput, 0f, zInput) * _moveSpeed);
    }
}
