
using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _pauseView;
    [SerializeField] private GameObject _settingsView;
    [SerializeField] private GameObject _deathView;
    [SerializeField] private GameObject _levelEndView;
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;
    private LevelTimer _levelTimer;
    private bool _isPaused;
    public TMP_Text _timeText;

    private AudioManager _audioManager;
    private PlayerCollectibles _playerCollectibles;
    
    public TMP_Text _goldCoinTextEND;
    public TMP_Text _silverCoinTextEND;
    public TMP_Text _diamondTextEND;
    public TMP_Text _keyTextEND;
    private int _goldCoinCounter;
    private int _silverCoinCounter;
    private int _diamondCounter;
    private int _keyCounter;

    private static int _goldCoinFinal;
    private static int _silverCoinFinal;
    private static int _diamondFinal;
    private static int _keyFinal;
    private static float _timeFinal;
    
    private static int _goldCoinTotal;
    private static int _silverCoinTotal;
    private static int _diamondTotal;
    private static int _keyTotal;
    private bool _levelEndProcessed = false;


    private void Awake()
    {
        
        
        Time.timeScale = 1;
        _mainView.SetActive(true);
        _pauseView.SetActive(false);
        _settingsView.SetActive(false);
        _levelEndView.SetActive(false);
        _deathView.SetActive(false);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _levelTimer = GetComponent<LevelTimer>();
        _playerCollectibles = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollectibles>();
        _levelTimer.StartTimer();
        _goldCoinCounter = GameObject.FindGameObjectsWithTag("Gold coins").Length;
        _silverCoinCounter= GameObject.FindGameObjectsWithTag("Silver coins").Length;
        _diamondCounter = GameObject.FindGameObjectsWithTag("Diamonds").Length;
        _keyCounter = GameObject.FindGameObjectsWithTag("Key").Length;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (_playerHealth._currentHealth <= 0)
        {
            StartCoroutine(Waiter1());
        }

        if (_playerMovement.levelEnd == true && !_levelEndProcessed)
        {
            _levelEndProcessed = true;
                _levelEndView.SetActive(true);
                _mainView.SetActive(false);
                _pauseView.SetActive(false);
                _settingsView.SetActive(false);
                _levelTimer.StopTimer();
               LevelStats();
               _goldCoinFinal += _playerCollectibles._goldCoinCounter;
               _silverCoinFinal += _playerCollectibles._silverCoinCounter;
               _diamondFinal += _playerCollectibles._diamondCounter;
               _keyFinal += _playerCollectibles._keyCounter;
               _timeFinal += _levelTimer.GetTime();

               _goldCoinTotal += _goldCoinCounter;
               _silverCoinTotal += _silverCoinCounter;
               _diamondTotal += _diamondCounter;
               _keyTotal += _keyCounter;
               
               if(SceneManager.GetActiveScene().buildIndex == 3)
               {
                   FinalStats();
                   _goldCoinFinal = 0;
                   _silverCoinFinal = 0;
                   _diamondFinal = 0;
                   _keyFinal = 0;
                   _timeFinal = 0;
                   _goldCoinTotal = 0;
                   _silverCoinTotal = 0;
                   _diamondTotal = 0;
                   _keyTotal = 0;
               }
              
            
        }
    }

    private void LevelStats()
    {
        // _timeText.text = _levelTimer.GetTime().ToString("F2");
        TimeSpan timeSpan = TimeSpan.FromSeconds(_levelTimer.GetTime());
        _timeText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        _goldCoinTextEND.text = _playerCollectibles._goldCoinCounter + "/" + _goldCoinCounter;
        _silverCoinTextEND.text = _playerCollectibles._silverCoinCounter + "/" + _silverCoinCounter;
        _diamondTextEND.text = _playerCollectibles._diamondCounter + "/" + _diamondCounter;
        _keyTextEND.text = _playerCollectibles._keyCounter + "/" + _keyCounter;
        
    }

    private void FinalStats()
    {
        PlayerPrefs.SetInt("GoldCoins", _goldCoinFinal);
        PlayerPrefs.SetInt("SilverCoins", _silverCoinFinal);
        PlayerPrefs.SetInt("Diamonds", _diamondFinal);
        PlayerPrefs.SetInt("Keys", _keyFinal);
        PlayerPrefs.SetFloat("Time", _timeFinal);
        
        PlayerPrefs.SetInt("GoldCoinsTotal", _goldCoinTotal);
        PlayerPrefs.SetInt("SilverCoinsTotal", _silverCoinTotal);
        PlayerPrefs.SetInt("DiamondsTotal", _diamondTotal);
        PlayerPrefs.SetInt("KeysTotal", _keyTotal);
        
    }
    

    public void Music()
    {
        if (_audioManager.IsMute() == false)
        {
            _audioManager.MuteMusic();
        }
        else
        {
            _audioManager.UnMuteMusic();
        }
    }

    public void NextLevel()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        _levelTimer.StopTimer();
        
    }
    
    public void RestartLevel()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        _levelTimer.StopTimer();
    }
    


    public void SettingsClicked()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        _pauseView.SetActive(false);
        _settingsView.SetActive(true);

       
    }


    Vector2Int rez = new Vector2Int(1920, 1080);

    public void FullScreen()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        FullScreenMode mode;
        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            //Save the windowed size
            rez.y = Screen.height;
            rez.x = Screen.width;
            //
            mode = FullScreenMode.FullScreenWindow;
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height,
                mode); //This is the important part!
        }
        else
        {
            mode = FullScreenMode.Windowed;
            Screen.SetResolution(rez.x, rez.y, mode);
        }
    }


    public void ResumeGame()
    {
        _pauseView.SetActive(false);
        _settingsView.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }

    void PauseGame()
    {
        _pauseView.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void ResumAfterDeath()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        _levelTimer.StopTimer();
    }

    public void ExitToMenu()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        SceneManager.LoadSceneAsync("Wiki-Menu");
        _levelTimer.StopTimer();
        _goldCoinFinal = 0;
        _silverCoinFinal = 0;
        _diamondFinal = 0;
        _keyFinal = 0;
        _timeFinal = 0;
        _goldCoinTotal = 0;
        _silverCoinTotal = 0;
        _diamondTotal = 0;
        _keyTotal = 0;
    }


    public IEnumerator Waiter1()
    {
        yield return new WaitForSeconds(1.5f);
        _mainView.SetActive(false);
        _pauseView.SetActive(false);
        _settingsView.SetActive(false);
        _deathView.SetActive(true);
    }
}