using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectMap : PanelBasicSetter
{
    public RectTransform m_panel;     //각 UI중심이 되는 패널
    public RectTransform[] m_mapImage;//분할된 맵 리소스가 들어갈 이미지
    public RectTransform m_center;    //중앙 기준점이 될 빈 오브젝트
    public float m_lerpSpeed = 10f;   //감도

    private float[] m_distance;       //각 mapImage와 center간의 절대 거리값
    private float[] m_distReposition; //각 mapImage와 center간의 방향 거리값
    private bool m_dragging = false;  //현재 유저의 드래그 반응 여부
    private int m_minImageNum;        //mapImage 중 distance가 가장 작은 mapImage의 인덱스
    
    /// <summary>
    /// 각 mapImage들의 center와의 거리값을 저장할 배열의 크기 초기화
    /// </summary>
    void Start()
    {
        int bttnLength = m_mapImage.Length;
        m_distance = new float[bttnLength];
        m_distReposition = new float[bttnLength];
        //SetVisible(true, 1);
    }

    /// <summary>
    /// 맵을 활성화 비활성화 하는 초기화 함수
    /// </summary>
    /// <param name="value"></param>    활성화 여부
    /// <param name="mapIndex"></param> 최초 세팅할 맵인덱스번호
    public void SetVisible(bool value, int mapIndex)
    {
        m_thisPanel.SetActive(value);
        if (value)
        {
            Vector2 bound = m_panel.sizeDelta;
            m_panel.anchoredPosition = new Vector2(0, mapIndex * bound.y);
        }
    }

    void Update()
    {
        //매 Update마다 절대거리, 방향거리 배열 리셋
        for (int i = 0; i < m_mapImage.Length; i++)
        {
            m_distReposition[i] = m_center.position.y - m_mapImage[i].position.y;
            m_distance[i] = Mathf.Abs(m_distReposition[i]);
        }

        //절대거리 배열 중 제일 작은 값 선정
        float minDistance = Mathf.Min(m_distance);

        //절대거리값 배열 중 minDistance에 해당하는 인덱스 선정
        for (int a = 0; a < m_mapImage.Length; a++)
        {
            if (minDistance == m_distance[a])
            {
                m_minImageNum = a;
            }
        }

        //현재 유저가 드래그 상태가 아니라면 center위치로 mapImage이동
        if (!m_dragging)
        {
            LerpToBttn(-m_mapImage[m_minImageNum].anchoredPosition.y);
        }
    }

    /// <summary>
    /// 주어진 위치로 panel이동
    /// </summary>
    /// <param name="position"></param>
    void LerpToBttn(float position)
    {
        float newY = Mathf.Lerp(m_panel.anchoredPosition.y, position, Time.deltaTime * m_lerpSpeed);
        Vector2 newPosition = new Vector2(m_panel.anchoredPosition.x, newY);

        m_panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        m_dragging = true;
    }

    public void EndDrag()
    {
        m_dragging = false;
    }


}
