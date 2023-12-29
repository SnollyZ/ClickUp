using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
}
