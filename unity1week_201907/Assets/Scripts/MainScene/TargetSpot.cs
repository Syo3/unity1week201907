using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class TargetSpot : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("スコア親")]
        private GameObject _scoreParent;
        #endregion


        #region private field
        private MainSceneManager _sceneManager;
        #endregion

        void OnTriggerEnter2D(Collider2D other)
        {
            // 入った
            if(other.gameObject.tag == "FallObject"){
                _sceneManager.Player.Basket.RemoveFallObjectList(other.gameObject.GetInstanceID());
                var fallObject = other.GetComponent<FallObject>();
                _sceneManager.ScoreManager.AddScore(fallObject.Score);
                // スコア表示
                var scoreView = Instantiate(_sceneManager.PrefabManager._scoreGet).GetComponent<ScoreUp>();
                scoreView.transform.parent   = _scoreParent.transform;
//                scoreView.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, other.transform.position);
                scoreView.transform.position = other.transform.position;
                scoreView.Init(fallObject.Score);
                // サウンド
                _sceneManager.SoundManager.PlayOnShot(1);
                Destroy(other.gameObject);

            }
        }


        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }
    }
}