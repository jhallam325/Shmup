using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int numberOfEnemiesOnScreen = 0;
    bool startNextLevel = false;
    public float nextLevelTimer = 3f;
    string[] levels = { "Level1", "Level2" };
    int currentLevel = 1; // index of levels

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                // Move to next level, if there is a level
                // Otherwise, we end the game.
                currentLevel++;
                if (currentLevel <= levels.Length) 
                {
                    string sceneName = level1;
                }
                else
                {
                    // Create an end game screen
                    Debug.Log("Game Over");

                }
            }
            else
            {
                // Decrease timer so at 0 we change to next level.
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddEnemy()
    {
        numberOfEnemiesOnScreen++;
    }

    public void RemoveEnemy()
    {
        numberOfEnemiesOnScreen--;

        if (numberOfEnemiesOnScreen == 0)
        {
            startNextLevel = true;
        }
    }
}
