using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{

    public class Basket : MonoBehaviour {

        private Dictionary<int, GameObject> _fallObjectList;


        public void Init(Transform parent)
        {
            transform.parent        = parent;
            transform.localPosition = new Vector3(0.0f, 40.0f, 0.0f);
            _fallObjectList         = new Dictionary<int, GameObject>();

        }

        public void CheckMove(Vector2 vector)
        {
            foreach(var fallObj in _fallObjectList){

                fallObj.Value.gameObject.GetComponent<Rigidbody2D>().position += vector;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("In");
            if(collision.gameObject.tag == "FallObject"){
                _fallObjectList.Add(collision.gameObject.GetInstanceID(), collision.gameObject);
            }            
            Debug.Log(_fallObjectList.Count);
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Out");
            Debug.Log(_fallObjectList.Count);
            if(collision.gameObject.tag == "FallObject" && _fallObjectList.ContainsKey(collision.gameObject.GetInstanceID())){
                _fallObjectList.Remove(collision.gameObject.GetInstanceID());
            }
            Debug.Log(_fallObjectList.Count);
        }

        // void OnCollitionEnter2D(Collision2D collision)
        // {
        // }

        // void OnCollisionExit2D(Collision2D collision)
        // {
        // }

        
    }
}