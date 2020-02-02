using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FadeInEndScript : MonoBehaviour
{
    public float showDelay = 1.5f;

    public Text i;

    private void Awake()
    {
        // start text as transparenti
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFadeIn()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartFadeIn()
    {
        yield return new WaitForSeconds(showDelay);

        StartCoroutine(FadeTextToFullAlpha());

    }

    // adapted from https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/
    public IEnumerator FadeTextToFullAlpha()
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / displayTime));
            yield return null;
        }
    }
}
