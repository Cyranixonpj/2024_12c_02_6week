using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = (float)playerHealth._currentHealth / playerHealth._maxHealth;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = (float)playerHealth._currentHealth / playerHealth._maxHealth;
    }
}