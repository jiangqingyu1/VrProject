using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketManager : MonoBehaviour
{

    public Dictionary<string, int> BuyObjs = new Dictionary<string, int>();

    public string ResultStr = "";
    int nowmoney;
    public void AddBuy(string str)
    {
        if (BuyObjs.ContainsKey(str))
        {
            BuyObjs[str] = BuyObjs[str] + 1; 
        }
        else
        {
            BuyObjs.Add(str,1);
        }
    }

    //放置物体
    public void BuyOverMethod()
    {
        ResultStr += "本次您购买了";
        foreach (var item in BuyObjs)
        {
            ResultStr += item.Value.ToString() + "个" + item.Key+"   ";

            nowmoney += DataPath.GetValue(item.Key) * item.Value;
        }
        if (GameFacade._instance.StateManager.StateValue>=nowmoney)
        {
            ResultStr += "本次您共需支付" + nowmoney.ToString() + "圆"+", "+"您持有"+ GameFacade._instance.StateManager.StateValue.ToString()+"圆"+", "+"找零"+(GameFacade._instance.StateManager.StateValue-nowmoney).ToString()+"圆"+","+"您成功完成任务";
            GameFacade._instance.SpeechTest.SpeakVoice(ResultStr);
            GameFacade._instance.EndOver("游戏成功");
        }
        else
        {
            ResultStr += "本次您共需支付" + nowmoney.ToString() + "圆" + ", " + "您持有" + GameFacade._instance.StateManager.StateValue.ToString() + "圆" + ", " +"持有金钱不够支付费用，请重新开始游戏";
            GameFacade._instance.SpeechTest.SpeakVoice(ResultStr);
            GameFacade._instance.EndOver("游戏失败，请重新选择关卡");
        }
      
    }
    public void WinCallBack()
    {
        //GameFacade._instance.EndOver("游戏成功,获取小红花*1");
    }
    public void LostCallBack()
    {
        //GameFacade._instance.EndOver("游戏失败，请重新选择关卡");
    }
}
