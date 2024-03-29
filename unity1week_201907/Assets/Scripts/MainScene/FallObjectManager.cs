﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    /// <summary>
    /// 落下オブジェクト管理
    /// </summary>
    public class FallObjectManager : MonoBehaviour {

        #region define
        private float kCreateInterval = 0.25f;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        private float _intervalCount;
        private List<FallObject> _fallObjectList;
        #endregion

        void Update()
        {
            if(_sceneManager == null || _sceneManager.ControllFlg != true) return;
            _intervalCount += Time.deltaTime;
            if(_intervalCount > kCreateInterval){
                var fallObject = Instantiate(_sceneManager.PrefabManager._fallObject[Random.Range(0, _sceneManager.PrefabManager._fallObject.Count)]).GetComponent<FallObject>();
                fallObject.SceneManager = _sceneManager;
                _fallObjectList.Add(fallObject);
                _intervalCount = 0.0f;
            }
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager   = sceneManager;
            _intervalCount  = 0.0f;
            _fallObjectList = new List<FallObject>();
        }

    }
}