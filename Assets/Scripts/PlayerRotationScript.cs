using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerRotationScript : RotatorScript // "Inherits from RotatorScript instead of MonoBehaviour, so it can use LookAt"
{

    // "Called automatically by the Player Input component whenever the "Look" action
    // "changes, which here means whenever the mouse moves"
    private void OnLook(InputValue value)
    {

        // "The mouse position comes in screen pixels, so it's converted
        // to a position in the game world"
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());


        LookAt(mousePosition); // "rotates the player to face the mouse"
    }
}