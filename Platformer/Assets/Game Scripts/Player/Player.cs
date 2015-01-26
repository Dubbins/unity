using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// START public vars
	public float MaxHealth = 200;
	public float CurHealth = 200;
	public int PlayerLives = 5;

	// Specific relation to health modification
	public float HealthModTalent = 1; // if we have a talent which increases the health it will be assigned to this number
	public float HealthModModifier = 1; // if we have a power up with increases the health it will be assigned to this number.

	// Specific powerups in relation to block or otherwise abilities with take damage away from the player health
	public float DamageResistance; // if we have a powerup with increases this float, then the damage the player received to his life is then taken out of this. Armor
									// Consider making the Bar a type of which is subtractable from a number from a defined number.
	public float SetDamageResistanceMaxValue; // tie this in with above
	// END

	// Relations to player experience
	public float MaxExp = 200;
	public float CurExp = 0;
	public float NextLevelExpIncrease = 1.375f; // changes the value of the exp increase each turn
	public float NextLevelHealthIncrease = 1.1575f; // changes the value of the health increase each turn
	public float ExperienceMod = 1; // if you obtain a powerup which temporarily increases your experience gains
	public float ExperienceModTalent = 1; // small number ADDED to experience gains each time you obtain Exp. ( + $exp forever )
	public int PlayerLevel = 1; // Set level cap at 100 (or however we decide the game works)
	// END

	// GUI
	public GUIStyle BlackBar;
	public GUIStyle HealthBar;
	public GUIStyle TextField;
	public GUIStyle CharName;
	public GUIStyle ExperienceBar;
	// END

	// Text fields
	public string PlayerName = ""; 
	public string CheatField = "";
	// END

	// Currency and Loot
	public int Coins;
		
		// Sub Loot Objects
		public GameObject CoinItem;
		public GameObject GemItem; // maybe break down into different gems (Ruby, Diamond, Sapphire, etc.)
			// Ensure that you make the powers a rate loot drop
		public GameObject AdditionalLife; // Ensure that additional life is added
		// END Sub

	// END

	// Bools and Tools
	public bool Death = false;
	public bool CheatWindow = false;
	public bool StatWindow = false;
	// END

	// Timers
	public float Despawncountdown = 1;
	public int Despawn = 1;

		// Sub Powerups
		public float WepCooldown = 1;
		// End Sub

	// END

	// Powerups
	public GameObject Fireball;
	public GameObject Iceball;
	public ParticleEmitter InvincibleCloak;
	// END

	// Use this for initialization
	void Awake () {
		Load ();
	}

	void OnGUI() {

		// Characters Stats
		GUI.Box (new Rect (10,10,200,25), "", BlackBar); // Black bar behind the text;
		GUI.Box (new Rect (10,10,100,25), PlayerName, CharName);
		GUI.Box (new Rect (110,10,80,25), "Player Level: " + PlayerLevel, CharName);

		// Health Bar
		GUI.Box (new Rect (10, 40, 200, 25), "", BlackBar);
		GUI.Box (new Rect (10, 40, CurHealth / (PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease), 25), "", HealthBar);
		GUI.Box (new Rect (10, 40, 200, 25), "Health: " + CurHealth + "/" + MaxHealth, TextField);

		// Experience Bar
		GUI.Box (new Rect (10, 70, 200, 25), "", BlackBar);
		GUI.Box (new Rect (10, 70, CurExp / (PlayerLevel * ExperienceMod * ExperienceModTalent * NextLevelExpIncrease), 25), "", ExperienceBar);
		GUI.Box (new Rect (10, 70, 200, 25), "XP: " + CurExp + "/" + MaxExp, TextField);

		// Player Lives
		GUI.Box (new Rect (10, 100, 200, 25), "", BlackBar);
		GUI.Box (new Rect (10, 100, 200, 25), "Lives: " + PlayerLives, TextField);

	}
	
	// Update is called once per frame
	void Update () {

		MaxHealth = 200 * PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease;
		MaxExp = 200 * PlayerLevel * ExperienceMod * ExperienceModTalent * NextLevelExpIncrease;

		if (CurHealth >= MaxHealth) {
			CurHealth = MaxHealth;
		}

		if (CurHealth <= 0) {
			CurHealth = 0;
			DeathIdentifier();
		}

		if (CurExp >= MaxExp) {
			LevelUp ();
			// reset experience
			CurExp = 0;
		}

		if (CurExp <= 0) {
			CurExp = 0;
		}

		// fix player level max
		if (PlayerLevel <= 100) {
			PlayerLevel = 100;
			CurExp = 0;
		}
	}

	void LevelUp() {
		PlayerLevel += 1;
		CurExp = 0;
		CurHealth = 200 * PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease;
	}

	// if Health hits zero, then you are dead.
	void DeathIdentifier() {

	}

	void OnTriggerEnter(Collider c) {

	}

	void DeathSequence() {

	}

	void LootManagement() {

	}

	void CheatScreen() {

	}

	void Save() {

	}

	void Load() {
		// Set Stats for basic Health or Exp loads
		CurHealth = 200 * PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease;
		// END
	}

	// called when quiting application
	void OnApplicationQuit() {
		Save ();
	}


}
