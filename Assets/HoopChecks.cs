using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HoopChecks : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textMeshPro;
    bool check1;
    bool check2;
    bool check3;

    private void Start()
    {
        UpdateUI();
    }

    public void HoopCheckTrigger( int hoop)
    {
        if ( hoop == 1)
        {
            check1 = true;
            check2 = false;
            check3 = false;
        }
        if ( hoop == 2 )
        {
            if ( check1 )
            {
                check2 = true;
                check3 = false;
            }
            else
            {
                check1 = false;
                check2 = false;
                check3 = false;
            }
        }
        if ( hoop == 3 )
        {
            if ( check1 && check2 )
            {
                AddScore();
                check1 = false;
                check2 = false;
                check3 = false;
            }
        }
    }
    int currentScore = 0;
    void AddScore()
    {
        currentScore++;
        UpdateUI();
    }

    void UpdateUI()
    {
        textMeshPro.text = string.Format( "{0:00}", currentScore );
    }
}
