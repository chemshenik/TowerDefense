using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New tower", menuName = "Tower")]
public class Towers : ScriptableObject
{

    public float speedAttack;


    public float damage;

    public float damage_lvl2;
    public float damage_lvl3;

    public float range;

    public float range_lvl2;
    public float range_lvl3;

    public int price;

    public int price_lvl2;
    public int price_lvl3;

    public int sellprice;

    public int sellprice_lvl2;
    public int sellprice_lvl3;

    public Sprite level1;
    public Sprite level2;
    public Sprite level3;

    public Sprite bulletSprite;
}
