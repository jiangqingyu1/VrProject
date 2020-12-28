using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyGameFacade : MonoBehaviour
{
    public static DontDestroyGameFacade _instance;
    public GameObject obj;

    public int state;
    public int Login=0;
    private void Awake()
    {
        _instance = this;
    }

    public void LoadScene(int i)
    {
        state = i;
        Hide();
        SceneManager.LoadScene("GameScene");
    }
    public void Hide()
    {
        transform.position = new Vector3(-5.83f,0,3.78f);
        obj.SetActive(false);
    }
    public void Hide1()
    {
        transform.position = Vector3.zero;
    }
}
