using UnityEngine;
using System.Collections;

public class circularMotion : MonoBehaviour 
{
	
	public GameObject tailPiece;
	private GameObject[] tailPieces;
	private Vector3[] lookAtPositions;

	private int numTailPieces;
	
	private int frameDelay;
	// Use this for initialization
	void Start () 
	{
		numTailPieces = 10;
		frameDelay = 0;
		
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
		
		
		
		int radius = 50;
		int verticalScale = 5;
		
		float cosY = Mathf.Cos(UnityEngine.Time.time*4);
		float cos = Mathf.Cos(UnityEngine.Time.time);
		float sin = Mathf.Sin(UnityEngine.Time.time);
		
		Vector3 pos = new Vector3(cos, cosY*0.3f, sin);
		this.transform.position = pos * radius;
		
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
		
		
		for(int i=0; i<numTailPieces; i++)
		{
			if(i==0)
			{
				tailPieces[i].transform.forward = this.transform.position-tailPieces[i].transform.position;
				tailPieces[i].transform.position = this.transform.position + tailPieces[i].transform.forward * -2;
				
			}
			else
			{
				tailPieces[i].transform.forward = lookAtPositions[i-1] - lookAtPositions[i];
				tailPieces[i].transform.position = lookAtPositions[i] + tailPieces[i-1].transform.forward*-2;
				Vector3 scale = new Vector3(tailPieces[i-1].transform.localScale.x * .95f,tailPieces[i-1].transform.localScale.y * .95f, tailPieces[i-1].transform.localScale.z * 1.1f);
				tailPieces[i].transform.localScale = scale;
				
			}
		}
	}
}
