using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    #region Variables
    [Header("Movimiento")]
    [SerializeField] public float velocidad = 5f;
    private Vector3 direccion = Vector3.forward;
    public bool isSpeedBoostActive = false;
    PlayerInputs playerInputActions;

    [Header("Disparo")]
    [SerializeField] GameObject bulletPrefab; 
    [SerializeField] Transform shootPoint; 
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float fireRate = 1f;
    #endregion

    #region Base Methods
    private void Start()
    {
        StartCoroutine(handleShooting());

        playerInputActions = new PlayerInputs();
        playerInputActions.Player.Enable();
        playerInputActions.Player.RotateMov.performed += HandleMovement;
    }

    void Update()
    {
        float speed = isSpeedBoostActive ? velocidad * 2 : velocidad;
        transform.RotateAround(Vector3.zero, direccion, velocidad * Time.deltaTime);
    }

    private IEnumerator handleShooting()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = shootPoint.up * bulletSpeed;
            }
            yield return new WaitForSeconds(fireRate);
        }
    }
    #endregion

    #region Custom Variables
    public void HandleMovement(InputAction.CallbackContext context) 
    {
        Debug.Log("Cambio de direccion (desde InputAction)!" + context);
        direccion = -direccion;
    }

    public void ActivateSpeedBoost()
    {
        isSpeedBoostActive = true;
        Debug.Log("Speed boost activado");
    }

    public void DeactivateSpeedBoost()
    {
        isSpeedBoostActive = false;
    }
    #endregion
}
