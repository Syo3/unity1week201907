using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class MainSceneManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("メインカメラ")]
        private Camera _mainCamera;
        [SerializeField, Tooltip("プレハブ管理")]
        private PrefabManager _prefabManager;
        [SerializeField, Tooltip("サウンド管理")]
        private SoundManager _soundManager;

        [SerializeField, Tooltip("プレイヤー")]
        private Player _player;
        [SerializeField, Tooltip("落下オブジェクト管理")]
        private FallObjectManager _fallObjectManager;
        [SerializeField, Tooltip("入れるところ")]
        private TargetSpot _targetSpot;
        [SerializeField, Tooltip("スコア管理")]
        private ScoreManager _scoreManager;
        [SerializeField, Tooltip("タイムリミット管理")]
        private TimeLimitManager _timeLimitManager;
        [SerializeField, Tooltip("リザルト表示管理")]
        private ResultViewManager _resultViewManager;
        [SerializeField, Tooltip("")]
        private TutorialView _tutorialView;
        #endregion

        #region private field
        private bool _controllFlg;
        #endregion

        #region access
        public PrefabManager PrefabManager{
            get{return _prefabManager;}
        }
        public SoundManager SoundManager{
            get{return _soundManager;}
        }
        public Player Player{
            get{return _player;}
        }
        public Camera Camera{
            get{return _mainCamera;}
        }
        public ScoreManager ScoreManager{
            get{return _scoreManager;}
        }
        public bool ControllFlg{
            get{return _controllFlg;}
        }
        #endregion

        // Use this for initialization
        void Start()
        {
            _player.Init(this);
            _fallObjectManager.Init(this);
            _targetSpot.Init(this);
            _scoreManager.Init(this);
            _timeLimitManager.Init(this);
            _resultViewManager.Init(this);
            _tutorialView.Init(this);
        }


        public void EndTutorial()
        {
            _timeLimitManager.StartTimeCount();
            _controllFlg = true;
        }

        /// <summary>
        /// リザルト表示
        /// </summary>
        public void SetResult()
        {
            _controllFlg = false;
            _resultViewManager.SetContent(_scoreManager.Score);
        }
    }
}