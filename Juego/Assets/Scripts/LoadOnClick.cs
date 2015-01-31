using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int level){
		AutoFade.LoadLevel(level ,3,1,Color.black);
	}
}
