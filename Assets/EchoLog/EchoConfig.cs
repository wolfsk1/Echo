
using System;
using UnityEngine;
using UnityEngine.Events;

public class EchoConfig : ScriptableObject
{
    /// <summary>
    /// is open unity default logger.
    /// </summary>
    public bool IsOpenUnityLog = true;
    /// <summary>
    /// Max log count.-1 mean 
    /// </summary>
    public int MaxLogCount = -1;
    
    private static EchoConfig _instance;
    
    public static EchoConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                var result = Resources.Load<EchoConfig>("EchoConfig/EchoConfigFile");
                if (result == null)
                {
                    result = CreateInstance<EchoConfig>();    
                }

                _instance = result;
            }

            return _instance;
        }
    }
}
