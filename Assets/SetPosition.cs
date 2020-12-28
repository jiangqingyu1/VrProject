using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public GameObject VrObJ;
    public float IndexX;
    public float IndexY;
    public float IndexZ;
    public float Distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(VrObJ.transform.position,transform.position)>= Distance)
        {
            transform.position = new Vector3(VrObJ.transform.position.x + IndexX, IndexY, VrObJ.transform.position.z + IndexZ);
        }
    }
}
