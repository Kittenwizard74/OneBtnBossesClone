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
        // Inicializar el slider
        energySlider.maxValue = 100f;
        energySlider.value = energy;
    }

    void Update()
    {
        // Actualizar el slider
        energySlider.value = energy;

        // Activar el power-up
        if (Input.GetKeyDown(KeyCode.Space) && !isRecharging && energy > 0)
        {
            isPowerUpActive = true;
        }

        // Desactivar el power-up si no hay energía
        if (energy <= 0)
        {
            isPowerUpActive = false;
            StartCoroutine(RechargeEnergy());
        }

        // Aplicar efectos del power-up
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
        // Aumentar velocidad y consumir energía
        playerRb.velocity = new Vector2(boostedSpeed, playerRb.velocity.y);
        energy -= energyDrainRate * Time.deltaTime;
    }

    void DeactivatePowerUp()
    {
        // Volver a la velocidad normal
        playerRb.velocity = new Vector2(normalSpeed, playerRb.velocity.y);
    }

    System.Collections.IEnumerator RechargeEnergy()
    {
        if (isRecharging) yield break;
        isRecharging = true;

        // Esperar antes de recargar
        yield return new WaitForSeconds(rechargeDelay);

        // Recargar energía
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
        // Invulnerabilidad mientras el power-up está activo
        if (isPowerUpActive && collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            Debug.Log("No hay colisión porque el powerup está activado.");
        }
    }
}
