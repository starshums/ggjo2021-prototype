using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    float movHor;
    float movVer;
    Vector3 movement;
    Rigidbody rb;
    [SerializeField] float speed = 10;

    [Header("Bomb Settings")]
    public GameObject bombPrefab;
    public Transform bombSpawnLocation;
    [SerializeField] float bombThrowForce = 350f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Movement();
        ThrowBomb();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
        }
    }

    void Movement()
    {
        movHor = Input.GetAxis("Horizontal");
        movVer = Input.GetAxis("Vertical");
        movement = new Vector3(movHor, 0, movVer);
        rb.velocity = movement * speed;
        //rb.AddForce(movement * Time.fixedDeltaTime * speed, ForceMode.Impulse);
    }
    void ThrowBomb()
    {
        if (Input.GetButtonDown("Bomb"))
        {
            //Throw Bomb
            GameObject bomb = Instantiate(bombPrefab, bombSpawnLocation.position, bombSpawnLocation.rotation);
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddForce(bombSpawnLocation.forward * bombThrowForce);
            }
        }
    }
}
