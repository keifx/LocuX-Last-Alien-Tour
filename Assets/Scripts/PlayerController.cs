using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Rigidbody rbAnimate;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 360;

    private Animator animator;
    private float idle = 0;
    private Vector3 _input;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    bool grounded;

    public AudioSource audioSrc;
    public AudioSource moveSrc;
    public AudioClip moveSfx, jumpSfx;
    private void Start()
    {
        readyToJump = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        GatherInput();
        Look();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.Space) && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
            print("LOMPAT");
            audioSrc.clip = jumpSfx;
            audioSrc.Play();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
        {
            
            //moveSrc.enabled = true;
        }
        else
        {
            //moveSrc.enabled = false;
        }


    }

    void Look()
    {
        if(_input != Vector3.zero)
        {
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation,rot, turnSpeed * Time.deltaTime);
        }
    }

    private void Move()
    {
        var newPosition = transform.position + (_input * speed * Time.deltaTime);
        rb.velocity += _input * speed;
        rb.AddForce(newPosition, ForceMode.Force);

        rbAnimate.velocity += _input * speed;
        rbAnimate.AddForce(newPosition, ForceMode.Force);

        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            idle = 0;
        }
        else
        {
            idle += 0.001f;
        }

        animator.SetFloat("speed", velocity.z);
        animator.SetFloat("idle", idle);
    }

    private void Jump()
    {
        // reset y velocity
        var newPosition = transform.up * jumpForce;
        rb.velocity += newPosition;
        rb.AddForce(newPosition, ForceMode.Force);
        rbAnimate.velocity += newPosition;
        rbAnimate.AddForce(newPosition, ForceMode.Force);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
