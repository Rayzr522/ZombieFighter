using UnityEngine;
using UnityEngine.Internal;
using System.Collections;

public class GunController : MonoBehaviour {
	
	public float reloadTime = 0.3f;
	public GameObject bulletPrefab;

	private Transform playerPos;
	private Transform bulletSpawnPoint;
	private float elapsedTime;

	// Use this for initialization
	void Start() {

		playerPos = transform.GetComponentInParent<Transform>();
		bulletSpawnPoint = transform.GetChild(0);
		elapsedTime = reloadTime;
	
	}
	
	// Update is called once per frame
	void Update() {

		elapsedTime += Time.deltaTime;

		if (Input.GetButtonDown("Fire1")) {

			if (elapsedTime >= reloadTime) {
				elapsedTime = 0;
				fire();
			}

		}
	
	}

	public void fire() {

		// Fire a bullet
		Instantiate(bulletPrefab, bulletSpawnPoint.position, playerPos.rotation);

	}

}
