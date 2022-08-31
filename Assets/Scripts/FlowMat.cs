using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetTextureScale("_BaseMap", new Vector2(transform.localScale.x/4, transform.localScale.z/4));
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.SetTextureOffset("_BaseMap", new Vector2(Time.time / 5, Time.time / 5));
        GetComponent<Renderer>().material.SetTextureOffset("_EmissionMap", new Vector2(Time.time / 5, Time.time / 5));
    }
}
