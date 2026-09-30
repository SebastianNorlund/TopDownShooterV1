using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winUI;

    void Start()
    {
        winUI.SetActive(false); // sets winUI to disabled by default
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // runs if gameobject tagged Player collides with the box collider 2D
        {
            winUI.SetActive(true); // shows the win UI when the player enters the trophy's trigger
        }
    }




    public void EndGame() // called by the win button's On Click event
    {
        Application.Quit(); // closes the game (only works in a built game)

#if UNITY_EDITOR // starts if statement
        UnityEditor.EditorApplication.isPlaying = false; // stops Play mode, since the Application.Quit(); doesnt work in the unity editor
#endif // ends if statement
    }





}