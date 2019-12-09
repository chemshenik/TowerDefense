using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Stats
{
    public Text healthText;

    public int gold;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        healthText.text = health.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
