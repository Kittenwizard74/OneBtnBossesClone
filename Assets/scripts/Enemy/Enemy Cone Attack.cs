using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyConeAttack : MonoBehaviour 
{
    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] float minTime;
    [SerializeField] float maxTime;
    [SerializeField] float activeDuration;


    private void Awake()
    {
        StartCoroutine(HandleCones());
    }

    IEnumerator HandleCones()
    {
        while (true)
        {
            float randomTime = Random.Range(minTime, maxTime);

            yield return new WaitForSeconds(randomTime);

            int randomIndex = Random.Range(0, objectsToActivate.Length);
            GameObject selectedObject = objectsToActivate[randomIndex];

            selectedObject.SetActive(true);

            yield return new WaitForSeconds(activeDuration);

            selectedObject.SetActive(false);
        }
    }
}
