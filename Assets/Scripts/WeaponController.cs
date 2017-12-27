using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    GameObject Weapon;
    Animator Player;
    public float CooldownPA;
    public float CooldownBoom;
    private float lastFiretime;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player/Animation").GetComponent<Animator>();
        Weapon = GameObject.Find("Player/weapon");
        lastFiretime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 wpPosition = transform.position;
        Player.SetBool("Boom", false);
        Player.SetBool("PA", false);
        if (Input.GetKey("j")) {
            if (Time.time > lastFiretime + CooldownPA) {

                Player.SetBool("PA", true);
                Player.SetBool("Boom", false);
                GameObject pa = Instantiate(Resources.Load("Prefebs/PA") as GameObject) as GameObject;
                Vector3 PAPosition =wpPosition - new Vector3(0.2f,0,0);
                pa.transform.localPosition = PAPosition;
                lastFiretime = Time.time;
            }
        }
        else if (Input.GetKey("h")) {
            if (Time.time > lastFiretime + CooldownBoom) {
                Player.SetBool("Boom", true);
                Player.SetBool("PA", false);
                GameObject boom = Instantiate(Resources.Load("Prefebs/Boom") as GameObject) as GameObject;
                boom.transform.localPosition = wpPosition;
                lastFiretime = Time.time;
            }
        }
        else {
            Player.SetBool("PA", false);
            Player.SetBool("Boom", false);
        }

	}
}
