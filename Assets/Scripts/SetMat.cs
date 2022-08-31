using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMat : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetTextureScale("_BaseMap", new Vector2(transform.localScale.x/2, transform.localScale.z/2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
