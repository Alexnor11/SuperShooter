using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed, rotationSpeed;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKeyDown(KeyCode.S)) { transform.Translate(0, 0, -speed * Time.deltaTime); }        
        if(Input.GetKeyDown(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKeyDown(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
    }
}
