using System;
using UnityEngine;

namespace com.tdb.echo
{
	public class EchoUnityLogHandler : IEchoLogHandler
	{

		public void Log(EchoLogMessage logMessage)
		{
			Debug.unityLogger.Log(logMessage.Type, logMessage.Content);
		}

		public IEchoLogHandler GetInstance()
		{
			return new EchoUnityLogHandler();
		}

	}
}