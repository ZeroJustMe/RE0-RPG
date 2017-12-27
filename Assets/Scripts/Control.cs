using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public float HorizontalSpeed, VerticalSpeed;

    GameObject Camera;

    Animator Player;

    // Use this for initialization
    void Start () {
        HorizontalSpeed  = (float)3.8;
        VerticalSpeed    = (float)3.0;

        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player/Animation").GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
        if (H == 0 && V == 0) { Player.SetBool("IfRun", false); return; }

        Player.SetBool("IfRun", true);

        if (H != 0 && (transform.position.x > -10 && H < 0) || (transform.position.x < 30 && H > 0))
        {
            transform.position += new Vector3(H * HorizontalSpeed, 0, 0) * Time.deltaTime;
            if ((Camera.transform.position.x < 19 && transform.position.x >= (Camera.transform.position.x + Camera.GetComponent<Camera>().orthographicSize * 0.75) && H > 0) ||
             (Camera.transform.position.x > 2 && transform.position.x <= (Camera.transform.position.x - Camera.GetComponent<Camera>().orthographicSize * 0.75) && H < 0))
                Camera.transform.position += new Vector3(H * HorizontalSpeed, 0, 0) * Time.deltaTime;
        }

        if (V != 0 && ((transform.position.y < (Camera.transform.position.y + Camera.GetComponent<Camera>().orthographicSize * 0.6) && V > 0) ||
             (transform.position.y > (Camera.transform.position.y - Camera.GetComponent<Camera>().orthographicSize * 0.9) && V < 0)))
            transform.position += new Vector3(0, V * VerticalSpeed, V * VerticalSpeed) * Time.deltaTime;

        if (H > 0)transform.rotation = Quaternion.Euler(0, 0, 0);
        else if(H < 0)transform.rotation = Quaternion.Euler(0, 180f, 0);
    }
}
