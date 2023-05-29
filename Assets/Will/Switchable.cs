using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{
    public bool startActive = false;

    // Collider reference to the object
    private Collider2D _collider;

    // Colour references
    [SerializeField] private Color enabledColor;
    [SerializeField] private Color disabledColor;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        //StartCoroutine(DelayedStart());
        // Get the collider component
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the collider's active state
        _collider.enabled = startActive;

        // Set the color of the object
        _spriteRenderer.color = startActive ? enabledColor : disabledColor;
    }

    public void Toggle()
    {
        // Toggle the object's active state
        // gameObject.SetActive(!gameObject.activeSelf);

        // Toggle the collider's active state
        _collider.enabled = !_collider.enabled;

        // Change the color of the object
        _spriteRenderer.color = _collider.enabled ? enabledColor : disabledColor;
    }

    public bool GetActive()
    {
        return _collider.enabled;
    }
}