using UnityEngine;
using System.Collections;

public class SquidTailMotion_AA : MonoBehaviour 
{
	public Vector3 parentPos;
	public Vector3 parentRot;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		parentPos = this.transform.parent.position;
		parentRot = this.transform.parent.rotation.eulerAngles;
	
	}
}
