using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DebugManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Echo.Log(EchoConfig.Instance.MaxLogCount.ToString());
		Echo.Log("Hello","Nobody");
		StackTrace st = new StackTrace(true);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
