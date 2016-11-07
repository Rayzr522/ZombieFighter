
using UnityEngine;
using System.Collections;

namespace ZombieFighter {

	public interface IProjectile {

		// Damage related stuff
		void Kill();

		void OnHit(GameObject other);

		float GetDamage(IHurtable hit);

		// Velocity / movement stuff
		void Move(Vector2 direction);

		void SetVelocity(float velocity);

		float GetVelocity();

	}

}