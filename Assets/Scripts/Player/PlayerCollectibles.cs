using System;
using TMPro;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    private int _goldCoinCounter;
    public TMP_Text _goldCoinText;

    private void Awake()
    {
        _goldCoinCounter = 0;
        _goldCoinText.text = _goldCoinCounter.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gold coins"))
        {
            AddGoldCoin();
        }
    }


    private void AddGoldCoin()
    {
        _goldCoinCounter += 1;
        _goldCoinText.text = _goldCoinCounter.ToString();
    }
}