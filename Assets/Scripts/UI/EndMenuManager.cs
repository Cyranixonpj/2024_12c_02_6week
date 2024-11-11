using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private TMP_Text _goldCoinText;
    [SerializeField] private TMP_Text _silverCoinText;
    [SerializeField] private TMP_Text _diamondText;
    [SerializeField] private TMP_Text _keyText;
    [SerializeField] private TMP_Text _timeText;
    private AudioManager _audioManager;
    
    
    private void Awake()
    {
        _mainView.SetActive(true);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }

    private void Start()
    {
        
        _goldCoinText.text = "Gold Coins :    " + PlayerPrefs.GetInt("GoldCoins")+"/"+PlayerPrefs.GetInt("GoldCoinsTotal");
        _silverCoinText.text = "Silver Coins :    " +PlayerPrefs.GetInt("SilverCoins")+"/"+PlayerPrefs.GetInt("SilverCoinsTotal");
        _diamondText.text = "Diamonds :    " +PlayerPrefs.GetInt("Diamonds")+"/"+PlayerPrefs.GetInt("DiamondsTotal");
        _keyText.text = "Keys :    " +PlayerPrefs.GetInt("Keys")+"/"+PlayerPrefs.GetInt("KeysTotal");
        _timeText.text = "Time :    " +PlayerPrefs.GetFloat("Time");
    }
    
    public void Menu()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        SceneManager.LoadSceneAsync("Wiki-Menu");
    }
    
    public void ExitClicked()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
