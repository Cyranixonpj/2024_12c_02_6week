using System;
using TMPro;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    private int _goldCoinCounter;
    public TMP_Text _goldCoinText;
    private int _silverCoinCounter;
    public TMP_Text _silverCoinText;
    private int _diamondCounter;
    public TMP_Text _diamondText;


    private void Awake()
    {
        _goldCoinCounter = 0;
        _silverCoinCounter = 0;
        _diamondCounter = 0;
        _goldCoinText.text = _goldCoinCounter.ToString();
        _silverCoinText.text = _silverCoinCounter.ToString();
        _diamondText.text = _diamondCounter.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gold coins"))
        {
            AddGoldCoin();
        }

        if (other.gameObject.CompareTag("Silver coins"))
        {
            AddSilverCoin();
        }

        if (other.gameObject.CompareTag("Diamonds"))
        {
            AddDiamond();
        }
    }


    private void AddGoldCoin()
    {
        _goldCoinCounter += 1;
        _goldCoinText.text = _goldCoinCounter.ToString();
    }

    private void AddSilverCoin()
    {
        _silverCoinCounter += 1;
        _silverCoinText.text = _silverCoinCounter.ToString();
    }

    private void AddDiamond()
    {
        _diamondCounter += 1;
        _diamondText.text = _diamondCounter.ToString();
    }
}