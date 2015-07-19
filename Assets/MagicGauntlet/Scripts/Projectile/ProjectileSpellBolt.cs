using UnityEngine;
using System.Collections;

public class ProjectileSpellBolt : ProjectileBase {

	public int damage;

	private float spellpowerMult = 0.5f;

	// Use this for initialization
	void Start () {
		base.Start();
		damage = damage + (int)(spellpowerMult * spellpower);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D collision){
		GameObject go = collision.gameObject.gameObject;
		Debug.Log(go.layer.ToString());
		if (go.layer == obstacleLayer){
			GameObject.Destroy(gameObject);
			return;
		}
		EntityBase entity = go.GetComponentInChildren<EntityBase>();
		entity.Damage(damage, GetOwnerName());
		GameObject.Destroy(gameObject);
	}

}
