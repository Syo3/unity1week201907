using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScene{
    public class Player : MonoBehaviour {

        #region define
        private float kMoveSpeed = 100.0f;
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
        #endregion

        #region access
        public bool BasketFlg{
            get{return _basketFlg;}
        }
        #endregion

        /// <summary>
        /// Update
        /// </summary>
        void Update()
        {
            if(_initFlg != true) return;
            InputKey();   
        }


        // void LateUpdate()
        // {
        //     _drawCachePositoin      = transform.localPosition;
        //     transform.localPosition = new Vector3(Mathf.RoundToInt(_drawCachePositoin.x), Mathf.RoundToInt(_drawCachePositoin.y), Mathf.RoundToInt(_drawCachePositoin.z));
        // }

        // void OnRenderObject()
        // {
        //     transform.localPosition = _drawCachePositoin;
        // }

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
        }

        /// <summary>
        /// バスケット設定
        /// </summary>
        public void SetBasket()
        {
            if(_basketFlg) return;
            _basket = Instantiate(_sceneManager.PrefabManager._basket).GetComponent<Basket>();
            _basket.Init(transform);
            _basketFlg = true;
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
            PositionUpdate();
        }

        /// <summary>
        /// 座標更新
        /// </summary>
        private void PositionUpdate()
        {
            switch(_moveFlg){
            case MoveFlg.kLeft:
                //transform.Translate(new Vector3(-kMoveSpeed, 0.0f, 0.0f));
                _rigid2D.position += Vector2.left * kMoveSpeed * Time.deltaTime;
                //_rigid2D.AddForce(Vector2.left * kMoveSpeed * Time.deltaTime, ForceMode2D.Impulse);
                if(_moveFlg != _frameMoveFlg){
                    _animator.enabled = true;
                    _animator.Play("LeftMove");
                }
                if(_basketFlg){
                    _basket.CheckMove(Vector2.left * kMoveSpeed * Time.deltaTime);
                }
                break;
            case MoveFlg.kRight:
                //transform.Translate(new Vector3(kMoveSpeed, 0.0f, 0.0f));
                _rigid2D.position += Vector2.right * kMoveSpeed * Time.deltaTime;
                //_rigid2D.AddForce(Vector2.right * kMoveSpeed * Time.deltaTime, ForceMode2D.Impulse);
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
            _frameMoveFlg = _moveFlg;
        }
        #endregion
    }
}