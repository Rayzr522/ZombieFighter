using UnityEngine;
using System.Collections.Generic;
using ZombieFighter;

public class Textures {

	private static Dictionary<string, Sprite> textures = new Dictionary<string, Sprite>();

	public static void Init() {
		List<Sprite> _textures = new List<Sprite>(Resources.LoadAll<Sprite>("Textures"));
		Debug.Log("Sprites found: " + _textures.ToArray().Length);
		_textures.ForEach(tex => {
			Debug.Log("Adding tex named '" + tex + "'");
			Add(tex);
		});
	}

	public static Sprite Get(string name) {
		Sprite found;
		if (!textures.TryGetValue(name, out found)) {
			return null;
		}
		return found; 
	}

	public static void Add(string name, Sprite texture) {
		textures.Add(name, texture);
	}

	public static void Add(Sprite texture) {
		textures.Add(texture.name, texture);
	}

}

