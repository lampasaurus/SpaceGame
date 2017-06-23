using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactPlayerWeapons : MonoBehaviour {
    public GameObject explosion;
    private GameController controller;
    private Enemy enemy;
    // Use this for initialization
    void Start () {
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

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent<Mover>();
            if (enemy.life >= 0)
            {
                enemy.life--;
            }
            if (enemy.life < 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                controller.AddScore(enemy.scoreValue);
            }
        }
        if (other.tag == "Player" && gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

        }
    }
}
