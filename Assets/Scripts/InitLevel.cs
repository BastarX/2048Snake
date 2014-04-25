using UnityEngine;
using System.Collections;
using System;

public class InitLevel : MonoBehaviour 
{
	public int tileSize = 128;
	public int levelSize = 8;

	public static float offset = 0.8f;
	public static float mult = 1.2f;
	public static float time;
	public static float maxTime = 5000f;

	public GameObject level;
	public Player player;
	public GameObject[] texts;

	// Use this for initialization
	void Start () 
	{
		for(int y = 0;y<levelSize;y++)
		{
			for(int x = 0;x<levelSize;x++)
			{
				GameObject o = Instantiate (texts[0],new Vector2(offset + (-level.transform.localScale.x/2 + mult*x),-offset -(-level.transform.localScale.y/2 + mult*y)),Quaternion.identity) as GameObject;
				o.transform.parent = level.transform;
				o.transform.localScale = new Vector2(0.1f,0.1f);
			}
		}

		time = maxTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		time -= Time.deltaTime * 1000;
		//Debug.Log (Time.fixedDeltaTime);

		if(time <= 0)
		{
			time = maxTime;
			System.Random r = new System.Random();
			int i = r.Next (0,100);

			if(i <= 65)
			{
				GameObject o = (GameObject)Instantiate (texts[1], new Vector2(1,1),Quaternion.identity);
			}
			else
			{
				GameObject o = (GameObject)Instantiate (texts[2], new Vector2(1,1),Quaternion.identity);
			}
		}
	}
}
