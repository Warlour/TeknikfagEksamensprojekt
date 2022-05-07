using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubuttons : MonoBehaviour{

    public GameObject Settings;

    public void play() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void settings() {
        if (Settings) {
            Settings.SetActive(!Settings.activeSelf);
        }
    }

    public void quit() {
        Application.Quit();
        Debug.Log("Quit");
    }

    private void Start() {
        if (/*SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Menu")*/ SceneManager.sceneCount > 1) {
            for (int i = 0; i < SceneManager.sceneCount; i++) {
                if (SceneManager.GetSceneAt(i) != SceneManager.GetSceneByName("Menu"))
                    SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i)); 
            }
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
