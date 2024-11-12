using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    #region Variables
    [Header("movimiento")]
    [SerializeField] float velocidad = 5f;
    private Vector3 direccion = Vector3.forward;

    [Header("disparo")]
    [SerializeField] GameObject bulletPrefab; 
    [SerializeField] Transform shootPoint; 
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] float fireRate = 1f;
    #endregion
    #region base methods

    private void Start()
    {
        StartCoroutine(handleShooting());
    }
    void Update()
    {
        transform.RotateAround(Vector3.zero, direccion, velocidad * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleMovement();
        }
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
    #region custom variables
    protected virtual void HandleMovement()
    {
        direccion = -direccion;
    }

    //protected virtual void IncreaseSpeed()
    //{

    //}
    #endregion
}
