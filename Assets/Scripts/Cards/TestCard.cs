using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestCard : MonoBehaviour
{
    public GameObject location;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOLocalMove(location.transform.localPosition, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
