using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class Basket : MonoBehaviour {

        public void Init(Transform parent)
        {
            transform.parent        = parent;
            transform.localPosition = new Vector3(0.0f, 40.0f, 0.0f);
        }
    }
}