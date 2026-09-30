using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerSpawnerLocation;
    public GameObject gameOverScreen;

    private HealthScript healthScript;
    private bool isDead = false;

    void Start()
    {
        healthScript = GetComponent<HealthScript>();   // Get HealthScript so that you can reference the health int
        transform.position = playerSpawnerLocation.position; // makes spawnpoint easily customizable
        gameOverScreen.SetActive(false); // game over screen should be disabled at start
    }

    void Update()
    {
        if (!isDead && healthScript.health <= 0)
        {
            isDead = true; // makes sure the death code only runs once, not every frame
            gameOverScreen.SetActive(true); //enables the game over screen
            Time.timeScale = 0f; // pauses the game
        }
    }


    public void Respawn()
    {
        transform.position = playerSpawnerLocation.position; // makes player move back to spawnpoint
        healthScript.health = 100; // resets health back to 100
        gameOverScreen.SetActive(false); // disable game over screen
        Time.timeScale = 1f; // unpause game
        isDead = false; 
    
    
    
    
    
    
    }



}




