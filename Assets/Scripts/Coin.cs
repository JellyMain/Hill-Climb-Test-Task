using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static event Action<int> OnCoinCollected = delegate { };

    [SerializeField] int scoreValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnCoinCollected?.Invoke(scoreValue);
        }
    }
}
