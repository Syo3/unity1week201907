using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    #region SerializeField
    [SerializeField, Tooltip("AudioSource")]
    private AudioSource _audioSource;
    [SerializeField, Tooltip("SE一覧")]
    private List<AudioClip> _seList;
    #endregion

    #region public function
    public void PlayOnShot(int seID)
    {
        if(seID >= _seList.Count){
            return;
        }
        _audioSource.PlayOneShot(_seList[seID], 0.5f);
    }

    public void PlayBgm()
    {
        _audioSource.Play();
    }

    public void StopBgm()
    {
                    _audioSource.Stop();

    }
    #endregion
}
