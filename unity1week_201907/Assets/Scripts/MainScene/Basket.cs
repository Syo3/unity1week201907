using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class Basket : MonoBehaviour {

        #region private field
        private Dictionary<int, GameObject> _fallObjectList;
        private Vector3 _drawCachePositoin;
        #endregion


        void Update()
        {
            // var pos = Camera.main.WorldToScreenPoint (transform.localPosition);
            // var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos );
            // transform.localRotation = rotation;

            //GetComponent<Rigidbody2D>().rotation = rotation.ToEulerAngles().z;
        }

        void LateUpdate()
        {
            _drawCachePositoin      = transform.localPosition;
            transform.localPosition = new Vector3(Mathf.RoundToInt(_drawCachePositoin.x), Mathf.RoundToInt(_drawCachePositoin.y), Mathf.RoundToInt(_drawCachePositoin.z));
        }

        void OnRenderObject()
        {
            transform.localPosition = _drawCachePositoin;
        }


        public void Init(Transform parent)
        {
            //transform.parent        = parent;
            transform.localPosition = new Vector3(0.0f, 50.0f, 0.0f);
            _fallObjectList         = new Dictionary<int, GameObject>();

        }

        public void CheckMove(Vector2 vector)
        {
            var keys = _fallObjectList.Keys;
            foreach(var key in keys){
                // if(_fallObjectList.ContainsKey(key) == false){
                //     _fallObjectList.Remove(key);                    
                // }
                if(_fallObjectList[key] == null){
                    _fallObjectList.Remove(key);
                    continue;
                }
                _fallObjectList[key].gameObject.GetComponent<Rigidbody2D>().position += vector;
            }


            // foreach(var fallObj in _fallObjectList){

            //     if(fallObj.Value == null){
            //         _fallObjectList.Remove(fallObj.Key);
            //         continue;
            //     }
            //     fallObj.Value.gameObject.GetComponent<Rigidbody2D>().position += vector;
            // }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "FallObject" && !_fallObjectList.ContainsKey(collision.gameObject.GetInstanceID())){
                _fallObjectList.Add(collision.gameObject.GetInstanceID(), collision.gameObject);
            }            
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "FallObject" && _fallObjectList.ContainsKey(collision.gameObject.GetInstanceID())){
                _fallObjectList.Remove(collision.gameObject.GetInstanceID());
            }
        }

        public void RemoveFallObjectList(int instanceID)
        {
            if(_fallObjectList.ContainsKey(instanceID)){
                _fallObjectList.Remove(instanceID);
            }
        }

        // void OnCollitionEnter2D(Collision2D collision)
        // {
        // }

        // void OnCollisionExit2D(Collision2D collision)
        // {
        // }

        
    }
}