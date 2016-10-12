
using UnityEngine;
using System.Collections;

namespace ZombieFighter {

	public interface IProjectile {

		void Kill();

		void OnHit(GameObject other);

		float GetDamage(IEnemy enemy);

	}

}