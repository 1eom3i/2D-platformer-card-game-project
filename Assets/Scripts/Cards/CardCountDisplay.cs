using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardCountDisplay : MonoBehaviour
{
    public TMP_Text move;
    public TMP_Text jump;
    public TMP_Text dash;
    public TMP_Text dashBack;
    public TMP_Text moveBack;
    public TMP_Text slash;
    public TMP_Text redraw;
    // Update is called once per frame
    void Update()
    {
        move.text = "Move Right: " + CardManager.instance.remainingMoveCards;
        jump.text = "Jump: " + CardManager.instance.remainingJumpCards;
        dash.text = "Dash: " + CardManager.instance.remainingDashCards;
        dashBack.text = "Dash Back: " + CardManager.instance.remainingDashBackCards;
        moveBack.text = "Move Left: " + CardManager.instance.remainingMoveBackCards;
        slash.text = "Slash: " + CardManager.instance.remainingSlashCards;
        redraw.text = "Redraw: " + (CardManager.instance.RedrawLimit - CardManager.instance.RedrawTimes);
    }
}