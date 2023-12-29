using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void StartBtn(){
        GameManager.instance.LoadScene(1);
    }
}
