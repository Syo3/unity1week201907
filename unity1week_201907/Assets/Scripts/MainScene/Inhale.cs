using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhale : MonoBehaviour {

    #region SerializeField

    #endregion

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "FallObject"){
            var rigidBody = other.gameObject.GetComponent<Rigidbody2D>();
            rigidBody.velocity += new Vector2(0.0f, -50.0f);
        }
    }
}
