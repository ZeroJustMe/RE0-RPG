using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float MaxHP;
    public float HP;

    private float Lifelong;
    private bool dieFlag;

    GameObject Life;
    Animator enemyAnim;
    // Use this for initialization
	void Start () {
        HP = MaxHP;
        dieFlag = false;
        enemyAnim = transform.Find("Animation").GetComponent<Animator>();
        Life = GameObject.Find("Enemy(Clone)/Life");
        Lifelong = Life.transform.localScale.x;
    }
	private float Max(float a,float b) {
        if (a > b) return a;
        return b;
    }
	// Update is called once per frame
	void Update () {
        Vector3 nowLifelong = new Vector3(Lifelong*(Max(HP,0)/MaxHP),Life.transform.localScale.y,Life.transform.localScale.z);
        Life.transform.localScale = nowLifelong;
        if (HP <= 0 && !dieFlag) {
            enemyAnim.SetBool("die", true);
            dieFlag = true;
        }
        else if (!dieFlag) {
            enemyAnim.SetBool("die", false);
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Damage") {
            if (other.name == "PA(Clone)") {
                HP -= 33.4f;
                Destroy(other.gameObject);
            }
            else if (other.name == "Boom(Clone)") {
                HP -= 100f;
                Destroy(other.gameObject);
            }
        }
    }

}
