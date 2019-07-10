using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MainScene{
    public class BasketParent : MonoBehaviour {
        
        [SerializeField, Tooltip("バスケット本体")]
        private Basket _basket;

        public Basket Basket{
            get{return _basket;}
        }

        // Update is called once per frame
        void Update ()
        {
            // var pos      = Camera.main.WorldToScreenPoint (transform.localPosition);
            // var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos );
            // GetComponent<Rigidbody2D>().MoveRotation(rotation.eulerAngles.z);
        }

        public void Init(Transform parentTransform)
        {
            //transform.parent        = parentTransform;
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            _basket.Init(transform);
        }

        public void UpdateRotate()
        {
            var pos      = Camera.main.WorldToScreenPoint (transform.localPosition);
            Debug.Log(pos);
            var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos );
//            transform.localRotation = rotation;
            var tmp = GetComponent<Rigidbody2D>().rotation;
            var deg = transform.eulerAngles.z - rotation.eulerAngles.z;
            if(Math.Abs(deg) > 10.0f){
                deg = deg / Math.Abs(deg) * 10.0f;
            }
            deg += transform.eulerAngles.z;

            GetComponent<Rigidbody2D>().MoveRotation(rotation.eulerAngles.z);
            //GetComponent<Rigidbody2D>().MoveRotation(rotation.eulerAngles.z);
            //GetComponent<Rigidbody2D>().rotation = rotation.eulerAngles.z;
        }
    }
}