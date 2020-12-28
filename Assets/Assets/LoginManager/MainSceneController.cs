using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainSceneController : MonoBehaviour
{
    public Button BackBtn;
    // Start is called before the first frame update
    void Start()
    {
        BackBtn.onClick.AddListener(delegate() { SceneManager.LoadScene("loginscene"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
