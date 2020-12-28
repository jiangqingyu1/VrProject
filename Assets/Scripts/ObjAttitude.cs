using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAttitude : MonoBehaviour
{
    public string name;
    public Vector3 vec;
    public Quaternion quater;
    // Start is called before the first frame update
    void Start()
    {
        
        vec = transform.position;
        quater = transform.rotation;
    }
    private void Update()
    {
        name = gameObject.tag;
    }
    public void ResetPosAndQua()
    {
        transform.position = vec;
        transform.rotation = quater;
    }
    public void TriggerEvent()
    {
        int i = GameFacade._instance.StateManager.CheckState(name);
        if (i == 0)
        {
            GameFacade._instance.PocketManager.AddBuy(gameObject.tag);
            Destroy(gameObject);
        }
        else
        {
            ResetPosAndQua();
        }

    }
}
