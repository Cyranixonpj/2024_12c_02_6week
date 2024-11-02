using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;
    [SerializeField] private GameObject _pauseView;
    [SerializeField] private GameObject _settingsView;
     private bool _isPaused;
     public Toggle fullscreenToggle;


    private void Awake()
    {
        
        _mainView.SetActive(true);
        _pauseView.SetActive(false);
        _settingsView.SetActive(false);
    }
    
    private void Start()
    {
        //fullscreenToggle.isOn = false;

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


    public void SettingsClicked()
    {
        _pauseView.SetActive(false);
        _settingsView.SetActive(true);
    }
    
    // public void ToggleFullscreen(bool fullscreen)
    // {
    //     Screen.fullScreen = fullscreen;
    //     if (Screen.fullScreen)
    //     {
    //         Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    //     }
    //     else
    //     {
    //         Screen.fullScreenMode = FullScreenMode.Windowed;
    //     }
    // }
    Vector2Int rez = new Vector2Int(1920, 1080);
    public void ToggleFullScreen()
    {
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
    
    
    
    
    
    void ResumeGame()
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


