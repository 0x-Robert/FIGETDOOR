using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBasicSetter : MonoBehaviour {

    public GameObject m_thisPanel;

    /// <summary>
    /// 패널을 활성화 하는 함수
    /// </summary>
    /// <param name="value"></param>
    public virtual void SetVisible(bool value)
    {
        m_thisPanel.SetActive(value);

    }
}
