using UnityEngine;
using System.Collections;
using ZombieFighter;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

	private static PlayerController instance;

	public static PlayerController INSTANCE {
		get { return instance; }
	}

	// -- ROTATION / VELOCITY VARIABLES -- //
	// The last rotation
	private Vector2 rot;
	[Tooltip("The movement speed of the player")]
	public float acceleration = 3f;

	// ----- ALL COMPONENT VARIABLES ----- //
	// The Rigidbody2D
	private Rigidbody2D rb;
	// The animator
	private Animator animator;

	// Use this for initialization
	void Start() {
		// @I-Al-Istannen: Please don't yell at me for this
		instance = this;

		// Get components
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		// Ensure the animator isn't running to start with
		animator.SetBool("Moving", false);
	}

	void OnDestroy() {

		instance = null;

	}
	
	// Update is called once per frame
	void Update() {

		// Slow us down (pretty quickly too)
		rb.velocity = rb.velocity * 0.1f;

		// Figure out where they're looking. This used to be ugly, but extension methods made it far easier
		transform.rotation = transform.position.ScreenPos().AngleTo(Input.mousePosition);

		// Temporary variable
		float speed = acceleration;
		// Check for sprinting and modify the animator speed too
		if (Input.GetButton("Sprint")) {
			speed *= 2.5f;
			animator.speed = 1f;
		} else {
			animator.speed = 0.5f;
		}

		// // rot.ToSide() is an extension method of mine used to turn a vector 90 degrees to the right.
		// // Yes, ugly, but it is needed for side-to-side movement.
		// Vector2 motion = rot * Input.GetAxis("Vertical") + rot.ToSide() * Input.GetAxis("Horizontal");
		// If I ever want to re-implement `rot` and `rot.ToSide()` into this... well I have bugs to fix
		Vector2 motion = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		rb.velocity = motion * speed;

		// Make sure the feet are only moving when necessary
		if (motion.magnitude > 0.2) {
			// They are moving!
			animator.SetBool("Moving", true);
		} else {
			// Nope, they aren't anymore
			animator.SetBool("Moving", false);
		}

	}

}
