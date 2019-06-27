using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    #region const
    private readonly float kFadeSpeed = 0.05f;
    #endregion

    #region SerializeField
    [SerializeField, Tooltip("フェード用画像")]
    private Image _fadeImage;
    #endregion

    #region private field
    private System.Action _callback;
    #endregion

    /// <summary>
    /// フェード終了コールバック設定
    /// </summary>
    /// <param name="callback"></param>
    public void SetCallBack(System.Action callback)
    {
        _callback = callback;
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeOut()
    {
        _fadeImage.enabled = true;
        var color          = _fadeImage.color;
        while(color.a < 1.0f){
            yield return null;
            color.a         += kFadeSpeed;
            _fadeImage.color = color;
        }
        _fadeImage.color = Color.white;
        if(_callback != null){
            _callback();
        }
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeIn()
    {
        _fadeImage.enabled = true;
        var color          = _fadeImage.color;
        while(color.a > 0.0f){
            yield return null;
            color.a         -= kFadeSpeed;
            _fadeImage.color = color;
        }
//        _fadeImage.color = ;
        if(_callback != null){
            _callback();
        }
        _fadeImage.enabled = false;
    }
}
