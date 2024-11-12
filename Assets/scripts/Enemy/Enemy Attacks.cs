using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class EnemyAttacks : MonoBehaviour
{
    //code a ser abstract como ref para enemy attack cone, line y spin

    [Header("shooting")]
    [SerializeField] float EnemyBulletVel;
    [SerializeField] GameObject EnemyBulletPrefab;
    [SerializeField] List <Transform> EnemyBulletSpawn;
    [SerializeField] float delay;

    private Coroutine shootingCoroutine;

    private void Awake()
    {
        
    }

}
