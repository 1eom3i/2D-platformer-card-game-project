using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemainingHealthDisplay : MonoBehaviour
{
    public TMP_Text remainingPlayer;
    public TMP_Text remainingBoss;
    
    private int playerMaxHealth;
    private int bossMaxHealth;
    public BossController[] boss = new BossController[2];

    private int index;
    // Update is called once per frame
    void Start()
    {
        // player = FindObjectOfType<Player>();
        // boss = FindObjectOfType<Boss>();
    
        playerMaxHealth = PlayerController.instance.health;
        bossMaxHealth = boss[PlayerController.instance.boss_index].health;
    }
    void Update()
    {
        remainingPlayer.text = PlayerController.instance.health + "/" + playerMaxHealth;
        
        remainingBoss.text = boss[PlayerController.instance.boss_index].health + "/" + bossMaxHealth;
    }
    
    
    
}
