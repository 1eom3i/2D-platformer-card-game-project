using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    public float activeDuration = 1.5f;
    public float inactiveDuration = 1f;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(TogglePlatformActiveState());
    }

    private IEnumerator TogglePlatformActiveState()
    {
        while (true)
        {
            // Enable the platform's SpriteRenderer and BoxCollider2D, and wait for the active duration
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(activeDuration);

            // Disable the platform's SpriteRenderer and BoxCollider2D, and wait for the inactive duration
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(inactiveDuration);
        }
    }
}