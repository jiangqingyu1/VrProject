using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneUIManager : MonoBehaviour
{
    public Button ui;
    // Start is called before the first frame update
    void Start()
    {
        ui.onClick.AddListener(onClickUI);
    }
    public void onClickUI()
    {
        DontDestroyGameFacade._instance.Hide();
        DontDestroyGameFacade._instance.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
