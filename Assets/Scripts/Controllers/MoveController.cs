using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour {

	[Tooltip("The (bool) property of the animator to change")]
	public string animatorProperty = "Moving";
	[Tooltip("The velocity required to set the bool to true")]
	public float velocityThreshold = 4.0f;

	// ----- ALL COMPONENT VARIABLES ----- //
	// The Rigidbody2D
	private Rigidbody2D rb;
	// The animator
	private Animator animator;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {

		// Make sure the feet are only moving when necessary
		if (rb.velocity.magnitude > 0.2) {
			// They are moving!
			animator.SetBool(animatorProperty, true);
		} else {
			// Nope, they aren't anymore
			animator.SetBool(animatorProperty, false);
		}
	
	}
}

