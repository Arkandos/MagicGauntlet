using UnityEngine;
using System.Collections;

public class EntityPlayer : EntityLiving {

	public Rigidbody2D fireballPrefab;

	private string playerName = "Magician";
	private float cooldown = 0;

	// Use this for initialization
	void Start () {
		playerEntity = true;
	}
	
	// Update is called once per frame
	void Update () {
		base.GameUpdate();
	}

	public void GameUpdate(){
		Update();
	}

	// Triggers attacks.
	// Temporary system
	void FixedUpdate(){
		if(cooldown <= 0){
			if(Input.GetMouseButton(0)){
				cooldown = 0.5f;
				Rigidbody2D Projectile = (Rigidbody2D) Instantiate(fireballPrefab, transform.position, transform.rotation);
				//Projectile.transform.Translate(new Vector3(10, 10, 0));
				//print ("Transformed");
				//Clone = Projectile.GetComponent<Rigidbody2D>();
				Physics2D.IgnoreCollision(Projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
				ProjectileBase projectileBase = Projectile.GetComponent<ProjectileBase>();
				Projectile.GetComponent<ProjectileBase>().SetOwnerName(GetPlayerName());
				Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, projectileBase.velocity));
				Projectile.GetComponent<ProjectileBase>().SetSpellPower(GetSpellpower());

			}
		}else{
			cooldown -= Time.fixedDeltaTime;
			if(cooldown < 0){
				cooldown = 0;
			}
		}
	}

	public string GetPlayerName(){
		return playerName;
	}

	public void SetPlayerName(string name){
		playerName = name;
	}

	void OnCollisionEnter2D(Collision2D collision){
		print ("Player collision");
	}
}
