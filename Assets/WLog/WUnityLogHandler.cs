using com.tdb.w;
using UnityEngine;

public class WUnityLogHandler : IWLogHandler 
{

	public void Log(WLogMessage message)
	{
		Debug.unityLogger.Log(message.Type, message.Content);
	}
	
}
