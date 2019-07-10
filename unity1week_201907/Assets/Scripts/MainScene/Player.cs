using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class Player : MonoBehaviour {

        #region define
        private float kMoveSpeed = 150.0f;
       private enum MoveFlg{
            kNone,
            kLeft,
            kRight
        }
        #endregion

        #region SerializeField
        [SerializeField, Tooltip("アニメーター")]
        private Animator _animator;
        [SerializeField, Tooltip("RigidBody")]
        private Rigidbody2D _rigid2D;
        #endregion

        #region private field
        private MainSceneManager _sceneManager;
        private bool _initFlg;
        private MoveFlg _moveFlg;
        private MoveFlg _frameMoveFlg;
        private bool _basketFlg;
        private Vector3 _drawCachePositoin;
        private Basket _basket;
        private BasketParent _basketParent;
        private bool _jumpFlg;
        private bool _groundFlg;
        private float _jumpRate;
        private GameObject _groundObject;
        #endregion

        #region access
        public bool BasketFlg{
            get{return _basketFlg;}
        }
        public Basket Basket{
            get{return _basket;}
        }
        #endregion

        /// <summary>
        /// Update
        /// </summary>
        void Update()
        {
            if(_initFlg != true || _sceneManager.ControllFlg != true) return;
            InputKey();   
        }

        //void OnCollisionStay2D(Collision2D other)
        void OnTriggerStay2D(Collider2D other)
        {
            if(other.gameObject.tag == "Ground"){
                //_rigid2D.position = _rigid2D.position * Vector2.right + new Vector2(0.0f, -89.0f);
                if(_jumpFlg){
                    var vector = new Vector3(transform.position.x, other.transform.position.y + other.gameObject.GetComponent<BoxCollider2D>().size.y * other.transform.localScale.y / 2.0f + GetComponent<BoxCollider2D>().size.y / 2.0f * transform.localScale.y, 0.0f);
                    transform.position =  vector;
                }
                    _groundFlg = true;
                    _jumpFlg   = false;

                _groundObject = other.gameObject;
            }
        }


        void LateUpdate()
        {
            if(_groundFlg){
                //var vector = new Vector3(transform.position.x, _groundObject.transform.position.y + _groundObject.gameObject.GetComponent<BoxCollider2D>().size.y * _groundObject.transform.localScale.y / 2.0f + GetComponent<BoxCollider2D>().size.y * transform.localScale.y, 0.0f);
                // var vector = new Vector3(transform.position.x, _groundObject.transform.position.y + _groundObject.gameObject.GetComponent<BoxCollider2D>().size.y * _groundObject.transform.localScale.y / 2.0f + GetComponent<BoxCollider2D>().size.y / 2.0f * transform.localScale.y, 0.0f);
                // transform.position =  vector;
            }
            _drawCachePositoin      = transform.localPosition;
            transform.localPosition = new Vector3(Mathf.RoundToInt(_drawCachePositoin.x), Mathf.RoundToInt(_drawCachePositoin.y), Mathf.RoundToInt(_drawCachePositoin.z));
            var cameraPos           = _sceneManager.Camera.transform.position;
            cameraPos.x             = transform.position.x;
            cameraPos.y             = transform.position.y + 100.0f;
            _sceneManager.Camera.transform.position = cameraPos;
        }

        void OnRenderObject()
        {
            transform.localPosition = _drawCachePositoin;
        }

        #region public function
        /// <summary>
        /// 初期化
        /// </summary>
        public void Init(MainSceneManager sceneManager)
        {
            _frameMoveFlg = MoveFlg.kNone;
            _initFlg      = true;
            _basketFlg    = false;
            _sceneManager = sceneManager;
            SetBasket();
        }

        /// <summary>
        /// バスケット設定
        /// </summary>
        public void SetBasket()
        {
            if(_basketFlg) return;
            _basketParent = Instantiate(_sceneManager.PrefabManager._basket).GetComponent<BasketParent>();
            _basketParent.Init(transform);
            _basket       = _basketParent.Basket;
            _basketFlg    = true;
        }
        #endregion

        #region private function
        /// <summary>
        /// キー入力
        /// </summary>
        private void InputKey()
        {
            _moveFlg = MoveFlg.kNone;
            if(Input.GetKey(KeyCode.A)){
                _moveFlg = MoveFlg.kLeft;
            }
            else if(Input.GetKey(KeyCode.D)){
                _moveFlg = MoveFlg.kRight;
            }
            // スペースキー
            // if(Input.GetKey(KeyCode.Space) && !_jumpFlg && _groundFlg){
            //     _jumpFlg   = true;
            //     _groundFlg = false;
            //     _jumpRate  = 10.0f;
            // }
            PositionUpdate();
        }

        /// <summary>
        /// 座標更新
        /// </summary>
        private void PositionUpdate()
        {
            switch(_moveFlg){
            case MoveFlg.kLeft:
                Debug.Log("left");
                //_rigid2D.position += Vector2.left * kMoveSpeed * Time.deltaTime;
                transform.position += Vector3.left * kMoveSpeed * Time.deltaTime;
                // 移動制限
                if(transform.position.x < -210.0f){
                    var vector         = transform.position;
                    vector.x           = -210.0f;
                    transform.position = vector;
                }
                if(_moveFlg != _frameMoveFlg){
                    _animator.enabled = true;
                    _animator.Play("LeftMove");
                }
                if(_basketFlg){
                    _basket.CheckMove(Vector2.left * kMoveSpeed * Time.deltaTime);
                }
                break;
            case MoveFlg.kRight:
                //_rigid2D.position += Vector2.right * kMoveSpeed * Time.deltaTime;
                transform.position += Vector3.right * kMoveSpeed * Time.deltaTime;
                // 移動制限
                if(transform.position.x > 210.0f){
                    var vector         = transform.position;
                    vector.x           = 210.0f;
                    transform.position = vector;
                }
                if(_moveFlg != _frameMoveFlg){
                    _animator.enabled = true;
                    _animator.Play("RightMove");
                }
                if(_basketFlg){
                    _basket.CheckMove(Vector2.right * kMoveSpeed * Time.deltaTime);
                }
                break;
            default:
                _animator.enabled = false;
                break;
            }
            if(_jumpFlg){
                Debug.Log("jump");
                transform.localPosition += Vector3.up * kMoveSpeed / 2.0f * _jumpRate * Time.deltaTime;

                _jumpRate -= 0.5f;


                // ジャンプのエネルギーを与える
            }



            _frameMoveFlg = _moveFlg;
            if(_basketParent != null){
                _basketParent.transform.position = transform.position - new Vector3(0.0f, 5.0f, 0.0f);
                _basketParent.UpdateRotate();
            }
        }
        #endregion
    }
}