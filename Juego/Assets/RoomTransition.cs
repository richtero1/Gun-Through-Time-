using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    private CameraFollow cam;
    public Vector2 cambioCam;
    public Vector3 cambioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cam.maxp += cambioCam;
            cam.minp += cambioCam;
            collision.transform.position += cambioPlayer;
        }
    }
}
