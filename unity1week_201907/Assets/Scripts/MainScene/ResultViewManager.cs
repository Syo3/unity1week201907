using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class ResultViewManager : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("スコア表示")]
        private TMPro.TextMeshProUGUI _scoreText;
        [SerializeField, Tooltip("ボタn")]
        private Button _retryButton;
        [SerializeField, Tooltip("ランキングボタン")]
        private Button _rankingButton;
        [SerializeField, Tooltip("シェアボタン")]
        private Button _shareButton;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        private int _score;
        #endregion

        #region public function
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="sceneManager"></param>
        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            // リトライボタン
            _retryButton.onClick.AddListener(()=>{
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            });
            // ランキングボタン
            _rankingButton.onClick.AddListener(()=>{
                // Type == Number の場合
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking (_score);
            });
            // シェアボタン
            _shareButton.onClick.AddListener(()=>{
                naichilab.UnityRoomTweet.Tweet ("donguriguriguri", "どんぐりあつめて"+_score+"てんをとった！", "unityroom", "unity1week");
            });
        }

        /// <summary>
        /// リザルト設定
        /// </summary>
        /// <param name="score"></param>
        public void SetContent(int score)
        {
            _score          = score;
            _scoreText.text = score.ToString();
            gameObject.SetActive(true);
        }
        #endregion
    }
}