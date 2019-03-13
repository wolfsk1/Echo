using System;
using UnityEngine;

namespace com.tdb.echo
{
	public class EchoUnityLogHandler : IEchoLogHandler
	{

		public void Log(EchoMessage message)
		{
			Debug.unityLogger.Log(message.Type, message.Content);
		}

		public IEchoLogHandler GetInstance()
		{
			return new EchoUnityLogHandler();
		}

	}
}