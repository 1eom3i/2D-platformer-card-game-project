using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public List<GameObject> deck;
    public List<GameObject> cardsInDeck;
    public List<GameObject> handCards;

    public GameObject JumpCardPrefab;
    public GameObject MoveCardPrefab;
    public GameObject MoveBackCardPrefab;
    public GameObject DashCardPrefab;
    public GameObject DashBackCardPrefab;
    public GameObject SlashCardPrefab;

    public int startingMoveRightCard = 0;
    public int startingDashCard = 10;
    public int startingDashBackCard = 10;
    public int startingJumpCard = 10;
    public int startingMoveBackCard = 10;
    public int startingSlashCard = 20;

    public Transform cards;
    public Transform deckLocation;

    public int currentCardCount = 0;

    public List<GameObject> cardLocations;

    public int loseScreenIndex;

    public int remainingMoveCards = 0;
    public int remainingJumpCards = 0;
    public int remainingMoveBackCards = 0;
    public int remainingDashCards = 0;
    public int remainingDashBackCards = 0;
    public int remainingSlashCards = 0;
    public int moveCardsInHand = 0;
    public int jumpCardsInHand = 0;
    public int moveBackCardsInHand = 0;
    public int dashCardsInHand = 0;
    public int dashBackCardsInHand = 0;
    public int slashCardsInHand = 10;

    public int jumpRewardsCounter;
    public int moveRewardsCounter;
    public int backRewardsCounter;
    public int dashRewardsCounter;
    public int dashBackRewardsCounter;
    public int slashRewardsCounter;

    public int RedrawTimes = 0;
    public int RedrawLimit = 5;

    private static int Move_Index = 0;
    private static int MoveBack_Index = 1;
    private static int Jump_Index = 2;
    private static int Dash_Index = 3;
    private static int DashBack_Index = 4;
    private static int Slash_Index = 5;

    private static int Card_Type_Number = 6;


    // Start is called before the first frame update
    void Awake()
    {
        if (CardManager.instance == null)
        {
            CardManager.instance = this;
        }
        else
        {
            Destroy(this);
        }
        InitalizedDeck();
    }

    void InitalizedDeck()
    {
        deck = new List<GameObject>();
        for (int i = 0; i < startingSlashCard; i++)
        {
            GameObject newCard = Instantiate(SlashCardPrefab, deckLocation);
            deck.Add(newCard);
            remainingSlashCards++;
            newCard.SetActive(false);
        }
        for (int i = 0; i < startingDashBackCard; i++)
        {
            GameObject newCard = Instantiate(DashBackCardPrefab, deckLocation);
            deck.Add(newCard);
            remainingDashBackCards++;
            newCard.SetActive(false);
        }
        for (int i = 0; i < startingDashCard; i++)
        {
            GameObject newCard = Instantiate(DashCardPrefab, deckLocation);
            deck.Add(newCard);
            remainingDashCards++;
            newCard.SetActive(false);
        }
        for (int i = 0; i < startingMoveRightCard; i++)
        {
            GameObject newCard = Instantiate(MoveCardPrefab, deckLocation);
            deck.Add(newCard);
            remainingMoveCards++;
            newCard.SetActive(false);
        }
        for (int i = 0; i < startingJumpCard; i++)
        {
            GameObject newCard = Instantiate(JumpCardPrefab, deckLocation);
            deck.Add(newCard);
            remainingJumpCards++;
            newCard.SetActive(false);
        }
        for (int i = 0; i < startingMoveBackCard; i++)
        {
            GameObject newCard = Instantiate(MoveBackCardPrefab, deckLocation);
            deck.Add(newCard);
            remainingMoveBackCards++;
            newCard.SetActive(false);
        }
        cardsInDeck = new List<GameObject>(deck);
    }

    public void AddMove()
    {
        GameObject newCard = Instantiate(MoveCardPrefab, deckLocation);
        deck.Add(newCard);
        cardsInDeck.Add(newCard);
        remainingMoveCards++;
        newCard.SetActive(false);
    }

    public void AddMoveBack()
    {
        GameObject newCard = Instantiate(MoveBackCardPrefab, deckLocation);
        deck.Add(newCard);
        cardsInDeck.Add(newCard);
        remainingMoveBackCards++;
        newCard.SetActive(false);
    }

    public void AddJump()
    {
        GameObject newCard = Instantiate(JumpCardPrefab, deckLocation);
        deck.Add(newCard);
        cardsInDeck.Add(newCard);
        remainingJumpCards++;
        newCard.SetActive(false);
    }

    public void AddDash()
    {
        GameObject newCard = Instantiate(DashCardPrefab, deckLocation);
        deck.Add(newCard);
        cardsInDeck.Add(newCard);
        remainingDashCards++;
        newCard.SetActive(false);
    }

    public void AddDashBack()
    {
        GameObject newCard = Instantiate(DashBackCardPrefab, deckLocation);
        deck.Add(newCard);
        cardsInDeck.Add(newCard);
        remainingDashBackCards++;
        newCard.SetActive(false);
    }
    public void AddSlash()
    {
        GameObject newCard = Instantiate(SlashCardPrefab, deckLocation);
        deck.Add(newCard);
        cardsInDeck.Add(newCard);
        remainingSlashCards++;
        newCard.SetActive(false);
    }

    public void setBackCounter()
    {
        backRewardsCounter++;
    }
    public void setJumpCounter()
    {
        jumpRewardsCounter++;
    }
    public void setMoveCounter()
    {
        moveRewardsCounter++;
    }
    public void setDashCounter()
    {
        dashRewardsCounter++;
    }
    public void setDashBackCounter()
    {
        dashBackRewardsCounter++;
    }
    public void setSlashCounter()
    {
        slashRewardsCounter++;
    }

    private void Start()
    {
        jumpRewardsCounter = 0;
        backRewardsCounter = 0;
        moveRewardsCounter = 0;
        dashRewardsCounter = 0;
        dashBackRewardsCounter = 0;
        slashRewardsCounter = 0;
        StartCoroutine(UpdateHand());
    }

    void Update()
    {
        /*if (currentCardCount < 5 && cardsInDeck.Count >= 1)
        {
            int cardChoice = Random.Range(0, cardsInDeck.Count);
            cardsInDeck[cardChoice].SetActive(true);
            cardsInDeck[cardChoice].transform.SetParent(cards);
            handCards.Add(cardsInDeck[cardChoice]);
            cardsInDeck.RemoveAt(cardChoice);
            currentCardCount++;
            RearrangeHand();
        }
        else if (currentCardCount == 0 && cardsInDeck.Count == 0)
        {
            SceneManager.LoadScene("LoseScreen 1");
        }*/
    }


    private int getCardInHand(int current_type)
    {
        if (current_type == 0)
        {
            return moveCardsInHand;
        }
        else if (current_type == 1)
        {
            return moveBackCardsInHand;
        }
        else if (current_type == 2)
        {
            return jumpCardsInHand;
        }
        else if (current_type == 3)
        {
            return dashCardsInHand;
        }
        else if (current_type == 4)
        {
            return dashBackCardsInHand;
        }
        return slashCardsInHand;
    }

    private int getCardRemaining(int current_type)
    {
        if (current_type == 0)
        {
            return remainingMoveCards;
        }
        else if (current_type == 1)
        {
            return remainingMoveBackCards;
        }
        else if (current_type == 2)
        {
            return remainingJumpCards;
        }
        else if (current_type == 3)
        {
            return remainingDashCards;
        }
        else if (current_type == 4)
        {
            return remainingDashBackCards;
        }
        return remainingSlashCards;
    }

    private bool isGoodChoice(int current_type)
    {
        int current_remain = remainingJumpCards + remainingMoveBackCards + remainingDashCards + remainingDashBackCards + remainingSlashCards + remainingMoveCards;
        if (current_remain <= 5)
        {
            return true;
        }
        if (current_remain == getCardRemaining(current_type))
        {
            return true;
        }
        int current_in_hand = getCardInHand(current_type);
        if (current_in_hand == 2)
        {
            int prob = Random.Range(0, 10);
            if (prob >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (current_in_hand == 3)
        {
            int prob = Random.Range(0, 10);
            if (prob >= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (current_in_hand == 4)
        {
            int prob = Random.Range(0, 10);
            if (prob >= 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    private int RedrawCards()
    {
        int current_remain = remainingJumpCards + remainingMoveBackCards + remainingDashCards + remainingDashBackCards + remainingSlashCards + remainingMoveCards;
        if (current_remain <= 5)
        {
            return Random.Range(0, current_remain);
        }
        if (remainingJumpCards > 0 || remainingMoveBackCards > 0 || remainingDashCards > 0 || remainingDashBackCards > 0 || remainingSlashCards > 0 || remainingMoveCards > 0)
        {
            int randomTarget = Random.Range(0, 6);
            while (isRemaining(randomTarget) == false || isGoodChoice(randomTarget) == false)
            {
                randomTarget = Random.Range(0, 6);
            }

            CardEnum targetEnum;
            if (randomTarget == 0)
            {
                targetEnum = CardEnum.Move;
            }
            else if (randomTarget == 1)
            {
                targetEnum = CardEnum.MoveBack;
            }
            else if (randomTarget == 2)
            {
                targetEnum = CardEnum.Jump;
            }
            else if (randomTarget == 3)
            {
                targetEnum = CardEnum.Dash;
            }
            else if (randomTarget == 4)
            {
                targetEnum = CardEnum.DashBack;
            }
            else
            {
                targetEnum = CardEnum.Slash;
            }

            for (int i = 0; i < cardsInDeck.Count; i++)
            {
                if (cardsInDeck[i].GetComponent<ICard>().GetCardType() == targetEnum)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    private bool isRemaining(int number)
    {
        if (number == Move_Index)
        {
            if (remainingMoveCards <= 0)
            {
                return false;
            }
            return true;
        }
        else if (number == MoveBack_Index)
        {
            if (remainingMoveBackCards <= 0)
            {
                return false;
            }
            return true;
        }
        else if (number == Dash_Index)
        {
            if (remainingDashCards <= 0)
            {
                return false;
            }
            return true;
        }
        else if (number == DashBack_Index)
        {
            if (remainingDashBackCards <= 0)
            {
                return false;
            }
            return true;
        }
        else if (number == Jump_Index)
        {
            if (remainingJumpCards <= 0)
            {
                return false;
            }
            return true;
        }
        else
        {
            if (remainingSlashCards <= 0)
            {
                return false;
            }
            return true;
        }
    }

    IEnumerator UpdateHand()
    {
        while (currentCardCount != 0 || cardsInDeck.Count != 0)
        {
            if (currentCardCount < 5 && cardsInDeck.Count >= 1)
            {
                int cardChoice = -1;
                cardChoice = RedrawCards();

                CardEnum cardType = cardsInDeck[cardChoice].GetComponent<ICard>().GetCardType();
                switch (cardType)
                {
                    case CardEnum.Move:
                        remainingMoveCards--;
                        moveCardsInHand++;
                        break;
                    case CardEnum.MoveBack:
                        remainingMoveBackCards--;
                        moveBackCardsInHand++;
                        break;
                    case CardEnum.Jump:
                        remainingJumpCards--;
                        jumpCardsInHand++;
                        break;
                    case CardEnum.Dash:
                        remainingDashCards--;
                        dashCardsInHand++;
                        break;
                    case CardEnum.DashBack:
                        remainingDashBackCards--;
                        dashBackCardsInHand++;
                        break;
                    case CardEnum.Slash:
                        remainingSlashCards--;
                        slashCardsInHand++;
                        break;
                }
                cardsInDeck[cardChoice].SetActive(true);
                cardsInDeck[cardChoice].transform.SetParent(cards);

                handCards.Add(cardsInDeck[cardChoice]);
                cardsInDeck.RemoveAt(cardChoice);
                currentCardCount++;
                RearrangeHand();
            }
            yield return new WaitForSeconds(0.2f);
        }
        Analyzer.instance.reach_end_point(false);
        PlayerController.instance.sendCardStatToAnalyzer(false);
        SceneManager.LoadScene(loseScreenIndex);
    }

    void RearrangeHand()
    {
        switch (handCards.Count)
        {
            case 0:
                break;
            case 1:
                handCards[0].transform.DOLocalMove(cardLocations[2].transform.localPosition, 1).OnComplete(() => handCards[0].GetComponent<ICard>().EnableDragging());
                //handCards[0].GetComponent<ICard>().DisableDragging();
                break;
            case 2:
                handCards[0].transform.DOLocalMove(cardLocations[1].transform.localPosition, 1).OnComplete(() => handCards[0].GetComponent<ICard>().EnableDragging());
                handCards[1].transform.DOLocalMove(cardLocations[3].transform.localPosition, 1).OnComplete(() => handCards[1].GetComponent<ICard>().EnableDragging());

                //handCards[0].GetComponent<ICard>().DisableDragging();
                //handCards[1].GetComponent<ICard>().DisableDragging();
                break;
            case 3:
                handCards[0].transform.DOLocalMove(cardLocations[1].transform.localPosition, 1).OnComplete(() => handCards[0].GetComponent<ICard>().EnableDragging());
                handCards[1].transform.DOLocalMove(cardLocations[2].transform.localPosition, 1).OnComplete(() => handCards[1].GetComponent<ICard>().EnableDragging());
                handCards[2].transform.DOLocalMove(cardLocations[3].transform.localPosition, 1).OnComplete(() => handCards[2].GetComponent<ICard>().EnableDragging());

                //handCards[0].GetComponent<ICard>().DisableDragging();
                //handCards[1].GetComponent<ICard>().DisableDragging();
                //handCards[2].GetComponent<ICard>().DisableDragging();
                break;
            case 4:
                handCards[0].transform.DOLocalMove(cardLocations[0].transform.localPosition, 1).OnComplete(() => handCards[0].GetComponent<ICard>().EnableDragging());
                handCards[1].transform.DOLocalMove(cardLocations[1].transform.localPosition, 1).OnComplete(() => handCards[1].GetComponent<ICard>().EnableDragging());
                handCards[2].transform.DOLocalMove(cardLocations[3].transform.localPosition, 1).OnComplete(() => handCards[2].GetComponent<ICard>().EnableDragging());
                handCards[3].transform.DOLocalMove(cardLocations[4].transform.localPosition, 1).OnComplete(() => handCards[3].GetComponent<ICard>().EnableDragging());

                //handCards[0].GetComponent<ICard>().DisableDragging();
                //handCards[1].GetComponent<ICard>().DisableDragging();
                //handCards[2].GetComponent<ICard>().DisableDragging();
                //handCards[3].GetComponent<ICard>().DisableDragging();
                break;
            case 5:
                handCards[0].transform.DOLocalMove(cardLocations[0].transform.localPosition, 1).OnComplete(() => handCards[0].GetComponent<ICard>().EnableDragging());
                handCards[1].transform.DOLocalMove(cardLocations[1].transform.localPosition, 1).OnComplete(() => handCards[1].GetComponent<ICard>().EnableDragging());
                handCards[2].transform.DOLocalMove(cardLocations[2].transform.localPosition, 1).OnComplete(() => handCards[2].GetComponent<ICard>().EnableDragging());
                handCards[3].transform.DOLocalMove(cardLocations[3].transform.localPosition, 1).OnComplete(() => handCards[3].GetComponent<ICard>().EnableDragging());
                handCards[4].transform.DOLocalMove(cardLocations[4].transform.localPosition, 1).OnComplete(() => handCards[4].GetComponent<ICard>().EnableDragging());

                //handCards[0].GetComponent<ICard>().DisableDragging();
                //handCards[1].GetComponent<ICard>().DisableDragging();
                //handCards[2].GetComponent<ICard>().DisableDragging();
                //handCards[3].GetComponent<ICard>().DisableDragging();
                //handCards[4].GetComponent<ICard>().DisableDragging();
                break;
            default:
                break;
        }
    }

    public void ShuffleCard()
    {
        if (RedrawTimes < RedrawLimit)
        {
            foreach (GameObject card in handCards)
            {
                card.SetActive(false);
                card.transform.SetParent(deckLocation);
                card.transform.localPosition = new Vector3(0, 0);
                cardsInDeck.Add(card);
                currentCardCount--;
                switch (card.GetComponent<ICard>().GetCardType())
                {
                    case CardEnum.Move:
                        remainingMoveCards++;
                        moveCardsInHand--;
                        break;
                    case CardEnum.MoveBack:
                        remainingMoveBackCards++;
                        moveBackCardsInHand--;
                        break;
                    case CardEnum.Jump:
                        remainingJumpCards++;
                        jumpCardsInHand--;
                        break;
                    case CardEnum.Dash:
                        remainingDashCards++;
                        dashCardsInHand--;
                        break;
                    case CardEnum.DashBack:
                        remainingDashBackCards++;
                        dashBackCardsInHand--;
                        break;
                }
            }
            handCards.Clear();
            RedrawTimes += 1;
        }
    }

    public int getJumpRewardsCounter()
    {
        return jumpRewardsCounter;
    }
    public int getBackRewardsCounter()
    {
        return backRewardsCounter;
    }
    public int getMoveRewardsCounter()
    {
        return moveRewardsCounter;
    }
}
