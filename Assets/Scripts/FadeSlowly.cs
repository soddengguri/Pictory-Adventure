using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSlowly : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadeAway());
    }

    IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(1);
        while (_spriteRenderer.color.a > 0)
        {
            var color = _spriteRenderer.color;
            //color.a is 0 to 1. So .5*time.deltaTime will take 2 seconds to fade out
            color.a -= (.5f * Time.deltaTime);

            _spriteRenderer.color = color;
            //wait for a frame
            yield return null;
        }
        Destroy(gameObject);
    }
}
