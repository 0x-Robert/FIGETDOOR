using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PANELTYPE
{
    MAP, RECORDER
}
public enum INVENTORY
{
    BODY, SLOT
}
public enum DATATYPE
{
    INVENTORY
}
public enum ITEMTYPE
{
    BODY, HINT
}

//데이터 및 enum타입 선언 관리, 
public class DataType : MonoBehaviour {

    public static DataType inst = null;

    private DATATYPE m_dataType = DATATYPE.INVENTORY;
    
    private void Awake()
    {
        inst = this;
    }
}
public struct Item
{
    public int itemType;
    public int key;
    public Item(int type, int key)
    {
        itemType = type;
        this.key = key;
    }
}
