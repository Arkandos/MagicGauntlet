using UnityEngine;
using System.Collections;

public class MovementBase : MonoBehaviour {

	public int movementSpeed = 1000;

	private Vector2 stoppedVector = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}

	public void Move(Rigidbody2D rigidbody,Vector2 direction, int movementSpeed){
		rigidbody.AddForce(direction * movementSpeed);
		//rigidbody2D.velocity = stoppedVector;
	}

	public void Move(Rigidbody2D rigidbody, Vector2 direction){
		GetComponent<Rigidbody2D>().AddForce(direction);
		//Debug.Log("Moving ai with " + direction.x + "x and " + direction.y + "y");
		//rigidbody2D.velocity = stoppedVector;
	}

	public void MoveUp(Rigidbody2D rigidbody, int movementSpeed){
		Move(rigidbody, Vector2.up, movementSpeed);
	}

	public void MoveDown(Rigidbody2D rigidbody, int movementSpeed){
		Move(rigidbody, -Vector2.up, movementSpeed);
	}

	public void MoveRight(Rigidbody2D rigidbody, int movementSpeed){
		Move(rigidbody, Vector2.right, movementSpeed);
	}

	public void MoveLeft(Rigidbody2D rigidbody, int movementSpeed){
		Move(rigidbody, -Vector2.right, movementSpeed);
	}

	public void MoveStop(Rigidbody2D rigidbody){
		GetComponent<Rigidbody2D>().velocity = stoppedVector;
	}
}
