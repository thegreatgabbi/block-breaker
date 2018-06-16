using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;
    private float maxX = 0.75f;
    private float maxY = 15.25f;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = this.ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, maxX, maxY);

        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        float MousePosInBox = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(MousePosInBox, maxX, maxY);

        this.transform.position = paddlePos;
    }
}
