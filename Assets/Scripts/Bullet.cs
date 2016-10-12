using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	
	public float speed = 5.0f;
	public float lifetime = 3.0f;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody2D> ().velocity = transform.up * speed;
	}

	IEnumerator Routine_Die() {

		yield return new WaitForSeconds (lifetime);
		Destroy (this);

	}

}
