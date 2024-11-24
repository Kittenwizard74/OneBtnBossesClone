using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class SpeedPowerup : MonoBehaviour
{
    #region Variables
    [SerializeField] float energy = 100f;
    [SerializeField] float energyDrainRate = 20f;
    [SerializeField] float rechargeRate = 10f;
    [SerializeField] float rechargeDelay = 2f;
    [SerializeField] Slider energySlider;
    public Player playerScript;
    //private bool isPowerUpActive = false;
    private bool isRecharging = false;
    #endregion

    #region Base Methods
    void Start()
    {
        energySlider.maxValue = 100f;
        energySlider.value = energy;
    }

    void Update()
    {
        energySlider.value = energy;

        if (Input.GetKeyDown(KeyCode.Space) && !isRecharging && energy > 0)
        {
            playerScript.ActivateSpeedBoost();
            energy -= energyDrainRate * Time.deltaTime;

            if (energy <= 0)
            {
                StartCoroutine(RechargeEnergy());
            }
        }
        else
        {
            playerScript.DeactivateSpeedBoost();
        }
    }
    #endregion

    #region Custom Variables
    System.Collections.IEnumerator RechargeEnergy()
    {
        if (isRecharging) yield break;
        isRecharging = true;

        yield return new WaitForSeconds(rechargeDelay);

        while (energy < 100f)
        {
            energy += rechargeRate * Time.deltaTime;
            energySlider.value = energy;
            yield return null;
        }

        isRecharging = false;
    }
    #endregion
}