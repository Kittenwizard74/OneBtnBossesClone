using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    #region variables

    [Header("Health")]
    [SerializeField] int HPEnemy;

    [SerializeField] GameObject victoryPanel;
    #endregion
    #region base methods

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            HandleEnemyHealth();
        }
    }
    #endregion
    #region custom methods
    protected virtual void HandleEnemyHealth()
    {
        --HPEnemy;

        if (HPEnemy <= 0)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    #endregion
}
