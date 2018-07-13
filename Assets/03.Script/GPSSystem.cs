using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPSSystem : MonoBehaviour
{
    public GoogleMap m_GoogleMap;
  //  public GPSPanel m_GPSPanel;

    IEnumerator Start()
    {
        //사용자 위치 서비스가 실행되고 있는지 먼저 점검한다.
        if (Input.location.isEnabledByUser == false) //!Input.location.isEnabledByUser
            yield break;

        // 위치를 조회하기 전에 서비스를 시작합니다.
        Input.location.Start(0.5f);

        // 서비스 시작하기 전까지 대기 합니다.
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // 20초 안에 서비스가 초기화하지 않았다.
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // 연결 실패
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            while (true)
            {
                // 구글맵 업데이트 
                m_GoogleMap.centerLocation.latitude = Input.location.lastData.latitude; //center location
                m_GoogleMap.centerLocation.longitude = Input.location.lastData.longitude;

                //m_GPSPanel.SetGPSUI(Input.location.lastData.latitude, Input.location.lastData.longitude);

                yield return new WaitForSeconds(1);
            }
        }
    }
}