
using UnityEngine;
using System.Collections;

public interface Projectile {

	void Kill();

	void OnHit(GameObject other);

	float GetDamage(Enemy enemy);

}
