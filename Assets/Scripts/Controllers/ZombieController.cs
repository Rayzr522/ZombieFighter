using UnityEngine;
using System.Collections;
using ZombieFighter;


public class ZombieController : MonoBehaviour, IEnemy {

	// -- ALL COMPONENT VARIABLES -- //
	private Rigidbody2D rb;

	// ----- GAMEPLAY VARIABLES ---- //
	[Tooltip("The health of the zombie")]
	public float health = 5.0f;
	[Tooltip("The speed at which the zombie moves.\nBest to leave this low for realism.")]
	public float speed = 0.8f;
	[Tooltip("How close the player must be to get noticed.")]
	public float attackRange = 8.0f;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {

		rb.velocity = rb.velocity * 0.1f;

		if (PlayerController.INSTANCE == null) {
			Debug.Log("What the heck? PlayerController.INSTANCE = null!");
			Kill();
			return;
		}

		PlayerController player = PlayerController.INSTANCE;

		Vector2 distance = (player.transform.position - transform.position).To2D();
		if (distance.magnitude >= attackRange) {
			return;
		}

		rb.velocity = distance.normalized * speed;

		transform.rotation = transform.position.AngleTo(player.transform.position);
	
	}

	// Enemy#OnHit(Projectile) impl
	public void OnHit(IProjectile proj) {
		Damage(proj.GetDamage(this));
	}

	// IHurtable#GetHealth() impl
	public float GetHealth() {
		return health;
	}

	// IHurtable#Damage(float) impl
	public void Damage(float amount) {
		Sounds.Play("Hit", 0.2f);
		this.health -= amount;
		if (health <= 0.0f) {
			Kill();
		}
	}

	// IHurtable#Kill() impl
	public void Kill() {
		// Here is where you would spawn pretty particles :P
		Destroy(gameObject);
	}

}