using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(DontDestroyGameFacade._instance.gameObject.transform.position.x,transform.position.y, DontDestroyGameFacade._instance.gameObject.transform.position.z));
    }
}
