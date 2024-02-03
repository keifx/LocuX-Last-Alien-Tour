using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevBiarGakMati : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.localPosition.y < -3)
        {
            this.gameObject.transform.localPosition = new Vector3(5, 5, 0);
        }
    }
}
