using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform teleportPoint;
    public Transform player;
    void ToPos(){
        player.position = teleportPoint.position;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Gravity>().Blink();
            Invoke(nameof(ToPos), 0.4f);
        }
    }
}
