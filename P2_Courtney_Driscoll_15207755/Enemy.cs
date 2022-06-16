//Courtney Driscoll 15207755
//Code for the Enemy Riding the other Merry Go Round

using UnityEngine;
using System.Collections;
    public class Eenemy : MonoBehaviour
{

    private Animator anim2;
    public enum State
    {
        SIT,
        THROW,
        DUCK
    }
    private bool alive;
    public State state;
    public GameObject[] waypoints;
    GameObject prefab;
    private Vector3 direction; 
    // Use this for initialization
    void Start()
    {
        prefab = Resources.Load("enemy_coconut") as GameObject;
        anim2 = gameObject.GetComponentInChildren<Animator>();
        character = GetComponent<ThirdPersonCharacter>();
        alive = true;
        state = basicAI.State.SIT;
        StartCoroutine("FMS");
    }
    IEnumerator FMS()
    {
        while (alive)
        {
            switch (state)
            {
                case State.SIT:
                    SIT();
                    break;
                case State.THROW:
                    THROW();
                    break;
                case State.DUCK:
                    DUCK();
                    break;
            }
        }
    }
    void SIT()
    {
        anim2.SetInteger("AnimPar2", 2);
    }

    void THROW()
    {
        anim2.SetInteger("AnimPar2", 3);
        GameObject enemy_coconut = Instantiate(prefab) as GameObject;
        enemy_coconut.transform.position = transform.position;
        Rigidbody rb = enemy_coconut.GetComponent<Rigidbody>();
        //where direction is facing the ememys position
        rb.velocity = direction * 40;
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            state = SIT;
        }
    }

    void DUCK()
    {
        anim2.SetInteger("AnimPar2", 1);
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("DUCK"))
        {
            state = SIT;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "player_coconut")
        {
            state = DUCK;
        }
        if (coll.tag == "player")
        {
            target = coll.GameObject;
            state = THROW;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "player_coconut")
        {
            Destroy(col.gameObject);
            GameStatus.PlayerScore += 10;
        }

    }
}
