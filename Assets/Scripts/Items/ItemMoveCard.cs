using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMoveCard : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfCards = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                CardManager.instance.AddMove();
            }
            CardManager.instance.setMoveCounter();
            Destroy(this.gameObject);
        }
    }
}
