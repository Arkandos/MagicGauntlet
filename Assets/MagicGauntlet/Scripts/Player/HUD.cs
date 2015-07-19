using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	
	public Text healthText;
	public Slider healthBarSlider;
	public Text manaText;
	public Slider manaBarSlider;
	public Text expText;
	public Text levelText;
	public Slider expBarSlider;

	protected EntityBase player;
	protected EntityLeveled playerLevel;

	//private EntityBase player;

	// Use this for initialization
	void Start () {
		//EntityBase player = this.GetComponentInParent<EntityBase>();
		player = this.GetComponentInParent<EntityBase>();
		playerLevel = this.GetComponentInParent<EntityLeveled>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateHealthbar();
		UpdateManaBar();
		UpdateExpBar();
	}

	void UpdateHealthbar(){
		healthText.text = "Health: " + player.GetHealth().ToString() + "/" + player.GetMaxHealth().ToString();

		healthBarSlider.maxValue = player.GetMaxHealth();
		healthBarSlider.value = player.GetHealth();
	}

	void UpdateManaBar(){
		manaText.text = "Mana: " + player.GetMana().ToString() + "/" + player.GetMaxMana().ToString();

		manaBarSlider.maxValue = player.GetMaxMana();
		manaBarSlider.value = player.GetMana();
	}

	void UpdateExpBar(){
		expText.text = "XP: " + playerLevel.GetExperience().ToString() + "/" + playerLevel.GetMaxExperience().ToString();

		expBarSlider.maxValue = playerLevel.GetMaxExperience();
		expBarSlider.value = playerLevel.GetExperience();

		levelText.text = playerLevel.GetLevel().ToString();
	}
}
