using UnityEngine;
using System;

namespace ZombieFighter {

	[System.Serializable]
	public class Weapon : ScriptableObject {

		[Tooltip("The name of the weapon")]
		public string weaponName = "New Gun";
		[Tooltip("The cost of the weapon")]
		public int cost = 50;
		[Tooltip("The description of the weapon")]
		public string description = "A $50 gun.";
		[Tooltip("The name of the gun texture")]
		public string texture = "NewGun";

		[Tooltip("How many seconds it takes to reload")]
		public float reloadTime = 0.2f;
		[Tooltip("What speed the projectiles move at")]
		public float projectileSpeed = 4.5f;
		[Tooltip("The projectile that is actually fired")]
		public GameObject projectile;

	}
}

