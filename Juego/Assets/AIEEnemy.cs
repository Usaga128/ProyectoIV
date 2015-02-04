using UnityEngine;
using System.Collections;

public class AIEEnemy : MonoBehaviour {


	public float vPlayerDistance;
	NavMeshAgent vNav;
	GameObject vLocalPlayer;
	public float vRotationDamping;
	public float vMoveSpeed;
	public static bool vIsPlayerAlive = true;
	public static bool vEnemyLooked = false;
	public float distanceFromTarget  = 4.0f;
	public Transform vTarget;
	public int vMaxDistance;


	//Ataque
	 


	// Use this for initialization
	void Awake(){
		 vLocalPlayer = GameObject.FindGameObjectWithTag ("Player");
		vTarget = vLocalPlayer.transform;
		vNav = GetComponent<NavMeshAgent>();
	}



	void Start () {
		
	}

	void OnTriggerExit(Collider other){
		//Debug.Log("NO ATACK");
		Animator animator = GameObject.Find("EnemySpider").GetComponent<Animator>();
		animator.SetBool("Bite", false);
	}


	void OnTriggerEnter(Collider other){
		//Debug.Log("ATACK22");
		vNav.Stop (true);

		Animator animator = GameObject.Find("EnemySpider").GetComponent<Animator>();
		animator.SetBool("Bite", true);


	}



	
	// Update is called once per frame
	void Update () {

		if (vIsPlayerAlive) {

			LookAtPlayer();
			vNav.SetDestination(vTarget.position);

		}
	

	}

	void LookAtPlayer(){
		vEnemyLooked = true;
		Quaternion vRotation = Quaternion.LookRotation(vTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,vRotation,Time.deltaTime * vRotationDamping);
		 
	}

	void Chase(){
		Debug.Log("Enemy Aproximate");
		transform.Translate (Vector3.forward * vMoveSpeed * Time.deltaTime);
	}

	void Attack(){

		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.forward,out hit)){
			if(hit.collider.gameObject.tag == "Player"){
				hit.collider.gameObject.GetComponent<HealthPayerScript>().vHealth -= 5f;
		}

	    }

	}


}
