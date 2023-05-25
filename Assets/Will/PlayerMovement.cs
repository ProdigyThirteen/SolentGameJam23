using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    
    [Header("Segments")]
    [SerializeField] private GameObject segmentPrefab;
    private int _remainingSegments = 0;
    private List<GameObject> _segments = new List<GameObject>();

    [Header("Movement")]
    [SerializeField] private float movementTimer = 0.5f;
    private float _movementTimer = 0.0f;
    private bool _extend = false;

    void Start()
    {
        // Initialise remaining segments
        _remainingSegments = GameManager.Instance.TotalSegments;
    }

    void Update()
    {
        // Update movement timer and handle input
        _movementTimer -= Time.deltaTime;
        
        HandleInput();
    }

    private void HandleInput()
    {
        // Check if should switch between placement or movement
        if (Input.GetKeyDown(KeyCode.Space))
            _extend = !_extend;

        if (_extend)
            HandlePlacement();
        else
            HandleMovement();
    }

    private void HandleMovement()
    {
        // If timer is still running, don't move
        if (_movementTimer > 0)
            return;

        // Otherwise, move and reset timer
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right);
            _movementTimer = movementTimer;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left);
            _movementTimer = movementTimer;
        }
    }

    // Order of operation for placement:
    /*
     * Validate movement direction
     *  - If moving backwards, revert last move
     *    - Recoup segment
     *  - If moving to new position, place new segment
     *    - Check remaining segment count
     *      - If 0, do nothing
     *      - If > 0, place new segment
     *  - If movement would collide with environment, do nothing
    */
    
    private void HandlePlacement()
    {
        // Check for objects at desired location

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject hit = CheckCollision(Vector3.right);

            if (hit != null)
                HitDetected(hit);
            else
                PlaceSegment(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject hit = CheckCollision(Vector3.left);

            if (hit != null)
                HitDetected(hit);
            else
                PlaceSegment(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject hit = CheckCollision(Vector3.down);

            if (hit != null)
                HitDetected(hit);
            else
                PlaceSegment(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject hit = CheckCollision(Vector3.up);

            if (hit != null)
                HitDetected(hit);
            else
                PlaceSegment(Vector3.up);
        }
    }

    private GameObject CheckCollision(Vector3 direction)
    {
        // Raycast to check for collision
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1.0f);

        // If hit, return the object
        if (hit.collider != null)
            return hit.collider.gameObject;

        // Otherwise, return null
        return null;
    }
    private void HitDetected(GameObject other)
    {
        if (_segments.Last() == other)
        {
            transform.position = other.transform.position;
            _segments.Remove(other);
            Destroy(other);
            _remainingSegments++;
        }
    }

    private void PlaceSegment(Vector3 direction)
    {
        if (_remainingSegments > 0)
        {
            GameObject newSegment = Instantiate(segmentPrefab, transform.position, Quaternion.identity);
            _segments.Add(newSegment);
            _remainingSegments--;

            transform.Translate(direction);
        }
    }
}
