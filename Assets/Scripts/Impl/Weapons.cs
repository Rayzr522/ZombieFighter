using UnityEngine;
using System.Collections;
using ZombieFighter;

public class Weapons {

	private static Weapon[] weapons;

	public static void Init() {
		weapons = Resources.LoadAll<Weapon>("Data");
	}

	public static Weapon[] GetWeapons() {
		return weapons;
	}

}

