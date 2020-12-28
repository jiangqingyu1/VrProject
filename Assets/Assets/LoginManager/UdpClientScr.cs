using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UdpClientScr : MonoBehaviour
{
    public static UdpClientScr instance = null;
    //private UdpClient client;
    private Thread thread = null;
    //private IPEndPoint remotePoint;
    //private int port = 12581;
    ////private int port = 23;

    //public Action<string> receiveMsg = null;

    public string receiveString = "";

    public string ip1 = "fe80::55cc:27b:f662:c73b%13";
    //public string ip2;

    public Socket client;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //ip1 = PlayerPrefs.GetString("ip1");
            //ip2 = PlayerPrefs.GetString("ip2");
            //ip1 = "192.168.5.130";
            //ip2 = "192.168.1.3";
            //Debug.Log(ip1 + "" + ip2);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DataPath.ObjValue.Add("铅笔", 2);
        DataPath.ObjValue.Add("书包", 30);
        DataPath.ObjValue.Add("可乐", 3);

        DataPath.ObjValue.Add("菠萝", 10);

        DataPath.ObjValue.Add("订书器", 15);
        //if (ip1 == "" || ip2 == "")
        //{
        //    CTETime2.instance.ipConfigPanel.SetActive(true);
        //}

        client = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
        client.Bind(new IPEndPoint(IPAddress.IPv6Any, 6003));
        thread = new Thread(ReciveMsg);
        thread.Start();
        //Console.WriteLine("客户端已经开启");
        SceneManager.LoadScene("mainScene");    
    }

    public void sendMsg(string msg)
    {
        EndPoint point = new IPEndPoint(IPAddress.Parse(ip1), 6001);
        Debug.Log(ip1);
        client.SendTo(Encoding.UTF8.GetBytes(msg), point);
        Debug.Log("aaaa");
    }

    /// <summary>
    /// 接收发送给本机ip对应端口号的数据报
    /// </summary>
    public void ReciveMsg()
    {
        while (true)
        {
            EndPoint point = new IPEndPoint(IPAddress.IPv6Any, 0);//用来保存发送方的ip和端口号
            byte[] buffer = new byte[1024];
            int length = client.ReceiveFrom(buffer, ref point);//接收数据报
            string message = Encoding.UTF8.GetString(buffer, 0, length);
            receiveString = message;
        }
    }
    //接受消息
    //void ReceiveMsg()
    //{
    //    while (true)
    //    {
    //        client = new UdpClient(11234, AddressFamily.InterNetworkV6);

    //        byte[] receiveData = client.Receive(ref remotePoint);//接收数据
    //        receiveString = Encoding.UTF8.GetString(receiveData);
    //        Debug.Log(receiveString);
    //        client.Close();
    //    }
    //    Debug.Log("aaaaaaaaaaa");
    //}

    //public void SocketSend( string msg)
    //{
    //    //           SendMsg(IPAddress.Parse("192.168.1.207"), msg);
    //    //SendMsg(IPAddress.Parse("172.20.10.2"), msg);
    //    //Debug.Log(ip1);
    //    //Debug.Log(ip2);
    //    //SendMsg(IPAddress.Parse("192.168.5.130"), msg);
    //    SendMsg(IPAddress.Parse(ip1), msg);



    //    //SendMsg(IPAddress.Parse("192.168.1.213"), msg);
    //    //SendMsg(IPAddress.Parse("172.20.10.2"), msg);
    //    //SendMsg(IPAddress.Parse(ip2), msg);


    //}
    //public void UDPSend()
    //{
    //    //IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse("192.168.10.17"), 23);
    //    //byte[] sendData = TcpClient.strToToHexByte("02 41 44 5a 5a 3b 50 4f 46 03");
    //    //UdpClient client = new UdpClient();
    //    //client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点
    //    //client.Close();//关闭连接
    //}
    ////发送消息
    //void SendMsg(IPAddress ip, string _msg)
    //{
    //    Debug.Log("IP:" + ip + "~~~Msg:" + _msg);
    //    IPEndPoint remotePoint = new IPEndPoint(ip, 12581);//实例化一个远程端点

    //    if (_msg != null)
    //    {
    //        byte[] sendData = Encoding.Default.GetBytes(_msg);
    //        UdpClient client = new UdpClient(port, AddressFamily.InterNetworkV6);
    //        client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点
    //        client.Close();//关闭连接
    //    }
    //}
    void Update()
    {
        if (receiveString!="")
        {
            LoginController._instance.ShowMessage(receiveString);
            receiveString = "";
        }
    }
    //public void Click()
    //{
    //    SendMsg(IPAddress.Parse("172.20.10.2"), "aaa");
    //}

    void OnDestroy()
    {
        SocketQuit();
    }
    void SocketQuit()
    {
        if (thread != null)
        {
            thread.Abort();
            thread.Interrupt();

        }
        client.Close();
    }
    void OnApplicationQuit()
    {
        SocketQuit();
    }
}