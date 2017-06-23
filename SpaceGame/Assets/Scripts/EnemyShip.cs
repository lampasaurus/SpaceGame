using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Enemy {
    private Rigidbody rb;
    private bool edge;

    private void Start()
    {
        edge = false;
        this.rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 1) * speed;
    }
    private void Update()
    {
        if (edge)
        {
            if(rb.position.x <= -5)
            {
                edge = false;
            }
            rb.velocity = new Vector3(2, 0, 1) * speed;
        }
        else
        {
            if(rb.position.x >= 5)
            {
                edge = true;
            }
            rb.velocity = new Vector3(-2, 0, 1) * speed;
        }
        // if (rb.transform.position.z > 15) Destroy(gameObject);
    }
    private void OnDestroy()
    {

    }
}
