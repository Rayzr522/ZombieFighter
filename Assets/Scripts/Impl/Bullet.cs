using UnityEngine;
using System.Collections;
using ZombieFighter;

// --------------------------------------------------- //
// This class is nice as it can be used for any        //
// kind of bullet, since the speed and lifetime        //
// are public. If you want to extend the functionality //
// then you could extend this class. I will functions  //
// for this purpose soon, allowing you to do things    //
// when a bullet hits an enemy for example. This will  //
// make my life 100x easier, as well as any modding    //
// capabilities I might add to it later. Enjoy!        //
//                                          – Rayzr :D //
// --------------------------------------------------- //
public class Bullet : MonoBehaviour, IProjectile {

	// -- PUBLIC VARIABLES -- //
	private float velocity = 1.0f;
	public float lifetime = 3.0f;

	private Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		Move(transform.up);
		Destroy(gameObject, lifetime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		OnHit(other.gameObject);
	}

	// -- PROJECTILE INTERFACE IMPLEMENTATION -- //
	public void Kill() {
		Destroy(gameObject);
	}

	public void OnHit(GameObject other) {
		if (other.GetComponent<IEnemy>() != null) {
			other.GetComponent<IEnemy>().OnHit(this);
		}
		Kill();
	}

	public float GetDamage(IHurtable enemy) {
		// Placeholder, eventually there will be some sort of defense value for the enemy... anyways
		return 1.0f;
	}

	public void Move(Vector2 direction) {
		direction = direction.normalized;
		transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
		rb.velocity = direction * velocity;
	}

	public void SetVelocity(float velocity) {
		this.velocity = velocity;
		Move(transform.up);
	}

	public float GetVelocity() {
		return velocity;
	}

}
