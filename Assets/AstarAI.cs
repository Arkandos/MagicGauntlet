using UnityEngine;
using System.Collections;
using Pathfinding;

public class AstarAI : MovementBase {
	public Transform target;

	private Vector2 targetPosition;
	private bool pathCalculating = false;
	private EntityEnemy entity;

	public Path path;

	public float nextWaypointDistance = 3;
	public int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
		entity = this.GetComponentInChildren<EntityEnemy>();
		CalculatePath();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FixedUpdate(){
		CheckPath();
		TryAttack();
	}

	public void CheckPath(){
		//InvokeRepeating("CalculatePath", 2, 3);
		if (path == null){
			return;
		}
		
		Vector2 direction = target.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
		//Debug.Log (path.vectorPath.Count);
		Vector3 cDest = path.vectorPath[path.vectorPath.Count - 1];
		Vector2 currentDestination = new Vector2(cDest.x, cDest.y);
		
		if (Vector2.Distance(target.position, currentDestination) >= 25){
			//Debug.Log("Distance too far! Recalculating");
			CalculatePath();
		}
		
		
		if (currentWaypoint >= path.vectorPath.Count){
			//Debug.Log("End of path reached");
			MoveStop(GetComponent<Rigidbody2D>());
			CalculatePath();
			return;
		}
		
		Vector2 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= movementSpeed;
		
		Move (GetComponent<Rigidbody2D>(), dir);
		
		if (Vector2.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance){
			currentWaypoint++;
			return;
		}
		
		MoveStop(GetComponent<Rigidbody2D>());
		//rigidbody2D.velocity = new Vector2(0, 0);
	}

	public void OnPathComplete(Path p){
		//Debug.Log("Yay, we got a path back. Did it have an error? " +p.error);
		if(!p.error){
			path = p;

			currentWaypoint = 0;
			pathCalculating = false;
		}
	}

	public void CalculatePath(){
		if (pathCalculating == false){
			pathCalculating = true;
			targetPosition = target.position;

			
			Seeker seeker = GetComponent<Seeker>();
			seeker.StartPath(transform.position, targetPosition, OnPathComplete);
			//Debug.Log("Calculated new path");
		}
	}

	public void TryAttack(){
		if(entity.attackCooldown > 0){
			entity.attackCooldown -= Time.fixedDeltaTime;
			if(entity.attackCooldown < 0){
				entity.attackCooldown = 0;
			}
		}

		//Debug.Log("Distance: " + Vector2.Distance(transform.position, target.position).ToString());

		if(Vector2.Distance(transform.position, target.position) <= entity.attackRange){
			//Debug.Log("Trying attack. CD: " + entity.attackCooldown);
			if(entity.attackCooldown <= 0){
				//	Debug.Log("Successfull attack! Sending " + entity.attackDamage.ToString() + " dmg");
				target.GetComponentInChildren<EntityBase>().Damage(entity.attackDamage);
				entity.attackCooldown = entity.GetAttackSpeed();
			}
		}
	}
}
