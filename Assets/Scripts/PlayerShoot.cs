using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera cam;
    public GameObject ballTarget;
    public Transform ballPosition;
    public ForceMode forceMode;
    public float forceAmount;
    bool haveBall = false;
    
    bool shoot = false;

    string shootInputName = "Fire1";
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Shoot();
    }

    void Inputs()
    {
        shoot = Input.GetButtonDown( shootInputName );
    }
    void Shoot()
    {
        if ( !shoot )
        {
            return;
        }
        if ( haveBall )
        {
            //Throw it.
            UnFreezeBall();
            ShootBall();
        }
        else
        {
            FreezeBall();
            //bring it.
        }
    }

    void FreezeBall()
    {
        Rigidbody rb = ballTarget.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        ballTarget.transform.SetParent( ballPosition );
        ballTarget.transform.localPosition = Vector3.zero;
        ballTarget.transform.position = ballPosition.position;
        haveBall = true;
    }

    void UnFreezeBall()
    {
        Rigidbody rb = ballTarget.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        ballTarget.transform.SetParent( null );
        
    }

    void ShootBall()
    {
        Rigidbody rb = ballTarget.GetComponent<Rigidbody>();
        Vector3 endPoint = ( cam.transform.position ) + ( cam.transform.up * 2f ) + ( cam.transform.forward * 100f );
        Vector3 startPoint = ballTarget.transform.position;
        Vector3 direction = endPoint - startPoint;  
        direction.Normalize();
        rb.AddForce( direction * forceAmount, ForceMode.Force  );
        haveBall = false;
    }

}
