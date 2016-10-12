using UnityEngine;
using System.Collections;

namespace ZombieFighter {

	public static class ExtensionMethods {

		// ----- VEC2 EXTENSION METHODS ----- //
		public static Vector2 Multiply(this Vector2 self, Vector2 b) {
			return new Vector2(self.x * b.x, self.y * b.y);
		}

		public static Vector2 ToSide(this Vector2 self) {
			return new Vector2(self.y, -self.x);
		}

		public static Vector3 To3D(this Vector2 self, float z) {
			return new Vector3(self.x, self.y, z);
		}

		public static Vector3 To3D(this Vector2 self) {
			return self.To3D(0);
		}

		public static Quaternion AngleTo(this Vector2 self, Vector2 target) {
			// (WARNING: ugly code ahead!)
			// Get the normalized direction from the character's position on screen to the mouse position
			Vector3 newAngle = (target - self).normalized;
			// Do lovely arc tangent stuff to figure out direction, then multiply by Mathf.Rad2Deg to convert to degrees
			return Quaternion.Euler(0, 0, -Mathf.Atan2(newAngle.x, newAngle.y) * Mathf.Rad2Deg);
		}

		public static Vector2 WorldPos(this Vector2 self) {
			return Camera.main.ScreenToWorldPoint(self.To3D()).To2D();
		}

		public static Vector2 ScreenPos(this Vector2 self) {
			return Camera.main.WorldToScreenPoint(self.To3D()).To2D();
		}

		// ----- VEC3 EXTENSION METHODS ----- //
		public static Vector2 To2D(this Vector3 self) {
			return new Vector2(self.x, self.y);
		}

		public static Quaternion AngleTo(this Vector3 self, Vector3 target) {
			return self.To2D().AngleTo(target.To2D());
		}

		public static Vector3 WorldPos(this Vector3 self) {
			return Camera.main.ScreenToWorldPoint(self);
		}

		public static Vector3 ScreenPos(this Vector3 self) {
			return Camera.main.WorldToScreenPoint(self);
		}

	}

}