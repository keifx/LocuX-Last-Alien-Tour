using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallCubeScr : MonoBehaviour
{
    public BoxCollider col;
    public AudioSource src;
    public AudioClip clp;
    public Rigidbody rb;
    bool playOnce;

    public void Start()
    {
        playOnce = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "playerCube")
        {
            col.enabled = false;
        }

        //if (collision.gameObject.tag == "Floor"|| collision.gameObject.tag == "fallCube")
        //{
        //    src.clip = clp;
        //    src.Play();
        //}
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.01f && playOnce)
        {
            src.clip = clp;
            src.Play();
            playOnce = false;
        }
    }
}
