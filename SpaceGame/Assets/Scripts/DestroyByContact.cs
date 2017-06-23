using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController controller;
    private Enemy enemy;
    
    private void Start()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
    }
    private void OnDestroy()
    {
        
    }
}
