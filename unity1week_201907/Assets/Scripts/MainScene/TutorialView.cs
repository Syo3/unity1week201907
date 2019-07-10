using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScene{
    public class TutorialView : MonoBehaviour {

        #region SerializeField
        [SerializeField, Tooltip("")]
        private Button _button;
        #endregion
        private MainSceneManager _sceneManager;

        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _button.onClick.AddListener(()=>{
                _sceneManager.EndTutorial();
                gameObject.SetActive(false);
            });
        }
    }
}