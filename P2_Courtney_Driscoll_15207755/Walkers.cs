//Courtney Driscoll 15207755
//Code for bystanders on walking around

using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class Walkers : MonoBehaviour
    {
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public enum State
    {
        FAST,
        SLOW
    }
    private bool alive;
    public State state; 
    public GameObject[] waypoints;
    public int waypointInd;
    public float FastSpeed = 1.0f;
    public float SlowSpeed = 0.5f;
        // Use this for initialization
        void Start()
        {
        agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
        agent.updatePosition = true;
        agent.updateRotation = false;
            waypoints = GameObjects.FindGameObjectsWithTag("Waypoints");
            waypointInd = Random.Range(0, waypoints.Length);
        alive = true;
        state = basicAI.State.SLOW;
        StartCoroutine("FMS");
        }
        IEnumerator FMS()
        {
            while(alive)
            {
            switch (state)
            {
                case State.SLOW;
                    FAST();
                    break;
                case State.FAST;
                    SLOW();
                    break;
            }
            }
        }
    void SLOW()
    {
        agent.speed = SlowSpeed;
            walk();
    }

    void FAST()
    {
        agent.speed = FastSpeed;
            walk();
            state = basicAI.State.SLOW;
    }

        void OnTriggerEnter(Collider coll)
        {
            if (coll.tag == "enemy_coconut" || coll.tag == "player_coconut")
            {
                state = basicAI.State.FAST;
            }
        }

        void walk()
        {
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd = Random.Range(0, waypoints.Length);
            }
            else
            {
                character.Move(Vecore3.zero, false, false);
            }
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "player_coconut")
            {
                Destroy(col.gameObject);
                GameStatus.PlayerScore -= 5;
            }
            if (col.gameObject.name == "enemy_coconut")
            {
                Destroy(col.gameObject);
                GameStatus.EnemyScore -= 5;
            }

        }

    }
}

