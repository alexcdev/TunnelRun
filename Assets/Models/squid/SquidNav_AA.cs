using UnityEngine;
using System.Collections;

public class SquidNav_AA : MonoBehaviour {
	
	public GameObject Head;
	public GameObject Turbine;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 myV = new Vector3(1,0,0);
		this.transform.Translate(myV);
		Camera myC = this.GetComponent<Camera>();
		myC.transform.LookAt(this.transform.position);
		this.GetComponent("turbine");
	}
}
