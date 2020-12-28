using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using System.Threading;

public class SpeechTest : MonoBehaviour
{

    Thread t;
    public SpVoice spVoice;
    string DefaultEnglishLangID = "804";//中文 409：英文

    public void SpeakVoice(string content)
    {
        t = null;
        try
        {
            if (t == null)
            {
                t = new Thread(() =>
                {
                    string contentStr = "<voice required=\"Language=" + DefaultEnglishLangID + "\">" + content + "</voice>";
                    Debug.Log("aa");
                    if (spVoice == null)
                    {
                        Debug.Log("bb");
                        spVoice = new SpVoice();
                        Debug.Log("cc");
                        //spVoice.Voice = spVoice.GetVoices(string.Empty, string.Empty).Item(0);
                        spVoice.Speak(contentStr, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak | SpeechVoiceSpeakFlags.SVSFlagsAsync);
                        Debug.Log("dd");
                    }
                    else
                    {
                        spVoice.Speak(contentStr, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak | SpeechVoiceSpeakFlags.SVSFlagsAsync);
                        Debug.Log("ggg");
                    }
                });
            }

            t.Start();
        }
        catch (System.Exception e)
        {
            Debug.Log("ffffff");
            Debug.Log(e);
           
        }
    }
}

