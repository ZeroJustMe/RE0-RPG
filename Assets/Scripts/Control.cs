using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public float HorizontalSpeed, VerticalSpeed;

    Animator Player;

    // Use this for initialization
    void Start () {
        HorizontalSpeed  = (float)3.8;
        VerticalSpeed    = (float)3.0;

        Player = GameObject.Find("Player/Animation").GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        if (H == 0 && V == 0) { Player.SetBool("IfRun", false); return; }

        Player.SetBool("IfRun", true);
        transform.position += new Vector3(H * HorizontalSpeed, V * VerticalSpeed, V * VerticalSpeed) * Time.deltaTime;

        if (H > 0)transform.rotation = Quaternion.Euler(0, 0, 0);
        else if(H < 0)transform.rotation = Quaternion.Euler(0, 180f, 0);
    }
}
