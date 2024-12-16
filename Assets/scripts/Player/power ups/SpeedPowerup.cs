using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class SpeedPowerup : MonoBehaviour
{
    #region Variables
    [SerializeField] float speedBoost;
    [SerializeField] Slider powerUpLoad;
    private float normalSpeed;
    private Player player;
    private PlayerHealth playerHealth;
    [SerializeField] private Slider sliderPwrp;

    #endregion

    #region Base Methods
    void Start()
    {
        if (powerUpLoad == null)
        {
            Debug.LogError("PowerUpLoad Slider reference is missing.");
        }
        else
        {
            Debug.Log("PowerUpLoad Slider reference is assigned.");
        }

        player = gameObject.GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("Player component not found.");
        }

        playerHealth = gameObject.GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth component not found.");
        }

        normalSpeed = player.velocidad;
        SetSliderValues();
    }

    void Update()
    {
        PowerUpEffect();
    }
    #endregion

    #region Custom Variables
    private void PowerUpEffect()
    {
        if (powerUpLoad == null)
        {
            Debug.LogError("PowerUpLoad slider is not assigned!");
            return; // Salir de la función si no está asignado
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (powerUpLoad.value > 0)
            {
                PowerUpState(false, player.velocidad, speedBoost);
                powerUpLoad.value -= Time.deltaTime * 100;
            }
            else
            {
                PowerUpState(true, normalSpeed, 0);
            }
        }
        else
        {
            PowerUpState(true, normalSpeed, 0);
            powerUpLoad.value += Time.deltaTime * 100;
        }
    }


    private void PowerUpState(bool playerCanTakeDamage, float speed, float aditionalSpeed)
    {
        playerHealth.canTakeDamage = playerCanTakeDamage;
        player.velocidad = speed + aditionalSpeed;
    }


    private void SetSliderValues()
    {
        if (powerUpLoad != null)
        {
            powerUpLoad.minValue = 0;
            powerUpLoad.maxValue = 100;
            powerUpLoad.value = powerUpLoad.maxValue;
        }
        else
        {
            Debug.LogError("Slider reference is still null, cannot set values.");
        }
    }

    #endregion
}