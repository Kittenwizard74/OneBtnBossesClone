using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;

    [SerializeField] List<TextMeshProUGUI> besttimetxt;
    [SerializeField] List<TextMeshProUGUI> currenttimetxt;
    [SerializeField] TextMeshProUGUI record;

    private float currentTime;
    private float bestTime;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);  
        }

        bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
        record.gameObject.SetActive(false); 
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > bestTime)
        {
            bestTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);  

            record.gameObject.SetActive(true);
        }

        //estan separados en 2 porque sino no funcionaba
        float bestMinutes = Mathf.Floor(bestTime / 60);
        float bestSeconds = bestTime % 60;

        float currentMinutes = Mathf.Floor(currentTime / 60);
        float currentSeconds = currentTime % 60;

        foreach (TextMeshProUGUI t in besttimetxt)
        {
            t.text = string.Format("Best Time: {0:00}:{1:00}", bestMinutes, bestSeconds);
        }
        foreach (TextMeshProUGUI t in currenttimetxt)
        {
            t.text = string.Format("Current Time: {0:00}:{1:00}", currentMinutes, currentSeconds);
        }
    }
}

