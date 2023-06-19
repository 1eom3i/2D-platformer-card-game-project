using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockplatformController : MonoBehaviour
{
    public GameObject root;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Set Rigidbody2D to kinematic at start
    }

    // Call this method when the root disappears
    public void DetachFromRoot()
    {
        if (root != null)
        {
            root = null;
            rb.isKinematic = false; // Set Rigidbody2D to dynamic (non-kinematic) so it can fall
        }
    }
}
