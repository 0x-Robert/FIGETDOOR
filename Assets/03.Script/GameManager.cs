using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Stage
{
    Game_Start,
    Loading,
    NoTice,
    Title_Scene,
    Intro_Video,
    Guide_Ui,
    Call_Start,
    A_Stage,
    B_Stage,
    C_Stage,
    D_Stage,


}


public class GameManager : MonoBehaviour {

    public GameObject intro_text;
    public int count;
    Stage stage = Stage.Game_Start;
    public SubtitleManager subtitleManager;
   
    
    public GameObject[] callView;
    public bool winORdefeat;
    public Text timeText;
    private float time = 1800f;



    void Start()
    {
       

        intro_text.SetActive(false);
        StartCoroutine(GameControl());
        StartCoroutine(TimeManager());
    }
    public IEnumerator TimeManager()
    {
        yield return new WaitForSeconds(1.0f);
        while (time <= 1800.0f)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;


                int min = (int)time / 60;
                int sec = (int)time % 60;

                if (sec < 10) timeText.text = min + ":0" + sec;
                else timeText.text = min + ":" + sec;
            }
          //시간이 다됬을때 못깬경우 게임오버
          //중간에 숍오벨 체력이 다달았을경우에도 게임오버

        }
       
    }

    IEnumerator GameControl()
    {
      
        yield return new WaitForSeconds(5.0f);
        intro_text.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        intro_text.SetActive(false);

        yield return new WaitForSeconds(3.0F);
        callView[0].SetActive(true);
        yield return new WaitForSeconds(3.0F);
        callView[0].SetActive(false);
        callView[1].SetActive(true);
        yield return new WaitForSeconds(3.0F);
        callView[1].SetActive(false);
        callView[2].SetActive(true);
        yield return new WaitForSeconds(3.0F);
        callView[2].SetActive(false);

      

        switch (stage)
        {
            /* Game_Start,
    Loading,
    NoTice,
    Title_Scene,
    Intro_Video,
    Guide_Ui,
    Call_Start,
    A_Stage,
    B_Stage,
    C_Stage,
    D_Stage,
*/

            case Stage.Game_Start:
                Game_Start();
                break;
            case Stage.Loading:
                Loading();
                break;
            case Stage.NoTice:
                NoTice();
                break;
            case Stage.Title_Scene:
                Title_Scene();
                break;
            case Stage.Intro_Video:
                Intro_Video();
                break;
            case Stage.Guide_Ui:
                Guide_Ui();
                break;
            case Stage.Call_Start:
                Call_Start();
                break;
            case Stage.A_Stage:
                A_Stage();
                break;
            case Stage.B_Stage:
                B_Stage();
                break;
            case Stage.C_Stage:
                C_Stage();
                break;
            case Stage.D_Stage:
                D_Stage();
                break;


        }

        {




        }

        yield break;
    }
    void Game_Start()
    {
      //  subtitleManager.AddText("유기를 했더니 물을 마셔야겠다 ->다이어리로 A장소안내");
       // if (  ) { }



    }
    void Loading()
    {

    }
    void NoTice()
    {


    }
    void Title_Scene()
    {

    }
    void Intro_Video()
    {

    }
    void Guide_Ui()
    {

    }
    void Call_Start()
    {

    }
    void A_Stage()
    {

    }
    void B_Stage()
    {

    }
    void C_Stage()
    {

    }
    void D_Stage()
    {

    }
    

    
    
}
