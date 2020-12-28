using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag!="vive")
        {
            other.GetComponent<ObjAttitude>().TriggerEvent();
        }

    }
}
