using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	private Vector2 rot;
	private Rigidbody2D rb;
	private Animator animator;

	public float acceleration = 3f;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		animator.StopPlayback ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		rb.velocity /= 1.2f;

		Vector3 newAngle = (Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position)).normalized;
		rot = new Vector2 (newAngle.x, newAngle.y);
		transform.localRotation = Quaternion.Euler (0, 0, -Mathf.Atan2 (newAngle.x, newAngle.y) * Mathf.Rad2Deg);

		float speed = acceleration;
		if (Input.GetButton ("Sprint")) {
			speed *= 2.5f;
			animator.speed = 1f;
		} else {
			animator.speed = 0.5f;
		}

		Vector2 motion = rot * Input.GetAxis ("Vertical") + rot.ToSide () * Input.GetAxis ("Horizontal");
		rb.velocity = motion * speed;

		if (motion.magnitude > 0.2) {
			animator.SetBool ("Moving", true);
		} else {
			animator.SetBool ("Moving", false);
		}

	}

}
