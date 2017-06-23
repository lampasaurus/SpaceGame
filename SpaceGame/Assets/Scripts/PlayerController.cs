using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
    public float speed;
    public float tilt;
    public float fireRate;
    private float nextFire;

    private Rigidbody rb;
    private GameController controller;
    public Boundry boundry;
    public GameObject shot;
    public GameObject player;
    public Transform shotSpawn;



 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            controller = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find GameController script");
        }
    }
    private void OnDestroy()
    {
        controller.Died();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.velocity = movement;
        if (moveHorizontal == moveVertical && moveHorizontal == 0) rb.velocity = new Vector3(0, 0, 0);
        Rotation();
        Clamp();
    }
    void Rotation()
    {
        rb.transform.rotation = Quaternion.Euler(rb.velocity.z, 0, rb.velocity.x * -tilt);
    }
    void Clamp()
    {
        if (transform.position.x > boundry.xMax)
        {
            GetComponent<Rigidbody>().position = new Vector3(boundry.xMax, 0, transform.position.z);
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
        }
        if (transform.position.x < boundry.xMin)
        {
            GetComponent<Rigidbody>().position = new Vector3(boundry.xMin, 0, transform.position.z);
            rb.AddForce(new Vector3(1, 0, 0) * speed);
        }
        if (transform.position.z > boundry.zMax)
        {
            GetComponent<Rigidbody>().position = new Vector3(transform.position.x, 0, boundry.zMax);
            rb.AddForce(new Vector3(0, 0, -1) * speed);
        }
        if (transform.position.z < boundry.zMin)
        {
            GetComponent<Rigidbody>().position = new Vector3(transform.position.x, 0, boundry.zMin);
            rb.AddForce(new Vector3(0, 0, 1) * speed);
        }
    }
}
