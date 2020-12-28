using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginController : MonoBehaviour
{
    public static LoginController _instance;
    public InputField UserNameInput;
    public InputField PassWordInput;
    public Button LoginBtn;
    public GameObject obj;

    public GameObject IPObj;
    public InputField IPInput;
    public Button IPBtn;



    public GameObject objMain;
    public Button button1;
    public Button button2;
    public Button button3;

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        LoginBtn.onClick.AddListener(ClickLoginBtn);
        IPBtn.onClick.AddListener(IPClick);
        button1.onClick.AddListener(delegate() { DontDestroyGameFacade._instance.LoadScene(1); });
        button2.onClick.AddListener(delegate () { DontDestroyGameFacade._instance.LoadScene(2); });
        button3.onClick.AddListener(delegate () { DontDestroyGameFacade._instance.LoadScene(3); });
        if (DontDestroyGameFacade._instance.Login==1)
        {
            objMain.SetActive(true);
        }

    }
    public void LoadScene(int i)
    {

    }
    public void IPClick()
    {
        UdpClientScr.instance.ip1 = IPInput.text;
        IPObj.gameObject.SetActive(false);
        ShowMessage("IpV6链接成功");
    }
    public void ClickLoginBtn()
    {
        if (UserNameInput.text==""||PassWordInput.text=="")
        {
            Debug.Log("用户名或密码不能为空");
            return ;
        }
        else
        {
            UdpClientScr.instance.sendMsg(UserNameInput.text+"|"+PassWordInput.text);
        }
    }
    public void ShowMessage(string str)
    {
        if (str=="0")
        {
            objMain.SetActive(true);
            DontDestroyGameFacade._instance.Login = 1;
        }
        if (str=="1")
        {
            obj.SetActive(true);
            obj.transform.GetChild(0).GetComponent<Text>().text = "用户名或密码错误";
            Invoke("Hide", 1f);
        }
    }
    public void Hide()
    {
        obj.SetActive(false);
    }
}
