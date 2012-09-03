using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquidNav_AA : MonoBehaviour 
{
	public GameObject turbine;
	public GameObject tailPiece;
	public float turbineRotationSpeed;
	
	private GameObject[] tailPieces;
	private Vector3[] lookAtPositions;

	private int numTailPieces;
	private int frameCount;
	
	

	// Use this for initialization
	void Start () 
	{
		numTailPieces = 10;
		
		tailPieces = new GameObject[numTailPieces];
		lookAtPositions = new Vector3[numTailPieces];
		
		for(int i=0; i< this.tailPieces.Length; i++)
		{
			GameObject squidTail = (GameObject)Instantiate(tailPiece);
			Vector3 offset = new Vector3(0,0,3);
			if(i == 0)
			{
				squidTail.transform.position = this.transform.position + offset;
				lookAtPositions[i] = this.transform.position;
			}
			else
			{
				squidTail.transform.position = this.tailPieces[i-1].transform.position + offset;
				lookAtPositions[i] = this.tailPieces[i-1].transform.position;
			}
			tailPieces[i] = squidTail;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// update the turbine rotation //
		float timeDelta = UnityEngine.Time.deltaTime;
		Vector3 turbineRotation = new Vector3(0,0, timeDelta * turbineRotationSpeed);
		turbine.transform.Rotate(turbineRotation);
		 
		// update the tail parts //
		
		UpdateTailFollowMovement();
		
		//  updatae the root transform //
		Vector3 yOffset = new Vector3(0.0f, Mathf.Cos(UnityEngine.Time.time)*10.1f,15.0f);
		
		this.transform.LookAt(yOffset);
		this.transform.Translate(yOffset*.005f);
		//this.transform.Translate(yOffset);
	}
	
	void UpdateTailFollowMovement()
	{
		int tailIndex = numTailPieces-1;
		while(tailIndex !=0)
		{
			lookAtPositions[tailIndex] = tailPieces[tailIndex-1].transform.position;
			tailIndex--;
		}
		lookAtPositions[tailIndex] = this.transform.position;
		
		if(frameCount > 0)
		{
		
			for(int i=0; i<numTailPieces; i++)
			{
				if(i==0)
				{
					tailPieces[i].transform.position = this.transform.position + this.transform.forward*-4;
					tailPieces[i].transform.forward = this.transform.position;
				}
				else
				{
					tailPieces[i].transform.position = lookAtPositions[i] + tailPieces[i-1].transform.forward*-2;
					tailPieces[i].transform.forward = lookAtPositions[i-1] ;
				}
			}
			frameCount = 0;
		}

		frameCount++;
		
	}
}
