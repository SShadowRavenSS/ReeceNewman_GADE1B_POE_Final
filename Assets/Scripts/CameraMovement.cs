using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float zoomSpeed = 20f;
    private float minZoomFOV = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        //Zooming
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.fieldOfView -= speed/2;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.fieldOfView += speed / 2;
        }

    }

    public void ZoomIn()
    {
        Camera.main.fieldOfView -= zoomSpeed / 8;
        if (Camera.main.fieldOfView < minZoomFOV)
        {
            Camera.main.fieldOfView = minZoomFOV;
        }
    }
}
