using UnityEngine;

/// <summary>
/// Binds object to the screen
/// </summary>
public class BoundObjectToScreen : MonoBehaviour
{
    /// <summary>
    /// Camera field
    /// </summary>
    private Camera _camera;

    /// <summary>
    /// Vector for bottom left screen
    /// </summary>
    private Vector2 screenMin;

    /// <summary>
    /// Vector for top right screen
    /// </summary>
    private Vector2 screenMax;

    /// <summary>
    /// Object width field
    /// </summary>
    private float objectWidth;

    /// <summary>
    /// Initialize camera and current object width
    /// </summary>
    private void Start()
    {
        _camera = Camera.main;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    /// <summary>
    /// Keeps the object in bounds
    /// </summary>
    private void LateUpdate()
    {
        // Gets the proper camera vectors and translates to world coordinates
        screenMin = _camera.ViewportToWorldPoint(Vector2.zero);
        screenMax = _camera.ViewportToWorldPoint(Vector2.one);

        // Current object position
        Vector3 viewPos = transform.position;

        // Clamp position of object to the bounds of the screen according to it's hitbox
        viewPos.x = Mathf.Clamp(viewPos.x, screenMin.x + objectWidth, screenMax.x - objectWidth);
        transform.position = viewPos;
    }
}