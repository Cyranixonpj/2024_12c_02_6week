using System;
using UnityEngine.UI;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _pauseView;
    [SerializeField] private GameObject _settingsView;
     private bool _isPaused;
     public Toggle fullscreenToggle;
     public Toggle musicToggle;
     private AudioManager _audioManager;


    private void Awake()
    {
        
        _mainView.SetActive(true);
        _pauseView.SetActive(false);
        _settingsView.SetActive(false);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }

    public void Start()
    {
        if (_audioManager.IsMute() == true)
            musicToggle.isOn = true;
        else
            musicToggle.isOn = false;
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        
    }
    public void MusicToggle()
    {
        if(_audioManager.IsMute() == false)
        {
            _audioManager.MuteMusic();
        }
        else
        {
            _audioManager.UnMuteMusic();
        }
    }


    public void SettingsClicked()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        _pauseView.SetActive(false);
        _settingsView.SetActive(true);
    }
    

    Vector2Int rez = new Vector2Int(1920, 1080);
    public void ToggleFullScreen()
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
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, mode); //This is the important part!
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
}


