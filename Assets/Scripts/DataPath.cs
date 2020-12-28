using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPath
{
    public static Dictionary<string, int> ObjValue = new Dictionary<string, int>();

    public static int GetValue(string ObjName)
    {
        foreach (var item in ObjValue)
        {
            if (item.Key == ObjName)
            {
                return item.Value;
            }
        }
        return 0;
    }
}
