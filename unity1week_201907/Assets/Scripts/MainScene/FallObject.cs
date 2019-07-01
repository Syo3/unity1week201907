using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class FallObject : MonoBehaviour {

        #region define
        private float kSpawnX = 200.0f;
        private float kSpawnY = 200.0f;
        #endregion

        #region private field
        #endregion

        void Start()
        {
            transform.position = new Vector3(Random.Range(-kSpawnX, kSpawnX), kSpawnY, 0.0f);
        }

        void Update()
        {
            // 一定以上落ちたら消す
            if(transform.position.y < -kSpawnY){
                Destroy(gameObject);
            }
        }
    }
}