using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    private float _startTime;
    private float _elapsedTime;
    private bool _isTiming;

    private void Start()
    {
        StartTimer();

    }
    
    public void StartTimer()
    {
        _startTime = Time.time;
        _isTiming = true;
    }
    
    
    public void StopTimer()
    {
        if (_isTiming)
        {
            _elapsedTime = Time.time - _startTime;
            _isTiming = false;
        }
    }

    public float GetTime()
    {
        return _elapsedTime;
    }
}
