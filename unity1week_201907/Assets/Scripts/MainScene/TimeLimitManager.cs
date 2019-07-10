using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class TimeLimitManager : MonoBehaviour {

        #region define
        private readonly float kTimeLimit = 60.0f;
        #endregion

        #region SerializeField
        [SerializeField, Tooltip("タイムリミット表示")]
        private TMPro.TextMeshProUGUI _timeLimitText;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        private float _time;
        private bool  _timeCountFlg;
        #endregion

        void Update()
        {
            if(_timeCountFlg != true) return;
            _time += Time.deltaTime;
            _timeLimitText.text = "じかん "+(int)(kTimeLimit - _time);
            if(_time > kTimeLimit){
                _sceneManager.SetResult();           
                _timeLimitText.text = "じかん 0";
                // リザルト処理
            }
        }

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _time         = 0.0f;
        }

        /// <summary>
        /// 時間カウント開始
        /// </summary>
        public void StartTimeCount()
        {
            _timeCountFlg = true;
        }
    }
}