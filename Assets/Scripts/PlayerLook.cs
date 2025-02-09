using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    float mouseX = 0f;
    [SerializeField] float horizontalSensitivity = 180f;
    float mouseY = 0f;
    [SerializeField] float verticalSensitivity = 180f;

    string mouseXInputName = "Mouse X";
    string mouseYInputName = "Mouse Y";
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        
    }

    private void LateUpdate()
    {
        Look();
    }

    void Inputs()
    {
        mouseX = Input.GetAxis( mouseXInputName );
        mouseY = Input.GetAxis( mouseYInputName );
    }
    void Look()
    {
        transform.Rotate( 0f, mouseX * horizontalSensitivity * Time.deltaTime, 0f);   
        cam.transform.Rotate( mouseY * verticalSensitivity * Time.deltaTime, 0f, 0f );
    }
}
