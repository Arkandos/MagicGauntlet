using UnityEngine;
using System.Collections;

public class PlayerMovement : MovementBase {

	// Use this for initialization
	void Start () {

	}
	
	// Graphics update
	void Update () {

	}

	// Physics update
	void FixedUpdate(){
		LookAtMouse();

		if(Input.GetKey(KeyCode.W)){
			MoveUp(GetComponent<Rigidbody2D>(), movementSpeed);
			//rigidbody2D.AddForce(Vector2.up * movementSpeed);
		}else if(Input.GetKey(KeyCode.S)){
			MoveDown (GetComponent<Rigidbody2D>(), movementSpeed);
		}
		
		if(Input.GetKey(KeyCode.D)){
			MoveRight (GetComponent<Rigidbody2D>(), movementSpeed);
		}else if(Input.GetKey(KeyCode.A)){
			MoveLeft(GetComponent<Rigidbody2D>(), movementSpeed);
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	}

	void LookAtMouse(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
