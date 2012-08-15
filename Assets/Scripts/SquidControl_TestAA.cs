using UnityEngine;
using System.Collections;

public class SquidControl_TestAA : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 yOffset = new Vector3(0.0f, Mathf.Cos(UnityEngine.Time.time),0.0f);
		this.transform.Translate(yOffset);
	
	}
}
