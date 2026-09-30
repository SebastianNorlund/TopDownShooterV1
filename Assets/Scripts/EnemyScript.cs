using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 2f;

    public Rigidbody2D body;

    private Vector2 _movementDelta; // how far and in which direction the enemy should move per second

    private float _rotation;

    private void Start()
    {
        // Finds the player automatically, since enemies are spawned from a prefab
        // and can't have the player dragged in through the Inspector
        player = GameObject.FindWithTag("Player").transform;
        _rotation = body.rotation;
    }

    // Update calculates where to go, FixedUpdate does the actual moving
    private void Update()
    {
        // Direction from the enemy to the player, with length 1
        var directionToTarget = ((Vector2)player.position - body.position).normalized;

        // Turns the direction into an angle in degrees.
        // -90 because the sprite is drawn facing up, while Unity's 0° points right
        _rotation = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90f;

        _movementDelta = directionToTarget * moveSpeed;
    }

    private void FixedUpdate() //"FixedUpdate runs in step with the physics engine, so physics movement goes here"
    {
        
        
        body.MovePosition(body.position + _movementDelta * Time.fixedDeltaTime); 
        // "MovePosition moves the enemy with physics, so it still collides with walls." 
        // Time.fixedDeltaTime makes the speed the same no matter how often this runs
        body.SetRotation(_rotation);
    }
}