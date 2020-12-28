using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private int qianbicount;
    private int state;
    public int StateValue;
    //进入游戏开始，
    public void InitState(int i)
    {
        state = i;
        if (i==1)
        {
            GameFacade._instance.SpeechTest.SpeakVoice("小朋友，欢迎光临本超市，本局任务为购买一只铅笔并前往收银台结账，完成任务后会有精美礼品哦");
            StateValue = 2;
        }
        if (i==2)
        {
            GameFacade._instance.SpeechTest.SpeakVoice("小朋友，欢迎光临本超市，本局任务为您共持有十元现金，请购买物品并保证您持有现金足够支付您购买的物品并前往收银台结账，完成任务后会有精美礼品哦");
            StateValue = 10;
        }
        if (i==3)
        {
            GameFacade._instance.SpeechTest.SpeakVoice("小朋友，欢迎光临本超市，本局任务为您共持有一百元现金，请购买物品并保证您持有现金足够支付您购买的物品并前往收银台结账，完成任务后会有精美礼品哦");
            StateValue = 100;
        }
        
    }
    //结算，每次放置物品都调用一次这个方法
    public int CheckState(string str)
    {
        if (state==1)
        {
            if (qianbicount>=1)
            {
                GameFacade._instance.SpeechTest.SpeakVoice("你已经获取需要购买的物品，请前往收银台结账");
                //Debug.Log("你已经获取需要购买的物品，请前往收银台结账");
                return 2 ;
            }
            if (str!="铅笔")
            {
                GameFacade._instance.SpeechTest.SpeakVoice("小朋友您购买的不是铅笔，请小朋友购买铅笔");
                Debug.Log("请小朋友购买铅笔");
                return  1;
            }
            else
            {
                qianbicount++;
                GameFacade._instance.SpeechTest.SpeakVoice("小朋友已经成功购买铅笔了，请前往收银台结算");
                Debug.Log("小朋友已经成功购买铅笔了，请前往收银台结算");
                return 0;
            }
        }
        else
        {
            GameFacade._instance.SpeechTest.SpeakVoice("请小朋友购买完成后前往收银台结算");
            return 0;
        }
    }
}
