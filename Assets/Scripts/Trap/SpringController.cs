using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    public GameObject head;
    public GameObject stick;

    public float minLength = 0f;
    public float maxLength = 8f;
    public float speed = 1f;

    private float currentLength;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StretchHammer());
    }

    // Coroutine that stretches the hammer like a spring
    private IEnumerator StretchHammer()
    {
        float progress = 0f;
        bool increasing = true;

        while (true)
        {
            if (increasing)
            {
                progress += Time.deltaTime * speed;
                if (progress >= 1f)
                {
                    progress = 1f;
                    increasing = false;
                }
            }
            else
            {
                progress -= Time.deltaTime * speed;
                if (progress <= 0f)
                {
                    progress = 0f;
                    increasing = true;
                }
            }

            currentLength = Mathf.Lerp(minLength, maxLength, progress);

            stick.transform.localScale = new Vector3(currentLength, stick.transform.localScale.y, stick.transform.localScale.z);
            head.transform.localPosition = new Vector3(stick.transform.localPosition.x - currentLength -1f, head.transform.localPosition.y, head.transform.localPosition.z);

            yield return null;
        }
    }
}