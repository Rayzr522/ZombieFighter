using System;

namespace ZombieFighter {

	public interface IHurtable {

		float GetHealth();

		void Damage(float amount);

		void Kill();

	}

}

