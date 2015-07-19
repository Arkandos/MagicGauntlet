using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour {
	
	public int health = 1;
	public int maxHealth = 256;
	public int armor = 0;
	public int mana = 0;
	public int maxMana = 0;
	public int manaRegen = 0;
	public int expReward = 0;

	// If true, this entity is a player
	protected bool playerEntity = false;

	protected float healthModifier = 1.0f;
	protected float armorModifier = 1.0f;
	protected float manaModifier = 1.0f;
	protected float manaRegenModifier = 1.0f;

	private string killer = "EntityEnemy";

	// Use this for initialization
	void Start () {
		health = maxHealth;
		mana = maxMana;
	}
	
	// Update is called once per frame
	void Update () {
		DeathCheck();
	}
	

	public void GameUpdate(){
		Update();
	}

	public string GetKiller(){
		return killer;
	}

	public void SetKiller(string x){
		killer = x;
	}

	public void OnDeath(){
		if(playerEntity == true){
			health = 0;
		}else{
			if (GetKiller() != "EntityEnemy"){
				var objects = GameObject.FindGameObjectsWithTag("Player");

				foreach (var obj in objects){
					EntityPlayer entity = obj.GetComponentInChildren<EntityPlayer>();
					if (entity.GetPlayerName() == GetKiller()){
						EntityLeveled leveled = obj.GetComponentInChildren<EntityLeveled>();
						leveled.AddExperience(expReward);
						break;
					} 
				}
			}
			GameObject.Destroy(gameObject);
		}
	}

	public void SetHealth(int x){
		if(x <= maxHealth){
			health = x;
		}else{
			health = maxHealth;
		}

		if(health <= 0){
			OnDeath();
		}
	}

	public bool DeathCheck(){
		if(health <= 0){
			OnDeath();
			return true;
		}else if(health > maxHealth){
			health = maxHealth;
		}

		return false;
	}

	public void SetMaxHealth(int x){
		maxHealth = x;
	}

	public int GetHealth(){
		return health;
	}

	public int GetMaxHealth(){
		return Mathf.CeilToInt(maxHealth * healthModifier);
	}

	public void AddMaxHealth(int amount){
		SetMaxHealth(GetMaxHealth() + amount);
	}

	public void RemoveMaxHealth(int amount){
		SetMaxHealth(GetMaxHealth() - amount);
	}

	public float GetPercentageHealth(){
		float p = (health * 1.0f / maxHealth);
		return p;
	}
	
	public int Damage(int dmg, string source){

		//Debug.Log ("BEING DAMAGED BY " + dmg.ToString());

		int appliedDamage = 0;
		dmg = dmg * ((100 - GetArmor()) / 100);
		if(dmg <= health) {
			appliedDamage = dmg;
		}else{
			appliedDamage = dmg - health;
		}

		SetHealth(health - dmg);

		// DEBUG!!!!!
		//Debug.Log ("APPLIED DAMAGE: " + appliedDamage.ToString());
		//
		if(source != "EntityEnemy" && source != GetKiller()){
			SetKiller(source);
		}

		return appliedDamage;
	}

	public int Damage(int dmg){
		return Damage(dmg, "EntityEnemy");
	}

	public int PercentageDamageCurrentHealth(float dmg){
		return Damage(Mathf.FloorToInt(health * dmg));
	}

	public int PercentageDamageMaxHealth(float dmg){
		return Damage(Mathf.FloorToInt(maxHealth * dmg));
	}

	public int Heal(int heal){
		int appliedHeal = 0;
		if ((GetHealth() + heal) <= GetMaxHealth()){
			appliedHeal = heal;
		}else{
			appliedHeal = GetMaxHealth() - GetHealth ();
		}

		SetHealth(GetHealth() + heal);
		return appliedHeal;
	}

	public void SetMana(int x){
		if(x <= maxMana){
			mana = x;
		}else{
			mana = maxMana;
		}
	}
	
	public void SetMaxMana(int x){
		maxMana = x;
	}
	
	public int GetMana(){
		return mana;
	}
	
	public int GetMaxMana(){
		return Mathf.CeilToInt(maxMana * manaModifier);
	}
	
	public float GetPercentageMana(){
		float p = (health * 1.0f / maxMana);
		return p;
	}

	public int AddMana(int amount){
		int appliedMana = 0;
		if((GetMana() + amount) <= GetMaxMana()){
			appliedMana = amount;
		}else{
			appliedMana = GetMaxMana() - GetMana();
		}

		SetMana(GetMana() + appliedMana);
		return appliedMana;
	}

	public void SetManaRegen(int x){
		manaRegen = x;
	}

	public int GetManaRegen(){
		return Mathf.CeilToInt(manaRegen * manaRegenModifier);
	}

	public void AddManaRegen(int amount){
		SetManaRegen(manaRegen + amount);
	}

	public void RemoveManaRegen(int amount){
		SetManaRegen(manaRegen - amount);
	}

	public int GetArmor(){
		return Mathf.CeilToInt(armor * armorModifier);
	}

	public void SetArmor(int amount){
		armor = amount;
	}

	public void AddArmor(int amount){
		SetArmor (armor + amount);
	}

	public void RemoveArmor(int amount){
		SetArmor (armor - amount);
	}
}
