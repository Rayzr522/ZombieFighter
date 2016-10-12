using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ZombieFighter {

	public class Sounds : MonoBehaviour {

		public const string NAME_FORMAT = "ZF|Sounds - Player for clip '{0}'";

		private static Sounds instance;

		private static IDictionary dict = new Dictionary<string, AudioClip>();

		public AudioClip[] clips;

		// Use this for initialization
		void Start() {

			instance = this;

			foreach (AudioClip clip in clips) {
				Log("Adding clip with name '" + clip.name + "'");
				AddClip(clip);
			}
	
		}
	
		// Update is called once per frame
		void Update() {
	
		}

		private static bool CreatePlayerFor(AudioClip clip, string name) {

			if (GetPlayerFor(name) != null) {
				Error("Attempted to create a player for clip '" + name + "', but one already existed! Cancelling...");
				return false;
			}
				
			GameObject go = (GameObject)Instantiate(new GameObject(), instance.transform.position, instance.transform.rotation);
			go.name = string.Format(NAME_FORMAT, name);
			go.transform.SetParent(instance.transform);

			AudioSource audio = go.AddComponent<AudioSource>();
			audio.maxDistance = 5000;
			audio.clip = clip;
			audio.playOnAwake = false;
			audio.Stop();

			return true;

		}

		public static AudioSource GetPlayerFor(string name) {
			Transform tf = instance.transform.FindChild(string.Format(NAME_FORMAT, name));
			if (tf == null) {
				return null;
			}
			return tf.GetComponent<AudioSource>();
		}

		public static void AddClip(AudioClip clip, string name) {
			if (dict.Contains(name)) {
				Error("A script tried to add the clip '" + name + "', but it already existed! Cancelling...");
				return;
			}
			if (CreatePlayerFor(clip, name)) {
				dict.Add(name, clip);
			}
		}

		public static void AddClip(AudioClip clip) {
			AddClip(clip, clip.name);
		}

		public static void Play(string name) {
			Play(name, -1.0f);
		}

		public static void Play(string name, float randomizeAmount) {
			if (!dict.Contains(name)) {
				// Fail quietly
				return;
			}
			AudioSource source = GetPlayerFor(name);
			if (source == null) {
				// Again, fail quietly
				return;
			}
			source.Stop();
			// This ugly piece of *stuff* math is to randomly vary `randomizeAmount` up or down from 1.0f
			source.pitch = randomizeAmount < 0.0f ? 1.0f : Random.value * randomizeAmount * 2 - randomizeAmount + 1.0f;
			source.Play();
		}

		private static void Error(string msg) {
			Debug.LogWarning(string.Format("[ZF|Sounds] {0}", msg));
		}

		private static void Log(string msg) {
			Debug.Log(string.Format("[ZF|Sounds] {0}", msg));
		}

	}

}