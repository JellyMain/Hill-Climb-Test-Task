using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Crash : MonoBehaviour
{
    public static event Action<Vector3> OnPlayerDied = delegate { };

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            OnPlayerDied?.Invoke(transform.position);
        }
    }
}
