using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineAttack : MonoBehaviour
{
    [SerializeField] GameObject[] bulletSpawners;
    [SerializeField] GameObject bulletPref;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float fireRate;
    [SerializeField] float bulletSpeed;


    private void Awake()
    {
        StartCoroutine(HandleEnemyShooting()); 
    }

    IEnumerator HandleEnemyShooting()
    {
        while (true)
        {
            float randomTime = Random.Range(minTime, maxTime);

            yield return new WaitForSeconds(randomTime);

            int randomIndex = Random.Range(0, bulletSpawners.Length);
            GameObject selectedObject = bulletSpawners[randomIndex];

            GameObject bullet = Instantiate(bulletPref, selectedObject.transform.position, selectedObject.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = selectedObject.transform.up * bulletSpeed;
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
 