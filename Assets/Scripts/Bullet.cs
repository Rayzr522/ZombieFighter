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
public class Bullet : MonoBehaviour {

	// -- PUBLIC VARIABLES -- //
	public float speed = 5.0f;
	public float lifetime = 3.0f;

	// Use this for initialization
	void Start() {
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
		StartCoroutine(Routine_Die());
	}

	IEnumerator Routine_Die() {

		yield return new WaitForSeconds(lifetime);
		Destroy(this);

	}

}
