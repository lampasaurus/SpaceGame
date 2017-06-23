using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Enemy {

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 1) * speed;
    }
    private void FixedUpdate()
    {
       // if (rb.transform.position.z > 15) Destroy(gameObject);
    }
    private void OnDestroy()
    {
        
    }
}
