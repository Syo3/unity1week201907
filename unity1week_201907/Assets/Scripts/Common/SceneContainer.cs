using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContainer : MonoBehaviour {

	#region public field
    private Object[] _sendData;
	#endregion

	#region access
    public Object[] SendData{
        get{return _sendData;}
        set{_sendData = value;}
    }
	#endregion
}
