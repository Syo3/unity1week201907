using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

public class MainSceneManager : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("プレハブ管理")]
    private PrefabManager _prefabManager;
    [SerializeField, Tooltip("プレイヤー")]
    private Player _player;
    [SerializeField, Tooltip("バスケット置き場")]
    private BasketSupply _basketSupply;
    #endregion

    #region access
    public PrefabManager PrefabManager{
        get{return _prefabManager;}
    }
    public Player Player{
        get{return _player;}
    }
    #endregion

	// Use this for initialization
	void Start()
    {
		_player.Init(this);
        _basketSupply.Init(this);
	}
	

}
}