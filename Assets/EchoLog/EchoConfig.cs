
using System;
using UnityEngine;
using UnityEngine.Events;

public class EchoConfig : ScriptableObject
{
    /// <summary>
    /// is open unity default logger.
    /// </summary>
    public bool IsOpenUnityLog
    {
        get { return _isOpenUnityLog; }
        set
        {
            if (value != _isOpenUnityLog)
            {
                _isOpenUnityLog = value;
                if (ConfigChanged != null)
                {
                    ConfigChanged.Invoke();
                }
            }
        }
    }
    private bool _isOpenUnityLog = true;
    /// <summary>
    /// Max log count.-1 mean 
    /// </summary>
    public int MaxLogCount
    {
        get { return _maxLogCount; }
        set
        {
            if (value != _maxLogCount)
            {
                _maxLogCount = value;
                if (ConfigChanged != null)
                {
                    ConfigChanged.Invoke();
                }
            }
        }
    }

    private int _maxLogCount = -1;
    
    public UnityAction ConfigChanged;

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
