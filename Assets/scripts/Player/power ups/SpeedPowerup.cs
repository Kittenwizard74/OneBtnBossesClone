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

    #endregion

    #region Base Methods
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();

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
        powerUpLoad.minValue = 0;
        powerUpLoad.maxValue = 100;
        powerUpLoad.value = powerUpLoad.maxValue;
    }
    #endregion
}