using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {
    public float waitingTime;
    public float StartTime;
    private bool dieFlag;

    bool HaveEntered = false;
    
    Vector3 PreCamera, PrePlayer;

    GameObject Enemy = null, Camera, Map2;

    Collider2D Player;

    EnemyController enemyScript;

    // Use this for initialization
    void Start () {
        dieFlag = false;
        Map2 = GameObject.Find("Map2");
        Camera = GameObject.Find("Main Camera");
    }
	
	// Update is called once per frame
	void Update () {
        if(Enemy!=null && enemyScript.HP <= 0 && !dieFlag) {
            StartTime = Time.time;
            dieFlag = true;
}
        if (Enemy != null && dieFlag && Time.time - StartTime >= waitingTime)
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

        Enemy = Instantiate(Resources.Load("Prefebs/Enemy") as GameObject) as GameObject;
        Enemy.transform.localScale = new Vector3((float)0.0073, (float)0.0073, 1);
        Enemy.transform.localPosition = new Vector3((float)5.4, (float)-10, -10);
        enemyScript = Enemy.GetComponent<EnemyController>();
        dieFlag = false;

        Player = other;
        PrePlayer = Player.transform.position;
        Player.transform.localPosition = new Vector3((float)-7, (float)-10, -10);
        
        PreCamera = Camera.transform.position;
        Camera.transform.localPosition = new Vector3(Map2.transform.position.x+2, Map2.transform.position.y, -100);
    }
}
