using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTextField;
    public int score = 0;


    private void Start()
    {
        score = 0;
    }


    private void AddScore(int coinValue)
    {
        score += coinValue;
        scoreTextField.text = "Score:" + score;
    }


    private void OnEnable()
    {
        Coin.OnCoinCollected += AddScore;
    }
}
