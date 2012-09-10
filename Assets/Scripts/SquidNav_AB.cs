using UnityEngine;
using System.Collections;

public class SquidNav_AB : MonoBehaviour 
{
	public GameObject head;

	public GameObject tailPiece;

	private GameObject[] tailPieces;
	private Vector3[] lookAtPositions;
	private int numTailPieces;
	private int frameDelay;
	private float turbineRotationSpeed;
	// Use this for initialization
	void Start () 
	{
		numTailPieces = 15;
		frameDelay = 0;
		turbineRotationSpeed = 5000;
		
		tailPieces = new GameObject[numTailPieces];
		lookAtPositions = new Vector3[numTailPieces];
		
		//turbineInstance = GameObject.Find("turbine");
		
		
		for(int i=0; i< this.tailPieces.Length; i++)
		{
			
			Vector3 offset = new Vector3(0,0,3);
			if(i == 0)
			{
				GameObject squidHead = (GameObject)Instantiate(head);
				squidHead.transform.position = this.transform.position + offset;
				lookAtPositions[i] = this.transform.position;
				tailPieces[i] = squidHead;
			}
			else
			{
				GameObject squidTail = (GameObject)Instantiate(tailPiece);
				if(i == 1) offset *= 2; // this the first tail piece
				squidTail.transform.position = this.tailPieces[i-1].transform.position + offset;
				lookAtPositions[i] = this.tailPieces[i-1].transform.position;
				tailPieces[i] = squidTail;
			}
			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.UpdatePosition();
		//this.UpdateTurbine();
		if(frameDelay > 0)
		{
			this.UpdateTailPieces();
			frameDelay = 0;
		}
		frameDelay++;
	}
	
	void UpdateTailPieces()
	{
		int tailIndex = numTailPieces-1;
		while(tailIndex !=0)
		{
			lookAtPositions[tailIndex] = tailPieces[tailIndex-1].transform.position;
			tailIndex--;
		}
		lookAtPositions[tailIndex] = this.transform.position;
		
		
		for(int i=0; i<numTailPieces; i++)// includes head
		{
			if(i==0)
			{
				tailPieces[i].transform.forward = this.transform.position-tailPieces[i].transform.position;
				tailPieces[i].transform.position = this.transform.position + tailPieces[i].transform.forward * -1.555511f;
				
			}
			else
			{
				tailPieces[i].transform.forward = lookAtPositions[i-1] - lookAtPositions[i];
				tailPieces[i].transform.position = lookAtPositions[i] + tailPieces[i-1].transform.forward*-2;
				Vector3 scale = new Vector3(tailPieces[i-1].transform.localScale.x * .95f,
					tailPieces[i-1].transform.localScale.y * .95f, 
					tailPieces[i-1].transform.localScale.z * 1.051515f);
				tailPieces[i].transform.localScale = scale;
				
			}
		}
	}
	
	void UpdatePosition()
	{
		CircularMotionTest();
	}
	/*
	void UpdateTurbine()
	{

	}
	*/
	void CircularMotionTest()
	{
		int radius = 50;
		
		float cosY = Mathf.Cos(UnityEngine.Time.time*2);
		float cos = Mathf.Cos(UnityEngine.Time.time*.1f);
		float sin = Mathf.Sin(UnityEngine.Time.time*.1f);
		
		Vector3 pos = new Vector3(cos, cosY*0.3f, sin);
		this.transform.position = pos * radius;
	}
	

}
 