using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour {

    #region SerializeField
    [SerializeField, Tooltip("スコア表示")]
    private TMPro.TextMeshProUGUI _text;
    #endregion

    public void Init(int score)
    {
        _text.text = "+"+score.ToString();
        StartCoroutine(DestroyWait());
    }

    private IEnumerator DestroyWait()
    {
        var cnt = 0;
        while(cnt < 120){

            yield return null;
            transform.position += new Vector3(0.0f, 0.3f, 0.0f);
            ++cnt;
        }
        Destroy(gameObject);
    }
}
