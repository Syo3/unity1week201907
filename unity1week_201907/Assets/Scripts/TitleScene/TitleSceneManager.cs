using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitleScene{
    public class TitleSceneManager : MonoBehaviour {

        // Use this for initialization
        void Start ()
        {
            
        }

        void Update()
        {
            // スペースキー
            if (Input.GetMouseButton(0)) {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            }
        }

    }
}