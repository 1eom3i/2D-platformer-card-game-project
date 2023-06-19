using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemEndPoint : MonoBehaviour
{
    public int sceneIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Analyzer.instance.reach_end_point(true);
            PlayerController.instance.sendCardStatToAnalyzer(true);
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
