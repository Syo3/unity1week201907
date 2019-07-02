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

        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Trigger");
            if(other.name != "Player")return;
            _sceneManager.Player.SetBasket();    
        }
    }
}