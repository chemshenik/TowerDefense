using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0)
            Die();
    }
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
