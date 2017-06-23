using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIn5Seconds : MonoBehaviour {
    private float startTime;
    
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (startTime + 5 < Time.time) Destroy(gameObject);
	}
}
