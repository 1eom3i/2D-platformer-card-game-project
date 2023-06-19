using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image playerHealthBar;
    public Image bossHealthBar;
    
    public float playerHealthPercentage;
    
    public float bossHealthPercentage;
    // private Player player;
    // private Boss boss;
    
    private int playerMaxHealth;
    private int bossMaxHealth;
    public BossController[] boss = new BossController[2];
    
    void Start()
    {
        // player = FindObjectOfType<Player>();
        // boss = FindObjectOfType<Boss>();
    
        playerMaxHealth = PlayerController.instance.health;
        bossMaxHealth = boss[PlayerController.instance.boss_index].health;
    }
    
    void Update()
    {
         playerHealthPercentage = (float) PlayerController.instance.health / playerMaxHealth; 
         bossHealthPercentage = (float)boss[PlayerController.instance.boss_index].health / bossMaxHealth;
    
        playerHealthBar.fillAmount = playerHealthPercentage;
        bossHealthBar.fillAmount = bossHealthPercentage;
    }
}

