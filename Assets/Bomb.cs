using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;
    public float radius = 5f;
    public float explosionForce = 500f;

    public float delay = 3f;
    public float countdown;

    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        //Show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);
        
        //get nearby objects
        Collider[] nearbyObjectsColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in nearbyObjectsColliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add force
                rb.AddExplosionForce(explosionForce, transform.position, radius);
                //damage
            }


        }

        //destroy grenade
        Destroy(gameObject);
    }
}
