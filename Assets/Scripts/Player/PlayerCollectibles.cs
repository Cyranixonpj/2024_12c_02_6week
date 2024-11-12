
using TMPro;
using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public int _goldCoinCounter;
    public TMP_Text _goldCoinText;
    public int _silverCoinCounter;
    public TMP_Text _silverCoinText;
    public int _diamondCounter;
    public TMP_Text _diamondText;
    public int _keyCounter;
    public TMP_Text _keyText;
    public int _keyCounterForPlayer;

   


    private void Awake()
    {
        _goldCoinCounter = 0;
        _silverCoinCounter = 0;
        _diamondCounter = 0;
        _keyCounter = 0;
        _goldCoinText.text = _goldCoinCounter.ToString();
        _silverCoinText.text = _silverCoinCounter.ToString();
        _diamondText.text = _diamondCounter.ToString();
        _keyText.text = _keyCounter.ToString();
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
        if (other.gameObject.CompareTag("Key"))
        {
            AddKey();
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
    private void AddKey()
    {
        _keyCounter += 1;
        _keyCounterForPlayer += 1;
        _keyText.text = _keyCounter.ToString();
    }
    public int GetKeyCount()
    {
        return _keyCounterForPlayer;
    }
    public void UseKey()
    {
        _keyCounterForPlayer -= 1;
    }

    public bool HasKey()
    {
        return _keyCounterForPlayer > 0;
    }
}