using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class ScoreManager : MonoBehaviour {

        #region private field
        private MainSceneManager _sceneManager;
        private int _score;
        #endregion

        #region access
        public int Score{
            get{return _score;}
        }
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _score        = 0;
        }

        /// <summary>
        /// スコア追加
        /// </summary>
        /// <param name="add"></param>
        public void AddScore(int add)
        {
            _score += add;
        }
        #endregion
    }
}