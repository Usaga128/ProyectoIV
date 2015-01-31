using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	public float delayTime = 5;
	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
