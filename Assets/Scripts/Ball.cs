using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Lock the ball relative to the paddle
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }

        // Wait for a mouse press to launch
        if (Input.GetMouseButtonDown(0))
        {
            print("mouse clicked");
            hasStarted = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }

    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        // add random amounts to X and Y
        Vector2 tweak = new Vector2(Random.Range(0, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted) {
			GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
	}
}
