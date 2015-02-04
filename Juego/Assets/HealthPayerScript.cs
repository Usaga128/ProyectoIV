using UnityEngine;
using System.Collections;

public class HealthPayerScript : MonoBehaviour {

	public float vHealth;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(vHealth < 0f){
			AIEEnemy.vIsPlayerAlive=false;
			Destroy(gameObject);
		}

	}
}
