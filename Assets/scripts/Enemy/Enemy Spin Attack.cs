using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpinAttack : MonoBehaviour
{
    [SerializeField] GameObject attack;
    [SerializeField] GameObject center;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float fireRate;
    [SerializeField] float radio;
    //se puede reusar code con esto y cone attack, cambiar si necesario

    private void Awake()
    {
        StartCoroutine(HandleCircleAttack());
    }

    IEnumerator HandleCircleAttack()
    {
        while (true)
        {
            float angle = Random.Range(0f, 360f);   
            float angleRadians = angle * Mathf.Deg2Rad;     
            float randomTime = Random.Range(minTime, maxTime);           

            yield return new WaitForSeconds(randomTime);

            Vector3 spawnPosition = new Vector3(center.transform.position.x + Mathf.Cos(angleRadians) * radio,center.transform.position.y + Mathf.Sin(angleRadians) * radio,center.transform.position.z);
            GameObject spawnedAttack = Instantiate(attack, spawnPosition, center.transform.rotation);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
