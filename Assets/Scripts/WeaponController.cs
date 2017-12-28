using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    GameObject Weapon,pa;
    Animator Player;
    public float CooldownPA;
    public float CooldownBoom;
    public float FrontMove;
    private float lastFiretime;
    private float UpHand = 0;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player/Animation").GetComponent<Animator>();
        Weapon = GameObject.Find("Player/weapon");
        lastFiretime = -100;
    }
	
	// Update is called once per frame
	void Update () {

        if (UpHand != 0 && Time.time - UpHand >= FrontMove) 
        {
            pa = Instantiate(Resources.Load("Prefebs/PA") as GameObject) as GameObject;
            Vector3 PAPosition = transform.position;
            pa.transform.localPosition = PAPosition;
            UpHand = 0;
        }
        Player.SetBool("Boom", false);
        Player.SetBool("PA", false);
        if (Input.GetKey("j")) {
            if (Time.time > lastFiretime + CooldownPA) {
                Player.SetBool("PA", true);
                Player.SetBool("Boom", false);
                lastFiretime = UpHand = Time.time;
            }
        }
        else if (Input.GetKey("h")) {
            if (Time.time > lastFiretime + CooldownBoom) {
                Player.SetBool("Boom", true);
                Player.SetBool("PA", false);
                GameObject boom = Instantiate(Resources.Load("Prefebs/Boom") as GameObject) as GameObject;
                boom.transform.localPosition = transform.position;
                lastFiretime = Time.time;
            }
        }
        else {
            Player.SetBool("PA", false);
            Player.SetBool("Boom", false);
        }

	}
}
