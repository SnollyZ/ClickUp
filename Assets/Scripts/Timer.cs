using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private int startTime = 60;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(TimerRoutine());
    }

    private IEnumerator TimerRoutine(){
        int time = startTime;
        ChangeText(time);
        while(time > 0){
            yield return new WaitForSeconds(1f);
            time--;
            ChangeText(time);
        }
        MainSceneManager.instance.EndGame();
    }

    private void ChangeText(int value){
        text.text = value.ToString();
    }
}
