using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class FileManager : MonoBehaviour
{
    string str = Application.streamingAssetsPath + "/aaa/";
    List<string> ListString = new List<string>();
    private void Start()
    {
        GetFiles();
    }
    public void GetFiles()
    {
        string path = string.Format("{0}", str);
        string strPathAll = "";
        if (Directory.Exists(str))
        {
            DirectoryInfo directory = new DirectoryInfo(str);
            FileInfo[] files = directory.GetFiles("*");
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                if (files[i].Name.EndsWith(".png"))
                {
                    strPathAll += "," + files[i].Name;
                }
                if (files[i].Name.EndsWith(".mp4"))
                {
                    strPathAll += "," + files[i].Name;
                }
            }
            if (PlayerPrefs.HasKey("File"))
            {
                string str = PlayerPrefs.GetString("File");
                if (str == strPathAll)
                {
                    Debug.Log("文件名一致不用替换"+ str);
                }
                else
                {
                    PlayerPrefs.SetString("File", strPathAll);
                    Debug.Log("文件名不一致进行替换" + PlayerPrefs.GetString("File"));
                    PlayerPrefs.SetString("FileGet","");
                }
            }
            else
            {
                PlayerPrefs.SetString("File", strPathAll);
                Debug.Log("没有文件进行添加" + PlayerPrefs.GetString("File"));
                PlayerPrefs.SetString("FileGet", "");
            }
            string strGet = PlayerPrefs.GetString("File");
            string[] strArray = strGet.Split(',');
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != "")
                {
                    ListString.Add(strArray[i]);
                }
            }
            for (int i = 0; i < ListString.Count; i++)
            {
                Debug.Log(ListString[i]);
            }
        }
    }
    public void GetAward()
    {

    }
}
