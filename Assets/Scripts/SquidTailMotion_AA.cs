using UnityEngine;
using System.Collections;

public class SquidTailMotion_AA : MonoBehaviour 
{
	public GameObject parent;
	public float zOffset;
	
	private Quaternion parentLastRot;

	
	
	// Use this for initialization
	void Start ()
	{

		
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
		Vector3 parentPos =  parent.transform.position;
		Vector3 parentRot =  parent.transform.rotation.eulerAngles;
		Vector3 postDelta = new Vector3(0.0f, 0.0f, zOffset);
		
		this.transform.position = this.parent.transform.position + postDelta;
		this.transform.rotation = (this.parentLastRot * this.transform.rotation);
		
		parentLastRot = parent.transform.rotation;

	}
}
