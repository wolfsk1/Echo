
using System;
using UnityEngine;

public class EchoConfig : ScriptableObject
{
    public bool IsOpenUnityLog = true;

    public static EchoConfig GetOrCreateConfig()
    {
    }
}
