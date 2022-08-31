using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class KeyUI : MonoBehaviour
{
    public Text text;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            text.DOFade(1, 0.5f);
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            text.DOFade(0, 0.5f);
        }
    }
}
