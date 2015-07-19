using UnityEngine;
using System.Collections;

public class EntityEnemy : EntityLiving {

	public float attackRange = 1;
	public int attackDamage = 1;
	public float attackSpeed = 1;
	public float attackCooldown = 0;

	// Use this for initialization
	void Start () {
		attackCooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}

	public float GetAttackSpeed(){
		return attackSpeed * attackSpeedModifier;
	}
}
