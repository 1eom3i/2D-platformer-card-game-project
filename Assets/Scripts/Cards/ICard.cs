using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    void ActiveCard();
    void RemoveCard();
    
    public void EnableDragging();

    public void DisableDragging();

    public CardEnum GetCardType();

    public void EnableNumber(Sprite i);
}
