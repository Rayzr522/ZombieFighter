using UnityEngine;
using UnityEngine.Internal;
using System.Collections;
using ZombieFighter;

public class GunController : MonoBehaviour {
	
	[Tooltip("The weapon that this represents")]
	public Weapon weapon;

	private Transform playerPos;
	private Transform bulletSpawnPoint;
	private float elapsedTime;

	// Use this for initialization
	void Start() {

		SwitchWeapon(Weapons.GetWeapons()[0]);

		playerPos = transform.GetComponentInParent<Transform>();
		bulletSpawnPoint = transform.GetChild(0);
		elapsedTime = weapon.reloadTime;
	
	}

	public void SwitchWeapon(Weapon weapon) {

		this.weapon = weapon;
		GetComponent<SpriteRenderer>().sprite = Textures.Get(weapon.texture);

	}
	
	// Update is called once per frame
	void Update() {

		elapsedTime += Time.deltaTime;

		if (Input.GetButtonDown("Fire1") && elapsedTime >= weapon.reloadTime) {
			elapsedTime = 0;
			fire();
		}
	
	}

	public void fire() {

		// Fire a bullet
		GameObject go = (GameObject) Instantiate(weapon.projectile, bulletSpawnPoint.position, playerPos.rotation);
		go.GetComponent<IProjectile>().SetVelocity(weapon.projectileSpeed);

	}

}
