using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    public float maxSpeed = 4f;
    public float acceleration = 20f;
    public float deceleration = 15f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var kb = Keyboard.current; // shortcut so I don't have to type Keyboard.current every time

        Vector2 moveInput = Vector2.zero;

        // Pressing opposite keys (like W and S) cancels out to 0
        if (kb.wKey.isPressed) moveInput.y += 1f;
        if (kb.sKey.isPressed) moveInput.y -= 1f;
        if (kb.dKey.isPressed) moveInput.x += 1f;
        if (kb.aKey.isPressed) moveInput.x -= 1f;

        // Makes the length 1, so moving diagonally isn't faster than moving straight
        moveInput = moveInput.normalized;

        Vector2 targetVelocity = moveInput * maxSpeed;

        // Short if/else: use acceleration if a key is pressed, otherwise deceleration
        float rate = (moveInput.magnitude > 0f) ? acceleration : deceleration;

        // Moves the velocity a little closer to the target each frame, so the player
        // speeds up and slows down smoothly. Time.deltaTime keeps it the same at any frame rate.
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, rate * Time.deltaTime);

        rb.linearVelocity = currentVelocity;
    }
}