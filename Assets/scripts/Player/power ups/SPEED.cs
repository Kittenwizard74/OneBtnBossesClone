using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class SPEED : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostedSpeed = 10f;
    public float energy = 100f;
    public float energyDrainRate = 20f;
    public float rechargeRate = 10f;
    public float rechargeDelay = 2f;
    public Slider energySlider;
    public Rigidbody2D playerRb;
    private bool isPowerUpActive = false;
    private bool isRecharging = false;

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
            isPowerUpActive = true;
        }

        if (energy <= 0)
        {
            isPowerUpActive = false;
            StartCoroutine(RechargeEnergy());
        }

        if (isPowerUpActive)
        {
            ActivatePowerUp();
        }
        else
        {
            DeactivatePowerUp();
        }
    }

    void ActivatePowerUp()
    {
        playerRb.velocity = new Vector2(boostedSpeed, playerRb.velocity.y);
        energy -= energyDrainRate * Time.deltaTime;
    }

    void DeactivatePowerUp()
    {
        playerRb.velocity = new Vector2(normalSpeed, playerRb.velocity.y);
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPowerUpActive && collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            Debug.Log("No hay colisión porque el powerup está activado.");
        }
    }
}
