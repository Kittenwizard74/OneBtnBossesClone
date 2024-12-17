using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    #region variables

    [Header("HP")]
    [SerializeField] int MaxHP = 3;
    [SerializeField] int CurrentHP;

    [SerializeField] public GameObject deathPanel;
    [SerializeField] private GameObject[] lifeSprites;

    [SerializeField] public bool canTakeDamage = true;
    private bool alive;
    
    #endregion
    #region base methods
    void Awake()
    {
        alive = true;
        CurrentHP = MaxHP;

        if (deathPanel == null)
        {
            deathPanel = new GameObject("DeathPanel");
            deathPanel.SetActive(false); 
        }

        deathPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alive && canTakeDamage && collision.CompareTag("Enemy_Bullet"))
        {
            TakeDamage();
        }
    }

    #endregion
    #region custom methods
    public void handleHealth()
    {
        if(CurrentHP <= 0) 
        {
            deathPanel.SetActive(true);
            alive = false;
            Time.timeScale = 0f;
        }
    }

    private void TakeDamage()
    {
        if (CurrentHP > 0)
        {
            CurrentHP--;
            if (CurrentHP < lifeSprites.Length)
            {
                lifeSprites[CurrentHP].SetActive(false);
            }

            handleHealth();
        }
    }
    #endregion
}
