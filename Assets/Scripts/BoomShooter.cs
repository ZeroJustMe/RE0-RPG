using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomShooter : MonoBehaviour {
    public float speed = 10f;
    public float lifeTime = 0.5f;
    public float dist = 100;

    private float spawnTime;
    private int zsFlag;

    GameObject player;
    // Use this for initialization
	void Start () {
        spawnTime = Time.time;

        player = GameObject.Find("Player");
        if (player.transform.rotation.y == 0) zsFlag = 1;
        else zsFlag = -1;
    }
	
	// Update is called once per frame
	void Update () {     
        Vector3 move = new Vector3(zsFlag, 0, 0) * speed * Time.deltaTime;
        dist -= speed * Time.deltaTime;
        transform.position += move;
        if(Time.time-spawnTime>lifeTime || dist < 0) {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other) {
    
    }
}
