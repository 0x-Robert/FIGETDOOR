using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiaryManager : MonoBehaviour {
   
    public GameObject Diaryobj;
    bool DiaryOff = false;

    
    public Text[] text_num;
    DiaryTextStep Step;
    public int text_Array=9;


    private bool aZONE = false;
    private bool bZONE= false;
    private bool cZONE= false;
    private bool dZONE= false;

    public enum DiaryTextStep

    {
        diary_First,
        diary_Second,
        diary_Third,
        diary_Fourth,
        diary_Fifth,
        diary_Six,
        diary_Seven,
        diary_Eight,
        diary_Nine,
        diary_None
    }

	void Start ()
    {
        DiaryTextStep Step = DiaryTextStep.diary_First;

        if (Step == DiaryTextStep.diary_First)
        {
            for (int i=0; i < text_Array; i++)
            {
                text_num[i].color = new Color(0, 0, 0, 0);
               
            }
        }

        StartCoroutine(diary_Master());


    }

    IEnumerator diary_Master()
    {
        yield return new WaitForSeconds(3.0f);
        diary_First();
        yield break;
    }
    void diary_First()
    {
        text_num[0].color = new Color(255, 255, 255, 255);
        


        if(aZONE== true){
            Step = DiaryTextStep.diary_Second;

        }
    }
 public   void diary_Second()
    {
        text_num[1].color = new Color(255, 255, 255, 255);
        /*너의 주머니에 있었던 우리의 연극 티켓
          소중한 거니까 보관해 둬야지 
          */
    }
    public void diary_Third()
    {
        text_num[2].color = new Color(255, 255, 255, 255);

    }
    public void diary_Fourth()
    {
        text_num[3].color = new Color(255, 255, 255, 255);

    }
    void diary_Fifth()
    {
        text_num[4].color = new Color(255, 255, 255, 255);

    }
    void diary_Six()
    {
        text_num[5].color = new Color(255, 255, 255, 255);

    }
    void diary_Seven()
    {
        text_num[6].color = new Color(255, 255, 255, 255);

    }

    void diary_Eight()
    {
        text_num[7].color = new Color(255, 255, 255, 255);

    }
    void diary_Nine()
    {
        text_num[8].color = new Color(255, 255, 255, 255);

    }



    void Update()
    {
        switch (Step)
        {
            case DiaryTextStep.diary_First:
                diary_First();
                
       
            break;
            case DiaryTextStep.diary_Second:
                diary_Second();
                break;
            case DiaryTextStep.diary_Third:
                diary_Third();
                break;
            case DiaryTextStep.diary_Fourth:
                diary_Fourth();
                break;
            case DiaryTextStep.diary_Fifth:
                diary_Fifth();
                break;
            case DiaryTextStep.diary_Six:
                diary_Six();
                break;
            case DiaryTextStep.diary_Seven:
                diary_Seven();
                break;
            case DiaryTextStep.diary_Eight:
                diary_Eight();
                break;
            case DiaryTextStep.diary_Nine:
                diary_Nine();
                break;


        }
    }

    public void OnMouseDown()
    {
        if (Diaryobj.activeSelf == true)
        {
        Diaryobj.SetActive(false);

        }
        else if (Diaryobj.activeSelf == false)
        {
        Diaryobj.SetActive(true);
        }
    }

}