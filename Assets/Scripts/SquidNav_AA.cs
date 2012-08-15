using UnityEngine;
using System.Collections;

public class SquidNav_AA : MonoBehaviour {
	
	public GameObject head;
	public GameObject turbine;
	
	

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 turbineRotation = new Vector3(0,0, Time.time);
		
		turbine.transform.Rotate(turbineRotation);
		
		Vector3 yOffset = new Vector3(0.0f, Mathf.Cos(UnityEngine.Time.time),0.0f);
		this.transform.Translate(yOffset);
	
			
	}
}
