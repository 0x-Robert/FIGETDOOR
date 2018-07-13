using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SubtitleManager : MonoBehaviour
{

    struct SubtitleInformation
    {
        public string text;
        public float time;
    }

    public FadeInOutText textInOutText;

    private Queue<SubtitleInformation> subtitleQueue = new Queue<SubtitleInformation>();

    // Update is called once per frame
    void Update()
    {
        if (textInOutText.State == FadeInOutText.FadeInOutTextState.NONE)
        {
            if (subtitleQueue.Count != 0)
            {
                SubtitleInformation info = subtitleQueue.Dequeue();
                textInOutText.StartShow(info.text, info.time);
            }
        }
    }

    public void AddText(string text, float time = 4.0f)
    {
        SubtitleInformation info;
        info.text = text;
        info.time = time;
        subtitleQueue.Enqueue(info);
    }
}
