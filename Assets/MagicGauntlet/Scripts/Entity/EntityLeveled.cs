using UnityEngine;
using System.Collections;

public class EntityLeveled : MonoBehaviour {

	public int experience = 0;
	public int maxExperience = 100;
	public int level = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetExperience(){
		return experience;
	}

	public void SetExperience(int x){
		experience = x;
	}

	public void AddExperience(int x){
		if(GetExperience() + x < GetMaxExperience()){
			SetExperience(GetExperience() + x);
		}else{
			int expLeft = (GetExperience() + x) - GetMaxExperience();
			IncreaseLevel();
			SetExperience(0);
			AddExperience(expLeft);
		}
	}

	public int GetMaxExperience(){
		return maxExperience;
	}

	public void SetMaxExperience(int x){
		maxExperience = x;
	}

	public int GetLevel(){
		return level;
	}

	public void SetLevel(int x){
		level = x;
	}

	public void AddLevel(int x){
		SetLevel(GetLevel() + x);
	}

	public void IncreaseLevel(){
		SetLevel(GetLevel() + 1);
		SetMaxExperience(Mathf.FloorToInt(GetMaxExperience() * 1.25f));
	}
}
