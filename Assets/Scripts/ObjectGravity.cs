using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    public Gravity globalGravity;
    public string localGravity;

    private bool isGrabbing;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        isGrabbing = false;   
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbing){
            localGravity = globalGravity.currentState;
        }
        else{
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
    private void FixedUpdate() {
        switch(localGravity){
            case "bottom":
            rb.AddForce(0, -9.8f, 0);          
            break;
            case "right":
            rb.AddForce(9.8f, 0, 0);           
            break;
            case "left":
            rb.AddForce(-9.8f, 0, 0);            
            break;
            case "top":
            rb.AddForce(0, 9.8f, 0);
            break;
        }
    }
    public void Grabbing(){
        isGrabbing = true;
        gameObject.layer = LayerMask.NameToLayer("GrabbingObject");
    }
    public void Loosen(){
        isGrabbing = false;
        gameObject.layer = LayerMask.NameToLayer("Object");

    }
}
