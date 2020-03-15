using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnBeat : MonoBehaviour
{
    [Header("Behaviour Settings")]
    public Transform _target;
    private float _currentSize;
    public float _growSize, _shrinkSize;
    [Range(0.8f, 0.99f)]
    public float _shrinkFactor;
    [Header("Beat Settings")]
    [Range(0,3)]
    public int _onFullBeat;
    [Range(0, 7)]
    public int[] _onBeatD8;
    private int _beatCountFull;

    private void Start()
    {
        if(_target == null)
        {
            _target = this.transform;
        }
        _currentSize = _shrinkSize;
    }

    private void Update()
    {
        if(_currentSize > _shrinkSize)
        {
            _currentSize *= _shrinkFactor;
        }
        else
        {
            _currentSize = _shrinkSize;
        }
        CheckBeat();
        _target.localScale = new Vector3(_target.localScale.x, _currentSize, _target.localScale.z);
    }
    void Grow()
    {
        _currentSize = _growSize;
    }
    void CheckBeat()
    {
        _beatCountFull = BPeerM._beatCountFull % 4;
        for(int i = 0; i < _onBeatD8.Length; i++)
        {
            if (BPeerM._beatD8 && _beatCountFull == _onFullBeat && BPeerM._beatCountD8 % 8 == _onBeatD8[i])
            {
                Grow();
            }
        }
    }
}
