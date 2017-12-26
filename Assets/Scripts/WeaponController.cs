using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    GameObject Weapon;
    Animator Player;
    public float frequencyPA;
    public float frequencyBoom;
    private float lastFiretime;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player/Animation").GetComponent<Animator>();
        Weapon = GameObject.Find("Player/weapon");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 wpPosition = transform.position;
        if (Input.GetKey("j")) {
        //    if(Time.time>lastFiretime)
            Player.SetBool("PA", true);
            Player.SetBool("Boom", false);
            GameObject pa = Instantiate(Resources.Load("Prefebs/PA") as GameObject) as GameObject;
            pa.transform.localPosition = wpPosition;
        }
        else if (Input.GetKey("h")) {
            Player.SetBool("Boom", true);
            Player.SetBool("PA", false);
            GameObject boom = Instantiate(Resources.Load("Prefebs/Boom") as GameObject) as GameObject;
            boom.transform.localPosition = wpPosition;
        }
        else {
            Player.SetBool("PA", false);
            Player.SetBool("Boom", false);
        }

	}
}
