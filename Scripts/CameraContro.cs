using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContro : MonoBehaviour
{
    public Transform payler;
  
    void Update()
    {
        transform.position = new Vector3(payler.position.x, payler.position.y, -10f);//镜头跟踪
    }
}
