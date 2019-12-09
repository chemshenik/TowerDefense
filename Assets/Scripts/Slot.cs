using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Towers[] towers;
    public GameObject[] towersUI;
    Tower tower;
    public GameObject UI;
    public GameObject Upgrade;
    public GameObject UpgradeButton;
    public GameObject SellButton;
    public Sprite _slot;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < towersUI.Length; i++) {
            towersUI[i].GetComponentInChildren<Text>().text = towers[i].price.ToString();
        }
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        _slot = GetComponent<SpriteRenderer>().sprite;
        tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpLevel() {
        if (gameManager.Getcoins() < tower.price)
            return;
        else
            gameManager.RemoveCoins(tower.price);
        tower.LevelUp(tower.currentlvl);
        UpgradeButton.GetComponentInChildren<Text>().text = tower.price.ToString();
        SellButton.GetComponentInChildren<Text>().text = tower.sellprice.ToString();
        if (tower.currentlvl == 3)
            UpgradeButton.SetActive(false);
    }

    public void BuyTower(int i) {
        if (gameManager.Getcoins() < towers[i].price)
            return;
        else
            gameManager.RemoveCoins(towers[i].price);
        UpgradeButton.GetComponentInChildren<Text>().text = towers[i].price_lvl2.ToString();
        SellButton.GetComponentInChildren<Text>().text = towers[i].sellprice.ToString();
        Activate();
        tower.type = towers[i];
        tower.ActivateTower();
    }
    public void Activate() { 
        if(tower.type == null)
            UI.SetActive(!UI.activeSelf);
        else
            Upgrade.SetActive(!Upgrade.activeSelf);
    }
    public void SellTower() {
        Activate();
        gameManager.AddCoins(tower.sellprice);
        tower.DeactivateTower();
        UpgradeButton.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = _slot;
    }
}
