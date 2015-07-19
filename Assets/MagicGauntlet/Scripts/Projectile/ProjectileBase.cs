using UnityEngine;
using System.Collections;

public class ProjectileBase : MonoBehaviour {

	public int velocity;
	public int spellpower = 0;

	protected int projectileLayer = 8;
	protected int obstacleLayer = 10;
	protected string owner = "EntityEnemy";

	// Use this for initialization
	public void Start () {
		Physics2D.IgnoreLayerCollision(projectileLayer, projectileLayer, true);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){

	}

	void OnCollisionEnter2D(Collision2D collision){
		//if (collision.gameObject.tag != "Projectile"){
		//print ("Collision!");
		GameObject.Destroy(gameObject);
		//}
	}

	public void SetSpellPower(int x){
		spellpower = x;
	}

	public void SetOwnerName(string name){
		owner = name;
	}

	public string GetOwnerName(){
		return owner;
	}
}
