using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior.
/// </summary>


public class BalloonScript : MonoBehaviour {

	// The speed.
	public Vector2 speed = new Vector2 (10, 0);

	// Store the movement.
	private Vector2 movement;

	// Update is called once per frame
	void Update () {
		// Retrieve axis information
		float inputX = Input.GetAxis ("Horizontal");

		// Movement per direction
		movement = new Vector2 (speed.x * inputX, 0);
	
		// Make sure we are not outside the camera bound
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (
			new Vector3 (0, 0, dist)).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)).x;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			transform.position.y,
			transform.position.z);		
	} //Update

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}//FixedUpdate

	void OnCollisionEnter2D(Collision2D collision)
	{
		//bool damagePlayer = false;

		// Collision with enemy
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			//kill player
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			//damagePlayer = true;
			Destroy(gameObject);
		}

			
	}
}
