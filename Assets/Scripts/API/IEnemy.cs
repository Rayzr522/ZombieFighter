using System;

namespace ZombieFighter {

	public interface IEnemy : IHurtable {

		void OnHit(IProjectile projectile);

	}

}