using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour {

    public EndingScroll endingScroll;

    public Image screen;
    public Image winIlust;
    public Image defeatIlust;
    public Text  subTitle;
    public Text gameOverT;
    private bool win = false;

    public float waitTime = 5f;
    public float fadeTime = 2f;
    public float textColRate = 2f;

    private bool skip = false;
    private int subTitleKey = 0;

    /* 필요 자막 자료
     * 1. 승리 시의 주인공 독백
     * 2. 패배 시의 리포터 보도 내용
     * 
     * 자막자료 소스 형태 = JSON형태 ( 엑셀로 작업 - JSON 전환 사이트에서 전환)
     * 
     * 자막 자료 만들고, 파싱스크립트 만들것
     * */
     
    private void Start()
    {
        subTitle.color = new Color(1f, 1f, 1f, 0f);
        gameOverT.color = new Color(1f, 1f, 1f, 0f);
        //승리 - 패배 여부 확인
        if (win)
        {
            StartCoroutine(WinView());
        }
        else
        {
            StartCoroutine(DefeatView());
        }
    }

    IEnumerator FadeIN()
    {
        screen.color = new Color(0f, 0f, 0f, 1f);

        Color col = screen.color;

        while (true)
        {
            if (screen.color.a <= 0)
                break;
            col.a -= fadeTime * Time.deltaTime;
            screen.color = col;
            yield return null;
        }
    }
    IEnumerator FadeOUT()
    {
        screen.color = new Color(0f, 0f, 0f, 0f);

        Color col = screen.color;

        while (true)
        {
            if (screen.color.a >= 1f)
                break;
            col.a += fadeTime * Time.deltaTime;
            screen.color = col;
            yield return null;
        }

        gameOverT.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        endingScroll.StartScroll();
    }

    IEnumerator WinView()
    {
        winIlust.gameObject.SetActive(true);
        defeatIlust.gameObject.SetActive(false);

        yield return StartCoroutine(FadeIN());

        Color col = subTitle.color;
        //승리 텍스트DB에서 가져올것
        subTitle.text = "Win subTitleKey = " + subTitleKey;
        while (true)
        {
            if(subTitleKey >= 10)
            {
                break;
            }
            if(subTitle.color.a >= 1f)
            {
                yield return new WaitForSeconds(waitTime);
                skip = true;
                col.a = 1f;
            }
            else if(subTitle.color.a <= 0f)
            {
                yield return new WaitForSeconds(waitTime / 5f);
                skip = false;
                col.a = 0f;
                //승리 텍스트DB에서 가져올것
                subTitleKey++;
                subTitle.text = "Win subTitleKey = " + subTitleKey;
            }

            if (skip)
            {
                col.a -= textColRate * Time.deltaTime;
                subTitle.color = col;
            }
            else
            {
                col.a += textColRate * Time.deltaTime;
                subTitle.color = col;
            }
        }
        StartCoroutine(FadeOUT());
    }

    IEnumerator DefeatView()
    {
        winIlust.gameObject.SetActive(false);
        defeatIlust.gameObject.SetActive(true);

        yield return StartCoroutine(FadeIN());

        Color col = subTitle.color;
        //패배 텍스트DB에서 가져올것
        subTitle.text = "Defeat subTitleKey = " + subTitleKey;
        while (true)
        {
            if (subTitleKey >= 10)
            {
                break;
            }
            if (subTitle.color.a >= 1f)
            {
                yield return new WaitForSeconds(waitTime);
                skip = true;
                col.a = 1f;
            }
            else if (subTitle.color.a <= 0f)
            {
                yield return new WaitForSeconds(waitTime / 5f);
                skip = false;
                col.a = 0f;
                //패배 텍스트DB에서 가져올것
                subTitleKey++;
                subTitle.text = "Defeat subTitleKey = " + subTitleKey;
            }

            if (skip)
            {
                col.a -= textColRate * Time.deltaTime;
                subTitle.color = col;
            }
            else
            {
                col.a += textColRate * Time.deltaTime;
                subTitle.color = col;
            }
        }
        StartCoroutine(FadeOUT());
    }


}
