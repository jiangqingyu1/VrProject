using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CinemaController : MonoBehaviour
{
    public Button ExitBtn;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyGameFacade._instance.Hide1();
        ExitBtn.onClick.AddListener(delegate() { UnityEngine.SceneManagement.SceneManager.LoadScene("mainScene"); });
    }

}
