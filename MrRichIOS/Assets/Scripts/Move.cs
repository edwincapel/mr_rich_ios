using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Move : MonoBehaviour {


	public float speed = 10, jumpVelocity = 10;
	Rigidbody2D myBody;
	float hInput = 0;

	void Start () {

		myBody = this.GetComponent<Rigidbody2D>();


	}

	void Update () {

		Mov(hInput);


		//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);


		Vector3 playerSize = GetComponent<Renderer>().bounds.size;

		// Here is the definition of the boundary in world point
		var distance = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x + (playerSize.x/2);
		var rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x - (playerSize.x/2);

		var bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).y + (playerSize.y/2);
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distance)).y - (playerSize.y/2);
		transform.position = new Vector3 ((Mathf.Clamp(transform.position.x, leftBorder-0.5f, rightBorder+0.7f)), Mathf.Clamp (transform.position.y, bottomBorder, topBorder),-5);




	}

	void Mov(float horizonalInput)
	{

		Vector2 moveVel = myBody.velocity;
		moveVel.x = horizonalInput * speed;
		myBody.velocity = moveVel;
	}


	public void StartMoving(float horizontalInput){

		hInput = horizontalInput;

	}

}

