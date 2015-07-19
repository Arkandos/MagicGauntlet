using UnityEngine;
using System.Collections;

public class EntityLiving : EntityBase {
	
	public int spellpower = 0;
	public int willpower = 0;
	public int strength = 0;

	protected float attackSpeedModifier = 1.0f;
	protected float spellpowerModifier = 1.0f;
	protected float willpowerModifier = 1.0f;
	protected float strengthModifier = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		base.GameUpdate();
	}

	public void GameUpdate(){
		Update();
	}

	public bool Attack(){
		return false;
	}

	public int GetSpellpower(){
		return Mathf.CeilToInt(spellpower * spellpowerModifier);
	}

	public int GetWillpower(){
		return Mathf.CeilToInt(willpower * willpowerModifier);
	}

	public int GetStrength(){
		return Mathf.CeilToInt(strength * strengthModifier);
	}

	public void SetSpellpower(int amount){
		spellpower = amount;
	}

	public void SetWillpower(int amount){
		willpower = amount;
	}

	public void SetStrength(int amount){
		strength = amount;
	}
}
