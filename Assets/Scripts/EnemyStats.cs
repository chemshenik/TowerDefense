using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : Stats
{
    public int coinsMin;
    public int coinsMax;
    public float damage;
    public float speed;

    public Image hpBar;

    public TYPE enemyType;

    public enum TYPE {
        MELEE,
        RANGE
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TakeDamage(float damage) {
        base.TakeDamage(damage);
        hpBar.fillAmount = health / maxHealth;
    }
    public override void Die()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().AddCoins(Random.Range(coinsMin, coinsMax));
        base.Die();
    }

    public void UpdateStats(CreateEnemy type) {
        coinsMax = type.dropCoinMax;
        coinsMin = type.dropCoinMin;
        damage = type.Damage;
        speed = type.speed;
        maxHealth = type.Health;
        health = maxHealth;

        GetComponent<SpriteRenderer>().sprite = type.sprite;
    }
}
