using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutText : MonoBehaviour
{

    public enum FadeInOutTextState
    {
        FADE_IN,
        FADE_OUT,
        NONE,
    }

    private FadeInOutTextState state = FadeInOutTextState.NONE;
    private Text text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        state = FadeInOutTextState.NONE;
    }

    public FadeInOutTextState State { get { return state; } }

    float mTime = 0.01f;


    public void StartShow(string stringText, float time)
    {
        text = GetComponent<Text>();
        this.text.text = stringText;
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        state = FadeInOutTextState.FADE_IN;
        mTime = time / 2;
        if (mTime < 0.1f)
        {
            mTime = 0.1f;
        }
    }

   
    void Update()
    {
        if (state == FadeInOutTextState.FADE_IN)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (1 / mTime) * Time.deltaTime);
          
            
            
            /*if (text.color.a >= 0.98f)
             {
                 state = FadeInOutTextState.FADE_OUT;
             }*/
        }

        /*        else if (state == FadeInOutTextState.FADE_OUT)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (1 / mTime) * Time.deltaTime);
            if (text.color.a <= 0.05f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                state = FadeInOutTextState.NONE;
            }
        }*/
    }
}
