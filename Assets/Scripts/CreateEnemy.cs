using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class CreateEnemy : ScriptableObject
{

    public float Health;

    public float speed;

    public float Damage;

    public int dropCoinMin;
    public int dropCoinMax;


    public Sprite sprite;
}
