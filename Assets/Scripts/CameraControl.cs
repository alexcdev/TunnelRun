using UnityEngine;
using System.Collections;


public class CameraControl : MonoBehaviour 
{

	public GameObject Squid;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		this.transform.LookAt(Squid.transform.position);
	}
}
