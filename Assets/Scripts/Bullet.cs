using UnityEngine;
using System.Collections;


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
public class Bullet : MonoBehaviour, Projectile {

	// -- PUBLIC VARIABLES -- //
	public float speed = 5.0f;
	public float lifetime = 3.0f;

	// Use this for initialization
	void Start() {
		// ------------------------------------------------------ //
		// Might be confusing, but since Unity is actually 3D,    //
		// transform.forward would move you on the Z axis.        //
		// Instead, for "2D" in Unity you use transform.up, as    //
		// Y is basically forward for my game (pointing upwards), //
		// so transform.up = forward for all intents and purposes //
		// in this game. Yay massive comments!                    //
		//                                             – Rayzr :D //
		// ------------------------------------------------------ //
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
		StartCoroutine(Routine_Die());
	}

	IEnumerator Routine_Die() {

		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);

	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);

	}



	void OnTriggerEnter2D(Collider2D other) {
		OnHit(other.gameObject);
	}

	// -- PROJECTILE INTERFACE IMPLEMENTATION -- //
	public void Kill() {
		Destroy(gameObject);
	}

	public void OnHit(GameObject other) {
		if (other.GetComponent<Enemy>() != null) {
			other.GetComponent<Enemy>().OnHit(this);
		}
		Kill();
	}

	public float GetDamage(Enemy enemy) {
		// Placeholder, eventually there will be some sort of defense value for the enemy... anyways
		return 1.0f;
	}

}
