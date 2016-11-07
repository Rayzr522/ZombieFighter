using System;
using UnityEngine;
using UnityEditor;

namespace ZombieFighter {

	public class DataObjectMenus {

		// Actual work
		public static void Create<T>(String name) 
			where T : ScriptableObject {

			T asset = ScriptableObject.CreateInstance<T>();

			if (!AssetDatabase.IsValidFolder("Assets/Resources")) {
				Debug.Log("Creating folder Assets/Resources");
				AssetDatabase.CreateFolder("Assets/", "Resources");
			}

			if (!AssetDatabase.IsValidFolder("Assets/Resources/Data")) {
				Debug.Log("Creating folder Assets/Resources/Data");
				AssetDatabase.CreateFolder("Assets/Resources/", "Data");
			}
				
			AssetDatabase.CreateAsset(asset, "Assets/Resources/Data/New" + name + ".asset");
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = asset;

		}

		// Implementations
		[MenuItem("Assets/Data Objects/Weapon")]
		public static void CreateWeapon() {
			Create<Weapon>("Weapon");
		}
	}
}

