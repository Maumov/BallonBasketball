using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( CharacterController ) )]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.3f;
    CharacterController characterController;


    float vertical = 0f;
    float horizontal = 0f;

    string verticalInputName = "Vertical";
    string horizontalInputName = "Horizontal";
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Move();
    }

    void Inputs()
    {
        vertical = Input.GetAxis( verticalInputName );
        horizontal = Input.GetAxis( horizontalInputName );
    }

    Vector3 moveDirection;
    void Move()
    {
        moveDirection = Vector3.zero;
        moveDirection = transform.forward * vertical + transform.right * horizontal;
        if ( moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }
        characterController.Move( moveDirection * speed * Time.deltaTime );
    }
}
