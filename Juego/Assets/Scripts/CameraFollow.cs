using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;
    public float smoothing;
    public Vector2 maxp;
    public Vector2 minp;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
   
    void LateUpdate()
    {
        Vector3 temp = new Vector3(playerTransform.position.x,playerTransform.position.y,transform.position.z);

        temp.x = Mathf.Clamp(temp.x, minp.x, maxp.x);
        temp.y = Mathf.Clamp(temp.y, minp.y, maxp.y);

        transform.position = Vector3.Lerp(transform.position, temp, smoothing);



    }
}
