using UnityEngine;
using UnityEngine.Internal;
using System.Collections;

public class GunController : MonoBehaviour {

	[Tooltip("How long it takes to be able to shoot again")]
	public float reloadTime = 0.1f;
	[Tooltip("The bullet prefab that gets spawned")]
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

		if (Input.GetButtonDown("Fire1") && elapsedTime >= reloadTime) {
			elapsedTime = 0;
			fire();
		}
	
	}

	public void fire() {

		// Fire a bullet
		Instantiate(bulletPrefab, bulletSpawnPoint.position, playerPos.rotation);

	}

}
