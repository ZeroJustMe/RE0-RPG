using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float MaxHP;
    public float StartTime;
    public float HP;

    private bool dieFlag;
    
    Animator enemyAnim;
    // Use this for initialization
	void Start () {
        HP = MaxHP;
        dieFlag = false;
        enemyAnim = transform.Find("Animation").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0 && !dieFlag) {
            enemyAnim.SetBool("die", true);
            dieFlag = true;
            StartTime = Time.time;
        }
        else if (!dieFlag) {
            enemyAnim.SetBool("die", false);
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Damage") {
            if (other.name == "PA(Clone)") {
                HP -= 33.4f;
                Destroy(other);
            }
            else if (other.name == "Boom(Clone)") {
                HP -= 100f;
                Destroy(other);
            }
        }
    }

}
