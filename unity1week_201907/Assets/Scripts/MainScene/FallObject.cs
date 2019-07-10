using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class FallObject : MonoBehaviour {

        #region define
        private float kSpawnX = 200.0f;
        private float kSpawnY = 46.0f;
        private float kRandMax = 110.0f;
        private Vector3 kDefaultSize = new Vector3(0.5f, 0.5f, 0.5f);
        #endregion

        #region private field
        [SerializeField, Tooltip("物理")]
        private Rigidbody2D _rigid2D;
        [SerializeField, Tooltip("加算スコア")]
        private int _baseScore;
        [SerializeField, Tooltip("種類ID")]
        private int _objectID;
        #endregion

        #region private field
        private bool _fallFlg;
        private int _size;
        private Dictionary<int,FallObject> _collisionObjectList;
        private int _score;
        private bool _initFlg;
        private MainSceneManager _sceneManager;
        #endregion

        #region access
        public int Score{
            get{return _score;}
        }
        public int ObjectID{
            get{return _objectID;}
        }
        public int Size{
            get{return _size;}
        }
        public MainSceneManager SceneManager{
            set{_sceneManager = value;}
        }
        #endregion

        void Start()
        {
            transform.position   = new Vector3(Random.Range(-kSpawnX, kSpawnX), kSpawnY+Random.Range(0.0f, kRandMax), 0.0f);
            _fallFlg             = true;
            _collisionObjectList = new Dictionary<int, FallObject>();
            _size                = 1;
            _score               = _baseScore;
            _rigid2D.bodyType    = RigidbodyType2D.Kinematic;
            transform.localScale = Vector3.zero;
            
            //_initFlg             = true;
            StartCoroutine(Spawn());
        }

        void Update()
        {
            if(_initFlg != true) return;

            // 一定以上落ちたら消す
            // if(transform.position.y < -kSpawnY){
            //     Destroy(gameObject);
            // }
            var velocity = _rigid2D.velocity;
            if(velocity.x > 100 || velocity.x < -100){
                velocity.x *= 0.5f;
            }
            if(velocity.y > 100 || velocity.y < -100){
                velocity.y *= 0.5f;
            }
            _rigid2D.velocity = velocity;
            // 合体判定
            if(_collisionObjectList.Count > 1){
                _score               = _baseScore * 5 * _size;
                ++_size;
                transform.localScale = kDefaultSize * _size;
                foreach(var obj in _collisionObjectList){

                    if(obj.Value != null){
                        Destroy(obj.Value.gameObject);
                    }
                }
                _sceneManager.SoundManager.PlayOnShot(0);
            }
            _collisionObjectList = new Dictionary<int, FallObject>();
        }

        void OnCollisionEnter2D (Collision2D other)
        {
            Debug.Log(other.gameObject.tag);
            if(_fallFlg && other.gameObject.tag == "Ground"){
                _fallFlg          = false;
                _rigid2D.bodyType = RigidbodyType2D.Kinematic;
                StartCoroutine(DestroyWait());
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if(_initFlg != true) return;
            // 合体
            if(other.gameObject.tag == "FallObject"){
                var fallObject = other.gameObject.GetComponent<FallObject>();
                if(fallObject.ObjectID == _objectID && _size == fallObject.Size && !_collisionObjectList.ContainsKey(other.gameObject.GetInstanceID())){
                    _collisionObjectList.Add(other.gameObject.GetInstanceID(), other.gameObject.GetComponent<FallObject>());
                }
            }
        }


        private IEnumerator DestroyWait()
        {
            yield return null;
            Destroy(gameObject);
            // 点滅して消す
        }

        private IEnumerator Spawn()
        {
            var nowTransform = transform;
            while(nowTransform.localScale.x < kDefaultSize.x){
                yield return null;
                nowTransform.localScale = nowTransform.localScale + kDefaultSize / 10.0f;
            }
            nowTransform.localScale = kDefaultSize;
            var cnt = 0;
            while(cnt < 60){
                yield return null;
                float sin = Mathf.Sin(Time.time*10);
                nowTransform.eulerAngles += new Vector3(0.0f, 0.0f, sin);
                ++cnt;
            }
            _initFlg = true;
            _rigid2D.bodyType    = RigidbodyType2D.Dynamic;

        }
    }
}