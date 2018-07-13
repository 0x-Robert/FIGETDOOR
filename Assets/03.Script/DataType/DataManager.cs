using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager inst = null;

    private List<Item> m_Itemlist = new List<Item>();

    public List<Item> GetItemlist
    {
        get { return m_Itemlist; }
    }
    public Item SetItemList
    {
        set { m_Itemlist.Add(value); }
    }

    private void Awake()
    {
        inst = this;
    }
    


    //public JsonData GetJsonData(string filename, DATATYPE type)
    //{
    //    string str = ReadStringFromFile(filename);
    //    if (str == null) return null;
    //    JsonData getData = JsonMapper.ToObject(str);

    //    switch (type)
    //    {
    //        case DATATYPE.INVENTORY:
    //            string itype;
    //            string ikey;

    //            for(int i = 0; i <  getData.Count; i++)
    //            {
    //                itype = getData[i]["itemType"].ToString();
    //                ikey = getData[i]["key"].ToString();
    //                Item item = new Item(System.Convert.ToInt32(itype), System.Convert.ToInt32(ikey));
    //            }

    //            break;
    //    }
    //}

    public void WriteStringToFile(string str, string filename)
    {
#if !WEB_BUILD
        string path = PathForDocumentsFile(filename);
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(str);

        sw.Close();
        file.Close();
#endif
    }
    public string ReadStringFromFile(string filename)
    {
#if !WEB_BUILD
        string path = PathForDocumentsFile(filename);

        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }
        else
        {
            return null;
        }
#else
    return null;
#endif
    }
    public string PathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }
}
