using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New wave", menuName = "Waves/Wave")]
public class Wave : ScriptableObject
{

    public float duration;

    public float spawnInterval;

    public int bonusGold;

    public float bonusHealth;

    public CreateEnemy[] enemies;

    public GameObject enemyPrefab;
}