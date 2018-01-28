using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
	public GameObject cam;
	public CurveMover curveMover;
	Rigidbody rigidBody;

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;

	void Awake () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		rigidBody = GetComponent<Rigidbody> ();

		rigidBody.freezeRotation = true;
		rigidBody.useGravity = false;
	}

	void FixedUpdate () {
		MoveCamera();
		if (grounded) {
			Move(GetVelocity());

			if (canJump && Input.GetButtonDown("Jump")) {
				Jump();
			}
		} 
		CalculateGravity();
	}

	void Move(Vector3 velocity){
		rigidBody.AddForce (velocity, ForceMode.VelocityChange);
	}

	Vector3 GetVelocity(){
		Vector3 targetVelocity = GetInputDirection();
		targetVelocity = transform.TransformDirection (targetVelocity);
		targetVelocity *= speed;

		Vector3 velocity = rigidBody.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;

		return velocityChange;
	}

	Vector3 GetInputDirection(){
		Vector3 directionHorizontal = cam.transform.right * Input.GetAxisRaw ("Horizontal");
		Vector3 directionVertical = cam.transform.forward * Input.GetAxisRaw ("Vertical");
		Vector3 direction = directionVertical + directionHorizontal;
		direction.y = 0;

		return direction;
	}

	void MoveCamera(){
		//if(Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) curveMover.OnTrigger();
	}

	void CalculateGravity(){
		rigidBody.AddForce(new Vector3 (0, -gravity * rigidBody.mass, 0));
		grounded = false;
	}

	void Jump(){
		Vector3 velocity = rigidBody.velocity;
		rigidBody.velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
		canJump = false;
	}

	void OnCollisionStay (Collision coll) {
		grounded = true;
		if(coll.gameObject.tag == "Land") canJump = true;    
	}

	void OnCollisionExit(Collision coll){

	}

	float CalculateJumpVerticalSpeed () {
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}


}