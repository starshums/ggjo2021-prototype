using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float movHor;
    float movVer;
    Vector3 movement;
    Rigidbody rb;
    [SerializeField] float speed = 1000f;
    Animator animator;
    Camera cam;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        animator = GetComponentInChildren<Animator> ();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        Movement ();
        Shoot ();
    }

    void Movement () {
        movHor = Input.GetAxis ("Horizontal");
        movVer = Input.GetAxis ("Vertical");
        movement = new Vector3 (movHor, 0, movVer);
        rb.velocity = movement * Time.deltaTime * speed;
        //rb.AddForce(movement * Time.fixedDeltaTime * speed, ForceMode.Impulse);

        Vector3 vel = rb.velocity;
        if (vel.magnitude == 0) {
            animator.SetTrigger ("Idle");
        } else {
            animator.SetTrigger ("Run");
        }
    }
    void Shoot () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            //Throw Bomb
            animator.SetTrigger ("Attack");
        }
    }
}