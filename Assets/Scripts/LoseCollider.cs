using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    // Use this for initialization
	private void OnTriggerEnter2D(Collider2D collision)
	{
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        Brick.breakableCount = 0;
        levelManager.LoadLevel("Lose Screen");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
	}
}
