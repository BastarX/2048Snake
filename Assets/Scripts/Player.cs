using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	int dir = 0;					// 0 - up, 1 - right, 2 - down, 3 - left;
	float speed = 1000f;			//how much time we need to move;
	float maxSpeed = 1000f;			//actual max;
	public static bool alive = true;

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
		Debug.Log ("coll");
		if(g.name == "Wall")
		{
			Debug.Log ("Collided with wall");
			alive = false;
		}
	}
}
