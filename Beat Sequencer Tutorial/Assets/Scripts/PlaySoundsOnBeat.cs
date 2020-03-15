using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsOnBeat : MonoBehaviour
{
    public SoundManager _soundManager;
    public AudioClip _tap, _tick;
    public AudioClip[] _strum;
    int _randomStrum;

    private void Update()
    {
        if (BPeerM._beatFull)
        {
            _soundManager.PlaySound(_tap, 1);
            if(BPeerM._beatCountFull%2 == 0)
            {
                _randomStrum = Random.Range(0, _strum.Length);
            }
        }
        if(BPeerM._beatD8 && BPeerM._beatCountD8 % 2 == 0)
        {
            _soundManager.PlaySound(_tick, 0.1f);
        }
        if(BPeerM._beatD8 && (BPeerM._beatCountD8 % 8 == 2 || BPeerM._beatCountD8 % 8 == 4))
        {
            _soundManager.PlaySound(_strum[_randomStrum], 1);
        }
    }
}
