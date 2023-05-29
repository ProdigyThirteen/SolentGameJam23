using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    [Header("Segments")]
    [SerializeField] private GameObject segmentPrefab;
    private int _remainingSegments = 0;
    private List<GameObject> _segments = new List<GameObject>();

    [Header("Movement")]
    [SerializeField] private float movementTimer = 0.5f;
    private float _movementTimer = 0.0f;
    private bool _extend = false;
    private Rigidbody2D _rb;
    private bool _canfall = true;

    private Vector3 _lastTeleportLocation;
    [Header("Sprites")]
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite extendingSprite;

    void Start()
    {
        // Initialise remaining segments
        _remainingSegments = GameManager.Instance.TotalSegments;

        // Initialise rigidbody
        _rb = GetComponent<Rigidbody2D>();

        _lastTeleportLocation = transform.position;
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        // Update movement timer and handle input
        _movementTimer -= Time.deltaTime;
        
        HandleInput();

        if (_extend)
            GetComponent<SpriteRenderer>().sprite = extendingSprite;
        else
            GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    private void HandleInput()
    {
        GameObject hit = CheckCollision(Vector3.down, 0.6f, _canfall);
        if (!_extend && (hit == null || hit.GetComponent<Segment>()!=null))
            return;

        // Check if should switch between placement or movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _extend = !_extend;

            if (_extend)
            {
                _rb.bodyType = RigidbodyType2D.Static;
                _canfall = false;
            }
                
            else
            {
                _rb.bodyType = RigidbodyType2D.Dynamic;
                _canfall = true;

            }
                
            if (_segments.Count > 0)
            {
                StartCoroutine(ConfirmExtend());
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _extend = !_extend;

            if (_segments.Count > 0)
            {
                //StartCoroutine(CancelExtend());
                CancelExtend();
            }
        }

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
            if (CheckCollision(Vector3.right) == null)
            {
                transform.Translate(Vector3.right);
                _movementTimer = movementTimer;                
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (CheckCollision(Vector3.left) == null)
            {
                transform.Translate(Vector3.left);
                _movementTimer = movementTimer;
            }
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject hit = CheckCollision(Vector3.right);

            if (hit != null)
                SelfHitDetected(hit);
            else
                PlaceSegment(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject hit = CheckCollision(Vector3.left);

            if (hit != null)
                SelfHitDetected(hit);
            else
                PlaceSegment(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject hit = CheckCollision(Vector3.down);

            if (hit != null)
                SelfHitDetected(hit);
            else
                PlaceSegment(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject hit = CheckCollision(Vector3.up);

            if (hit != null)
                SelfHitDetected(hit);
            else
                PlaceSegment(Vector3.up);
        }
    }

    private GameObject CheckCollision(Vector3 direction, float rayLength=1.0f, bool collect=true)
    {
        // Raycast to check for collision
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayLength);

        // If hit, return the object
        if (hit.collider != null)
        {

            // Check for a pickup component
            BasePickup PickUp = hit.collider.gameObject.GetComponent<BasePickup>();

            // If found and player wants to collect, call collect on the base class, and return null to allow the player to move into it.
            if (PickUp != null && collect == true)
            {
                PickUp.Collect();
                return null;
            }

            if (hit.collider.gameObject.GetComponent<PortalScript>() != null)
                return null;

            return hit.collider.gameObject;
        }
        

        // Otherwise, return null
        return null;
    }
    private void SelfHitDetected(GameObject other)
    {

        if (_segments.Count() == 0)
            return;
        
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

    IEnumerator ConfirmExtend()
    {
        // Iterate through segement list and dissipate segment
        foreach (GameObject segment in _segments)
        {
            segment.GetComponent<Segment>().Dissipate();
            yield return new WaitForSeconds(0.01f);
        }

        // Clear list of segements
        _segments.Clear();

        // Reset remaining segments
        _remainingSegments = GameManager.Instance.TotalSegments;
    }

    private void CancelExtend()
    {
        transform.position = _segments.First().transform.position;
        
        foreach (GameObject segment in _segments)
        {
            segment.GetComponent<Segment>().Dissipate();
            //yield return new WaitForSeconds(0.1f);
        }

        _segments.Clear();

        _remainingSegments = GameManager.Instance.TotalSegments;

        //yield return null;
    }

    public void AddSegment()
    {

        _remainingSegments += 1;

    }

    public bool IsExtending()
    {
        return _extend;
    }

    public Vector3 getLastTeleportLocation()
    {
        return _lastTeleportLocation;
    }

    public void setLastTeleportLocation()
    {
        _lastTeleportLocation = gameObject.transform.position;
    }

    public GameObject getFirstSegment()
    {

        if (_segments.Count() > 0)
            return _segments.First();
        else
            return gameObject;

    }

    public void forceCancel()
    {

        if (_segments.Count > 0)
        {
            StartCoroutine(ConfirmExtend());
        }

        _extend = !_extend;

        _rb.bodyType = RigidbodyType2D.Dynamic;
        _canfall = true;

    }

    public int getSegmentCount()
    {

        return _segments.Count();

    }
}
