using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJumpCard : MonoBehaviour, IItem
{
    public int numberOfCards = 1;
    public bool Collided = false;

    public event Action collideEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for(int i = 0; i< numberOfCards; i++)
            {
                CardManager.instance.AddJump();
            }
            Collided = true;
            CardManager.instance.setJumpCounter();
            if (collideEvent!= null) collideEvent();
            Destroy(this.gameObject);
        }
    }


}
