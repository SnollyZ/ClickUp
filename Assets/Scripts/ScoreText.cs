using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text text;
    private Animator anim;

    private void Start(){
        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    public void ChangeScore(int score){
        string newText = "Score: " + score.ToString();
        text.text = newText;
        anim.SetTrigger("Up");
    }
}
