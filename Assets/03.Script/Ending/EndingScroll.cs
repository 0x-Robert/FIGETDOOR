using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScroll : MonoBehaviour {

    public GameObject text;
    public float speed = 100f;

    public void StartScroll()
    {
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
        var rect = text.GetComponent<RectTransform>();
        while (true)
        {
            if(rect.position.y >= 450)
            {

                yield break;
            }
            text.transform.Translate(Vector2.up * speed * Time.deltaTime);
            yield return null;
        }
    }

    
}
