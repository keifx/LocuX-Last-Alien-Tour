using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBoxScr : MonoBehaviour
{
    public GameObject ular;
    public Vector3 target = new Vector3(0.25f, 0.25f, 0.25f);
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ular.transform.localScale = Vector3.Slerp(ular.transform.localScale, target, 3f * Time.deltaTime);
    }
}
