//Courtney Driscoll 15207755
//Code for the character player on the Merry Go Round 

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Animator anim;
	private CharacterController controller;
	public float turnSpeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	GameObject prefab; 
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("player_coconut") as GameObject;
		anim = gameObject.GetComponentInChildren<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("space")) {
			anim.SetInteger ("AnimPar", 1);
		} else if (Input.GetKey ("c")) {
			anim.SetInteger ("AnimPar", 2);
			GameObject player_coconut = Instantiate (prefab) as GameObject;
            player_coconut.transform.position = transform.position + Camera.main.transform.forward * 2;
			Rigidbody rb = player_coconut.GetComponent<Rigidbody> ();
			rb.velocity = Camera.main.transform.forward * 40;
		} else if (this.anim.GetCurrentAnimatorStateInfo (0).IsName ("Throw")) {
			anim.SetInteger ("AnimPar", 0);
		}
		float turn = Input.GetAxis ("Horizontal");
		transform.Rotate (0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "enemy_coconut") {
			Destroy (col.gameObject);
			GameStatus.EnemyScore += 10;
		}
			
	}

}
