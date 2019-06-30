using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class BasketSupply : MonoBehaviour {

        #region private field
        private MainSceneManager _sceneManager;
        #endregion

        public void Init(MainSceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        void OnTriggerEnter(Collider other)
        {
            _sceneManager.Player.SetBasket();    
        }
    }
}