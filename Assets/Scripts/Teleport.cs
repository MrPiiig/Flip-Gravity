using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetPos;
    public Transform player;
    void ToPos(){
        player.position = targetPos.position;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Gravity>().Blink();
            Invoke(nameof(ToPos), 0.4f);
        }
    }
}
