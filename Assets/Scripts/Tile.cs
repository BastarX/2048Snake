using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour 
{
	public int val;
	public InitLevel level;

	// Use this for initialization
	void Start () 
	{
		//GetComponent<SpriteRenderer>().material.SetTexture(level.texts[(int)Mathf.Sqrt (val)]);
		renderer.material.mainTexture = level.texts[(int)Mathf.Sqrt (val)];
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SetVal(int val)
	{
		this.val = val;
		//GetComponent<SpriteRenderer>().material.SetTexture(level.texts[(int)Mathf.Sqrt (val)]);
		renderer.material.mainTexture = level.texts[(int)Mathf.Sqrt (val)];
	}
}
