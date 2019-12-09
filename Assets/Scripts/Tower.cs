using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(SpriteRenderer))]
public class Tower : MonoBehaviour
{
    public float damage;
    public float speed_attack;

    public int price;
    public int sellprice;
    public float range;

    float attackCooldown;

    public Sprite bullet;

    public Collider2D mainTarget;

    public Towers type;

    public int currentlvl = 1;

    public Transform shootPosition;

    public List<Transform> visibleTargets = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        DeactivateTower();
        
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            LevelUp(currentlvl);
        attackCooldown -= Time.deltaTime;
    }
    void Attack(Stats target) {
        target.TakeDamage(damage);
        attackCooldown = 5 / speed_attack;
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        mainTarget = null;
        mainTarget = Physics2D.OverlapCircle(shootPosition.position, range);
        if (mainTarget != null)
        {

            if(attackCooldown <= 0)
            Attack(mainTarget.GetComponent<Stats>());
        }//Collider2D[] targetsInView = Physics2D.OverlapCircleAll(transform.position, range);
        //for (int i = 0; i < targetsInView.Length; i++)
            //visibleTargets.Add(targetsInView[i].transform);
        //mainTarget = visibleTargets[0];
        /*for (int i = 0; i < targetsInView.Length; i++)
        {
            Transform target = targetsInView[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2f)
            {
            }
        }*/
    }
    public void LevelUp(int lvl) {
        switch (lvl)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = type.level2;
                price = type.price_lvl3;
                damage = type.damage_lvl2;
                range = type.range_lvl2;
                sellprice = type.sellprice_lvl2;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = type.level3;
                damage = type.damage_lvl3;
                range = type.range_lvl3;
                sellprice = type.sellprice_lvl3;
                break;
        }
        if (currentlvl != 3)
            currentlvl++;
    }
    public void ActivateTower()
    {
        GetComponent<SpriteRenderer>().sprite = type.level1;
        damage = type.damage;
        speed_attack = type.speedAttack;

        price = type.price_lvl2;
        sellprice = type.sellprice;

        range = type.range;
    }
    public void DeactivateTower()
    {
        type = null;
        damage = 0;
        currentlvl = 1;
        range = 0;
        price = 0;
    }
}
