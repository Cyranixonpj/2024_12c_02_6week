using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _settingsView;
    private AudioManager _audioManager;
    public Toggle musicToggle;

    private void Awake()
    {
        _mainView.SetActive(true);
        _settingsView.SetActive(false);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
    }

  


    public void StartClicked()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        SceneManager.LoadScene("Wiki-Player");

    }
    
    public void SettingsClicked()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        _mainView.SetActive(false);
        _settingsView.SetActive(true);
        musicToggle.isOn = !_audioManager.IsMute();


    }

    public void ReturnClicked()
    {
        _audioManager.PlaySFX(_audioManager.ButtonCLicked);
        _settingsView.SetActive(false);
        _mainView.SetActive(true);
        
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
