using UnityEngine;
using System.Collections;

public class Tubinetest : MonoBehaviour 
{
	public GameObject turbine;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	  UpdateTurbine();
	}
	
	
	void UpdateTurbine()
	{
		// update the turbine rotation //
		
		float timeDelta = UnityEngine.Time.deltaTime;
		//Debug.Log(timeDelta);
		Vector3 turbineRotation = new Vector3(0,0, timeDelta * 50);
		Vector3 eulerRot = new Vector3(0,UnityEngine.Time.time*.1f,0);

		this.turbine.transform.Rotate( turbineRotation);
	}
}
