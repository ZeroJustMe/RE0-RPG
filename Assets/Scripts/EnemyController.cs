using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float MaxHP;
    public float HP;

    private float Lifelong;
    private float StartPosition;
    private bool dieFlag;

    GameObject Life;
    Animator enemyAnim;
    // Use this for initialization
	void Start () {
        HP = MaxHP;
        dieFlag = false;
        enemyAnim = transform.Find("Animation").GetComponent<Animator>();
        Life = GameObject.Find("Enemy(Clone)/Life/Rest");
        Lifelong = Life.transform.localScale.x;
        StartPosition = Life.transform.localPosition.x;
    }
	private float Max(float a,float b) {
        if (a > b) return a;
        return b;
    }
	// Update is called once per frame
	void Update () {
        if (HP <= 0 && !dieFlag) {
            enemyAnim.SetBool("die", true);
            dieFlag = true;
            Destroy(GetComponent<BoxCollider>());
        }
        else if (!dieFlag) {
            enemyAnim.SetBool("die", false);
        }
	}

    public void ModifyHP()
    {
        Vector3 nowLifelong = new Vector3(Lifelong * (Max(HP, 0) / MaxHP), Life.transform.localScale.y, Life.transform.localScale.z);
        Life.transform.localScale = nowLifelong;
        Life.transform.localPosition = new Vector3(StartPosition - (1 - Max(HP, 0) / MaxHP)*60, Life.transform.localPosition.y, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Damage") {
            if (other.name == "PA(Clone)") {
                HP -= 34f;
                Destroy(other.gameObject);
            }
            else if (other.name == "Boom(Clone)") {
                HP -= 100f;
                Destroy(other.gameObject);
            }
            ModifyHP();
        }
    }

}
