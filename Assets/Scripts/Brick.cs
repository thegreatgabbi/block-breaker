using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        // Keep track if breakable bricks
        if (isBreakable) {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
        if (isBreakable)
        {
            HandleHits();
            print(breakableCount);
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            Debug.Log("Instantiate smoke.");
            breakableCount--;
            levelManager.BrickDestoyed();
            ParticleSystem.MainModule newMain = smoke.GetComponent<ParticleSystem>().main;
            newMain.startColor = this.GetComponent<SpriteRenderer>().color;
            GameObject smokeObj = Instantiate(smoke, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Brick sprite missing");
        }
    }

    // TODO Remove this method once we can actually win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
