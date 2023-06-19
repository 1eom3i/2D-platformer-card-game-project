using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStack : MonoBehaviour
{
    public static CardStack instance;

    public List<ICard> cards;

    public Sprite number1;
    public Sprite number2;
    public Sprite number3;
    public Sprite number4;
    public Sprite number5;

    public Button Shuffle;

    private void Awake()
    {
        if (CardStack.instance == null)
        {
            CardStack.instance = this;
        }
        else
        {
            Destroy(this);
        }
        cards = new List<ICard>();
    }

    public bool executing = false;

    public void executeCards()
    {
        if (!executing) { executing = true; StartCoroutine(wait()); }
    }

    public IEnumerator wait()
    {
        while (cards.Count > 0)
        {
            if (cards.Count>=2 && cards[0].GetCardType() == CardEnum.Dash && cards[1].GetCardType() == CardEnum.Dash)
            {
                ICard card1 = cards[0];
                ICard card2 = cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                PlayerController.instance.SuperDash();
                card1.RemoveCard();
                card2.RemoveCard();
            }
            // else if (cards.Count>=3 && cards[0].GetCardType() == CardEnum.Move && cards[1].GetCardType() == CardEnum.Move && cards[2].GetCardType() == CardEnum.Move)
            // {
            //     ICard card1 = cards[0];
            //     ICard card2 = cards[1];
            //     ICard card3 = cards[2];
            //     cards.RemoveAt(0);
            //     cards.RemoveAt(0);
            //     cards.RemoveAt(0);
            //     PlayerController.instance.SuperDash();
            //     card1.RemoveCard();
            //     card2.RemoveCard();
            //     card3.RemoveCard();
            // }
            else if (cards.Count>=2 && cards[0].GetCardType() == CardEnum.Dash && cards[1].GetCardType() == CardEnum.DashBack)
            {
                ICard card1 = cards[0];
                ICard card2 = cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                PlayerController.instance.FreeDamage();
                card1.RemoveCard();
                card2.RemoveCard();
            }
            else if (cards.Count>=2 && cards[0].GetCardType() == CardEnum.DashBack && cards[1].GetCardType() == CardEnum.Dash)
            {
                ICard card1 = cards[0];
                ICard card2 = cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                PlayerController.instance.FreeDamage();
                card1.RemoveCard();
                card2.RemoveCard();
            }
            else if (cards.Count>=2 && cards[0].GetCardType() == CardEnum.Move && cards[1].GetCardType() == CardEnum.MoveBack)
            {
                ICard card1 = cards[0];
                ICard card2 = cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                PlayerController.instance.FreeDamage();
                card1.RemoveCard();
                card2.RemoveCard();
            }
            else if (cards.Count>=2 && cards[0].GetCardType() == CardEnum.Slash && cards[1].GetCardType() == CardEnum.Slash)
            {
                ICard card1 = cards[0];
                ICard card2 = cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                PlayerController.instance.FreezeBoss();
                card1.RemoveCard();
                card2.RemoveCard();
            }
            
            else if (cards.Count>=2 && cards[0].GetCardType() == CardEnum.Jump && cards[1].GetCardType() == CardEnum.Jump)
            {
                ICard card1 = cards[0];
                ICard card2 = cards[1];
                cards.RemoveAt(0);
                cards.RemoveAt(0);
                PlayerController.instance.SuperJump();
                card1.RemoveCard();
                card2.RemoveCard();
            }
            else
            {
                ICard card = cards[0];
                cards.RemoveAt(0);
                card.ActiveCard();
                yield return new WaitForSeconds(0.5f);
            }
        }
        executing = false;
    }

    public void ArrangeNumber()
    {
        if (cards.Count > 0)
        {
            int counter = 1;
            foreach (ICard card in cards)
            {
                switch (counter)
                {
                    case 1:
                        card.EnableNumber(number1);
                        break;
                    case 2:
                        card.EnableNumber(number2);
                        break;
                    case 3:
                        card.EnableNumber(number3);
                        break;
                    case 4:
                        card.EnableNumber(number4);
                        break;
                    case 5:
                        card.EnableNumber(number5);
                        break;
                    default: break;
                }
                counter++;
            }
        }
    }
}
