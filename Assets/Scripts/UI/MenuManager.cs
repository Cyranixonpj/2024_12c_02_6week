using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainView;

    private void Awake()
    {
        _mainView.SetActive(true);
    }
    
    #region Main Menu

    public void StartClicked()
    {
        SceneManager.LoadScene("Wiki-Player");

    }

    public void ExitClicked()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    #endregion
}
