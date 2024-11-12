using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyConeAttack : MonoBehaviour 
{
    public GameObject[] objectsToActivate;  // Lista de objetos que se activarán aleatoriamente
    public float minTime = 1f;  // Tiempo mínimo para el temporizador (en segundos)
    public float maxTime = 2f;  // Tiempo máximo para el temporizador (en segundos)
    public float activeDuration = 3f;  // Tiempo durante el cual el objeto se mantiene activo


    private void Awake()
    {
        StartCoroutine(HandleCones());
    }

    IEnumerator HandleCones()
    {
        while (true)
        {
            // Genera un tiempo aleatorio entre minTime y maxTime
            float randomTime = Random.Range(minTime, maxTime);

            // Espera el tiempo aleatorio generado
            yield return new WaitForSeconds(randomTime);

            // Elige un objeto aleatorio de la lista
            int randomIndex = Random.Range(0, objectsToActivate.Length);
            GameObject selectedObject = objectsToActivate[randomIndex];

            // Activa el objeto seleccionado
            selectedObject.SetActive(true);

            // Espera el tiempo durante el cual el objeto estará activo
            yield return new WaitForSeconds(activeDuration);

            // Desactiva el objeto después del tiempo de duración
            selectedObject.SetActive(false);
        }
    }
}
