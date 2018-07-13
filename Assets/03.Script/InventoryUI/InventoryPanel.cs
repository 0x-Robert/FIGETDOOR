using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : PanelBasicSetter
{
    public Toggle           m_toggle;
    public RectTransform    m_switch;
    public Image            m_charging;
    public GameObject       m_bodyPanel;
    public GameObject       m_slotPanel;

    public Image            m_slotSample;
    public Image[]          m_part;
    public List<Image>      m_slotList = new List<Image>();

    private INVENTORY   m_invenType;
    
    /// <summary>
    /// 장비창 유형을 변환
    /// </summary>
    public void ChangMode()
    {
        if (m_invenType.Equals(INVENTORY.BODY))
        {
            m_invenType = INVENTORY.SLOT;
            m_bodyPanel.SetActive(false);
            m_slotPanel.SetActive(true);
            StartCoroutine(MoveChangeToggle(1));
        }
        else
        {
            m_invenType = INVENTORY.BODY;
            m_bodyPanel.SetActive(true);
            m_slotPanel.SetActive(false);
            StartCoroutine(MoveChangeToggle(-1));
        }
    }

    /// <summary>
    /// 아이템 데이터가 추가될 때 마다 실행
    /// 보관함의 slot을 추가, 혹은 body를 갱신
    /// </summary>
    public void SetInventory(Item item)
    {
        //데이터 셋에 맞춰 slotSample 복사
        //List<Item> iList = DataManager.inst.GetItemlist;

        if (item.itemType.Equals(ITEMTYPE.BODY))
        {
            m_part[item.key].gameObject.SetActive(true);    //TODO 추후 효과를 넣어 활성화 하도록 할것
        }
        else
        {
            GameObject go;
            go = Instantiate(m_slotSample.gameObject);
            go.transform.SetParent(m_slotSample.transform.parent);
            go.transform.localScale = new Vector3(1f, 1f, 1f);

            //TODO key값에 따라 만든 go의 이미지리소스 할당
        }
    }

    IEnumerator MoveChangeToggle(int vector)
    {
        float T = 0.5f;
        float S = 5f; //Speed
        float V = S / T;
        float nowT = 0f;

        Vector2 pos = m_switch.anchoredPosition;
        m_toggle.interactable = false;
        if (vector > 0)
        {
            pos.x = 35f;
            while (true)
            {
                if(nowT > T)
                {
                    m_switch.anchoredPosition = pos;
                    break;
                }
                nowT += Time.deltaTime;
                m_switch.anchoredPosition = Vector3.Lerp(m_switch.anchoredPosition, pos, V * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            pos.x = -35f;
            while (true)
            {
                if (nowT > T)
                {
                    m_switch.anchoredPosition = pos;
                    break;
                }
                nowT += Time.deltaTime;
                m_switch.anchoredPosition = Vector3.Lerp(m_switch.anchoredPosition, pos, V * Time.deltaTime);
                yield return null;
            }
        }
        m_toggle.interactable = true;
    }
}
