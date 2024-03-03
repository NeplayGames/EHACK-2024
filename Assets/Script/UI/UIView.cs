using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    // Start is called before the first frame update
    public void Initial(PlayerHealth playerHealth){
        playerHealth.HealthChange += ChangeHealthUI;
    }

    private void ChangeHealthUI(int arg1, int arg2)
    {
        health.text = $"Health = {arg1} / {arg2}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
