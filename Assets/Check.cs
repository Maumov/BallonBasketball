using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int check;
    HoopChecks hoopCheck;

    private void OnEnable()
    {
        hoopCheck = GetComponentInParent<HoopChecks>();
    }

    private void OnTriggerEnter( Collider other )
    {
        hoopCheck.HoopCheckTrigger( check );
    }
}
