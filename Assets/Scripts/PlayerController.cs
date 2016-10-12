using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

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
		// Get components
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		// Ensure the animator isn't running to start with
		animator.SetBool("Moving", false);
	}
	
	// Update is called once per frame
	void Update() {

		// Slow us down (pretty quickly too)
		rb.velocity = rb.velocity * 0.5f;

		// Figure out where they're looking (WARNING: ugly code ahead!)
		// Get the normalized direction from the character's position on screen to the mouse position
		Vector3 newAngle = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
		// Convert to Vec2
		rot = new Vector2(newAngle.x, newAngle.y);
		// Do lovely arc tangent stuff to figure out direction, then multiply by Mathf.Rad2Deg to convert to degrees
		transform.localRotation = Quaternion.Euler(0, 0, -Mathf.Atan2(newAngle.x, newAngle.y) * Mathf.Rad2Deg);

		// Temporary variable
		float speed = acceleration;
		// Check for sprinting and modify the animator speed too
		if (Input.GetButton("Sprint")) {
			speed *= 2.5f;
			animator.speed = 1f;
		} else {
			animator.speed = 0.5f;
		}

		// rot.ToSide() is an extension method of mine used to turn a vector 90 degrees to the right.
		// Yes, ugly, but it is needed for side-to-side movement.
		Vector2 motion = rot * Input.GetAxis("Vertical") + rot.ToSide() * Input.GetAxis("Horizontal");
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
