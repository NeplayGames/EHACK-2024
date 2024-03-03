using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI finalScore;
    private EnemyController enemyController;
    private int score = 0;
    // Start is called before the first frame update
    public void Initial(PlayerHealth playerHealth, EnemyController enemyController){
        playerHealth.HealthChange += ChangeHealthUI;
        enemyController.hit += IncreaseScore;
    }

    public void GameOver(){
        gameOver.SetActive(true);
        finalScore.text = $"Score : {score}"; 
    }
    private void IncreaseScore()
    {
        score++;
        scoreTxt.text = $"Score : {score}";
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
