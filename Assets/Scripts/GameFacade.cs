using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameFacade : MonoBehaviour
{
    public static GameFacade _instance;

    public StateManager StateManager;
    public PocketManager PocketManager;
    public SpeechTest SpeechTest;
    public int state;

    public GameObject EndPanel;
    public Button EndButton;
    public Text EndText;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {

        EndButton.onClick.AddListener(delegate() { SceneManager.LoadScene("mainScene"); });
        state = DontDestroyGameFacade._instance.state;
        StateManager = new StateManager();
        PocketManager = new PocketManager();

        SpeechTest = new SpeechTest();
        StateManager.InitState(state);
    }
    public void EndOver(string str)
    {
        EndText.text = str;
        Invoke("Set", 6f);
    }
    public void Set()
    {
        if (DontDestroyGameFacade._instance.state==1)
        {
          
            SceneManager.LoadScene("Cinema");
        }
        else
        {
            EndPanel.SetActive(true);
        }
    }
}
    