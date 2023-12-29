using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private Text totalScore;
    
    public void SetTotalScore(int value){
        string newText = "Your score: " + value.ToString();
        totalScore.text = newText;
    }

    public void TryAgainBtn(){
        Time.timeScale = 1;
        MainSceneManager.instance.TryAgain();
    }
}
