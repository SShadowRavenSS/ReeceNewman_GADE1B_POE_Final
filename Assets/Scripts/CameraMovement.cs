using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(0, 15, 0);
        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        
        transform.position += new Vector3(mouse.x, mouse.y, transform.position.z);
        //Camera.main.fieldOfView = mouseScroll;
        


    }
}
