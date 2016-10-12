using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{

	public static Vector2 Multiply (this Vector2 self, Vector2 b)
	{
		return new Vector2 (self.x * b.x, self.y * b.y);
	}

	public static Vector2 ToSide (this Vector2 self)
	{
		return new Vector2 (self.y, -self.x);
	}

}

