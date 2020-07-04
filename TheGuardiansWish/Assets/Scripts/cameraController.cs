using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float rotationSpeed = 1.5f;
    public Transform viewDirection;
    public Transform Player;
    float mousePosX;
    float mousePosY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX += Input.GetAxis("Mouse X") * rotationSpeed;
        mousePosY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        //for debuff 
        /* -- um Achsen zu invertieren
         mousePosX -= Input.GetAxis("Mouse X") * rotationSpeed;
        mousePosY += Input.GetAxis("Mouse Y") * rotationSpeed;
         */

        mousePosY = Mathf.Clamp(mousePosY, -35, 55);

        transform.LookAt(viewDirection);

        viewDirection.rotation = Quaternion.Euler(mousePosY, mousePosX, 0);
        Player.rotation = Quaternion.Euler(0, mousePosX, 0);
    }

    public Quaternion getViewDirection()
    {
        return viewDirection.rotation = Quaternion.Euler(0, mousePosX, 0);
    }
}
