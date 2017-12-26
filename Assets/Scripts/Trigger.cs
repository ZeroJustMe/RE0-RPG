using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    bool HaveEntered = false;

    float StartTime, NowTime;

    Vector3 PreCamera, PrePlayer;

    GameObject Enemy = null, Camera;
    Collider2D Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        NowTime = Time.time;
        if (Enemy != null && NowTime - StartTime >= 5)
        {
            Camera.transform.position = PreCamera;
            Player.transform.position = PrePlayer;
            Destroy(Enemy);
            HaveEntered = true;
            Enemy = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (HaveEntered) { HaveEntered = false; return;}
        StartTime = Time.time;

        Enemy = Instantiate(Resources.Load("Prefebs/Enemy") as GameObject) as GameObject;
        Enemy.transform.localScale = new Vector3((float)0.0073, (float)0.0073, 1);
        Enemy.transform.localPosition = new Vector3((float)5.4, (float)-10, -10);

        Player = other;
        PrePlayer = Player.transform.position;
        Player.transform.localPosition = new Vector3((float)-7, (float)-10, -10);

        Camera = GameObject.Find("Main Camera");
        PreCamera = Camera.transform.position;
        Camera.transform.localPosition = new Vector3((float)0, (float)-10, -100);
    }
}
