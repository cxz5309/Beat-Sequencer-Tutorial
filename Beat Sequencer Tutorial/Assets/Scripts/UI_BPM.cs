using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BPM : MonoBehaviour
{
    Text _text;
    public BPeerM _bPeerM;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = "BPM : " + _bPeerM._bpm.ToString();
    }
}
