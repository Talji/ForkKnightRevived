using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 8;
	int currentHealth;
	Health healthguiScript;
	PlayerScript pScript;
	Transform weapon;
	Score score; 
	public AudioClip hurtSound;


	void Start(){
		currentHealth = maxHealth;
		GameObject health = GameObject.Find ("Health");
		healthguiScript = (Health)health.GetComponent ("Health");
		pScript = GetComponent<PlayerScript> ();
	}

	void Update (){
		if (transform.position.y < -5) {
			Debug.Log ("PLAYERDEAD");
			Application.LoadLevel("GameOver");
		}
	}

	public void AdjustCurrentHealth(int adj) {
		currentHealth += adj;
		GetComponent<AudioSource>().PlayOneShot(hurtSound);

		if (currentHealth < 1)
			 currentHealth = 0;

		if (currentHealth > maxHealth)
			 currentHealth = maxHealth;

		if (maxHealth < 1)
			 maxHealth = 1;

		healthguiScript.modifyHealth (currentHealth);

		if (currentHealth <= 0) {
			//Debug.Log ("PLAYER DEAD");
			score = GameObject.Find ("Score").GetComponent<Score>();
			score.checkFinalScore();


            GameObject spawnerend = GameObject.Find("Spawners");
            Destroy(spawnerend);
			pScript.enabled = false;
			SpriteRenderer sprite = GetComponent<SpriteRenderer>();
			BoxCollider2D hitbox = GetComponent<BoxCollider2D>();
			weapon = pScript.weapon.transform;
			pScript.weapon.AddComponent<Rigidbody2D>();
			pScript.weapon.GetComponent<Rigidbody2D>().fixedAngle = true;
			weapon.parent = null;
			hitbox.isTrigger = true;
			GetComponent<Rigidbody2D>().gravityScale = 10;
			//enemy death anim (up and fall through ground)
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 800f));
			sprite.sortingOrder = 8;

			//reload level
			//Application.LoadLevel(Application.loadedLevel);
		}

	}
}	
	/*public float hp = 2f;
	public float resetAfterDeathTime = 5f;

	private PlayerScript playerMovement;
	private float timer;
	private bool playerDead;

	void Start(){}

	void Update(){
		if (hp <= 0f)
		{
			if(!playerDead)
				PlayerDying();
			else
				PlayerDead();
		}
	}

	void Alive(){
		
		playerMovement = GetComponent<PlayerScript>();
		
	}

	void PlayerDying(){
		
		playerDead = true;
	}

	void PlayerDead(){
		
		playerMovement.enabled = false;
	}

	void LevelReset(){		
	}

	public void TakeDamage (float amount)
	{
		// Decrement the player's health by amount.
		hp -= amount;
	}

	void FixedUpdate(){}
}*/