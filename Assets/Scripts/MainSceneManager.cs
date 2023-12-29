using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager instance;

    [SerializeField] private ScoreText scoreText;
    [SerializeField] private GameObject gameUIObj;
    [SerializeField] private GameObject endGameScreenObj;

    private int score = 0;
    private EndGameScreen endGameScreen;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }
    }

    private void Start() {
        endGameScreen = endGameScreenObj.GetComponent<EndGameScreen>();
    }
    
    public void EndGame(){
        AudioManager.instance.PlayEndSound();
        Time.timeScale = 0;
        ShowEndGameScreen();
        endGameScreen.SetTotalScore(score);
    }

    private void ShowEndGameScreen(){
        gameUIObj.SetActive(false);
        endGameScreenObj.SetActive(true);
    }

    public void AddScore(){
        score++;
        scoreText.ChangeScore(score);
    }

    public void TryAgain(){
        GameManager.instance.LoadScene(1);
    }
    
}
