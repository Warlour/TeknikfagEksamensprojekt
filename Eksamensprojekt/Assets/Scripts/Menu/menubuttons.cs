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
        SceneManager.UnloadSceneAsync("Menu");
        SceneManager.UnloadSceneAsync("Game");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
