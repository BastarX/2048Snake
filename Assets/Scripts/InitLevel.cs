using UnityEngine;
using System.Collections;
using System;

public class InitLevel : MonoBehaviour 
{
	public int tileSize = 128;
	public int levelSize = 8;

	public static float offset = 0.8f;
	public static float mult = 1.2f;
	public static float size;
	public static float time;
	public static float maxTime = 5000f;

	public GameObject level;
	public Player player;
	public GameObject[] texts;
	public GameObject wall;

	// Use this for initialization
	void Start () 
	{
		size = level.transform.localScale.x/2;

		for(int y = 0;y<levelSize;y++)
		{
			for(int x = 0;x<levelSize;x++)
			{
				GameObject o = Instantiate (texts[0],new Vector2(offset + (-level.transform.localScale.x/2 + mult*x),-offset -(-level.transform.localScale.y/2 + mult*y)),Quaternion.identity) as GameObject;
				o.transform.parent = level.transform;
				o.transform.localScale = new Vector2(0.1f,0.1f);
			}
		}

		for(int i = 0;i<levelSize;i++)
		{
			GameObject o = (GameObject)Instantiate (wall,new Vector2(+0.8f + (-level.transform.localScale.x/2 + mult*i),0.2f-(-level.transform.localScale.y/2 + mult*0)),Quaternion.identity);
			o.transform.parent = level.transform;
			o.name = "Wall";
			o.transform.localScale = new Vector2(0.1f,0.1f);

			o = (GameObject)Instantiate (wall,new Vector2(+0.8f + (-level.transform.localScale.x/2 + mult*i),-0.6f-(-level.transform.localScale.y/2 + mult*levelSize)),Quaternion.identity);
			o.transform.parent = level.transform;
			o.name = "Wall";
			o.transform.localScale = new Vector2(0.1f,0.1f);

			o = (GameObject)Instantiate (wall,new Vector2(-0.2f + (-level.transform.localScale.x/2 + mult*0),-0.8f-(-level.transform.localScale.y/2 + mult*i)),Quaternion.identity);
			o.transform.parent = level.transform;
			o.name = "Wall";
			o.transform.localScale = new Vector2(0.1f,0.1f);

			o = (GameObject)Instantiate (wall,new Vector2(0.6f + (-level.transform.localScale.x/2 + mult*levelSize),-0.8f-(-level.transform.localScale.y/2 + mult*i)),Quaternion.identity);
			o.transform.parent = level.transform;
			o.name = "Wall";
			o.transform.localScale = new Vector2(0.1f,0.1f);
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

			float x = offset + (-level.transform.localScale.x/2 + mult*r.Next (0,levelSize));
			float y = -offset -(-level.transform.localScale.y/2 + mult*r.Next (0,levelSize));

			if(i <= 65)
			{
				GameObject o = (GameObject)Instantiate (texts[1], new Vector2(x,y),Quaternion.identity);
				o.transform.parent = level.transform;
				o.transform.localScale = new Vector2(0.1f,0.1f);
			}
			else
			{
				GameObject o = (GameObject)Instantiate (texts[2], new Vector2(x,y),Quaternion.identity);
				o.transform.parent = level.transform;
				o.transform.localScale = new Vector2(0.1f,0.1f);
			}
		}
	}
}
