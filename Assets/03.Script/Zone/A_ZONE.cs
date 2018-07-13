using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_ZONE : MonoBehaviour {

    /*
     
(손)음수대 
-다이어리 출력 (너의 주머니에 있었던 우리의 연극 티켓 소중한
거니까 보관해 둬야지 )
	보관함(첫시작부터보관)에서 리트머스를 클릭하면 보관함이 닫히면서 투명버튼 생성 그후 
야외공연장티겟으로 변함 이미지 변환(물에적시는 연출)
	야외공연장 티겟변환후 데자뷰 버튼 등장 버튼클릭시 오브젝트 활성화 비활성화  
 
    구름다리 사진 발견 (데자뷰 재생후 화면에 등장 이때 5초후)
    데자뷰 재생후 유기장소 (구름다리)로 유저유도
    구름다리 도착 후 5초이후  반지오브젝트 생성 
    반지클릭 후 반지획득 캐리어 도구칸으로 이동 그이후
   손오브젝트 생성 후 터치 3번후 획득 캐리어 시체칸으로 이동 

         
         
         */

    public float latiTude;
    public float longiTude;
    public GoogleMap map = null;
    
   
    public SubtitleManager subtitleManager;
    public DiaryManager diaryManager;

    
    private void Start()
    {
        StartCoroutine(Check_Here());
        diaryManager = GetComponent<DiaryManager>();
       

    }
    public IEnumerator Check_Here()
    {
        yield return new WaitForSeconds(1.0f);


    }

    void Update()
    {
        
        float slatitude = map.centerLocation.latitude;
        float slongitude = map.centerLocation.longitude;

        float distance = (float)DistanceManager.Distance(
            latiTude, longiTude, slatitude, slongitude, 'K') * 1000;

       

        if (distance < 20)
        {
           
            diaryManager.diary_Second();

        }
        else
        {
            
        }

    }



    
}
