using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour 
{
	int dir = 0;					// 0 - up, 1 - right, 2 - down, 3 - left;
	float speed = 1000f;			//how much time we need to move;
	float maxSpeed = 1000f;			//actual max;
	public static bool alive = true;
	List<GameObject> tail = new List<GameObject>();
	public InitLevel level;

	// Use this for initialization
	void Start () 
	{
		transform.position = new Vector2(InitLevel.offset + (-InitLevel.size + InitLevel.mult*4),-InitLevel.offset -(-InitLevel.size + InitLevel.mult*4));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			dir = 1;
			rigidbody2D.transform.eulerAngles = new Vector3(0,0,270);
		}
		else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			dir = 2;
			rigidbody2D.transform.eulerAngles = new Vector3(0,0,180);
		}
		else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			dir = 3;
			rigidbody2D.transform.eulerAngles = new Vector3(0,0,90);
		}
		else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			dir = 0;
			rigidbody2D.transform.eulerAngles = new Vector3(0,0,0);
		}

		if(speed <= 0)
		{
			speed = maxSpeed;

			Move();
		}

		speed -= Time.deltaTime * 1000; 	//we need miliseconds
	}

	void Move()
	{
		if(alive)
		{
			Vector2 v = rigidbody2D.transform.position;

			UpdatePositions ();

			if(dir == 0)
			{
				v.y += 1.2f;
			}
			else if(dir == 1)
			{
				v.x += 1.2f;
			}

			else if(dir == 2)
			{
				v.y -= 1.2f;
			}
			else if(dir ==3)
			{
				v.x -= 1.2f;
			}

			rigidbody2D.transform.position = v;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		GameObject g = c.gameObject;
		if(g.name == "Wall")
		{
			Debug.Log ("Collided with wall");
			alive = false;
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		GameObject g = c.gameObject;
		g.collider2D.enabled = false;

		tail.Insert(0, g);

		//UpdateVals ();
	}

	void UpdatePositions()
	{
		if(tail.Count > 0)
		{
			for(int i = tail.Count-1;i>0;i--)
			{
				tail[i].transform.position = tail[i-1].transform.position;
			}
			tail[0].transform.position = transform.position;
		}
	}

	void UpdateVals()
	{
		if(tail.Count > 1)
		{			
			for(int i = 0;i<tail.Count-1;i++)
			{
				int v1 = tail[i].GetComponent<Tile>().val;
				int v2 = tail[i+1].GetComponent<Tile>().val;

				if(v1 == v2)
				{
					int t = (int)Math.Sqrt(v1 + v2);
					//Debug.Log (t + " " + tail[i].name + " " + tail[i+1].name);
					GameObject g = tail[i];
					tail.RemoveAt(i);
					tail[i] = (GameObject)Instantiate(level.texts[t],g.transform.position,Quaternion.identity);
					tail[i].GetComponent<Collider2D>().enabled = false;
					Destroy (g);
				}
			}
		}
	}
}
