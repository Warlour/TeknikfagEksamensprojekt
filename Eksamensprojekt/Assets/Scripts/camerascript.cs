using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camerascript : MonoBehaviour{
    public Camera[] cameras;
    private int currentCameraIndex;

    public Button[] buttons;

    void Start(){
        currentCameraIndex = 0;

        for (int i = 1; i < cameras.Length; i++)
            cameras[i].gameObject.SetActive(false);

        if (cameras.Length > 0){
            cameras[0].gameObject.SetActive(true);
            Debug.Log("Camera with name: " + cameras[0].name + ", is now enabled");
        }

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].onClick.AddListener(() => ChangeCamera(i));
    }

    void ChangeCamera(int button){
        Debug.Log("You have clicked button " + buttons[button+1].name + "!");
    }
}
