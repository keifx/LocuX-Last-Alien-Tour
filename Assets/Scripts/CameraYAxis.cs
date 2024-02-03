using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYAxis : MonoBehaviour
{
    public GameObject player;
    

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(0, player.transform.position.y, -13);
    }
}
