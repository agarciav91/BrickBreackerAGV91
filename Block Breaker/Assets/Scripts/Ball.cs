using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	
	private bool hasStarted = false;
	
	private Vector3 paddleToBallVector;
	
	void OnCollisionEnter2D (Collision2D colission){
		Vector2 tweak = new Vector2(Random.Range (0f, 0.05f), Random.Range (0f, 0.05f)) ;
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}

	// Use this for initialization
	void Start () {
	paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print (paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted){
		//Locks the ball in the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
		//waits for a mouse press to launch
			if (Input.GetMouseButtonDown(0)) {
			print ("Mouse clicked, launch ball");
			hasStarted = true;
			this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
